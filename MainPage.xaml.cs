namespace BarkoderMaui;

using Microsoft.Maui.ApplicationModel;
using Plugin.Maui.Barkoder.Enums;
using Plugin.Maui.Barkoder.Handlers;
using Plugin.Maui.Barkoder.Interfaces;
using System.Linq;
using System.Threading.Tasks;

public partial class MainPage : ContentPage, IBarkoderDelegate
{
	public MainPage()
	{
		InitializeComponent();

		_ = ExecuteAfterDelayAsync();
	}

	private async Task ExecuteAfterDelayAsync()
	{
		await Task.Delay(TimeSpan.FromSeconds(0.5));

		SetUI();
		SetBarkoderSettings();
		SetActiveBarcodeTypes();
	}

	private void SetUI()
	{
		Title = $"Barkoder Sample (v{BKDView.Version})";
		TitleLabel.Text = Title;
	}

	private void SetBarkoderSettings()
	{
		// These are optional settings, otherwise default values will be used
		BKDView.SetImageResultEnabled(true);
		BKDView.SetLocationInPreviewEnabled(true);
		BKDView.SetRegionOfInterestVisible(true);
		BKDView.SetCloseSessionOnResultEnabled(true);

		BKDView.SetRegionOfInterest(5, 5, 90, 90);
	}

	private void SetActiveBarcodeTypes()
	{
		BKDView.SetBarcodeTypeEnabled(BarcodeType.Ean13, true);
		BKDView.SetBarcodeTypeEnabled(BarcodeType.UpcA, true);
		BKDView.SetBarcodeTypeEnabled(BarcodeType.QR, true);
	}

	private void OnStartScanningBtnClicked(object sender, EventArgs e)
	{
		TextualDataLbl.Text = string.Empty;
		BKDView.StartScanning(this);
	}

	public void DidFinishScanning(BarcodeResult[] result, ImageSource originalImageSource)
	{
		var scannedText = result.Length == 0
			? "No barcodes detected."
			: string.Join(Environment.NewLine, result.Select(barcode => barcode.TextualData));

		MainThread.BeginInvokeOnMainThread(() =>
		{
			TextualDataLbl.Text = scannedText;
			OriginalImage.Source = originalImageSource;
		});
	}
}

