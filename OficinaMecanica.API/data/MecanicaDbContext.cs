using Microsoft.EntityFrameworkCore;
using OficinaMecanica.API.Models; // Importa seus Models

public class MecanicaDbContext : DbContext
{
    // Construtor obrigatório para configurar a conexão
    public MecanicaDbContext(DbContextOptions<MecanicaDbContext> options)
        : base(options)
    {
    }

    // --- Mapeamento das Tabelas ---

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }

    // Entidades do Tema (Importantes para as regras de negócio)
    public DbSet<OrdemDeServico> OrdensDeServico { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }

    // Opcional: Aqui você pode usar o método OnModelCreating para configurar as chaves estrangeiras, 
    // mas o EF Core geralmente as infere automaticamente por convenção (ex: MecanicoId).
}