using Microsoft.EntityFrameworkCore;
using Vize.API.Entities;

namespace Vize.API.Infra;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration _configuration;
    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Produto> Produto { get; set; }
    public DbSet<TipoProduto> TipoProduto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoProduto>().HasData(
                new TipoProduto { Id = 1, Nome = "Material", Chave = TipoProdutoEnum.Material },
                new TipoProduto { Id = 2, Nome = "Serviço", Chave = TipoProdutoEnum.Servico }
            );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Default"));
}
