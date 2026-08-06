using EventBus.Messages.Common;
using MassTransit;
using Microsoft.OpenApi;
using Order.Api.EventBusConsumer;
using Order.Application.DI;
using Order.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.

builder.Services.AddControllers();

// Register Swagger generation and endpoint explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "Order Api",
        Contact = new OpenApiContact
        {
            Email = "saadahmadpy@gmail.com",
            Name = "Saad Ahmed",

        },
        Description = "Order Api service in microservice ecommerce system .",
        Version = "V1"

    });


});

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1.0);
});

builder.Services.AddMassTransit(config =>
{
    //Mark this as consumer
    config.AddConsumer<BasketOrderingConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {

        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        //provide the queue name with consumer
        cfg.ReceiveEndpoint(EventBusConstant.BasketCheckoutQueue, c =>
        {
            c.ConfigureConsumer<BasketOrderingConsumer>(ctx);
        });
    });
});

// Register Clean Architecture Application & Infrastructure Services
builder.Services.AddApplicationServices();
builder.Services.AddInfraDI(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
