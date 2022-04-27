using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categoryList = await _categoryContext.Categories.ToListAsync();
            return categoryList;
        }

        public async Task<Category> GetCategoryByIdAync(int? id)
        {
            var categoryByiD = await _categoryContext.Categories.FindAsync(id);
            return categoryByiD;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> DeleteCategoryAsync(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();

            return category;
        }
    }
}
