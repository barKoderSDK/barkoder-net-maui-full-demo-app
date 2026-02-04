using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using _TmpMaui.Models;
using _TmpMaui.Services;
using _TmpMaui.Utils;

namespace _TmpMaui.Views;

public partial class HistoryPage : ContentPage
{
    public ObservableCollection<HistoryGroup> Groups { get; } = new();

    private bool _isLoading = true;
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }

    public HistoryPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadHistoryAsync();
    }

    private async Task LoadHistoryAsync()
    {
        IsLoading = true;
        Groups.Clear();

        var history = await HistoryService.GetHistoryAsync();

        var grouped = await Task.Run(() =>
            history
                .GroupBy(h => DateTimeOffset.FromUnixTimeMilliseconds(h.Timestamp).ToLocalTime().ToString("dd/MM/yyyy"))
                .Select(g => new HistoryGroup(g.Key, g.Select(ToViewItem)))
                .ToList()
        );

        MainThread.BeginInvokeOnMainThread(() =>
        {
            foreach (var group in grouped)
            {
                Groups.Add(group);
            }
            IsLoading = false;
        });
    }

    private static HistoryItemView ToViewItem(HistoryItem item)
    {
        var imageSource = !string.IsNullOrWhiteSpace(item.ImagePath) && File.Exists(item.ImagePath)
            ? ImageSource.FromFile(item.ImagePath)
            : null;

        var showPlaceholder = imageSource == null;
        var placeholder = Is1D(item.Type) ? "icon_1d.svg" : "icon_2d.svg";

        return new HistoryItemView
        {
            Text = item.Text,
            Type = item.Type,
            ImageSource = imageSource,
            ShowPlaceholder = showPlaceholder,
            PlaceholderIcon = placeholder,
            Count = item.Count,
            ImagePath = item.ImagePath
        };
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnInfoClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.CommandParameter is HistoryItemView item)
        {
            await Shell.Current.GoToAsync(nameof(BarcodeDetailsPage), new Dictionary<string, object>
            {
                ["Item"] = new ScannedItem
                {
                    Text = item.Text,
                    Type = item.Type,
                    ImagePath = item.ImagePath
                }
            });
        }
    }

    private static string Normalize(string input)
    {
        return Regex.Replace(input, "[^a-zA-Z0-9]", "").ToLowerInvariant();
    }

    private static bool Is1D(string type)
    {
        var normalized = Normalize(type);
        return BarcodeConstants.BarcodeTypes1D.Any(t => Normalize(t.Label) == normalized || Normalize(t.Id) == normalized);
    }

    public class HistoryGroup : ObservableCollection<HistoryItemView>
    {
        public HistoryGroup(string title, IEnumerable<HistoryItemView> items) : base(items)
        {
            Title = title;
        }

        public string Title { get; }
    }

    public class HistoryItemView
    {
        public string Text { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public ImageSource? ImageSource { get; set; }
        public string PlaceholderIcon { get; set; } = string.Empty;
        public bool ShowPlaceholder { get; set; }
        public int Count { get; set; }
        public string CountText => Count > 1 ? $"({Count})" : string.Empty;
        public bool HasCount => Count > 1;
        public string? ImagePath { get; set; }
    }
}
