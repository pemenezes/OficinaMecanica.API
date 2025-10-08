using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaMecanica.API.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int? FuncionarioId { get; set; } // mecânico responsável (opcional)
        public string Descricao { get; set; } = "";
        public bool Concluida { get; set; }
        public DateTime DataAbertura { get; set; } = DateTime.Now;
        public DateTime? DataConclusao { get; set; }

        [ForeignKey("ClienteId")] public Cliente? Cliente { get; set; }
        [ForeignKey("FuncionarioId")] public Funcionario? Funcionario { get; set; }
    }
}
