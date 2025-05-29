using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    internal class ProductRepository : IProductRepository // Implementa a interface IProductRepository
    {
        ApplicationDbContext _productContext; // Contexto do banco de dados para acessar as entidades
        public ProductRepository(ApplicationDbContext context) // Construtor que recebe o contexto do banco de dados
        {
            _productContext = context; // Inicializa o contexto do banco de dados

        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product); // Adiciona o produto ao contexto do banco de dados
            await _productContext.SaveChangesAsync(); // Salva as alterações no banco de dados
            return product; // Retorna o produto criado

        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContext.Products.FindAsync(id); // Busca o produto pelo ID no contexto do banco de dados
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
           return await _productContext.Products.ToListAsync(); // Retorna a lista de produtos do contexto do banco de dados
        }

        public async Task<Product> GetProductsByCategoryASync(int? id) // Método para obter produtos filtrados por categoria
        {
            return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id); // Busca produtos pela categoria no contexto do banco de dados

        }

        public async Task<Product> RemoveAsync(Product product)
        {
           _productContext.Products.Remove(product); // Remove o produto do contexto do banco de dados
            await _productContext.SaveChangesAsync(); // Salva as alterações no banco de dados
            return product; // Retorna o produto removido
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product); // Atualiza o produto no contexto do banco de dados
            await _productContext.SaveChangesAsync();
            return product;// Salva as alterações no banco de dados
        }
    }
}
