using System.Text.Json;
using BarkoderMaui.Models;

namespace BarkoderMaui.Services;

public class SavedSettings
{
    public Dictionary<string, bool> EnabledTypes { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public ScannerSettings ScannerSettings { get; set; } = new ScannerSettings();
}

public static class SettingsService
{
    private static readonly string SettingsPath =
        Path.Combine(FileSystem.AppDataDirectory, "scanner_settings.json");

    public static async Task<SavedSettings?> GetSettingsAsync(string mode)
    {
        if (!File.Exists(SettingsPath))
        {
            return null;
        }

        try
        {
            var json = await File.ReadAllTextAsync(SettingsPath);
            var allSettings = JsonSerializer.Deserialize<Dictionary<string, SavedSettings>>(json);
            if (allSettings != null && allSettings.TryGetValue(mode, out var saved))
            {
                return saved;
            }
        }
        catch
        {
            return null;
        }

        return null;
    }

    public static async Task SaveSettingsAsync(string mode, SavedSettings settings)
    {
        Dictionary<string, SavedSettings> allSettings;
        try
        {
            if (File.Exists(SettingsPath))
            {
                var json = await File.ReadAllTextAsync(SettingsPath);
                allSettings = JsonSerializer.Deserialize<Dictionary<string, SavedSettings>>(json) ??
                              new Dictionary<string, SavedSettings>();
            }
            else
            {
                allSettings = new Dictionary<string, SavedSettings>();
            }
        }
        catch
        {
            allSettings = new Dictionary<string, SavedSettings>();
        }

        allSettings[mode] = settings;
        var output = JsonSerializer.Serialize(allSettings);
        await File.WriteAllTextAsync(SettingsPath, output);
    }
}

