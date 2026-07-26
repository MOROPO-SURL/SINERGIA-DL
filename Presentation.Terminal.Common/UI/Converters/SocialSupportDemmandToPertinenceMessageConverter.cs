using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;
using System.Globalization;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Converters;

public sealed class SocialSupportDemmandToPertinenceMessageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null || value is not SocialSupportDemandBasicDtoModel model) return "---";

        if (model.StartAt != null)
        {
            if (model.EndAt != null)
            {
                return $"{model.StartAt:D} - {model.EndAt:D}";
            }
            else
            {
                return $"después de {model.StartAt:D}";
            }
        }
        else if (model.EndAt != null)
        {
            return $"antes de {model.EndAt:D}";
        }

        return "todo el tiempo";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
