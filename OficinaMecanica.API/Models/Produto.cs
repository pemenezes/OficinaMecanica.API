namespace OficinaMecanica.API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string? Sku { get; set; }  // opcional
    }
}
