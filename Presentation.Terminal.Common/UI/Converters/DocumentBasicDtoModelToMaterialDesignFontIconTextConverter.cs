using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Document.DTOs;
using System.Globalization;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Converters
{
    public class DocumentBasicDtoModelToMaterialDesignFontIconTextConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || value is not DocumentBasicDtoModel target) return null;

            return target.Extension switch
            {
                ".xml" => "\uF22E",
                ".txt" => "\uF219",
                ".xls" or ".xlsx" => "\uF21B",
                ".png" or ".bmp" or ".jpg" or ".gif" => "\uF21F",
                ".pdf" => "\uF225",
                ".ppt" or ".pptx" => "\uF227",
                ".doc" or ".docx" => "\uF22C",
                _ => "\uF214",
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}