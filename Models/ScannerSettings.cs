using Plugin.Maui.Barkoder.Enums;

namespace BarkoderMaui.Models;

public class ScannerSettings
{
    public bool CompositeMode { get; set; }
    public bool PinchToZoom { get; set; }
    public bool LocationInPreview { get; set; }
    public bool RegionOfInterest { get; set; }
    public bool BeepOnSuccess { get; set; }
    public bool VibrateOnSuccess { get; set; }
    public bool ScanBlurred { get; set; }
    public bool ScanDeformed { get; set; }
    public bool ContinuousScanning { get; set; }
    public int ContinuousThreshold { get; set; }
    public bool ShowResultSheet { get; set; }

    public DecodingSpeed DecodingSpeed { get; set; }
    public BarkoderResolution Resolution { get; set; }

    public BarkoderARMode ArMode { get; set; }
    public BarkoderARLocationType ArLocationType { get; set; }
    public BarkoderARHeaderShowMode ArHeaderShowMode { get; set; }
    public BarkoderAROverlayRefresh ArOverlayRefresh { get; set; }
    public bool ArDoubleTapToFreeze { get; set; }
}

