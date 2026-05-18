using Discount.Api.DependencyInjection;
using Discount.Api.Services;
using Discount.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDiscountApiDependencyInjection(builder.Configuration);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DiscountDbContext>();

    await context.Database.MigrateAsync();

    await DiscountContextSeed.SeedAsync(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();


app.MapGrpcService<DiscountService>();

app.MapGet("/", () =>
{
    return "Communication with grpc endpoints must be made through a grpc client";
});

app.Run();
