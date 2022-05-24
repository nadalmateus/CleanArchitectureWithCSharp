using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAync(int? id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(Product product);
    }
}