using FluentAssertions;
using OrderApi.Domain;

namespace OrderApi.Tests.OrderService;

public class GetAllAsyncShould
{
    [Fact]
    public async Task Return_All_Orders()
    {
        // Arrange
        var service = new OrderApi.Application.OrderService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().ContainEquivalentOf(new Order(1, 1, 2));
        result.Should().ContainEquivalentOf(new Order(2, 2, 1));
    }

    [Fact]
    public async Task Return_Empty_WhenNoOrdersExist()
    {
        // Arrange
        var service = new OrderApi.Application.OrderService();
        var ordersField = typeof(OrderApi.Application.OrderService).GetField("_orders", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        ordersField.SetValue(service, new System.Collections.Generic.List<Order>());

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}
