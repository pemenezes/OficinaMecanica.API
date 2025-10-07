public class AuthService : ApiBase, IAuthService
{
    public AuthService(IHttpClientFactory f) : base(f) { }
    public Task<LoginResultDto?> LoginAsync(UsuarioLoginDto dto)
        => GetAsync<LoginResultDto>($"api/auth/login?login={Uri.EscapeDataString(dto.Login)}&senha={Uri.EscapeDataString(dto.Senha)}");
// ou POST: return PostAsync("api/auth/login", dto) com retorno desserializado; alinhe com a API do colega.
}
