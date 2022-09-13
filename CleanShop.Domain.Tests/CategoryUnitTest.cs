using CleanShop.Domain.Entities;
using CleanShop.Domain.Validation;

namespace CleanShop.Domain.Tests;

public class CategoryUnitTest
{
    [Fact]
    public void CreateCategory_WithValidParameters_ResultObjectWithValidState()
    {
        Action action = () => new Category(1, "CategoryName");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateCategory_NegativeIdValue_DomainExceptionValidation()
    {
        Action action = () => new Category(-1, "CategoryName");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
    }

    [Fact]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, to short, minmum 3 characters");
    }

    [Fact]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, "");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
    }

    [Fact]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);
        action.Should().Throw<DomainExceptionValidation>();
    }
}