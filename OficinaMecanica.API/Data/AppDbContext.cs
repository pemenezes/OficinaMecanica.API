using Microsoft.EntityFrameworkCore;
using OficinaMecanica.API.Models;

namespace OficinaMecanica.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
        public DbSet<OrdemServico> OrdensServico => Set<OrdemServico>();
        public DbSet<Agendamento> Agendamentos => Set<Agendamento>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabelas simples para Oracle (sem schemas)
            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasColumnType("NUMBER(10,2)");

            // Seed (para a prova)
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Login = "admin", Senha = "123", Nome = "Administrador", Perfil = "Admin" },
                new Usuario { Id = 2, Login = "mec1",  Senha = "123", Nome = "Mecânico 1",  Perfil = "Mecanico" },
                new Usuario { Id = 3, Login = "aten1", Senha = "123", Nome = "Atendente 1", Perfil = "Atendente" }
            );

            modelBuilder.Entity<Funcionario>().HasData(
                new Funcionario { Id = 1, Nome = "Mecânico 1", Funcao = "Mecanico", Ativo = true },
                new Funcionario { Id = 2, Nome = "Mecânico 2", Funcao = "Mecanico", Ativo = true }
            );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nome = "João da Silva", Telefone = "1199999-9999", Email = "joao@ex.com" }
            );

            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, Nome = "Óleo 5W30", Preco = 79.90m, Estoque = 10, Sku = "OL-5W30" }
            );
        }
    }
}
