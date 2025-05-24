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
            DomainExcptionValidation.When(id < 0, "Invalid id, id must be greater than 0");
            ValidateDomaian(name, description, price, stock, image);

        }
        public void Update(string name, string description, decimal price, int stock, string image,int categoryId)
        {
            ValidateDomaian(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomaian(string name, string description, decimal price, int stock, string image)
        {
            DomainExcptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required");
            DomainExcptionValidation.When(name.Length < 3, "Invalid name, name must have at least 3 characters");
            DomainExcptionValidation.When(name.Length > 100, "Invalid name, name must have at most 100 characters");
            DomainExcptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, description is required");
            DomainExcptionValidation.When(description.Length < 5, "Invalid description, description must have at least 5 characters");
            DomainExcptionValidation.When(price < 0, "Invalid price, price must be greater than or equal to 0");
            DomainExcptionValidation.When(stock < 0, "Invalid stock, stock must be greater than or equal to 0");
            DomainExcptionValidation.When(image.Length > 250, "Invalid image, image must have at most 250 characters");
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
