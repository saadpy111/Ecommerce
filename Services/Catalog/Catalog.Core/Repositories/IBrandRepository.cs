using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<ProductBrand>> GetAllBrands();
        Task<ProductBrand> GetBrandById(string id);
        Task<ProductBrand> CreateBrand(ProductBrand brand);
        Task<bool> UpdateBrand(ProductBrand brand);
        Task<bool> DeleteBrand(string id);
    }
}
