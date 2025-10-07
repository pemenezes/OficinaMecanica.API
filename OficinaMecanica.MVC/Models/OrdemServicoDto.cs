public class OrdemServicoDto
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string Descricao { get; set; } = "";
    public bool Concluida { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime? DataConclusao { get; set; }

    // opcional para a View
    public string? ClienteNome { get; set; }
}
