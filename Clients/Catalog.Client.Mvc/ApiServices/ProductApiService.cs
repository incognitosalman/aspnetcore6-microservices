using Catalog.Domain.Models.Response;
using IdentityModel.Client;
using Newtonsoft.Json;
using System.Text.Json;

namespace Catalog.Client.Mvc.ApiServices
{
    public class ProductApiService : IProductApiService
    {
        public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
        {
            List<ProductResponse> products = new List<ProductResponse>();

            // 1. Get Token from IS
            var apiClientCredentials = new ClientCredentialsTokenRequest
            {
                Address = "https://localhost:5005/connect/token",
                ClientId = "CatalogClient",
                ClientSecret = "secret",
                Scope = "CatalogAPI"
            };

            var client = new HttpClient();
            var tokenRespponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);
            if(tokenRespponse.IsError)
            {
                return products;
            }

            // 2. Send Request to Protected API
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenRespponse.AccessToken);

            var response = await apiClient.GetAsync("https://localhost:5001/api/products");
            response.EnsureSuccessStatusCode();

            // 3. Deserialize the data to our Model 
            var content = await response.Content.ReadAsStringAsync();
            products = JsonConvert.DeserializeObject<List<ProductResponse>>(content);

            return products;
        }
    }
}
