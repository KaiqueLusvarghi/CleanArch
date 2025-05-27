using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<CleanArchMvc.Domain.Entities.Product> // Configuração da entidade Product usando a interface IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id); // Define a chave primária da entidade Product como a propriedade Id

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired(); // Define a propriedade Name como obrigatória e com um tamanho máximo de 100 caracteres
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired(); // Define a propriedade Description como obrigatória e com um tamanho máximo de 200 caracteres

            builder.Property(p=> p.Price).HasPrecision(10, 2); // Define a propriedade Price com precisão de 10 dígitos no total e 2 dígitos decimais

            builder.HasOne(e => e.Category).WithMany(e => e.Products)// Configura o relacionamento entre Product e Category, onde um Product pertence a uma Category e uma Category pode ter muitos Products
                .HasForeignKey(e => e.CategoryId); // chave estrangeira CategoryId na tabela Product que referencia a tabela Category
        }
    }
}
