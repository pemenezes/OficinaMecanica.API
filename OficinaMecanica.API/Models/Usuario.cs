namespace OficinaMecanica.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; } = "";
        public string Senha { get; set; } = ""; // para prova: texto puro. (em produção: hash)
        public string Nome { get; set; } = "";
        public string Perfil { get; set; } = "Atendente"; // Admin/Mecanico/Atendente
    }
}
