using ProductApi.Application;
using ProductApi.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

// Configure endpoints
app.MapGet("/api/products", async (IProductService service) => await service.GetAllAsync());
app.MapGet("/api/products/{id}", async (IProductService service, int id) => await service.GetByIdAsync(id));
app.MapPost("/api/products", async (IProductService service, Product product) => await service.CreateAsync(product));

await app.RunAsync();
