using CleanArchitecture.Domain.Validations;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            Validate(name);
        }

        public Category(string name)
        {
            Validate(name);
        }

        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public void Update(string name)
        {
            Validate(name);
        }

        private void Validate(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");
            Name = name;
        }
    }
}