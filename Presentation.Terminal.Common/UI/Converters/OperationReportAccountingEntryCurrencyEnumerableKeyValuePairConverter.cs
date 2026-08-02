using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Enumerations;
using System.Globalization;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Converters;

public sealed class OperationReportAccountingEntryCurrencyEnumerableKeyValuePairConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null || value is not IEnumerable<KeyValuePair<OperationReportAccountingEntryCurrency,float>> concreteValue) return null;

        return concreteValue.First().Value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
