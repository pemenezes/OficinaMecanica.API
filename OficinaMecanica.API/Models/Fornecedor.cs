namespace OficinaMecanica.API.Models
{
    public class Fornecedor
    {
        public int Id { get; set; } // Chave Primária (PK)
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // public List<Produto> ProdutosFornecidos { get; set; }
    }
}