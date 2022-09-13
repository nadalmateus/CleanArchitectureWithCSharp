using CleanShop.Domain.Entities;
using CleanShop.Domain.Interfaces;
using CleanShop.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace CleanShop.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryAsync(int? id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        _context.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _context.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> DeleteCategoryAsync(Category category)
    {
        _context.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }
}