using System.Globalization;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Converters;

public sealed class IsNullToObjectConverter : IValueConverter
{
    public object TrueValue { get; set; } = null!;

    public object FalseValue { get; set; } = null!;

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value == null ? TrueValue : FalseValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
