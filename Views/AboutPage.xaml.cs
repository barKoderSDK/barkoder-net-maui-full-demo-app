using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Storage;

namespace BarkoderMaui.Views;

public partial class AboutPage : ContentPage
{
    public string DeviceId { get; private set; } = string.Empty;
    public string AppVersion { get; private set; } = string.Empty;
    public string SdkVersion { get; private set; } = "1.6.7";
    public string LibVersion { get; private set; } = "19.1.1";

    public AboutPage()
    {
        InitializeComponent();
        LoadInfo();
        BindingContext = this;
    }

    private void LoadInfo()
    {
        AppVersion = AppInfo.Current.VersionString;
        DeviceId = GetOrCreateDeviceId();
    }

    private static string GetOrCreateDeviceId()
    {
        const string key = "barkoder_device_id";
        if (Preferences.ContainsKey(key))
        {
            return Preferences.Get(key, string.Empty);
        }

        var id = Guid.NewGuid().ToString("N");
        Preferences.Set(key, id);
        return id;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnTrialClicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://barkoder.com/trial");
    }

    private async void OnWebsiteTapped(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://barkoder.com/");
    }

    private async void OnOneDTapped(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://barkoder.com/barcode-types#1D-barcodes");
    }

    private async void OnTwoDTapped(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://barkoder.com/barcode-types#2D-barcodes");
    }
}

