using CleanShop.Domain.Entities;
using CleanShop.Domain.Interfaces;
using CleanShop.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace CleanShop.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductAsync(int? id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> GetProductCategoryAsync(int? id)
    {
        return await _context.Products.Include(category => category.Category)
            .SingleOrDefaultAsync(product => product.Id == id);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        _context.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteProductAsync(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }
}