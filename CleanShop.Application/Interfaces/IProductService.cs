using CleanShop.Application.DTO;

namespace CleanShop.Application.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetProductById(int? id);
    Task<ProductDTO> GetProductCategory(int? id);
    Task Add(ProductDTO productDTO);
    Task Update(ProductDTO productDTO);
    Task Delete(int? id);
}