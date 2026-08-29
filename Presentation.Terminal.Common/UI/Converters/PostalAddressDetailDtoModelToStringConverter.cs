using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using System.Globalization;
using System.Text;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Converters;

public sealed class PostalAddressDetailDtoModelToStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null || value is not PostalAddressDetailDtoModel model) return null;

        StringBuilder sb = new($"{model.Street} No. {model.Number ?? "S/N"}");

        if (!string.IsNullOrEmpty(model.Context) && !string.IsNullOrWhiteSpace(model.Context))
        {
            sb.Append(", ");
            sb.Append(model.Context);
        }

        if (model.ZipCode is not null)
        {
            sb.Append(", Código postal: ");
            sb.Append(model.ZipCode.Value);
        }

        return sb.ToString();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
