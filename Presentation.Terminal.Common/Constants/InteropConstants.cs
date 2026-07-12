namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Constants;

public static class InteropConstants
{
#if DEBUG
#if ANDROID
    public const string REPORT_DIAGNOSTIC_URL = "https://192.168.102.21:7045/report/diagnostic/print";
    public const string REPORT_STRATEGIC_URL = "https://192.168.102.21:7045/report/strategic/print";
    public const string USER_PROFILE_URL = "https://192.168.102.21:7123/session";
    public const string ADMINISTRATION_BASE_URL = "https://192.168.102.21:7123/management";
    public const string API_BASE_URL = "https://192.168.102.21:7235";
#else
    public const string REPORT_DIAGNOSTIC_URL = "https://localhost:7045/report/diagnostic/print";
    public const string REPORT_STRATEGIC_URL = "https://localhost:7045/report/strategic/print";
    public const string USER_PROFILE_URL = "https://localhost:7123/session";
    public const string ADMINISTRATION_BASE_URL = "https://localhost:7123/management";
    public const string API_BASE_URL = "https://localhost:7235";
#endif
#else
    public const string REPORT_DIAGNOSTIC_URL = "https://10.98.63.210:4443/report/diagnostic/print";
    public const string REPORT_STRATEGIC_URL = "https://10.98.63.210:4443/report/strategic/print";
    public const string USER_PROFILE_URL = "https://10.98.63.210:8443/session";
    public const string ADMINISTRATION_BASE_URL = "https://10.98.63.210:8443/management";
    public const string API_BASE_URL = "https://10.98.63.210";
#endif
}