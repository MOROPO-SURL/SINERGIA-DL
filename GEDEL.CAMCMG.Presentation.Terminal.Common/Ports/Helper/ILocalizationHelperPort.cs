namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Helper;

public interface ILocalizationHelperPort
{
    string GetString(string value, System.Globalization.CultureInfo culture);
}