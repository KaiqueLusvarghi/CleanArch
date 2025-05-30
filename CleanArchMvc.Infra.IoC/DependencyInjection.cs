using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) // Método de extensão para adicionar serviços de infraestrutura
        {
         services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
        ,b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))); // Configura o contexto do banco de dados usando SQL Server e especifica a string de conexão e o assembly para migrações

            services.AddScoped<ICategoryRepository, CategoryRepository>(); // Registra o repositório de categorias como um serviço escopo
            services.AddScoped<IProductRepository, ProductRepository>(); // Registra o repositório de produtos como um serviço escopo

            return services; // Retorna a coleção de serviços para permitir encadeamento de chamadas
        }
    }
}
