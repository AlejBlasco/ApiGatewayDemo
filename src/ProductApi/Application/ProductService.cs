using ProductApi.Domain;

namespace ProductApi.Application;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new()
    {
        new Product(1, "Laptop", 999.99m),
        new Product(2, "Phone", 499.99m)
    };

    public Task<Product> CreateAsync(Product product)
    {
        _products.Add(product);
        return Task.FromResult(product);
    }

    public Task<IEnumerable<Product>> GetAllAsync() => Task.FromResult(_products.AsEnumerable());

    public Task<Product?> GetByIdAsync(int id) => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
}
