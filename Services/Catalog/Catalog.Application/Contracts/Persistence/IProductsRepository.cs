using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Contracts.Persistence
{
    public interface IProductsRepository : IAsyncRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByBrand(int productBrandId);
        Task<IEnumerable<Product>> GetProductsByType(int productTypeId);
    }
}
