using FluentAssertions;
using ProductApi.Domain;

namespace ProductApi.Tests.ProductService;

public class GetByIdAsyncShould
{
    [Fact]
    public async Task Return_Product_When_Exists()
    {
        // Arrange
        var service = new ProductApi.Application.ProductService();
        var expected = new Product(1, "Laptop", 999.99m);

        // Act
        var result = await service.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task Return_Null_When_Product_Does_Not_Exist()
    {
        // Arrange
        var service = new ProductApi.Application.ProductService();

        // Act
        var result = await service.GetByIdAsync(99);

        // Assert
        result.Should().BeNull();
    }
}
