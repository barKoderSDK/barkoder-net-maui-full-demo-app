using System.Diagnostics;

namespace BarkoderMaui.Utils;

public static class AppLogger
{
    private const string Tag = "BarkoderMaui";

    public static void Info(string message) => Write("INFO", message, null);
    public static void Warn(string message) => Write("WARN", message, null);
    public static void Error(string message, Exception? ex = null) => Write("ERROR", message, ex);

    private static void Write(string level, string message, Exception? ex)
    {
        var line = $"[{level}] {message}";
        if (ex != null)
        {
            line = $"{line}{Environment.NewLine}{ex}";
        }

        Debug.WriteLine(line);
        Console.WriteLine(line);

#if ANDROID
        if (ex != null)
        {
            Android.Util.Log.Error(Tag, $"{message}\n{ex}");
        }
        else
        {
            Android.Util.Log.Info(Tag, message);
        }
#elif IOS
        Foundation.NSLog(line);
#endif
    }
}
