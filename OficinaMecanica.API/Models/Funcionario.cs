namespace OficinaMecanica.API.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Funcao { get; set; } = "Mecanico"; // Mecanico/Atendente etc.
        public bool Ativo { get; set; } = true;
    }
}
