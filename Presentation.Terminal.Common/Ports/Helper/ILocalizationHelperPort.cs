namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;

public interface ILocalizationHelperPort
{
    string GetString(string value, System.Globalization.CultureInfo culture);
}