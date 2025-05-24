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
            DomainExcptionValidation.When(id < 0, "Invalid id, id must be greater than 0");
        }
        public void Update(string name)
        {
            ValidationDomain(name);
        }
        public ICollection<Product> Products { get; set; }

        private void ValidationDomain(string name)
        {
            //Aplicando a logica da validação !
            DomainExcptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required");
            DomainExcptionValidation.When(name.Length < 3, "Invalid name, name must have at least 3 characters");
            DomainExcptionValidation.When(name.Length > 100, "Invalid name, name must have at most 100 characters");
            Name = name;
        }
    }
}
