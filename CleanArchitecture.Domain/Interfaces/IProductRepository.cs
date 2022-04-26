using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAync(int? id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Category> CreateProductAsync(Product product);
        Task<Category> UpdateProductAsync(Product product);
        Task<Category> DeleteProductAsync(Product product);
    }
}