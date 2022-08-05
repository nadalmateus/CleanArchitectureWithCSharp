using AutoMapper;

using CleanShop.Application.DTO;
using CleanShop.Application.Interfaces;
using CleanShop.Domain.Entities;
using CleanShop.Domain.Interfaces;

namespace CleanShop.Application.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper;
    }


    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productSEntity = await _productRepository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(productSEntity);
    }

    public async Task<ProductDTO> GetProductById(int? id)
    {
        var productEntity = await _productRepository.GetProductAsync(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task<ProductDTO> GetProductCategory(int? id)
    {
        var productEntity = await _productRepository.GetProductCategoryAsync(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task Add(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.CreateProductAsync(productEntity);
    }

    public async Task Update(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.UpdateProductAsync(productEntity);
    }
    public async Task Delete(int? id)
    {
        var productEntity = _productRepository.GetProductAsync(id).Result;
        await _productRepository.DeleteProductAsync(productEntity);
    }
}