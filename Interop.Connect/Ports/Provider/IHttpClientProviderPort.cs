namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;

public interface IHttpClientProviderPort
{
    public HttpClient GetHttpClient();

    public void Reset();
}
