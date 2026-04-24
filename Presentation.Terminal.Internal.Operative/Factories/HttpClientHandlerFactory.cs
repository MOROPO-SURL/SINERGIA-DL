using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Manager;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Factories;

internal static class HttpClientHandlerFactory
{
    public static HttpClientHandler Build()
    {
        var settingManager = IPlatformApplication.Current!.Services.GetRequiredService<ISettingManagerPort>();

        return new HttpClientHandler
        {
            Proxy = !settingManager.UseProxyServer ? null : new System.Net.WebProxy
            {
                Address = new Uri(settingManager.ProxyServerAddress),
                Credentials = !settingManager.UseProxyAuthentication ? null : new System.Net.NetworkCredential(settingManager.ProxyUsername, settingManager.ProxyPassword)
            },
            ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
        };
    }
}
