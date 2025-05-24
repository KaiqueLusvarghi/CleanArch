using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        // Definindo as assinaturas dos metodos que serão implementados
        Task<IEnumerable<Category>> GetCategories(); //retorna uma lista de categorias
        Task<Category> GetById(int? id); //retorna uma categoria pelo id
        Task Create(Category category); // cria uma categoria
        Task Update(Category category); //atualiza uma categoria
        Task Remove(Category category); //remove uma categoria

       //Task<bool> CategoryExists(int id); //verifica se a categoria existe
    }
}
