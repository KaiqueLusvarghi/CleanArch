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
        Task<IEnumerable<Product>> GetProductsByCategoryASync(int? categoryId); //retorna uma lista de produtos por categoria
        Task Create(Product product); //cria um produto
        Task Update(Product product); //atualiza um produto
        Task Remove(Product product); //remove um produto

        //Task<bool> ProductExists(int id); //verifica se o produto existe
    }
}
