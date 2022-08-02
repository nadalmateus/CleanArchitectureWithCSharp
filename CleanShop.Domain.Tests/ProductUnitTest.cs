using CleanShop.Domain.Entities;
using CleanShop.Domain.Validation;

namespace CleanShop.Domain.Tests;

public class ProductUnitTest
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 99.9m, 99, "image_url");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionValidation()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description", 99.9m, 99, "image_url");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
    }

    [Fact]
    public void CreateProduct_ShortNameValue_DomainExceptionValidation()
    {
        Action action = () => new Product(1, "Pr", "Product Description", 99.9m, 99, "image_url");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, to short, minmum 3 characters");
    }

    [Fact]
    public void CreateProduct_LongImageName_DomainExceptionValidation()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 99.9m, 99,
            "image_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_urlimage_url");
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image url, to long, maximun 250 characters");
    }

    [Fact]
    public void CreateProduct_WithNullImageName_DomainExceptionValidation()
    {
        Action action = () => new Product(1, "Pruduct Name", "Product Description", 99.9m, 99, null);
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_WithNullImageName_NoNullReferenceException()
    {
        Action action = () => new Product(1, "Pruduct Name", "Product Description", 99.9m, 99, null);
        action.Should().NotThrow<NullReferenceException>();
    }

    [Fact]
    public void CreateProduct_WithEmptyImageName_DomainExceptionValidation()
    {
        Action action = () => new Product(1, "Pruduct Name", "Product Description", 99.9m, 99, "");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Theory]
    [InlineData(-5)]
    public void CreateProduct_WithInvalidStockValue_DomainExceptionValidation(int value)
    {
        Action action = () => new Product(1, "Pruduct Name", "Product Description", 99.9m, value, "image_url");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Stock value");
    }
}