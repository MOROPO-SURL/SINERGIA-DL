using System.Globalization;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Converters;

internal sealed class ShellMenuItemToViewConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null || value is not ShellItem concreteValue) return null;

        return concreteValue.Title.StartsWith("» ") && concreteValue.Title.EndsWith(" «")
            ? new Views.SubtitleSectionShellMenuItemView()
            : new Views.TitleSectionShellMenuItemView();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
