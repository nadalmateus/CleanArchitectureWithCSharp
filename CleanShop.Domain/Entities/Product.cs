using CleanShop.Domain.Validation;

namespace CleanShop.Domain.Entities;

public sealed class Product : BaseEntity
{

    public Product(string name, string description, decimal price, int stock, string image)
    {
        Validate(name, description, price, stock, image);
    }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(id < 0, "Invalid ID value");
        Id = id;
        Validate(name, description, price, stock, image);
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        Validate(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void Validate(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, to short, minmum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description.Description is required");
        DomainExceptionValidation.When(description.Length < 5, "Invalid name, to short, minmum 3 characters");

        DomainExceptionValidation.When(price < 0, "Invalid Price value");

        DomainExceptionValidation.When(stock < 0, "Invalid Stock value");

        DomainExceptionValidation.When(image.Length > 250, "Invalid image url, to long, maximun 250 characters");


        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }
}