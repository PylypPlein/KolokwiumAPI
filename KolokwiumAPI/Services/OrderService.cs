using KolokwiumAPI.Dto;
using KolokwiumAPI.Models;
using KolokwiumAPI.Repositories;


namespace KolokwiumAPI.Services;

public interface IOrderService
{
    public IEnumerable<OrderDto> GetOrders(int IdOrder);
}

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public IEnumerable<OrderDto> GetOrders(int IdOrder)
    {
        return _orderRepository.GetOrderDetails(IdOrder);

    }
}