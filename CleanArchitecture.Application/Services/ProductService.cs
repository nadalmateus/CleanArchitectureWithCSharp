using AutoMapper;

using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetProductByIdAync(int? id)
        {
            var productsEntity = await _productRepository.GetProductByIdAync(id);

            return _mapper.Map<ProductDTO>(productsEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsEntity = await _productRepository.GetProductsAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task CreateProductsAsync(ProductDTO productDTO)
        {
            var productsEntity = _mapper.Map<Product>(productDTO);

            await _productRepository.CreateProductAsync(productsEntity);
        }

        public async Task UpdateProductsAsync(ProductDTO productDTO)
        {
            var productsEntity = _mapper.Map<Product>(productDTO);

            await _productRepository.UpdateProductAsync(productsEntity);
        }
        public async Task DeleteProductsAsync(int? id)
        {
            var productsEntity = _productRepository.GetProductByIdAync(id).Result;
            await _productRepository.DeleteProductAsync(productsEntity);
        }
    }
}