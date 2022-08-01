using CleanShop.Domain.Entities;

namespace CleanShop.Domain.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductAsync(int? id);
    Task<Product> GetProductCategoryAsync(int? id);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<Product> DeleteProductAsync(Product product);
}