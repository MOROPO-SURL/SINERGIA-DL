using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;
using System.Net.Http.Headers;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Ports.Adapter.Provider
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
            httpClient = new HttpClient(Terminal.Common.Factories.HttpClientHandlerFactory.Build())
            {
                BaseAddress = new Uri(Terminal.Common.Constants.InteropConstants.API_BASE_URL)
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
