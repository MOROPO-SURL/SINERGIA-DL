using Newtonsoft.Json;

namespace MOROPO.GEDET.CAM.Interop.Connect.Clients.Extensions;

internal static class HttpClientExtensions
{
    private const string CONTENT_TYPE = "application/json";

    public static async Task<TResponse> SendGetAsync<TResponse>(this HttpClient target, string url)
    {
        var response = await target.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<TResponse>(responseContent)!;
    }

    public static async Task SendPostAsync<TRequest>(this HttpClient target, string urlOrResource, TRequest request)
    {
        var content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PostAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();
    }

    public static async Task<TResponse> SendPostAsync<TRequest, TResponse>(this HttpClient target, string urlOrResource, TRequest request)
    {
        var content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PostAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<TResponse>(responseContent)!;
    }

    public static async Task SendPostFormAsync(this HttpClient target, string urlOrResource, MultipartFormDataContent multipartFormDataContent)
    {
        var response = await target.PostAsync(urlOrResource, multipartFormDataContent);

        response.EnsureSuccessStatusCode();
    }

    public static async Task SendPutFormAsync(this HttpClient target, string urlOrResource, MultipartFormDataContent multipartFormDataContent)
    {
        var response = await target.PutAsync(urlOrResource, multipartFormDataContent);

        response.EnsureSuccessStatusCode();
    }

    public static async Task<TResponse> SendPutAsync<TRequest, TResponse>(this HttpClient target, string urlOrResource, TRequest request)
    {
        var content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PutAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<TResponse>(responseContent)!;
    }

    public static async Task SendPutAsync<TRequest>(this HttpClient target, string urlOrResource, TRequest request)
    {
        var content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PutAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();
    }

    public static async Task SendPutAsync(this HttpClient target, string urlOrResource)
    {
        var content = new StringContent(string.Empty, System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PutAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();
    }

    public static async Task SendDeleteAsync(this HttpClient target, string url)
    {
        var response = await target.DeleteAsync(url);

        response.EnsureSuccessStatusCode();
    }
}
