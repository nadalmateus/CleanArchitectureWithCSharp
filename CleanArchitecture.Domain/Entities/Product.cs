﻿using CleanArchitecture.Domain.Validations;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            Validate(name, description, price, stock, image);
        }
        public Product(string name, string description, decimal price, int stock, string image)
        {
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
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");
            Name = name;

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 characters");
            Description = description;

            DomainExceptionValidation.When(price < 0, "Invalid price value");
            Price = price;

            DomainExceptionValidation.When(stock < 0, "Invalid stock value");
            Stock = stock;

            DomainExceptionValidation.When(image.Length > 250, "Invalid image name, too long, maximum 250 characters");
            Image = image;

        }
    }
}