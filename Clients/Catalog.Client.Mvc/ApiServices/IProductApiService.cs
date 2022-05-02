using Catalog.Domain.Models.Response;

namespace Catalog.Client.Mvc.ApiServices
{
    public interface IProductApiService
    {
        Task<IEnumerable<ProductResponse>> GetProductsAsync();
    }
}
