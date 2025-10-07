using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaMecanica.API.Models
{
    public class Agendamento
    {
        public int Id { get; set; } // Chave Primária (PK)

        // Campos essenciais para a regra de choque de horários
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }

        // --- Relacionamentos (Chaves Estrangeiras) ---

        // FK para Funcionário (o Mecânico)
        public int MecanicoId { get; set; }
        [ForeignKey("MecanicoId")]
        public Funcionario Mecanico { get; set; }

        // FK para Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string DescricaoServico { get; set; }
        public string Status { get; set; } // Ex: "Pendente", "Confirmado", "Cancelado"
    }
}