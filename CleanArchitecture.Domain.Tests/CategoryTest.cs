using System;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
    public class CategoryTest
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectWithValidState()
        {
            Action action = () => new Category(1, "Fake Category Name");
            action.Should().NotThrow<Validations.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_WithInvalidParameters_ResultObjectWithInvalidState()
        {
            Action action = () => new Category(-1, "Fake Category Name");
            action.Should().Throw<Validations.DomainExceptionValidation>().WithMessage("Invalid Id");
        }
        
        [Fact]
        public void CreateCategory_WithInvalidName_ResultObjectWithInvalidState()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<Validations.DomainExceptionValidation>().WithMessage("Invalid name, too short, 3 charecters is required");
        }
        [Fact]
        public void CreateCategory_WithNullName_ResultObjectWithInvalidState()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<Validations.DomainExceptionValidation>().WithMessage("Invalid name, name is required");
        }
    }
}