using Catalog.Application.Contracts.Persistence;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductsRepository : RepositoryBase<Product>, IProductsRepository
    {
        public ProductsRepository(ProductContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByBrand(int productBrandId)
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .Where(p => p.ProductBrandId == productBrandId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByType(int productTypeId)
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .Where(p => p.ProductTypeId == productTypeId)
                .ToListAsync();
        }
    }
}
