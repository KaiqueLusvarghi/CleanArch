using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        ApplicationDbContext _categoryContext; // Declaração do contexto do banco de dados

        public CategoryRepository(ApplicationDbContext context) // Construtor que recebe o contexto do banco de dados
        {
            _categoryContext = context; // Inicializa o contexto do banco de dados

        }

        public async Task<Category> Create (Category category) // Método para criar uma nova categoria
        {
            _categoryContext.Add(category); // Adiciona a categoria ao contexto
            await _categoryContext.SaveChangesAsync(); // Salva as alterações no banco de dados
            return category; // Retorna a categoria criada
        }

        public async Task<Category> GetById(int? id) // Método para obter uma categoria pelo ID
        {
           return await _categoryContext.Categories.FindAsync(id); // Busca a categoria pelo ID no contexto
        }

        public async Task<IEnumerable<Category>> GetCategories() // Método para obter todas as categorias     
        {
           return await _categoryContext.Categories.ToListAsync(); // Retorna a lista de categorias do contexto
        }

        public async Task<Category> Remove(Category category) // Método para remover uma categoria
        {
          _categoryContext.Categories.Remove(category); // Remove a categoria do contexto
            await _categoryContext.SaveChangesAsync(); // Salva as alterações no banco de dados
            return category; // Retorna a categoria removida
        }

        public async Task<Category> Update(Category category) // Método para atualizar uma categoria
        {
            _categoryContext.Update(category); // Atualiza a categoria no contexto
            await _categoryContext.SaveChangesAsync(); // Salva as alterações no banco de dados
            return category;  // Salva as alterações no banco de dados e retorna a categoria atualizada

        }
    }
}
