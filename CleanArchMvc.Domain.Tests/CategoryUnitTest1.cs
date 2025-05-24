using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System.Collections.Generic;
using System.Xml.Linq;


namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact (DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name"); // Testando com id 1 e nome "Category Name"
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId() // Testando com id -1 e nome "Category Name"
        {
            Action action = () => new Category(-1, "Category Name ");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid id, id must be greater than 0"); // Passando a mensagem de erro esperada
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName() // Testando com id 1 e nome "Ca"
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid name, name must have at least 3 characters"); // Passando a mensagem de erro esperada
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, ""); // Testando com id 1 e nome vazio
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required"); // Passando a mensagem de erro esperada
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null); // Testando com id 1 e nome nulo
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>(); 
        }
    }
}
