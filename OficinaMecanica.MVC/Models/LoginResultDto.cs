public class LoginResultDto
{
    public string Token { get; set; } = "";
    public string Nome { get; set; } = "";
    public string Perfil { get; set; } = ""; // Admin, Mecanico, Atendente...
}
