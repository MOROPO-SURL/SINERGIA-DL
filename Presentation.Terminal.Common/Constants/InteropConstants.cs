namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Constants;

public static class InteropConstants
{
#if DEBUG
#if ANDROID
    public const string REPORT_DIAGNOSTIC_URL = "https://10.0.2.2:7045/report/diagnostic/print";
    public const string REPORT_STRATEGIC_URL = "https://10.0.2.2:7045/report/strategic/print";
    public const string USER_PROFILE_URL = "https://10.0.2.2:7123/session";
    public const string ADMINISTRATION_BASE_URL = "https://10.0.2.2:7123/management";
    public const string API_BASE_URL = "https://10.0.2.2:7235";
#else
    public const string REPORT_DIAGNOSTIC_URL = "https://localhost:7045/report/diagnostic/print";
    public const string REPORT_STRATEGIC_URL = "https://localhost:7045/report/strategic/print";
    public const string USER_PROFILE_URL = "https://localhost:7123/session";
    public const string ADMINISTRATION_BASE_URL = "https://localhost:7123/management";
    public const string API_BASE_URL = "https://localhost:7235";
#endif
#else
    public const string REPORT_DIAGNOSTIC_URL = "https://portal.gedel.camcmg.moropo.cu/report/diagnostic/print";
    public const string REPORT_STRATEGIC_URL = "https://portal.gedel.camcmg.moropo.cu/report/strategic/print";
    public const string USER_PROFILE_URL = "https://admin.gedel.camcmg.moropo.cu/session";
    public const string ADMINISTRATION_BASE_URL = "https://admin.gedel.camcmg.moropo.cu/management";
    public const string API_BASE_URL = "https://api.gedel.camcmg.moropo.cu";
#endif
}