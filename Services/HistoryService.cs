using System.Text.Json;
using _TmpMaui.Models;

namespace _TmpMaui.Services;

public static class HistoryService
{
    private static readonly string HistoryPath =
        Path.Combine(FileSystem.AppDataDirectory, "scan_history.json");

    public static async Task<List<HistoryItem>> GetHistoryAsync()
    {
        if (!File.Exists(HistoryPath))
        {
            return new List<HistoryItem>();
        }

        try
        {
            var json = await File.ReadAllTextAsync(HistoryPath);
            return JsonSerializer.Deserialize<List<HistoryItem>>(json) ?? new List<HistoryItem>();
        }
        catch
        {
            return new List<HistoryItem>();
        }
    }

    public static async Task AddScanAsync(ScannedItem item)
    {
        var history = await GetHistoryAsync();
        var imagePath = item.ImagePath;

        if (item.Image != null && string.IsNullOrEmpty(imagePath))
        {
            imagePath = await SaveImageAsync(item.Image);
        }

        var existingIndex = history.FindIndex(h => h.Text == item.Text && h.Type == item.Type);
        if (existingIndex >= 0)
        {
            var existing = history[existingIndex];
            existing.Count += 1;
            existing.Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if (!string.IsNullOrEmpty(imagePath))
            {
                existing.ImagePath = imagePath;
            }

            history.RemoveAt(existingIndex);
            history.Insert(0, existing);
        }
        else
        {
            history.Insert(0, new HistoryItem
            {
                Text = item.Text,
                Type = item.Type,
                ImagePath = imagePath,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                Count = 1
            });
        }

        var json = JsonSerializer.Serialize(history);
        await File.WriteAllTextAsync(HistoryPath, json);
    }

    public static Task ClearHistoryAsync()
    {
        try
        {
            if (Directory.Exists(FileSystem.AppDataDirectory))
            {
                var files = Directory.GetFiles(FileSystem.AppDataDirectory, "scan_*.jpg");
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }

            if (File.Exists(HistoryPath))
            {
                File.Delete(HistoryPath);
            }
        }
        catch
        {
        }

        return Task.CompletedTask;
    }

    private static async Task<string?> SaveImageAsync(ImageSource imageSource)
    {
        try
        {
            await using var stream = await GetStreamAsync(imageSource);
            if (stream == null)
            {
                return null;
            }

            var fileName = $"scan_{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}.jpg";
            var filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
            await using var fileStream = File.Create(filePath);
            await stream.CopyToAsync(fileStream);
            return filePath;
        }
        catch
        {
            return null;
        }
    }

    private static async Task<Stream?> GetStreamAsync(ImageSource imageSource)
    {
        switch (imageSource)
        {
            case FileImageSource fileImage:
                if (File.Exists(fileImage.File))
                {
                    return File.OpenRead(fileImage.File);
                }
                return null;
            case StreamImageSource streamImage:
                return await streamImage.Stream(CancellationToken.None);
            case UriImageSource uriImage when uriImage.Uri != null:
                var client = new HttpClient();
                return await client.GetStreamAsync(uriImage.Uri);
            default:
                return null;
        }
    }
}
