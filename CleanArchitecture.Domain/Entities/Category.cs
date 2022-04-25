﻿using CleanArchitecture.Domain.Validations;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Category
    {
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id");
            Id = id;
            ValidateDomain(name);
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, 3 charecters is required");

            Name = name;
        }


    }
}