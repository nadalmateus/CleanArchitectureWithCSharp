using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _productContext = applicationDbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAync(int? id)
        {
            return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteProductAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();

            return product;
        }
    }
}