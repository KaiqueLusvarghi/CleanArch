using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        // Definindo as assinaturas dos metodos que serão implementados
        Task<IEnumerable<Product>> GetProductsAsync(); //retorna uma lista de produtos
        Task<Product> GetByIdAsync(int? id); //retorna um produto pelo id
        Task<Product> GetProductsByCategoryASync(int? id); //retorna uma lista de produtos por categoria
        Task<Product> CreateAsync(Product product); //cria um produto
        Task<Product> UpdateAsync(Product product); //atualiza um produto
        Task<Product> RemoveAsync(Product product); //remove um produto

        //Task<bool> ProductExists(int id); //verifica se o produto existe
    }
}
