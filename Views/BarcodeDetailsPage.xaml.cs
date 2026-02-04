using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using _TmpMaui.Models;
using _TmpMaui.Utils;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace _TmpMaui.Views;

[QueryProperty(nameof(Item), "Item")]
public partial class BarcodeDetailsPage : ContentPage
{
    public ObservableCollection<DetailItem> Details { get; } = new();

    private ScannedItem? _item;

    public ScannedItem? Item
    {
        get => _item;
        set
        {
            _item = value;
            BindingContext = this;
            PopulateDetails();
        }
    }

    public BarcodeDetailsPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void PopulateDetails()
    {
        Details.Clear();
        if (_item == null)
        {
            return;
        }

        if (_item.Image != null)
        {
            BarcodeImage.Source = _item.Image;
            BarcodeImage.IsVisible = true;
            BarcodePlaceholder.IsVisible = false;
        }
        else if (!string.IsNullOrWhiteSpace(_item.ImagePath) && File.Exists(_item.ImagePath))
        {
            BarcodeImage.Source = ImageSource.FromFile(_item.ImagePath);
            BarcodeImage.IsVisible = true;
            BarcodePlaceholder.IsVisible = false;
        }
        else
        {
            BarcodeImage.IsVisible = false;
            BarcodePlaceholder.IsVisible = true;
            PlaceholderIcon.Source = Is1D(_item.Type) ? "icon_1d.svg" : "icon_2d.svg";
        }

        var isMrz = _item.Type.Equals("mrz", StringComparison.OrdinalIgnoreCase);
        if (isMrz)
        {
            Details.Add(new DetailItem("Barcode Type", _item.Type));
            foreach (var field in ParseMrzData(_item.Text))
            {
                Details.Add(new DetailItem(field.Label, field.Value));
            }
        }
        else
        {
            Details.Add(new DetailItem("Barcode Type", _item.Type));
            Details.Add(new DetailItem("Value", _item.Text));
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCopyClicked(object sender, EventArgs e)
    {
        if (_item == null)
        {
            return;
        }
        await Clipboard.Default.SetTextAsync(_item.Text);
        await DisplayAlert("Copied", "Barcode copied to clipboard", "OK");
    }

    private async void OnSearchClicked(object sender, EventArgs e)
    {
        if (_item == null)
        {
            return;
        }

        var url = $"https://www.google.com/search?q={Uri.EscapeDataString(_item.Text)}";
        await Launcher.Default.OpenAsync(url);
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

    private static List<(string Id, string Label, string Value)> ParseMrzData(string text)
    {
        var fields = new List<(string Id, string Label, string Value)>();
        var lines = text.Split('\n');
        foreach (var line in lines)
        {
            var match = Regex.Match(line, "^([^:]+):\\s*(.+)$");
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

    public class DetailItem
    {
        public DetailItem(string label, string value)
        {
            Label = label;
            Value = value;
        }

        public string Label { get; }
        public string Value { get; }
    }
}
