namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Constants;

public static class InteropConstants
{
#if DEBUG
#if ANDROID
    public const string HELP_URL = "https://10.0.2.2:7123/help/mipyme";
#else
    public const string HELP_URL = "https://localhost:7123/help/mipyme";
#endif
#else
    public const string HELP_URL = "https://admin.gedel.camcmg.moropo.cu/help/mipyme";
#endif
}