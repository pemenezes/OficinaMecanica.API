using System.Text;
using System.Text.Json;

public class ApiBase : IApiBase
{
    protected readonly HttpClient _http;
    protected readonly JsonSerializerOptions _json = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    public ApiBase(IHttpClientFactory factory) => _http = factory.CreateClient("ApiClient");

    public async Task<T?> GetAsync<T>(string url)
    {
        var r = await _http.GetAsync(url);
        if (!r.IsSuccessStatusCode) return default;
        return JsonSerializer.Deserialize<T>(await r.Content.ReadAsStringAsync(), _json);
    }

    public async Task<List<T>> GetListAsync<T>(string url)
        => await GetAsync<List<T>>(url) ?? new List<T>();

    public async Task<bool> PostAsync<T>(string url, T body)
    {
        var r = await _http.PostAsync(url, new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json"));
        return r.IsSuccessStatusCode;
    }

    public async Task<bool> PutAsync<T>(string url, T body)
    {
        var r = await _http.PutAsync(url, new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json"));
        return r.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(string url)
    {
        var r = await _http.DeleteAsync(url);
        return r.IsSuccessStatusCode;
    }
}
