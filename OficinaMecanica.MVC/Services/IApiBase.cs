public interface IApiBase
{
    Task<T?> GetAsync<T>(string url);
    Task<List<T>> GetListAsync<T>(string url);
    Task<bool> PostAsync<T>(string url, T body);
    Task<bool> PutAsync<T>(string url, T body);
    Task<bool> DeleteAsync(string url);
}
