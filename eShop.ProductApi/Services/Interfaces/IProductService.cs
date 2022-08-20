﻿using eShop.ProductApi.DTOs;

namespace eShop.ProductApi.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAll();
    Task<ProductDTO> GetById(int id);
    Task Add(ProductDTO productDTO);
    Task Update(ProductDTO productDTO);
    Task Remove(int id);
}
