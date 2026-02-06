namespace BarkoderMaui.Models;

public class ScannedItemView
{
    public string Text { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Count { get; set; }
    public string DisplayText { get; set; } = string.Empty;
    public string CountText => Count > 1 ? $"({Count})" : string.Empty;
    public bool HasCount => Count > 1;
    public Color CardBackground { get; set; } = Colors.Transparent;
    public ScannedItem SourceItem { get; set; } = new ScannedItem();
}

