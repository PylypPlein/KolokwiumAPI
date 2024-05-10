using KolokwiumAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumAPI.Controllers;


[ApiController]
[Route("/api/")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("orders")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetOrder(int IdOrder)
    {
        var orders = _orderService.GetOrders(IdOrder);
        return Ok(orders);
    }
}