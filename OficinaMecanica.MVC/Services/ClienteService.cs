public class ClienteService : ApiBase, IClienteService
{
    public ClienteService(IHttpClientFactory f) : base(f) { }

    public Task<List<ClienteDto>> ListarAsync() => GetListAsync<ClienteDto>("api/cliente");
    public Task<ClienteDto?> ObterAsync(int id) => GetAsync<ClienteDto>($"api/cliente/{id}");
    public Task<bool> CriarAsync(ClienteDto dto) => PostAsync("api/cliente", dto);
    public Task<bool> AtualizarAsync(ClienteDto dto) => PutAsync($"api/cliente/{dto.Id}", dto);
    public Task<bool> ExcluirAsync(int id) => DeleteAsync($"api/cliente/{id}");
}
