using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data.Contexts;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository, IBrandRepository, ITypeRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
             _context = context;
        }
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


        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Find(_ => true).ToListAsync();
        }  

        public async Task<IEnumerable<Product>> GetAllProductsByBrand(string name)
        {
            return await _context.Products.Find(p => p.Brand.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByName(string name)
        {
            return await _context.Products.Find(p => p.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

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

        public async Task<Product> GetProductById(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updatedProduct = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updatedProduct.IsAcknowledged && updatedProduct.ModifiedCount > 0;
        }


    }
}
