namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Constants;

internal static class InteropConstants
{
#if DEBUG
    public const string REPORT_DIAGNOSTIC_URL = "https://localhost:7045/report/diagnostic/print";
    public const string HELP_URL = "https://localhost:7123/help/operative";
    public const string USER_PROFILE_URL = "https://localhost:7123/session";
    public const string API_BASE_URL = "https://localhost:7235";
#else
    public const string REPORT_DIAGNOSTIC_URL = "https://portal.gedel.cmcmg.gobcmg.co.cu/report/diagnostic/print";
    public const string HELP_URL = "https://backoffice.gedel.cmcmg.gobcmg.co.cu/help/operative";
    public const string USER_PROFILE_URL = "https://backoffice.gedel.cmcmg.gobcmg.co.cu/session";
    public const string API_BASE_URL = "https://api.gedel.cmcmg.gobcmg.co.cu:7235";
#endif
}
