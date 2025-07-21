using Microsoft.AspNetCore.Mvc;
using OrderApi.Application;
using OrderApi.Domain;

namespace OrderApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IEnumerable<Order>> GetAll() => await _orderService.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<Order?> GetById(int id) => await _orderService.GetByIdAsync(id);

    [HttpPost]
    public async Task<Order> Create(Order order) => await _orderService.CreateAsync(order);
}
