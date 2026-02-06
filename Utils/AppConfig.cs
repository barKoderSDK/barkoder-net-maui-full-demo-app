using System.Text;
using Microsoft.Maui.Storage;

namespace BarkoderMaui.Utils;

public static class AppConfig
{
    private const string LicenseKeyName = "BARKODER_LICENSE_KEY";
    private static readonly object InitLock = new();
    private static string? _barkoderLicenseKey;

    public static string BarkoderLicenseKey
    {
        get
        {
            EnsureLoaded();
            return _barkoderLicenseKey ?? string.Empty;
        }
    }

    public static void Initialize()
    {
        EnsureLoaded();
    }

    private static void EnsureLoaded()
    {
        if (_barkoderLicenseKey != null)
        {
            return;
        }

        lock (InitLock)
        {
            if (_barkoderLicenseKey != null)
            {
                return;
            }

            _barkoderLicenseKey = LoadLicenseKey() ?? string.Empty;
        }
    }

    private static string? LoadLicenseKey()
    {
        var fromEnvFile = ReadFromEnvFile(LicenseKeyName);
        if (!string.IsNullOrWhiteSpace(fromEnvFile))
        {
            return fromEnvFile;
        }

        var fromEnvVar = Environment.GetEnvironmentVariable(LicenseKeyName);
        if (!string.IsNullOrWhiteSpace(fromEnvVar))
        {
            return fromEnvVar.Trim();
        }

        return null;
    }

    private static string? ReadFromEnvFile(string key)
    {
        var candidates = new[] { ".env", "app.env" };
        foreach (var candidate in candidates)
        {
            try
            {
                using var stream = FileSystem.OpenAppPackageFileAsync(candidate).GetAwaiter().GetResult();
                using var reader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);

                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parsed = ParseEnvLine(line);
                    if (parsed == null)
                    {
                        continue;
                    }

                    var (name, value) = parsed.Value;
                    if (string.Equals(name, key, StringComparison.OrdinalIgnoreCase))
                    {
                        return value;
                    }
                }
            }
            catch
            {
                // Ignore missing env file in packaged builds.
            }
        }

        return null;
    }

    private static (string Name, string Value)? ParseEnvLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return null;
        }

        var trimmed = line.Trim();
        if (trimmed.StartsWith("#", StringComparison.Ordinal))
        {
            return null;
        }

        if (trimmed.StartsWith("export ", StringComparison.OrdinalIgnoreCase))
        {
            trimmed = trimmed.Substring("export ".Length).TrimStart();
        }

        var equalsIndex = trimmed.IndexOf('=');
        if (equalsIndex <= 0)
        {
            return null;
        }

        var name = trimmed.Substring(0, equalsIndex).Trim();
        var value = trimmed.Substring(equalsIndex + 1).Trim();

        if (value.Length >= 2)
        {
            if ((value[0] == '"' && value[^1] == '"') || (value[0] == '\'' && value[^1] == '\''))
            {
                value = value.Substring(1, value.Length - 2);
            }
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        return (name, value);
    }
}
