using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Contexts
{
    public static class BrandContextSeed
    {
        public static async Task SeedBrands(IMongoCollection<ProductBrand> brands)
        {
            var hasBrands = await brands.Find(_ => true).AnyAsync();

            if (hasBrands)
                return;
            var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "brands.json");

            if (!File.Exists(filePath))
                return;

            var brandData = await File.ReadAllTextAsync(filePath);
            var seedingbrands =  JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
            if(seedingbrands?.Any() is true)
            {
                await brands.InsertManyAsync(seedingbrands);
            }
        }
    }
}
