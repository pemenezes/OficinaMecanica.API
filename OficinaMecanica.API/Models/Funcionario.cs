namespace OficinaMecanica.API.Models
{
    public class Funcionario
    {
        public int Id { get; set; } // Chave Primária (PK)
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; } // Usado para o Login
        public string Senha { get; set; } // Usado para o Login
        public string Cargo { get; set; } // Ex: "Mecânico", "Gerente", "Recepcionista"

        // Lista de Agendamentos (Mecânico terá vários agendamentos)
        public List<Agendamento> Agendamentos { get; set; }
    }
}