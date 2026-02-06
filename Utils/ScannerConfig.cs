using Plugin.Maui.Barkoder.Enums;
using BarkoderMaui.Models;

namespace BarkoderMaui.Utils;

public static class ScannerConfig
{
    private static readonly HashSet<string> DefaultEnabled = new(StringComparer.OrdinalIgnoreCase)
    {
        "ean13", "upcA", "code128", "qr", "datamatrix"
    };

    public static Dictionary<string, bool> GetInitialEnabledTypes(string mode)
    {
        var allTypes = BarcodeConstants.BarcodeTypes1D
            .Concat(BarcodeConstants.BarcodeTypes2D)
            .Select(t => t.Id)
            .ToList();

        var types = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
        foreach (var id in allTypes)
        {
            if (mode == ScannerModes.Mode1D)
            {
                types[id] = BarcodeConstants.BarcodeTypes1D.Any(b => b.Id == id);
            }
            else if (mode == ScannerModes.Mode2D)
            {
                types[id] = BarcodeConstants.BarcodeTypes2D.Any(b => b.Id == id) && id != "ocrText";
            }
            else if (mode == ScannerModes.Continuous || mode == ScannerModes.AnyScan)
            {
                types[id] = id != "ocrText";
            }
            else if (mode == ScannerModes.Dotcode)
            {
                types[id] = id == "dotcode";
            }
            else if (mode == ScannerModes.Mrz)
            {
                types[id] = id == "idDocument";
            }
            else if (mode == ScannerModes.Gallery)
            {
                types[id] = true;
            }
            else if (mode == ScannerModes.Vin)
            {
                types[id] = new[] { "code39", "code128", "qr", "datamatrix" }.Contains(id);
            }
            else if (mode == ScannerModes.ArMode)
            {
                types[id] = new[] { "qr", "code128", "code39", "upcA", "upcE", "ean13", "ean8" }.Contains(id);
            }
            else
            {
                types[id] = id != "ocrText" && DefaultEnabled.Contains(id);
            }
        }

        if (mode != ScannerModes.Mrz && mode != ScannerModes.Gallery)
        {
            types["idDocument"] = false;
        }
        return types;
    }

    public static ScannerSettings GetInitialSettings(string mode)
    {
        var settings = new ScannerSettings
        {
            CompositeMode = false,
            PinchToZoom = true,
            LocationInPreview = true,
            RegionOfInterest = false,
            BeepOnSuccess = true,
            VibrateOnSuccess = false,
            ScanBlurred = false,
            ScanDeformed = false,
            ContinuousScanning = false,
            ContinuousThreshold = 5,
            ShowResultSheet = true,
            DecodingSpeed = DecodingSpeed.Normal,
            Resolution = BarkoderResolution.HD,
            ArMode = BarkoderARMode.InteractiveEnabled,
            ArLocationType = BarkoderARLocationType.NONE,
            ArHeaderShowMode = BarkoderARHeaderShowMode.ONSELECTED,
            ArOverlayRefresh = BarkoderAROverlayRefresh.NORMAL,
            ArDoubleTapToFreeze = false
        };

        switch (mode)
        {
            case ScannerModes.Continuous:
                settings.ContinuousScanning = true;
                settings.ContinuousThreshold = 5;
                break;
            case ScannerModes.Multiscan:
                settings.ContinuousScanning = true;
                settings.ContinuousThreshold = -1;
                break;
            case ScannerModes.Vin:
                settings.DecodingSpeed = DecodingSpeed.Slow;
                settings.Resolution = BarkoderResolution.FHD;
                settings.RegionOfInterest = true;
                settings.ScanDeformed = true;
                break;
            case ScannerModes.Dpm:
                settings.DecodingSpeed = DecodingSpeed.Slow;
                settings.Resolution = BarkoderResolution.FHD;
                settings.RegionOfInterest = true;
                break;
            case ScannerModes.Mrz:
                settings.ContinuousScanning = false;
                break;
            case ScannerModes.ArMode:
                settings.DecodingSpeed = DecodingSpeed.Slow;
                settings.Resolution = BarkoderResolution.FHD;
                settings.ContinuousScanning = true;
                settings.ArMode = BarkoderARMode.InteractiveEnabled;
                settings.ArLocationType = BarkoderARLocationType.NONE;
                settings.ArHeaderShowMode = BarkoderARHeaderShowMode.ONSELECTED;
                settings.ArOverlayRefresh = BarkoderAROverlayRefresh.NORMAL;
                settings.ArDoubleTapToFreeze = false;
                break;
            case ScannerModes.Gallery:
                settings.DecodingSpeed = DecodingSpeed.Rigorous;
                break;
            case ScannerModes.Dotcode:
                settings.RegionOfInterest = true;
                settings.DecodingSpeed = DecodingSpeed.Slow;
                settings.ContinuousScanning = true;
                break;
            case ScannerModes.Deblur:
                settings.ScanBlurred = true;
                settings.ScanDeformed = true;
                break;
        }

        return settings;
    }
}

