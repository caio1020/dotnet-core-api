using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteApiCaio.Data.Config;
using TesteApiCaio.Models;

namespace TesteApiCaio.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfig());

            modelBuilder.Entity<Produto>()
                .HasData(
                  new Produto { Id = 1, Nome = "Caderno", Preco = 7.50, Quantidade = 5, DataCadastro = DateTime.Now },
                  new Produto { Id = 2, Nome = "Caneta", Preco = 2.30, Quantidade = 5, DataCadastro = DateTime.Now });                
        }
    }
}
