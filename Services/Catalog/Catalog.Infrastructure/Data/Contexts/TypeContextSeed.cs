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
    public static class TypeContextSeed
    {
        public static async Task SeedTypes(IMongoCollection<ProductType> TypeCollection)
        {
            var hasTypes = await TypeCollection.Find(_ => true).AnyAsync();

            if (hasTypes)
                return;

            var filePath = Path.Combine("Data", "SeedData", "types.json");

            if (!File.Exists(filePath))
                return;

            var Types = await File.ReadAllTextAsync(filePath);
            var seedingData = JsonSerializer.Deserialize<List<ProductType>>(Types);

            if(seedingData?.Any() is true)
            {
               await TypeCollection.InsertManyAsync(seedingData);
            }

        }
    }
}
