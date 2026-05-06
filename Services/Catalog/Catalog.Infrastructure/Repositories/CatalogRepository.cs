using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using Catalog.Infrastructure.Data.Contexts;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Catalog.Infrastructure.Repositories
{
    public class CatalogRepository : IProductRepository, IBrandRepository, ITypeRepository
    {
        private readonly ICatalogContext _context;

        public CatalogRepository(ICatalogContext context)
        {
             _context = context;
        }


        #region Brands

        public async Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            return await _context.Brands.Find(_ => true).ToListAsync();
        }

        public async Task<ProductBrand> GetBrandById(string id)
        {
            return await _context.Brands.Find(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProductBrand> CreateBrand(ProductBrand brand)
        {
            await _context.Brands.InsertOneAsync(brand);
            return brand;
        }

        public async Task<bool> UpdateBrand(ProductBrand brand)
        {
            var updatedBrand = await _context.Brands.ReplaceOneAsync(b => b.Id == brand.Id, brand);
            return updatedBrand.IsAcknowledged && updatedBrand.ModifiedCount > 0;
        }

        public async Task<bool> DeleteBrand(string id)
        {
            var deletedBrand = await _context.Brands.DeleteOneAsync(b => b.Id == id);
            return deletedBrand.IsAcknowledged && deletedBrand.DeletedCount > 0;
        }

        #endregion

        #region Types
        public async Task<IEnumerable<ProductType>> GetAllTypes()
        {
            return await _context.Types.Find(_ => true).ToListAsync();
        }

        public async Task<ProductType> GetTypeById(string id)
        {
            return await _context.Types.Find(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProductType> CreateType(ProductType type)
        {
            await _context.Types.InsertOneAsync(type);
            return type;
        }

        public async Task<bool> UpdateType(ProductType type)
        {
            var updatedType = await _context.Types.ReplaceOneAsync(t => t.Id == type.Id, type);
            return updatedType.IsAcknowledged && updatedType.ModifiedCount > 0;
        }

        public async Task<bool> DeleteType(string id)
        {
            var deletedType = await _context.Types.DeleteOneAsync(t => t.Id == id);
            return deletedType.IsAcknowledged && deletedType.DeletedCount > 0;
        }
        #endregion




        #region Products
        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deletedProduct = await _context.Products.DeleteOneAsync(p => p.Id == id);
            return deletedProduct.IsAcknowledged && deletedProduct.DeletedCount > 0;
        }

        public async Task<Pagination<Product>> GetAllProducts(CatalogSpecParams  Params)
        {
            var query = _context.Products.AsQueryable();

            #region filter


            if (!string.IsNullOrEmpty(Params.Search))
            {
                var search = Params.Search.ToLower();

                query = query.Where(p =>
                    p.Name.ToLower().Contains(search) ||
                    p.Description.ToLower().Contains(search));
            }


            if (Params.BrandId != null)
                query = query.Where(p => p.Brand.Id == Params.BrandId);
            if (Params.TypeID != null)
                query = query.Where(p => p.Type.Id == Params.TypeID);


            #endregion

            var count = await query.CountAsync();

            query = query.Skip(Params.PageIndex * Params.PageSize - Params.PageSize);
            query = query.Take(Params.PageSize);




            if (!string.IsNullOrEmpty( Params.OrderBy))
            {
                switch(Params.OrderBy)
                {
                    case "priceDes": 
                       query = query.OrderByDescending(p => p.Price);
                        break;
                    case "priceAsc":
                        query = query.OrderBy(p => p.Price);
                        break;

                    default:
                        query = query.OrderBy(p => p.Name);
                        break;
                }
            }
           

            var products = await query.ToListAsync();
            
            var  hasNext = count > (Params.PageIndex * Params.PageSize);
            var hasPre = Params.PageIndex > 1 ? true : false;


            return new Pagination<Product>()
            {
                Data = products,
                HasPre = hasPre,
                HasNext = hasNext,
                PageIndex = Params.PageIndex,
                PageSize = Params.PageSize
            };
        }

        public async Task<IEnumerable<Product>> GetAllProductsByBrand(string name)
        {
            return await _context.Products.Find(p => p.Brand.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByName(string name)
        {
            return await _context.Products.Find(p => p.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updatedProduct = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updatedProduct.IsAcknowledged && updatedProduct.ModifiedCount > 0;
        }

        #endregion
    }
}