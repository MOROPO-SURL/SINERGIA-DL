using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.Portal.Ports.Provider.Adapter;

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
        httpClient = new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true,
        })
        {
            BaseAddress = new Uri("https://localhost:7235")
        };
    }
}
