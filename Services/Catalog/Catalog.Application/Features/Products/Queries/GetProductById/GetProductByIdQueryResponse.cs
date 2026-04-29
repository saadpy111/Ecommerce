using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catalog.Application.Dtos;

namespace Catalog.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryResponse
    {
        public ProductDto Product { get; set; }
    }
}
