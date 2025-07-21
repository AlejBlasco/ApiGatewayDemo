using FluentAssertions;
using Moq;
using OrderApi.Application;
using OrderApi.Domain;
using OrderApi.Presentation.Controllers;

namespace OrderApi.Tests.OrderService
{
    public class GetByIdAsyncShould
    {
        [Fact]
        public async Task Return_Order_When_Order_Exists()
        {
            // Arrange
            var expectedOrder = new Order(1, 2, 3);
            var serviceMock = new Mock<IOrderService>();
            serviceMock.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(expectedOrder);
            var controller = new OrdersController(serviceMock.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedOrder);
        }

        [Fact]
        public async Task Return_Null_When_Order_Does_Not_Exist()
        {
            // Arrange
            var serviceMock = new Mock<IOrderService>();
            serviceMock.Setup(s => s.GetByIdAsync(99)).ReturnsAsync((Order?)null);
            var controller = new OrdersController(serviceMock.Object);

            // Act
            var result = await controller.GetById(99);

            // Assert
            result.Should().BeNull();
        }
    }
}
