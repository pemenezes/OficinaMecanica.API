namespace OficinaMecanica.API.Models
{
    public class Produto
    {
        public int Id { get; set; } // Chave Primária (PK)
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; } // Preço de venda
        public int QuantidadeEstoque { get; set; }
        public string Tipo { get; set; } // Ex: "Peça", "Serviço"

        // Chave estrangeira para Fornecedor (opcional, mas bom para estoque)
        public int? FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}