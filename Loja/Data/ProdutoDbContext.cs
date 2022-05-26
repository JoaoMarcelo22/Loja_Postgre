using Loja.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
        {
        }
        public DbSet<Produto>Produtos{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var produto = modelBuilder.Entity<Produto>();
            produto.ToTable("tb_produto");
            produto.HasKey(x => x.Id);
            produto.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            produto.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            produto.Property(x => x.Categoria).HasColumnName("categoria");
            produto.Property(x => x.Preco).HasColumnName("preco");
        }
    }
}