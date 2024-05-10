using KolokwiumAPI.Services;

namespace KolokwiumAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/")]
public class OrderController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("order")]
    public IActionResult GetOrder(int IdOrder)
    {
        var orders = _orderService.GetOrders(IdOrder);
        return Ok(orders);
    }
}