
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using _TmpMaui.Models;
using _TmpMaui.Services;
using _TmpMaui.Utils;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Media;
using Microsoft.Maui.Storage;
using Plugin.Maui.Barkoder.Controls;
using Plugin.Maui.Barkoder.Enums;
using Plugin.Maui.Barkoder.Handlers;
using Plugin.Maui.Barkoder.Interfaces;

namespace _TmpMaui.Views;

[QueryProperty(nameof(Mode), "mode")]
[QueryProperty(nameof(SessionId), "sessionId")]
public partial class ScannerPage : ContentPage, IBarkoderDelegate
{
    private string _mode = ScannerModes.AnyScan;
    private long _sessionId;
    private bool _initialized;
    private bool _isScanningPaused;
    private bool _isSettingsVisible;
    private bool _isResultSheetHidden;
    private bool _isResultSheetExpanded;
    private bool _isFlashOn;
    private float _zoomLevel = 1.0f;
    private BarkoderCameraPosition _cameraPosition = BarkoderCameraPosition.BACK;
    private ScannerSettings _settings = ScannerConfig.GetInitialSettings(ScannerModes.AnyScan);
    private Dictionary<string, bool> _enabledTypes = ScannerConfig.GetInitialEnabledTypes(ScannerModes.AnyScan);
    private int _lastScanCount;
    private long _lastSessionId = -1;
    private double _expandedSheetHeight;
    private double _resultListMaxHeight = 180;

    public ObservableCollection<ScannedItem> ScannedItems { get; } = new();
    public ObservableCollection<ScannedItemView> UniqueScannedItems { get; } = new();

    public ICommand ResumeScanningCommand { get; }
    public ICommand ItemDetailsCommand { get; }

    public string Mode
    {
        get => _mode;
        set
        {
            _mode = value;
            OnPropertyChanged();
        }
    }

    public string SessionId
    {
        get => _sessionId.ToString();
        set
        {
            if (long.TryParse(value, out var parsed))
            {
                _sessionId = parsed;
            }
        }
    }

    public bool IsScanningPaused
    {
        get => _isScanningPaused;
        set
        {
            _isScanningPaused = value;
            OnPropertyChanged();
        }
    }

    public bool IsSettingsVisible
    {
        get => _isSettingsVisible;
        set
        {
            _isSettingsVisible = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ShowTopBar));
            OnPropertyChanged(nameof(ShowBottomControls));
        }
    }

    public bool ShowTopBar => !_isSettingsVisible;

    public bool IsResultSheetOpen => _settings.ShowResultSheet && ScannedItems.Count > 0 && !_isResultSheetHidden;

    public bool IsResultSheetExpanded
    {
        get => _isResultSheetExpanded;
        set
        {
            _isResultSheetExpanded = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ExpandLabel));
        }
    }

    public bool ShowBottomControls => !IsResultSheetOpen && !IsSettingsVisible;

    public string ActiveBarcodeText { get; private set; } = string.Empty;
    public bool HasActiveBarcodeText => !string.IsNullOrWhiteSpace(ActiveBarcodeText);

    public string ZoomIcon => _zoomLevel <= 1.0f ? "zoom_in.svg" : "zoom_out.svg";
    public string FlashIcon => _isFlashOn ? "flash_off.svg" : "flash_on.svg";

    public string ResultHeaderText
    {
        get
        {
            var uniqueCount = UniqueScannedItems.Count;
            var totalCount = ScannedItems.Count;
            var scanCount = _lastScanCount > 0 ? _lastScanCount : uniqueCount;
            return $"{scanCount} result{(scanCount == 1 ? "" : "s")} found ({totalCount} total)";
        }
    }

    public string ExpandLabel => IsResultSheetExpanded ? "Collapse" : "Expand";

    public double ExpandedSheetHeight
    {
        get => _expandedSheetHeight;
        set
        {
            _expandedSheetHeight = value;
            OnPropertyChanged();
        }
    }

    public double ResultListMaxHeight
    {
        get => _resultListMaxHeight;
        set
        {
            _resultListMaxHeight = value;
            OnPropertyChanged();
        }
    }

    public ScannerPage()
    {
        ResumeScanningCommand = new Command(ResumeScanning);
        ItemDetailsCommand = new Command<ScannedItemView>(OnDetailsClicked);
        InitializeComponent();
        BindingContext = this;
        SizeChanged += OnSizeChanged;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await InitializeAsync();
    }

    private void OnSizeChanged(object? sender, EventArgs e)
    {
        if (Height > 0)
        {
            ExpandedSheetHeight = Height * 0.82;
        }
    }

    private async Task InitializeAsync()
    {
        if (_initialized)
        {
            return;
        }

        _initialized = true;
        await BKDView.whenScannerReady();
        BKDView.InitCameraProperties();

        await LoadSettingsAsync();
        ApplySettings();
        ApplyBarcodeTypes();
        UpdateActiveBarcodeText();

        if (_lastSessionId != _sessionId)
        {
            ResetSession();
            _lastSessionId = _sessionId;
        }

        if (Mode == ScannerModes.Gallery)
        {
            await Task.Delay(400);
            await ScanImageFromGalleryAsync();
        }
        else
        {
            StartScanning();
        }
    }

    private void ResetSession()
    {
        ScannedItems.Clear();
        UniqueScannedItems.Clear();
        _lastScanCount = 0;
        _isResultSheetHidden = false;
        IsScanningPaused = false;
        FrozenImage.Source = null;
        UpdateResultSheetBindings();
    }

    private async Task LoadSettingsAsync()
    {
        _settings = ScannerConfig.GetInitialSettings(Mode);
        _enabledTypes = ScannerConfig.GetInitialEnabledTypes(Mode);

        var saved = await SettingsService.GetSettingsAsync(Mode);
        if (saved != null)
        {
            if (saved.EnabledTypes.Count > 0)
            {
                _enabledTypes = saved.EnabledTypes;
                if (Mode != ScannerModes.Vin)
                {
                    _enabledTypes["ocrText"] = false;
                }
                if (Mode != ScannerModes.Mrz)
                {
                    _enabledTypes["idDocument"] = false;
                }
            }

            _settings = saved.ScannerSettings ?? _settings;
        }

        if (Mode != ScannerModes.Mrz)
        {
            _enabledTypes["idDocument"] = false;
        }

        RenderSettings();
    }

    private void ApplySettings()
    {
        BKDView.SetImageResultEnabled(true);
        BKDView.SetLocationInImageResultEnabled(true);
        BKDView.SetLocationInPreviewEnabled(_settings.LocationInPreview);
        BKDView.SetRegionOfInterestVisible(_settings.RegionOfInterest);
        if (_settings.RegionOfInterest && Mode != ScannerModes.Vin && Mode != ScannerModes.Dpm)
        {
            BKDView.SetRegionOfInterest(5, 5, 90, 90);
        }
        BKDView.SetPinchToZoomEnabled(_settings.PinchToZoom);
        BKDView.SetBeepOnSuccessEnabled(_settings.BeepOnSuccess);
        BKDView.SetVibrateOnSuccessEnabled(_settings.VibrateOnSuccess);
        BKDView.SetCloseSessionOnResultEnabled(!_settings.ContinuousScanning);
        BKDView.SetUpcEanDeblurEnabled(_settings.ScanBlurred);
        BKDView.SetEnableMisshaped1DEnabled(_settings.ScanDeformed);
        BKDView.SetDecodingSpeed(_settings.DecodingSpeed);
        BKDView.SetBarkoderResolution(_settings.Resolution);
        BKDView.SetBarcodeThumbnailOnResultEnabled(true);
        BKDView.SetMaximumResultsCount(200);
        BKDView.SetThresholdBetweenDuplicatesScans(_settings.ContinuousScanning ? _settings.ContinuousThreshold : 0);

        if (Mode == ScannerModes.AnyScan)
        {
            BKDView.SetEnableComposite(_settings.CompositeMode ? 1 : 0);
        }

        if (Mode != ScannerModes.Vin)
        {
            BKDView.SetCustomOption("enable_ocr_functionality", 0);
        }

        if (Mode == ScannerModes.Vin)
        {
            BKDView.SetEnableVINRestrictions(true);
            BKDView.SetRegionOfInterest(0, 35, 100, 30);
            if (_enabledTypes.TryGetValue("ocrText", out var ocrEnabled) && ocrEnabled)
            {
                BKDView.SetCustomOption("enable_ocr_functionality", 1);
            }
        }
        else if (Mode == ScannerModes.Dpm)
        {
            BKDView.SetBarcodeTypeEnabled(BarcodeType.Datamatrix, true);
            BKDView.SetDatamatrixDpmModeEnabled(true);
            BKDView.SetRegionOfInterest(40, 40, 20, 10);
        }
        else if (Mode == ScannerModes.ArMode)
        {
            BKDView.SetBarkoderARMode(_settings.ArMode);
            BKDView.SetBarkoderARHeaderShowMode(_settings.ArHeaderShowMode);
            BKDView.SetBarkoderARLocationType(_settings.ArLocationType);
            BKDView.SetBarkoderARoverlayRefresh(_settings.ArOverlayRefresh);
            BKDView.SetARDoubleTapToFreezeEnabled(_settings.ArDoubleTapToFreeze);
            BKDView.SetARSelectedLocationLineColor("#00FF00");
            BKDView.SetARNonSelectedLocationLineColor("#FF0000");
        }
        else if (Mode == ScannerModes.Dotcode)
        {
            BKDView.SetBarcodeTypeEnabled(BarcodeType.Dotcode, true);
            BKDView.SetRegionOfInterest(30, 40, 40, 9);
        }
    }
    private void ApplyBarcodeTypes()
    {
        foreach (var type in _enabledTypes)
        {
            if (BarcodeTypeMapper.TryGet(type.Key, out var barkoderType))
            {
                BKDView.SetBarcodeTypeEnabled(barkoderType, type.Value);
            }
        }

        if (Mode != ScannerModes.Mrz)
        {
            if (BarcodeTypeMapper.TryGet("idDocument", out var idDocType))
            {
                BKDView.SetBarcodeTypeEnabled(idDocType, false);
            }
        }
    }

    private void UpdateActiveBarcodeText()
    {
        var activeTypes = BarcodeConstants.BarcodeTypes1D
            .Concat(BarcodeConstants.BarcodeTypes2D)
            .Where(t => _enabledTypes.TryGetValue(t.Id, out var enabled) && enabled)
            .Select(t => t.Label)
            .ToList();

        ActiveBarcodeText = string.Join(", ", activeTypes);
        OnPropertyChanged(nameof(ActiveBarcodeText));
        OnPropertyChanged(nameof(HasActiveBarcodeText));
    }

    private void StartScanning()
    {
        BKDView.StartScanning(this);
    }

    private void ResumeScanning()
    {
        IsScanningPaused = false;
        FrozenImage.Source = null;
        StartScanning();
    }

    public void DidFinishScanning(BarcodeResult[] result, ImageSource[] thumbnails, ImageSource originalImageSource)
    {
        if (result == null || result.Length == 0)
        {
            return;
        }

        var displayImage = thumbnails?.FirstOrDefault() ?? originalImageSource;

        _isResultSheetHidden = false;

        var newItems = result.Select(decoded => new ScannedItem
        {
            Text = decoded.TextualData,
            Type = decoded.BarcodeTypeName,
            Image = displayImage
        }).ToList();

        foreach (var item in newItems)
        {
            ScannedItems.Insert(0, item);
            _ = HistoryService.AddScanAsync(item);
        }

        _lastScanCount = newItems.Count;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            UpdateUniqueItems();
            UpdateResultSheetBindings();
        });

        if (!_settings.ContinuousScanning)
        {
            BKDView.StopScanning();
            IsScanningPaused = true;
            FrozenImage.Source = originalImageSource;
        }
    }

    public void DidFinishScanning(BarcodeResult[] result, ImageSource originalImageSource)
    {
        DidFinishScanning(result, Array.Empty<ImageSource>(), originalImageSource);
    }

    private void UpdateUniqueItems()
    {
        UniqueScannedItems.Clear();
        var uniqueTexts = new HashSet<string>();
        var index = 0;

        foreach (var item in ScannedItems)
        {
            if (uniqueTexts.Add(item.Text))
            {
                var count = ScannedItems.Count(i => i.Text == item.Text);
                UniqueScannedItems.Add(new ScannedItemView
                {
                    Text = item.Text,
                    Type = item.Type,
                    Count = count,
                    DisplayText = GetDisplayText(item),
                    CardBackground = index == 0 ? Color.FromArgb("#DFF4D7") : Color.FromArgb("#F3F3F3"),
                    SourceItem = item
                });
                index++;
            }
        }
    }

    private string GetDisplayText(ScannedItem item)
    {
        if (!string.Equals(item.Type, "mrz", StringComparison.OrdinalIgnoreCase))
        {
            return item.Text;
        }

        var fields = ParseMrzData(item.Text);
        var name = FindMrzField(fields, new[] { "name", "given name", "given names", "first name", "forename" });
        var surname = FindMrzField(fields, new[] { "surname", "last name", "family name" });
        var parts = new[] { name, surname }.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
        return parts.Count > 0 ? string.Join(" ", parts) : "Name/Surname not found";
    }

    private static List<(string Id, string Label, string Value)> ParseMrzData(string text)
    {
        var fields = new List<(string Id, string Label, string Value)>();
        var lines = text.Split('\n');
        foreach (var line in lines)
        {
            var match = System.Text.RegularExpressions.Regex.Match(line, "^([^:]+):\\s*(.+)$");
            if (match.Success)
            {
                var key = match.Groups[1].Value.Trim();
                var value = match.Groups[2].Value.Trim();
                var label = string.Join(" ", key.Split('_').Select(w => char.ToUpperInvariant(w[0]) + w.Substring(1)));
                fields.Add((key, label, value));
            }
        }
        return fields;
    }

    private static string? FindMrzField(IEnumerable<(string Id, string Label, string Value)> fields, IEnumerable<string> keys)
    {
        var lowered = keys.Select(k => k.ToLowerInvariant()).ToList();
        foreach (var field in fields)
        {
            var haystack = $"{field.Id} {field.Label}".ToLowerInvariant();
            if (lowered.Any(k => haystack.Contains(k)))
            {
                return field.Value;
            }
        }
        return null;
    }

    private void UpdateResultSheetBindings()
    {
        OnPropertyChanged(nameof(IsResultSheetOpen));
        OnPropertyChanged(nameof(ShowBottomControls));
        OnPropertyChanged(nameof(ResultHeaderText));
    }

    private async Task ScanImageFromGalleryAsync()
    {
        try
        {
            var file = await MediaPicker.PickPhotoAsync();
            if (file == null)
            {
                return;
            }

            await using var stream = await file.OpenReadAsync();
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            var base64 = Convert.ToBase64String(ms.ToArray());
            BKDView.ScanImage(base64, this);
        }
        catch
        {
        }
    }

    private async Task SaveSettingsAsync()
    {
        await SettingsService.SaveSettingsAsync(Mode, new SavedSettings
        {
            EnabledTypes = _enabledTypes,
            ScannerSettings = _settings
        });
    }

    private void OnSettingsClicked(object sender, EventArgs e)
    {
        if (IsSettingsVisible)
        {
            return;
        }

        MainThread.BeginInvokeOnMainThread(() =>
        {
            try
            {
                BKDView.PauseScanning();
            }
            catch
            {
            }

            try
            {
                BKDView.StopScanning();
            }
            catch
            {
            }

            IsSettingsVisible = true;
        });
    }

    private async void OnSettingsCloseClicked(object sender, EventArgs e)
    {
        IsSettingsVisible = false;
        try
        {
            BKDView.UnfreezeScanning();
        }
        catch
        {
        }

        if (Mode != ScannerModes.Gallery)
        {
            await Task.Delay(100);
            StartScanning();
        }
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void OnToggleFlash(object sender, EventArgs e)
    {
        _isFlashOn = !_isFlashOn;
        BKDView.SetFlashEnabled(_isFlashOn);
        OnPropertyChanged(nameof(FlashIcon));
    }

    private void OnToggleZoom(object sender, EventArgs e)
    {
        var max = BKDView.MaxZoomFactor > 1.0 ? BKDView.MaxZoomFactor : 2.0;
        _zoomLevel = _zoomLevel <= 1.0f ? (float)Math.Min(2.0, max) : 1.0f;
        BKDView.SetZoomFactor(_zoomLevel);
        OnPropertyChanged(nameof(ZoomIcon));
    }

    private void OnToggleCamera(object sender, EventArgs e)
    {
        _cameraPosition = _cameraPosition == BarkoderCameraPosition.BACK
            ? BarkoderCameraPosition.FRONT
            : BarkoderCameraPosition.BACK;
        BKDView.SetCamera(_cameraPosition);
    }

    private async void OnCopyClicked(object sender, EventArgs e)
    {
        if (ScannedItems.Count == 0)
        {
            return;
        }

        var allText = string.Join(Environment.NewLine, ScannedItems.Select(i => i.Text));
        await Clipboard.Default.SetTextAsync(allText);
        await DisplayAlert("Copied", $"{ScannedItems.Count} barcode(s) copied to clipboard", "OK");
    }

    private async void OnCsvClicked(object sender, EventArgs e)
    {
        if (ScannedItems.Count == 0)
        {
            return;
        }

        var header = "Barcode,Type";
        var rows = ScannedItems.Select(i => $"\"{i.Text.Replace("\"", "\"\"")}\",\"{i.Type}\"");
        var csv = string.Join(Environment.NewLine, new[] { header }.Concat(rows));

        var filePath = System.IO.Path.Combine(FileSystem.CacheDirectory, "scanned_barcodes.csv");
        await File.WriteAllTextAsync(filePath, csv);

        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = "Share CSV",
            File = new ShareFile(filePath)
        });
    }

    private void OnExpandClicked(object sender, EventArgs e)
    {
        IsResultSheetExpanded = !IsResultSheetExpanded;
    }

    private void OnExpandClose(object sender, EventArgs e)
    {
        IsResultSheetExpanded = false;
    }

    private void OnResultSheetClose(object sender, EventArgs e)
    {
        _isResultSheetHidden = true;
        UpdateResultSheetBindings();
    }

    private async void OnDetailsClicked(ScannedItemView? item)
    {
        if (item == null)
        {
            return;
        }

        await Shell.Current.GoToAsync(nameof(BarcodeDetailsPage), new Dictionary<string, object>
        {
            ["Item"] = item.SourceItem
        });
    }

    private void RenderSettings()
    {
        SettingsContainer.Children.Clear();

        AddSectionHeader("General Settings");
        var generalSettings = GetGeneralSettings().ToList();
        if (generalSettings.Count > 0)
        {
            SettingsContainer.Children.Add(CreateSettingsGroup(generalSettings));
        }

        var decoding = GetDecodingSettings().ToList();
        if (decoding.Count > 0)
        {
            AddSectionHeader("Decoding Settings");
            SettingsContainer.Children.Add(CreateSettingsGroup(decoding));
        }

        var group1D = GetFilteredBarcodeTypes("1D").ToList();
        if (group1D.Count > 0)
        {
            AddSectionHeader("1D Barcodes");
            SettingsContainer.Children.Add(CreateBarcodeGroup(group1D, "1D"));
        }

        var group2D = GetFilteredBarcodeTypes("2D").ToList();
        if (group2D.Count > 0)
        {
            AddSectionHeader("2D Barcodes");
            SettingsContainer.Children.Add(CreateBarcodeGroup(group2D, "2D"));
        }
    }

    private void AddSectionHeader(string title)
    {
        SettingsContainer.Children.Add(new Label
        {
            Text = title,
            FontSize = 14,
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.FromArgb("#E52E4C"),
            Margin = new Thickness(4, 18, 0, 8)
        });
    }

    private View CreateSettingsGroup(IReadOnlyList<SettingItem> items)
    {
        var container = CreateGroupContainer();
        var stack = new VerticalStackLayout { Spacing = 0 };
        foreach (var item in items)
        {
            stack.Children.Add(CreateSettingRow(item));
        }

        container.Content = stack;
        return container;
    }

    private View CreateBarcodeGroup(List<(string Id, string Label)> items, string category)
    {
        var container = CreateGroupContainer();
        var stack = new VerticalStackLayout { Spacing = 0 };

        var allEnabled = items.All(t => _enabledTypes.TryGetValue(t.Id, out var enabled) && enabled);
        stack.Children.Add(CreateSwitchRow("Enable All", allEnabled, value =>
        {
            foreach (var item in items)
            {
                _enabledTypes[item.Id] = value;
                if (BarcodeTypeMapper.TryGet(item.Id, out var type))
                {
                    BKDView.SetBarcodeTypeEnabled(type, value);
                }
            }

            if (Mode != ScannerModes.Vin)
            {
                _enabledTypes["ocrText"] = false;
            }

            UpdateActiveBarcodeText();
            _ = SaveSettingsAsync();
            RenderSettings();
        }, isLast: items.Count == 0));

        for (var i = 0; i < items.Count; i++)
        {
            var item = items[i];
            var isLast = i == items.Count - 1;
            var enabled = _enabledTypes.TryGetValue(item.Id, out var v) && v;
            stack.Children.Add(CreateSwitchRow(item.Label, enabled, value =>
            {
                _enabledTypes[item.Id] = value;
                if (item.Id == "ocrText" && Mode != ScannerModes.Vin)
                {
                    return;
                }

                if (BarcodeTypeMapper.TryGet(item.Id, out var type))
                {
                    BKDView.SetBarcodeTypeEnabled(type, value);
                }

                if (item.Id == "ocrText" && Mode == ScannerModes.Vin)
                {
                    BKDView.SetCustomOption("enable_ocr_functionality", value ? 1 : 0);
                }

                UpdateActiveBarcodeText();
                _ = SaveSettingsAsync();
                RenderSettings();
            }, isLast));
        }

        container.Content = stack;
        return container;
    }

    private View CreateSettingRow(SettingItem item)
    {
        if (item.Type == SettingItemType.Switch)
        {
            return CreateSwitchRow(item.Label, item.BoolValue, value =>
            {
                item.SetValue(value);
                ApplySettings();
                UpdateResultSheetBindings();
                if (item.Key == "continuousScanning")
                {
                    BKDView.StopScanning();
                    StartScanning();
                }
                _ = SaveSettingsAsync();
                RenderSettings();
            }, item.IsLast);
        }

        return CreateDropdownRow(item, item.IsLast);
    }
    private View CreateDropdownRow(SettingItem item, bool isLast)
    {
        var grid = new Grid { Padding = new Thickness(12, 12), ColumnDefinitions = new ColumnDefinitionCollection
        {
            new ColumnDefinition { Width = GridLength.Star },
            new ColumnDefinition { Width = GridLength.Auto }
        }};

        var label = new Label { Text = item.Label, FontSize = 15, TextColor = Color.FromArgb("#1B1B1B"), VerticalOptions = LayoutOptions.Center };
        var valueLabel = new Label { Text = item.SelectedLabel, FontSize = 15, TextColor = Color.FromArgb("#616161"), VerticalOptions = LayoutOptions.Center };

        grid.Children.Add(label);
        var valueStack = new HorizontalStackLayout
        {
            Spacing = 8,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                valueLabel,
                new Image { Source = "chevron_right.svg", HeightRequest = 14, WidthRequest = 14 }
            }
        };
        Grid.SetColumn(valueStack, 1);
        Grid.SetRow(valueStack, 0);
        grid.Children.Add(valueStack);

        var tap = new TapGestureRecognizer();
        tap.Tapped += async (_, _) =>
        {
            var options = item.Options.Select(o => o.Label).ToArray();
            var selection = await DisplayActionSheet(item.Label, "Cancel", null, options);
            if (selection == null || selection == "Cancel")
            {
                return;
            }

            var selected = item.Options.FirstOrDefault(o => o.Label == selection);
            if (selected != null)
            {
                item.SetValue(selected.Value);
                ApplySettings();
                UpdateResultSheetBindings();
                if (item.Key == "continuousThreshold" && _settings.ContinuousScanning)
                {
                    BKDView.StopScanning();
                    StartScanning();
                }
                _ = SaveSettingsAsync();
                RenderSettings();
            }
        };
        grid.GestureRecognizers.Add(tap);

        if (!isLast)
        {
            var divider = new BoxView { HeightRequest = 1, BackgroundColor = Color.FromArgb("#ECECEC") };
            var layout = new VerticalStackLayout { Spacing = 0 };
            layout.Children.Add(grid);
            layout.Children.Add(divider);
            return layout;
        }

        return grid;
    }

    private View CreateSwitchRow(string label, bool value, Action<bool> onToggle, bool isLast)
    {
        var grid = new Grid { Padding = new Thickness(12, 0, 0, 0), ColumnDefinitions = new ColumnDefinitionCollection
        {
            new ColumnDefinition { Width = GridLength.Star },
            new ColumnDefinition { Width = GridLength.Auto }
        }};

        var textLabel = new Label { Text = label, FontSize = 15, TextColor = Color.FromArgb("#1B1B1B"), VerticalOptions = LayoutOptions.Center, Margin = new Thickness(0) };
        Grid.SetColumn(textLabel, 0);
        Grid.SetRow(textLabel, 0);
        grid.Children.Add(textLabel);
        var toggle = new Switch
        {
            IsToggled = value,
            OnColor = Color.FromArgb("#E52E4C"),
            ThumbColor = Color.FromArgb("#E6E6E6"),
            Scale = 1.06,
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Center
        };
        toggle.Toggled += (_, args) => onToggle(args.Value);
        Grid.SetColumn(toggle, 1);
        Grid.SetRow(toggle, 0);
        grid.Children.Add(toggle);

        if (!isLast)
        {
            var divider = new BoxView { HeightRequest = 1, BackgroundColor = Color.FromArgb("#ECECEC") };
            var layout = new VerticalStackLayout { Spacing = 0 };
            layout.Children.Add(grid);
            layout.Children.Add(divider);
            return layout;
        }

        return grid;
    }

    private Border CreateGroupContainer()
    {
        return new Border
        {
            BackgroundColor = Colors.White,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(14) },
            Padding = 0,
            Margin = new Thickness(0, 0, 0, 6)
        };
    }

    private IEnumerable<SettingItem> GetGeneralSettings()
    {
        var items = new List<SettingItem>();

        if (Mode == ScannerModes.AnyScan)
        {
            items.Add(SettingItem.Switch("Composite Mode", "compositeMode", _settings.CompositeMode, val => _settings.CompositeMode = val));
        }

        items.Add(SettingItem.Switch("Allow Pinch to Zoom", "pinchToZoom", _settings.PinchToZoom, val => _settings.PinchToZoom = val));

        if (Mode != ScannerModes.Dpm && Mode != ScannerModes.ArMode && Mode != ScannerModes.Vin && Mode != ScannerModes.Mrz)
        {
            items.Add(SettingItem.Switch("Location in Preview", "locationInPreview", _settings.LocationInPreview, val => _settings.LocationInPreview = val));
        }

        if (Mode != ScannerModes.Dpm && Mode != ScannerModes.ArMode && Mode != ScannerModes.Mrz)
        {
            items.Add(SettingItem.Switch(Mode == ScannerModes.Vin ? "Narrow Viewfinder" : "Region of Interest", "regionOfInterest", _settings.RegionOfInterest, val => _settings.RegionOfInterest = val));
        }

        items.Add(SettingItem.Switch("Beep on Success", "beepOnSuccess", _settings.BeepOnSuccess, val => _settings.BeepOnSuccess = val));
        items.Add(SettingItem.Switch("Vibrate on Success", "vibrateOnSuccess", _settings.VibrateOnSuccess, val => _settings.VibrateOnSuccess = val));
        if (Mode != ScannerModes.Dpm && Mode != ScannerModes.ArMode && Mode != ScannerModes.Vin && Mode != ScannerModes.Mrz && Mode != ScannerModes.Dotcode)
        {
            items.Add(SettingItem.Switch("Scan Blurred UPC/EAN", "scanBlurred", _settings.ScanBlurred, val => _settings.ScanBlurred = val));
        }

        if (Mode != ScannerModes.Dpm && Mode != ScannerModes.ArMode && Mode != ScannerModes.Mrz && Mode != ScannerModes.Dotcode)
        {
            items.Add(SettingItem.Switch("Scan Deformed Codes", "scanDeformed", _settings.ScanDeformed, val => _settings.ScanDeformed = val));
        }

        if (Mode != ScannerModes.ArMode)
        {
            items.Add(SettingItem.Switch("Continuous Scanning", "continuousScanning", _settings.ContinuousScanning, val => _settings.ContinuousScanning = val));

            if (_settings.ContinuousScanning)
            {
                var options = Enumerable.Range(0, 11)
                    .Select(i => new SettingOption($"{i}s", i))
                    .ToList();
                items.Add(SettingItem.Dropdown("Duplicate Threshold", "continuousThreshold", options, _settings.ContinuousThreshold, val => _settings.ContinuousThreshold = (int)val));
            }
        }

        if (Mode == ScannerModes.ArMode)
        {
            items.Add(SettingItem.Switch("Double Tap to Freeze", "arDoubleTapToFreeze", _settings.ArDoubleTapToFreeze, val => _settings.ArDoubleTapToFreeze = val));
            items.Add(SettingItem.Dropdown("AR Mode", "arMode", new List<SettingOption>
            {
                new("Disabled", BarkoderARMode.InteractiveDisabled),
                new("Enabled", BarkoderARMode.InteractiveEnabled),
                new("Always", BarkoderARMode.NonInteractive),
            }, _settings.ArMode, val => _settings.ArMode = (BarkoderARMode)val));

            items.Add(SettingItem.Dropdown("Location Type", "arLocationType", new List<SettingOption>
            {
                new("None", BarkoderARLocationType.NONE),
                new("Tight", BarkoderARLocationType.TIGHT),
                new("Box", BarkoderARLocationType.BOUNDINGBOX),
            }, _settings.ArLocationType, val => _settings.ArLocationType = (BarkoderARLocationType)val));

            items.Add(SettingItem.Dropdown("Header Show Mode", "arHeaderShowMode", new List<SettingOption>
            {
                new("Never", BarkoderARHeaderShowMode.NEVER),
                new("Always", BarkoderARHeaderShowMode.ALWAYS),
                new("Selected", BarkoderARHeaderShowMode.ONSELECTED),
            }, _settings.ArHeaderShowMode, val => _settings.ArHeaderShowMode = (BarkoderARHeaderShowMode)val));

            items.Add(SettingItem.Dropdown("Overlay Refresh", "arOverlayRefresh", new List<SettingOption>
            {
                new("Smooth", BarkoderAROverlayRefresh.SMOOTH),
                new("Normal", BarkoderAROverlayRefresh.NORMAL),
            }, _settings.ArOverlayRefresh, val => _settings.ArOverlayRefresh = (BarkoderAROverlayRefresh)val));
        }

        MarkLast(items);
        return items;
    }

    private IEnumerable<SettingItem> GetDecodingSettings()
    {
        var items = new List<SettingItem>();

        if (Mode != ScannerModes.Dpm && Mode != ScannerModes.ArMode && Mode != ScannerModes.Vin && Mode != ScannerModes.Mrz && Mode != ScannerModes.Dotcode)
        {
            items.Add(SettingItem.Dropdown("Decoding Speed", "decodingSpeed", new List<SettingOption>
            {
                new("Fast", DecodingSpeed.Fast),
                new("Normal", DecodingSpeed.Normal),
                new("Slow", DecodingSpeed.Slow),
            }, _settings.DecodingSpeed, val => _settings.DecodingSpeed = (DecodingSpeed)val));

            items.Add(SettingItem.Dropdown("Resolution", "resolution", new List<SettingOption>
            {
                new("HD", BarkoderResolution.HD),
                new("FHD", BarkoderResolution.FHD),
            }, _settings.Resolution, val => _settings.Resolution = (BarkoderResolution)val));
        }

        MarkLast(items);
        return items;
    }

    private IEnumerable<(string Id, string Label)> GetFilteredBarcodeTypes(string category)
    {
        var types = category == "1D" ? BarcodeConstants.BarcodeTypes1D : BarcodeConstants.BarcodeTypes2D;
        var list = types.ToList();

        if (Mode == ScannerModes.Dpm)
        {
            list = list.Where(t => new[] { "datamatrix", "qr", "qrMicro" }.Contains(t.Id)).ToList();
        }
        else if (Mode == ScannerModes.Dotcode)
        {
            list = list.Where(t => t.Id == "dotcode").ToList();
        }
        else if (Mode == ScannerModes.Vin)
        {
            list = list.Where(t => new[] { "code39", "code128", "datamatrix", "qr", "ocrText" }.Contains(t.Id)).ToList();
        }
        else if (Mode == ScannerModes.Mrz)
        {
            return Enumerable.Empty<(string Id, string Label)>();
        }
        else if (Mode == ScannerModes.Mode1D && category == "2D")
        {
            return Enumerable.Empty<(string Id, string Label)>();
        }
        else if (Mode == ScannerModes.Mode2D && category == "1D")
        {
            return Enumerable.Empty<(string Id, string Label)>();
        }

        if (Mode != ScannerModes.Vin)
        {
            list = list.Where(t => t.Id != "ocrText").ToList();
        }

        return list;
    }

    private static void MarkLast(List<SettingItem> items)
    {
        for (var i = 0; i < items.Count; i++)
        {
            items[i].IsLast = i == items.Count - 1;
        }
    }

        private class SettingItem
        {
            public SettingItemType Type { get; init; }
            public string Label { get; init; } = string.Empty;
            public bool BoolValue { get; init; }
            public string Key { get; init; } = string.Empty;
            public List<SettingOption> Options { get; init; } = new();
            public object SelectedValue { get; init; } = new();
            public string SelectedLabel => Options.FirstOrDefault(o => Equals(o.Value, SelectedValue))?.Label ?? "Select";
            public Action<object> SetValue { get; init; } = _ => { };
            public bool IsLast { get; set; }

        public static SettingItem Switch(string label, string key, bool value, Action<bool> set)
        {
            return new SettingItem
            {
                Type = SettingItemType.Switch,
                Label = label,
                BoolValue = value,
                Key = key,
                SetValue = v => set((bool)v)
            };
        }

        public static SettingItem Dropdown(string label, string key, List<SettingOption> options, object selected, Action<object> set)
        {
            return new SettingItem
            {
                Type = SettingItemType.Dropdown,
                Label = label,
                Key = key,
                Options = options,
                SelectedValue = selected,
                SetValue = set
            };
        }
    }

    private class SettingOption
    {
        public SettingOption(string label, object value)
        {
            Label = label;
            Value = value;
        }

        public string Label { get; }
        public object Value { get; }
    }

    private enum SettingItemType
    {
        Switch,
        Dropdown
    }
}
