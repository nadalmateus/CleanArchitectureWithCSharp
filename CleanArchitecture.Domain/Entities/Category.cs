namespace CleanArchitecture.Domain.Entities
{
    class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }
    }
}
