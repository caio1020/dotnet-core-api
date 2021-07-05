using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteApiCaio.Models;

namespace TesteApiCaio.Data.Config
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {              
            public void Configure(EntityTypeBuilder<Produto> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
                builder.Property(x => x.Quantidade).IsRequired();
                builder.Property(x => x.Preco).IsRequired();
                builder.Property(x => x.DataCadastro).IsRequired();
                builder.Property(x => x.DataAlteracao);
                   
            }
        
    }
}
