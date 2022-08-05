using AutoMapper;

using CleanShop.Application.DTO;
using CleanShop.Application.Interfaces;
using CleanShop.Domain.Entities;
using CleanShop.Domain.Interfaces;

namespace CleanShop.Application.Services;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }


    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<CategoryDTO> GetCategoryById(int? id)
    {
        var categoryEntity = await _categoryRepository.GetCategoryAsync(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task Add(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.CreateCategoryAsync(categoryEntity);
    }

    public async Task Update(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.UpdateCategoryAsync(categoryEntity);
    }

    public async Task Delete(int? id)
    {
        var categoryEntity = _categoryRepository.GetCategoryAsync(id).Result;
        await _categoryRepository.DeleteCategoryAsync(categoryEntity);
    }
}

