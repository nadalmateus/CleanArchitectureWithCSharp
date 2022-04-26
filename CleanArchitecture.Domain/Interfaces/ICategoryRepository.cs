using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Product> GetCategoryByIdAync(int? id);
        Task<IEnumerable<Product>> GetCategoriesAsync();
        Task<Product> CreateCategoryAsync(Product category);
        Task<Product> UpdateCategoryAsync(Product category);
        Task<Product> DeleteCategoryAsync(Product category);
    }
}