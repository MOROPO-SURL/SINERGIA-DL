namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Converters;

public class ValidationResultToTargetPropertyErrorMessageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (value is not FluentValidation.Results.ValidationResult concreteValue || parameter == null || concreteValue.IsValid) return null;

        return concreteValue.Errors.FirstOrDefault(item => item.PropertyName.Split(".").LastOrDefault()!.Equals(parameter))?.ErrorMessage;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        return null;
    }
}