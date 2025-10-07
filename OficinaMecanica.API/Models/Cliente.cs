namespace OficinaMecanica.API.Models
{
    public class Cliente
    {
        public int Id { get; set; } // Chave Primária (PK)
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        // Opcional, mas útil: Lista de Agendamentos e Ordens de Serviço
        // public List<Agendamento> Agendamentos { get; set; }
        // public List<OrdemDeServico> OrdensDeServico { get; set; }
    }
}