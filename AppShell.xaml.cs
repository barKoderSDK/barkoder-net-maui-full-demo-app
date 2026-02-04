namespace _TmpMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Views.ScannerPage), typeof(Views.ScannerPage));
		Routing.RegisterRoute(nameof(Views.BarcodeDetailsPage), typeof(Views.BarcodeDetailsPage));
		Routing.RegisterRoute(nameof(Views.HistoryPage), typeof(Views.HistoryPage));
		Routing.RegisterRoute(nameof(Views.AboutPage), typeof(Views.AboutPage));
	}
}
