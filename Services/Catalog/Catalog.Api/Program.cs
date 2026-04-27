using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1" , new Microsoft.OpenApi.OpenApiInfo
    {
         Title = "Catalog Api",
          Contact = new  OpenApiContact 
          { 
               Email = "saadahmadpy@gmail.com",
                Name = "Saad Ahmed",
                 
          },
           Description =  "Catalog Api service in microservice ecommerce system .",
            Version = "V1"
        
    });
});
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
