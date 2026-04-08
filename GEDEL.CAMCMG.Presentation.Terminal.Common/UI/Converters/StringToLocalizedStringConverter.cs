using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Helper;
using System.Globalization;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Converters;

public class StringToLocalizedStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null) return null;

        var concreteValue = (string)value;

        return IPlatformApplication.Current!.Services.GetRequiredService<ILocalizationHelperPort>()?.GetString(concreteValue, culture) ?? concreteValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
