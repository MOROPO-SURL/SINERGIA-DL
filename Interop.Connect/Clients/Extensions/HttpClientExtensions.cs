using System.Text.Json;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;

public static class HttpClientExtensions
{
    private const string CONTENT_TYPE = "application/json";

    private readonly static JsonSerializerOptions DEFAULT_JSON_SERIALIZER_OPTIONS = new()
    {
        PropertyNameCaseInsensitive = false,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static async Task<TResponse> SendGetAsync<TResponse>(this HttpClient target, string url)
    {
        var response = await target.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TResponse>(responseContent, DEFAULT_JSON_SERIALIZER_OPTIONS)!;
    }

    public static async Task SendPostAsync<TRequest>(this HttpClient target, string urlOrResource, TRequest request)
    {
        var content = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PostAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();
    }

    public static async Task<TResponse> SendPostAsync<TRequest, TResponse>(this HttpClient target, string urlOrResource, TRequest request)
    {
        var content = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PostAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        TResponse result = JsonSerializer.Deserialize<TResponse>(responseContent, DEFAULT_JSON_SERIALIZER_OPTIONS)!;

        return result;
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
        var content = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PutAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TResponse>(responseContent, DEFAULT_JSON_SERIALIZER_OPTIONS)!;
    }

    public static async Task SendPutAsync<TRequest>(this HttpClient target, string urlOrResource, TRequest request)
    {
        var content = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PutAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();
    }

    public static async Task SendPutAsync(this HttpClient target, string urlOrResource)
    {
        var content = new StringContent(string.Empty, System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PutAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();
    }

    public static async Task SendPathcAsync<TRequest>(this HttpClient target, string urlOrResource, TRequest request)
    {
        var content = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PatchAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();
    }

    public static async Task SendPatchAsync(this HttpClient target, string urlOrResource)
    {
        var content = new StringContent(string.Empty, System.Text.Encoding.UTF8, CONTENT_TYPE);

        var response = await target.PatchAsync(urlOrResource, content);

        response.EnsureSuccessStatusCode();
    }

    public static async Task SendDeleteAsync(this HttpClient target, string url)
    {
        var response = await target.DeleteAsync(url);

        response.EnsureSuccessStatusCode();
    }
}
