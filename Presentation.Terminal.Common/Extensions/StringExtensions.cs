using SkiaSharp;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;

internal static class StringExtensions
{
    public static SKEncodedImageFormat ToSKEncodedImageFormat(this string self)
    {
        if (!self.StartsWith("image/")) throw new InvalidOperationException();

        switch (self) 
        {
            case "image/png": 
                return SKEncodedImageFormat.Png;

            case "image/bmp": 
                return SKEncodedImageFormat.Bmp;

            case "image/jpg":
            case "image/jpeg":
                return SKEncodedImageFormat.Jpeg;

            default: throw new InvalidOperationException();
        }
    }
}
