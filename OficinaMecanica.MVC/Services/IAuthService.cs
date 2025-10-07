public interface IAuthService
{
    Task<LoginResultDto?> LoginAsync(UsuarioLoginDto dto);
}
