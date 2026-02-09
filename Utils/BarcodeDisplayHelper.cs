using System.Text.RegularExpressions;

namespace BarkoderMaui.Utils;

public static class BarcodeDisplayHelper
{
    public static bool Is1D(string type)
    {
        var normalized = Normalize(type);
        return BarcodeConstants.BarcodeTypes1D.Any(t => Normalize(t.Label) == normalized || Normalize(t.Id) == normalized);
    }

    public static double GetPreferredImageRotationDegrees(string barcodeTypeName, IEnumerable<(double X, double Y)>? points)
    {
        if (!Is1D(barcodeTypeName))
        {
            return 0;
        }

        if (points == null)
        {
            return 0;
        }

        var pointList = points.ToList();
        if (pointList.Count < 2)
        {
            return 0;
        }

        var minX = pointList.Min(p => p.X);
        var maxX = pointList.Max(p => p.X);
        var minY = pointList.Min(p => p.Y);
        var maxY = pointList.Max(p => p.Y);

        var width = maxX - minX;
        var height = maxY - minY;

        if (width <= 0 || height <= 0)
        {
            return 0;
        }

        return height > width * 1.15 ? 90 : 0;
    }

    private static string Normalize(string input)
    {
        return Regex.Replace(input, "[^a-zA-Z0-9]", "").ToLowerInvariant();
    }
}
