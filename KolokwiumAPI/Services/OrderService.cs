using KolokwiumAPI.Models;
using KolokwiumAPI.Repositories;

namespace KolokwiumAPI.Services;

public interface IOrderService
{
    public IEnumerable<Order> GetOrders(int IdOrder);
}

public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public IEnumerable<Order> GetOrders(int IdOrder)
    {
        try
        {
            return _orderRepository.GetOrderDetails(IdOrder);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }
}