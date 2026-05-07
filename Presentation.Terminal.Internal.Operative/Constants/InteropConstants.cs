namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Constants;

internal static class InteropConstants
{
#if DEBUG
#if ANDROID
    public const string REPORT_DIAGNOSTIC_URL = "https://10.0.2.2:7045/report/diagnostic/print";
    public const string HELP_URL = "https://10.0.2.2:7123/help/operative";
    public const string USER_PROFILE_URL = "https://10.0.2.2:7123/session";
    public const string API_BASE_URL = "https://10.0.2.2:7235";
#else
    public const string REPORT_DIAGNOSTIC_URL = "https://localhost:7045/report/diagnostic/print";
    public const string HELP_URL = "https://localhost:7123/help/operative";
    public const string USER_PROFILE_URL = "https://localhost:7123/session";
    public const string API_BASE_URL = "https://localhost:7235";
#endif
#else
    public const string REPORT_DIAGNOSTIC_URL = "https://portal.gedel.camcmg.moropo.cu/report/diagnostic/print";
    public const string HELP_URL = "https://admin.gedel.camcmg.moropo.cu/help/operative";
    public const string USER_PROFILE_URL = "https://admin.gedel.camcmg.moropo.cu/session";
    public const string API_BASE_URL = "https://api.gedel.camcmg.moropo.cu";
#endif
}