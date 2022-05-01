using Catalog.Domain.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<List<ProductResponse>>
    {
        public int ProductTypeId { get; set; }

        public GetProductsListQuery(int productTypeId)
        {
            ProductTypeId = productTypeId;
        }
    }
}
