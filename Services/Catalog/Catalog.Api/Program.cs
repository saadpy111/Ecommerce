using Catalog.Api.DependencyInjection;
using Catalog.Infrastructure.Data.Contexts;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ICatalogContext>();
    await BrandContextSeed.SeedBrands(context.Brands);
    await TypeContextSeed.SeedTypes(context.Types);
    await ProductContextSeed.SeedDataAsync(context.Products);
}
catch (Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while seeding the database.");
}

app.Run();
