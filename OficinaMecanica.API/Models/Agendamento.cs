using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaMecanica.API.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; } // mecânico
        public DateTime DataHora { get; set; }
        public string Servico { get; set; } = "";

        [ForeignKey("ClienteId")] public Cliente? Cliente { get; set; }
        [ForeignKey("FuncionarioId")] public Funcionario? Funcionario { get; set; }
    }
}
