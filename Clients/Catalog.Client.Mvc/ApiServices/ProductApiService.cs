using Catalog.Domain.Models.Response;

namespace Catalog.Client.Mvc.ApiServices
{
    public class ProductApiService : IProductApiService
    {
        public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
        {
            var products = new List<ProductResponse>()
            {
                new ProductResponse() { Id = 1, Name = "Sample - 1", Description = "Sample product # 1", Price = 195.35m, ProductBrand = "Service", ProductType = "Boots" }
            };

            return await Task.FromResult(products);
        }
    }
}
