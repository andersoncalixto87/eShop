using eShop.Web.Models;
using eShop.Web.Services.Interfaces;
using System.Text.Json;

namespace eShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api/products/";
        private ProductViewModel productVM;
        private IEnumerable<ProductViewModel> productsVM;
        private readonly JsonSerializerOptions _options;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            var client = _clientFactory.CreateClient("ProdcutApi");

            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productsVM = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productsVM;
        }
        
        public async Task<ProductViewModel> FindProductById(int id)
        {
            var client = _clientFactory.CreateClient("ProdcutApi");

            using (var response = await client.GetAsync(apiEndpoint+id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productVM = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productVM;
        }

        public Task<ProductViewModel> CreateProdcut(ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
