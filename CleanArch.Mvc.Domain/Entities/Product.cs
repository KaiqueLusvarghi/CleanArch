using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
      
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
         ValidateDomaian(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id, id must be greater than 0"); //Validando o id
            Id = id;
            ValidateDomaian(name, description, price, stock, image);

        }
        public void Update(string name, string description, decimal price, int stock, string image,int categoryId)
        {
            ValidateDomaian(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomaian(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required");//Validando se o nome é vazio ou nulo
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, name must have at least 3 characters"); //Validando se o nome tem menos de 3 caracteres
            DomainExceptionValidation.When(name.Length > 100, "Invalid name, name must have at most 100 characters"); //Validando se o nome tem mais de 100 caracteres
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, description is required"); //Validando se a descrição é vazia ou nula
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, description must have at least 5 characters"); //Validando se a descrição tem menos de 5 caracteres
            DomainExceptionValidation.When(price < 0, "Invalid price, price must be greater than or equal to 0");//Validando se o preço é menor que 0
            DomainExceptionValidation.When(stock < 0, "Invalid stock, stock must be greater than or equal to 0");//Validando se o estoque é menor que 0
            DomainExceptionValidation.When(image?.Length > 250, "Invalid image, image must have at most 250 characters");//Validando se a imagem tem mais de 250 caracteres
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public int CategoryId{ get;  set; }
        public Category Category { get;  set; }

    }
}
