using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Helper;
using System.Globalization;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Ports.Adapter.Helper;

internal class LocalizationHelperPortAdapter : ILocalizationHelperPort
{
    public string GetString(string value, CultureInfo culture)
    {
        return LocalizationResources.ResourceManager.GetString(value, culture)!;
    }
}
