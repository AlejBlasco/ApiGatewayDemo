using OrderApi.Domain;

namespace OrderApi.Application;

public class OrderService : IOrderService
{
    private readonly List<Order> _orders = new()
    {
        new Order(1, 1, 2),
        new Order(2, 2, 1)
    };

    public Task<IEnumerable<Order>> GetAllAsync() => Task.FromResult(_orders.AsEnumerable());

    public Task<Order?> GetByIdAsync(int id) => Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));

    public Task<Order> CreateAsync(Order order)
    {
        _orders.Add(order);
        return Task.FromResult(order);
    }
}