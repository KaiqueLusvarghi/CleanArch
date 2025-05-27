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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category> // Configuração da entidade Category usando a interface IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
           builder.HasKey(t=> t.Id); // Define a chave primária da entidade Category como a propriedade Id
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired(); // Define a propriedade Name como obrigatória e com um tamanho máximo de 100 caracteres

            builder.HasData( // Popula a tabela Category com dados iniciais              
           
                new Category(1, "Material Escolar"), // Cria uma nova categoria com Id 1 e nome "Material Escolar"
                new Category(2, "Eletronicos"),  // Cria uma nova categoria com Id 2 e nome "Eletrônicos"
                new Category(3, "Acessórios")  // Cria uma nova categoria com Id 3 e nome "Acessórios"
            );       
        }
    }
}
