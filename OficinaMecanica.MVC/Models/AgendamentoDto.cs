public class AgendamentoDto
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime DataHora { get; set; }
    public string Servico { get; set; } = "";

    // opcional para a View
    public string? ClienteNome { get; set; }
}
