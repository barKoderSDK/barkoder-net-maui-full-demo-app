using Microsoft.Maui.Storage;

namespace BarkoderMaui.Utils;

public static class GalleryImageHelper
{
    public static async Task<string?> GetBase64Async(FileResult file, int maxDimension)
    {
#if ANDROID
        if (!string.IsNullOrWhiteSpace(file.FullPath))
        {
            var bounds = new Android.Graphics.BitmapFactory.Options { InJustDecodeBounds = true };
            Android.Graphics.BitmapFactory.DecodeFile(file.FullPath, bounds);

            var inSampleSize = 1;
            while ((bounds.OutWidth / inSampleSize) > maxDimension || (bounds.OutHeight / inSampleSize) > maxDimension)
            {
                inSampleSize *= 2;
            }

            var decodeOptions = new Android.Graphics.BitmapFactory.Options
            {
                InSampleSize = inSampleSize,
                InPreferredConfig = Android.Graphics.Bitmap.Config.Rgb565,
                InDither = true
            };
            using var bitmap = Android.Graphics.BitmapFactory.DecodeFile(file.FullPath, decodeOptions);
            if (bitmap == null)
            {
                return await ReadStreamBase64Async(file);
            }

            using var ms = new MemoryStream();
            var format = Android.Graphics.Bitmap.CompressFormat.Jpeg;
            bitmap.Compress(format!, 85, ms);
            return Convert.ToBase64String(ms.ToArray());
        }
#elif IOS
        if (!string.IsNullOrWhiteSpace(file.FullPath))
        {
            var image = UIKit.UIImage.FromFile(file.FullPath);
            if (image != null)
            {
                var resized = ResizeImage(image, maxDimension);
                using var data = resized.AsJPEG(0.85f);
                if (!ReferenceEquals(resized, image))
                {
                    resized.Dispose();
                }
                image.Dispose();
                return Convert.ToBase64String(data.ToArray());
            }
        }
#endif
        return await ReadStreamBase64Async(file);
    }

#if IOS
    private static UIKit.UIImage ResizeImage(UIKit.UIImage image, int maxDimension)
    {
        var max = Math.Max(image.Size.Width, image.Size.Height);
        if (max <= maxDimension)
        {
            return image;
        }

        var scale = maxDimension / max;
        var newSize = new CoreGraphics.CGSize(image.Size.Width * scale, image.Size.Height * scale);
        UIKit.UIGraphics.BeginImageContextWithOptions(newSize, false, 1.0f);
        image.Draw(new CoreGraphics.CGRect(0, 0, newSize.Width, newSize.Height));
        var result = UIKit.UIGraphics.GetImageFromCurrentImageContext();
        UIKit.UIGraphics.EndImageContext();
        return result ?? image;
    }
#endif

    private static async Task<string> ReadStreamBase64Async(FileResult file)
    {
        await using var stream = await file.OpenReadAsync();
        using var ms = new MemoryStream();
        await stream.CopyToAsync(ms);
        return Convert.ToBase64String(ms.ToArray());
    }
}

