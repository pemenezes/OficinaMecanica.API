public interface IClienteService
{
    Task<List<ClienteDto>> ListarAsync();
    Task<ClienteDto?> ObterAsync(int id);
    Task<bool> CriarAsync(ClienteDto dto);
    Task<bool> AtualizarAsync(ClienteDto dto);
    Task<bool> ExcluirAsync(int id);
}
