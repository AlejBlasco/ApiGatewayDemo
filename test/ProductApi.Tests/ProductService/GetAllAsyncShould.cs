using FluentAssertions;
using ProductApi.Domain;

namespace ProductApi.Tests.ProductService;

public class GetAllAsyncShould
{
    [Fact]
    public async Task Return_All_Products()
    {
        // Arrange
        var service = new ProductApi.Application.ProductService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().ContainEquivalentOf(new Product(1, "Laptop", 999.99m));
        result.Should().ContainEquivalentOf(new Product(2, "Phone", 499.99m));
    }

    [Fact]
    public async Task Return_Empty_WhenNoProductsExist()
    {
        // Arrange
        var service = new ProductApi.Application.ProductService();
        var productsField = typeof(ProductApi.Application.ProductService).GetField("_products", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        productsField.SetValue(service, new List<Product>());

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}
