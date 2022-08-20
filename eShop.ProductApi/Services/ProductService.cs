using AutoMapper;
using eShop.ProductApi.DTOs;
using eShop.ProductApi.Models;
using eShop.ProductApi.Repositories.Interfaces;
using eShop.ProductApi.Services.Interfaces;

namespace eShop.ProductApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task Add(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.Create(productEntity);
        productDTO.Id = productEntity.Id;
    }

    public async Task<IEnumerable<ProductDTO>> GetAll()
    {
        var productEntity = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
    }

    public async Task<ProductDTO> GetById(int id)
    {
        var productEntity = await _productRepository.GetById(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task Remove(int id)
    {
        var productEntity = _productRepository.GetById(id).Result;
        await _productRepository.Delete(productEntity.Id);
    }

    public async Task Update(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.Update(productEntity);
    }
}
