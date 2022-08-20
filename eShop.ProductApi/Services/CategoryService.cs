using AutoMapper;
using eShop.ProductApi.DTOs;
using eShop.ProductApi.Models;
using eShop.ProductApi.Repositories.Interfaces;
using eShop.ProductApi.Services.Interfaces;

namespace eShop.ProductApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task Add(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.Create(categoryEntity);
        categoryDTO.Id = categoryEntity.Id;            
    }

    public async Task<IEnumerable<CategoryDTO>> GetAll()
    {
        var categoryEntity = await _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity);
    }

    public async Task<CategoryDTO> GetById(int id)
    {
        var categoryEntity = await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task Remove(int id)
    {
        var categoryEntity = _categoryRepository.GetById(id).Result;
        await _categoryRepository.Delete(categoryEntity.Id);
    }

    public async Task Update(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.Update(categoryEntity);
    }
}
