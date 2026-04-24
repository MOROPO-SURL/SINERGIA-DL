using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Manager;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Factories;
using System.Net.Http.Headers;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Ports.Adapter.Provider
{
    public class HttpClientHelperProvider : IHttpClientProviderPort
    {
        public HttpClient httpClient = null!;

        public HttpClientHelperProvider()
        {
            Reset();
        }

        public HttpClient GetHttpClient()
        {
            return httpClient;
        }

        public void Reset()
        {
            var settingManager = IPlatformApplication.Current!.Services.GetRequiredService<ISettingManagerPort>();

            httpClient = new HttpClient(HttpClientHandlerFactory.Build())
            {
                BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7235" : "https://localhost:7235")
            };

            KeyValuePair<string, string> authorizationHeader = GetAuthorizeHeader();

            if (string.IsNullOrWhiteSpace(authorizationHeader.Key) || string.IsNullOrWhiteSpace(authorizationHeader.Value)) return;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorizationHeader.Key, authorizationHeader.Value);
        }

        private KeyValuePair<string, string> GetAuthorizeHeader()
        {
            var session = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>().CurrentSession;

            if (session == null)
            {
                return new KeyValuePair<string, string>();
            }
            else
            {
                return new KeyValuePair<string, string>(session.AuthenticationType, session.AuthorizationToken);
            }
        }
    }
}
