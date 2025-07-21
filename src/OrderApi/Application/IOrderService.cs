using OrderApi.Domain;

namespace OrderApi.Application;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();

    Task<Order?> GetByIdAsync(int id);

    Task<Order> CreateAsync(Order order);
}