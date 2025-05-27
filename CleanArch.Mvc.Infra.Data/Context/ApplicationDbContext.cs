using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // Construtor que recebe as opções de configuração do DbContext
        {
        }

        public DbSet<Category> Categories { get; set; } // DbSet para a entidade Category
        public DbSet<Product> Products { get; set; } // DbSet para a entidade Product

        protected override void OnModelCreating(ModelBuilder builder) // Método para configurar o modelo de dados
        {
          base.OnModelCreating(builder); // Chama o método base para garantir que a configuração padrão seja aplicada
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); // Aplica as configurações de entidade do assembly atual
        }

    }
}
