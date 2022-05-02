using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductByIdAync(int? id);
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task CreateProductsAsync(ProductDTO productDTO);
        Task UpdateProductsAsync(ProductDTO productDTO);
        Task DeleteProductsAsync(int? id);
    }
}
