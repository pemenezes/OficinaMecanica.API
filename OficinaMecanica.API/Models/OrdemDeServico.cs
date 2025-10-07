namespace OficinaMecanica.API.Models
{
    public class OrdemDeServico
    {
        public int Id { get; set; } // Chave Primária (PK)
        public DateTime DataCriacao { get; set; }

        // Campo essencial para a regra de não-edição
        public string Status { get; set; } // Ex: "Aberta", "Em Andamento", "Concluída"

        public decimal ValorTotal { get; set; }
        public string Observacoes { get; set; }

        // --- Relacionamentos (Chaves Estrangeiras) ---

        // FK para Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // FK para o Funcionário que abriu a OS (opcional)
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        // Opcional, mas comum: Itens da OS (Muitos-para-Muitos ou Tabela Intermediária)
        // Por simplicidade, você pode usar uma lista de IDs ou uma tabela intermediária.
        // public List<OSItem> Itens { get; set; } 
    }
}