using eShop.Web.Models;

namespace eShop.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProducts();
        Task<ProductViewModel> FindProductById(int id);
        Task<ProductViewModel> CreateProdcut(ProductViewModel productViewModel);
        Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel);
        Task<bool> DeleteProduct(int id);
    }
}
