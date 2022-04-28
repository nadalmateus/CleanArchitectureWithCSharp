using AutoMapper;

using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> GetCategoryByIdAync(int? id)
        {
            var categoriesEntity = await _categoryRepository.GetCategoryByIdAync(id);

            return _mapper.Map<CategoryDTO>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task CreateCategoryAsync(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.CreateCategoryAsync(categoryEntity);
        }

        public async Task UpdateCategoryAsync(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateCategoryAsync(categoryEntity);
        }

        public async Task DeleteCategoryAsync(int? id)
        {
            var categoryEntity = _categoryRepository.GetCategoryByIdAync(id).Result;
            await _categoryRepository.DeleteCategoryAsync(categoryEntity);
        }
    }
}