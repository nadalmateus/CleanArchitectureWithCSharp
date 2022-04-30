using AutoMapper;

using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Products.Queries;

using MediatR;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        //public async Task<ProductDTO> GetProductByIdAync(int? id)
        //{
        //    var productsEntity = await _productRepository.GetProductByIdAync(id);

        //    return _mapper.Map<ProductDTO>(productsEntity);
        //}

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            //var productsEntity = await _productRepository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        //public async Task CreateProductsAsync(ProductDTO productDTO)
        //{
        //    var productsEntity = _mapper.Map<Product>(productDTO);

        //    await _productRepository.CreateProductAsync(productsEntity);
        //}

        //public async Task UpdateProductsAsync(ProductDTO productDTO)
        //{
        //    var productsEntity = _mapper.Map<Product>(productDTO);

        //    await _productRepository.UpdateProductAsync(productsEntity);
        //}
        //public async Task DeleteProductsAsync(int? id)
        //{
        //    var productsEntity = _productRepository.GetProductByIdAync(id).Result;
        //    await _productRepository.DeleteProductAsync(productsEntity);
        //}
    }
}