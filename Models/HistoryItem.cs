namespace BarkoderMaui.Models;

public class HistoryItem
{
    public string Text { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? ImagePath { get; set; }
    public long Timestamp { get; set; }
    public int Count { get; set; }
}

