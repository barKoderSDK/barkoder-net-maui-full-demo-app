using System.Collections.ObjectModel;
using System.Windows.Input;
using BarkoderMaui.Models;
using BarkoderMaui.Utils;
using Microsoft.Maui.ApplicationModel;
using Plugin.Maui.Barkoder.Controls;
using Plugin.Maui.Barkoder.Enums;
using Plugin.Maui.Barkoder.Handlers;
using Plugin.Maui.Barkoder.Interfaces;

namespace BarkoderMaui.Views;

public partial class HomePage : ContentPage, IBarkoderDelegate
{
    public ObservableCollection<HomeSection> Sections { get; } =
        new ObservableCollection<HomeSection>(BarcodeConstants.HomeSections);

    public ICommand ItemTappedCommand { get; }

    private bool _galleryInitialized;
    private Dictionary<string, bool> _galleryEnabledTypes = new(StringComparer.OrdinalIgnoreCase);
    private ScannerSettings _gallerySettings = new();
    private string? _pendingGalleryBase64;
    private bool _isGalleryScanInProgress;
    private CancellationTokenSource? _galleryScanCts;

    public HomePage()
    {
        ItemTappedCommand = new Command<HomeItem>(OnItemTapped);
        InitializeComponent();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!string.IsNullOrWhiteSpace(_pendingGalleryBase64) && !_isGalleryScanInProgress)
        {
            await StartPendingGalleryScanAsync();
        }
    }

    private async void OnItemTapped(HomeItem? item)
    {
        if (item == null)
        {
            return;
        }

        if (item.Id == "gallery")
        {
            await ScanImageFromGalleryAsync();
            return;
        }

        if (!string.IsNullOrWhiteSpace(item.Mode))
        {
            await Shell.Current.GoToAsync($"{nameof(ScannerPage)}?mode={item.Mode}&sessionId={DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}");
        }
    }

    private async void OnRecentClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(HistoryPage));
    }

    private async void OnAnyScanClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(ScannerPage)}?mode={ScannerModes.AnyScan}&sessionId={DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}");
    }

    private async void OnAboutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AboutPage));
    }

    private async Task EnsureGalleryReadyAsync()
    {
        if (_galleryInitialized)
        {
            return;
        }

        _galleryInitialized = true;
        await GalleryScanBkdView.whenScannerReady();

        _gallerySettings = ScannerConfig.GetInitialSettings(ScannerModes.Gallery);
        _galleryEnabledTypes = ScannerConfig.GetInitialEnabledTypes(ScannerModes.Gallery);
    }

    private void ApplyGallerySettings()
    {
        GalleryScanBkdView.SetImageResultEnabled(true);
        GalleryScanBkdView.SetLocationInImageResultEnabled(true);
        GalleryScanBkdView.SetLocationInPreviewEnabled(_gallerySettings.LocationInPreview);
        GalleryScanBkdView.SetRegionOfInterestVisible(_gallerySettings.RegionOfInterest);
        if (_gallerySettings.RegionOfInterest)
        {
            GalleryScanBkdView.SetRegionOfInterest(5, 5, 90, 90);
        }
        GalleryScanBkdView.SetPinchToZoomEnabled(_gallerySettings.PinchToZoom);
        GalleryScanBkdView.SetBeepOnSuccessEnabled(_gallerySettings.BeepOnSuccess);
        GalleryScanBkdView.SetVibrateOnSuccessEnabled(_gallerySettings.VibrateOnSuccess);
        GalleryScanBkdView.SetCloseSessionOnResultEnabled(!_gallerySettings.ContinuousScanning);
        GalleryScanBkdView.SetUpcEanDeblurEnabled(_gallerySettings.ScanBlurred);
        GalleryScanBkdView.SetEnableMisshaped1DEnabled(_gallerySettings.ScanDeformed);
        GalleryScanBkdView.SetDecodingSpeed(DecodingSpeed.Rigorous);
        GalleryScanBkdView.SetBarkoderResolution(_gallerySettings.Resolution);
        GalleryScanBkdView.SetBarcodeThumbnailOnResultEnabled(true);
        GalleryScanBkdView.SetMaximumResultsCount(200);
        GalleryScanBkdView.SetThresholdBetweenDuplicatesScans(_gallerySettings.ContinuousScanning ? _gallerySettings.ContinuousThreshold : 0);

        foreach (var type in _galleryEnabledTypes)
        {
            if (BarcodeTypeMapper.TryGet(type.Key, out var barkoderType))
            {
                GalleryScanBkdView.SetBarcodeTypeEnabled(barkoderType, type.Value);
            }
        }
    }

    private async Task ScanImageFromGalleryAsync()
    {
        await EnsureGalleryReadyAsync();

        try
        {
            var file = await MediaPicker.PickPhotoAsync();
            if (file == null)
            {
                return;
            }

            var base64 = await GalleryImageHelper.GetBase64Async(file, 1024);
            if (string.IsNullOrWhiteSpace(base64))
            {
                await DisplayAlert("Error", "Could not read the selected image.", "OK");
                return;
            }

            _pendingGalleryBase64 = base64;
            await StartPendingGalleryScanAsync();
        }
        catch
        {
        }
    }

    private async Task StartPendingGalleryScanAsync()
    {
        if (string.IsNullOrWhiteSpace(_pendingGalleryBase64) || _isGalleryScanInProgress)
        {
            return;
        }

        _isGalleryScanInProgress = true;
        var base64 = _pendingGalleryBase64;
        _pendingGalleryBase64 = null;

        try
        {
            GalleryScanOverlay.IsVisible = true;
            _galleryScanCts?.Cancel();
            _galleryScanCts = new CancellationTokenSource();
            _ = HandleGalleryScanTimeoutAsync(_galleryScanCts.Token);

            await Task.Delay(100);
            await GalleryScanBkdView.whenScannerReady();
            ApplyGallerySettings();
            GalleryScanBkdView.ScanImage(base64, this);
        }
        finally
        {
            _isGalleryScanInProgress = false;
        }
    }

    private async Task HandleGalleryScanTimeoutAsync(CancellationToken token)
    {
        try
        {
            await Task.Delay(TimeSpan.FromSeconds(8), token);
            if (token.IsCancellationRequested)
            {
                return;
            }

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                GalleryScanOverlay.IsVisible = false;
                await DisplayAlert("No barcode found", "Scanning timed out. Please try another image.", "OK");
            });
        }
        catch (TaskCanceledException)
        {
        }
    }

    public void DidFinishScanning(BarcodeResult[] result, ImageSource[] thumbnails, ImageSource originalImageSource)
    {
        _galleryScanCts?.Cancel();
        MainThread.BeginInvokeOnMainThread(() => { GalleryScanOverlay.IsVisible = false; });

        if (result == null || result.Length == 0)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("No barcode found", "No barcode was detected in the selected image.", "OK");
            });
            return;
        }

        var display = thumbnails?.FirstOrDefault() ?? originalImageSource;
        var first = result[0];
        var item = new ScannedItem
        {
            Text = first.TextualData,
            Type = first.BarcodeTypeName,
            Image = display
        };

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Shell.Current.GoToAsync(nameof(BarcodeDetailsPage), new Dictionary<string, object>
            {
                ["Item"] = item
            });
        });
    }

    public void DidFinishScanning(BarcodeResult[] result, ImageSource originalImageSource)
    {
        DidFinishScanning(result, Array.Empty<ImageSource>(), originalImageSource);
    }
}

