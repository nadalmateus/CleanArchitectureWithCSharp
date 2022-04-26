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
    }
}