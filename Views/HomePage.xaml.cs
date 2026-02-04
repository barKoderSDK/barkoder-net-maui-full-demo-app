using System.Collections.ObjectModel;
using System.Windows.Input;
using _TmpMaui.Models;
using _TmpMaui.Utils;

namespace _TmpMaui.Views;

public partial class HomePage : ContentPage
{
    public ObservableCollection<HomeSection> Sections { get; } =
        new ObservableCollection<HomeSection>(BarcodeConstants.HomeSections);

    public ICommand ItemTappedCommand { get; }

    public HomePage()
    {
        ItemTappedCommand = new Command<HomeItem>(OnItemTapped);
        InitializeComponent();
        BindingContext = this;
    }

    private async void OnItemTapped(HomeItem? item)
    {
        if (item == null)
        {
            return;
        }

        if (item.Id == "gallery")
        {
            await Shell.Current.GoToAsync($"{nameof(ScannerPage)}?mode={ScannerModes.Gallery}&sessionId={DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}");
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
}
