using FluentAssertions;
using OrderApi.Domain;

namespace OrderApi.Tests.OrderService;

public class CreateAsyncShould
{
    [Fact]
    public async Task Add_Order_To_List()
    {
        // Arrange
        var service = new OrderApi.Application.OrderService();
        var newOrder = new Order(3, 5, 10);
        var ordersField = typeof(OrderApi.Application.OrderService).GetField("_orders", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var initialCount = ((List<Order>)ordersField.GetValue(service)).Count;

        // Act
        var result = await service.CreateAsync(newOrder);

        // Assert
        result.Should().BeEquivalentTo(newOrder);
        var orders = (List<Order>)ordersField.GetValue(service);
        orders.Should().ContainEquivalentOf(newOrder);
        orders.Count.Should().Be(initialCount + 1);
    }

    [Fact]
    public async Task Return_Order_With_Correct_Properties()
    {
        // Arrange
        var service = new OrderApi.Application.OrderService();
        var newOrder = new Order(10, 20, 30);

        // Act
        var result = await service.CreateAsync(newOrder);

        // Assert
        result.Id.Should().Be(10);
        result.ProductId.Should().Be(20);
        result.Quantity.Should().Be(30);
    }
}
