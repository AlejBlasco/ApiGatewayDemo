using FluentAssertions;
using ProductApi.Domain;

namespace ProductApi.Tests.ProductService;

public class CreateAsyncShould
{
    [Fact]
    public async Task Add_Product_To_List()
    {
        // Arrange
        var service = new ProductApi.Application.ProductService();
        var newProduct = new Product(3, "Tablet", 299.99m);
        var productsField = typeof(ProductApi.Application.ProductService).GetField("_products", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var initialCount = ((List<Product>)productsField.GetValue(service)).Count;

        // Act
        var result = await service.CreateAsync(newProduct);

        // Assert
        result.Should().BeEquivalentTo(newProduct);
        var products = (List<Product>)productsField.GetValue(service);
        products.Should().ContainEquivalentOf(newProduct);
        products.Count.Should().Be(initialCount + 1);
    }

    [Fact]
    public async Task Return_Product_With_Correct_Properties()
    {
        // Arrange
        var service = new ProductApi.Application.ProductService();
        var newProduct = new Product(10, "Monitor", 150.00m);

        // Act
        var result = await service.CreateAsync(newProduct);

        // Assert
        result.Id.Should().Be(10);
        result.Name.Should().Be("Monitor");
        result.Price.Should().Be(150.00m);
    }
}
