using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category :Entity
    {
      
        public string Name { get; private set;}

        public Category(string name)
        {
          ValidationDomain(name);

        }
        public Category(int id , string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id, id must be greater than 0"); //Validando o id
            Id = id; //Atribuindo o id
            ValidationDomain(name); //Validando o nome
        }
        public void Update(string name)
        {
            ValidationDomain(name); //Validando o nome
        }
        public ICollection<Product> Products { get; set; } //Propriedade de navegação para o produto

        private void ValidationDomain(string name) //Método privado para validar o nome da categoria
        {
            //Aplicando a logica da validação !
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required"); //Validando se o nome é vazio ou nulo
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, name must have at least 3 characters"); //Validando se o nome tem menos de 3 caracteres
            DomainExceptionValidation.When(name.Length > 100, "Invalid name, name must have at most 100 characters"); //Validando se o nome tem mais de 100 caracteres
            Name = name; //Atribuindo o nome
        }
    }
}
