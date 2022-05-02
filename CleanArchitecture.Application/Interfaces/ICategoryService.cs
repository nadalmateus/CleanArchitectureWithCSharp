using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetCategoryByIdAync(int? id);
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task CreateCategoryAsync(CategoryDTO categoryDto);
        Task UpdateCategoryAsync(CategoryDTO categoryDto);
        Task DeleteCategoryAsync(int? id);
    }
}