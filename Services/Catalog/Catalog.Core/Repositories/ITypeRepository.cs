using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Repositories
{
    public interface ITypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllTypes();
        Task<ProductType> GetTypeById(string id);
        Task<ProductType> CreateType(ProductType type);
        Task<bool> UpdateType(ProductType type);
        Task<bool> DeleteType(string id);
    }
}
