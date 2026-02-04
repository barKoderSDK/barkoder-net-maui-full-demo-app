using System.Collections.ObjectModel;
using _TmpMaui.Models;

namespace _TmpMaui.Utils;

public static class BarcodeConstants
{
    public static readonly ReadOnlyCollection<(string Id, string Label)> BarcodeTypes1D =
        new ReadOnlyCollection<(string Id, string Label)>(new[]
        {
            ("australianPost", "Australian Post"),
            ("codabar", "Codabar"),
            ("code11", "Code 11"),
            ("code128", "Code 128"),
            ("code25", "Code 2 of 5 Standard"),
            ("code32", "Code 32"),
            ("code39", "Code 39"),
            ("code93", "Code 93"),
            ("coop25", "COOP 25"),
            ("datalogic25", "Code 2 of 5 Datalogic"),
            ("databar14", "GS1 Databar 14"),
            ("databarExpanded", "GS1 Databar Expanded"),
            ("databarLimited", "GS1 Databar Limited"),
            ("ean13", "EAN 13"),
            ("ean8", "EAN 8"),
            ("iata25", "IATA 25"),
            ("interleaved25", "Interleaved 2 of 5"),
            ("itf14", "ITF 14"),
            ("japanesePost", "Japanese Post"),
            ("kix", "KIX"),
            ("matrix25", "Matrix 25"),
            ("msi", "MSI"),
            ("planet", "Planet"),
            ("postalIMB", "Postal IMB"),
            ("postnet", "Postnet"),
            ("royalMail", "Royal Mail"),
            ("telepen", "Telepen"),
            ("upcA", "UPC-A"),
            ("upcE", "UPC-E"),
            ("upcE1", "UPC-E1"),
        });

    public static readonly ReadOnlyCollection<(string Id, string Label)> BarcodeTypes2D =
        new ReadOnlyCollection<(string Id, string Label)>(new[]
        {
            ("aztec", "Aztec"),
            ("aztecCompact", "Aztec Compact"),
            ("datamatrix", "Datamatrix"),
            ("dotcode", "Dotcode"),
            ("idDocument", "ID Document"),
            ("maxiCode", "MaxiCode"),
            ("ocrText", "OCR Text"),
            ("pdf417", "PDF 417"),
            ("pdf417Micro", "PDF 417 Micro"),
            ("qr", "QR"),
            ("qrMicro", "QR Micro"),
        });

    public static readonly ReadOnlyCollection<HomeSection> HomeSections =
        new ReadOnlyCollection<HomeSection>(new[]
        {
            new HomeSection
            {
                Title = "General Barcodes",
                Items = new ObservableCollection<HomeItem>
                {
                    new HomeItem { Id = "1d", Label = "1D", Icon = "icon_1d.svg", Mode = ScannerModes.Mode1D },
                    new HomeItem { Id = "2d", Label = "2D", Icon = "icon_2d.svg", Mode = ScannerModes.Mode2D },
                    new HomeItem { Id = "continuous", Label = "Continuous", Icon = "icon_continuous.svg", Mode = ScannerModes.Continuous },
                }
            },
            new HomeSection
            {
                Title = "Showcase",
                Items = new ObservableCollection<HomeItem>
                {
                    new HomeItem { Id = "multiscan", Label = "MultiScan", Icon = "icon_multiscan.svg", Mode = ScannerModes.Multiscan },
                    new HomeItem { Id = "vin", Label = "VIN", Icon = "icon_vin.svg", Mode = ScannerModes.Vin },
                    new HomeItem { Id = "dpm", Label = "DPM", Icon = "icon_dpm.svg", Mode = ScannerModes.Dpm },
                    new HomeItem { Id = "deblur", Label = "DeBlur", Icon = "icon_blur.svg", Mode = ScannerModes.Deblur },
                    new HomeItem { Id = "dotcode", Label = "DotCode", Icon = "icon_dotcode.svg", Mode = ScannerModes.Dotcode },
                    new HomeItem { Id = "ar_mode", Label = "AR Mode", Icon = "icon_ar.svg", Mode = ScannerModes.ArMode },
                    new HomeItem { Id = "mrz", Label = "MRZ", Icon = "icon_mrz.svg", Mode = ScannerModes.Mrz },
                    new HomeItem { Id = "gallery", Label = "Gallery Scan", Icon = "icon_gallery.svg", Mode = ScannerModes.Gallery },
                }
            }
        });
}
