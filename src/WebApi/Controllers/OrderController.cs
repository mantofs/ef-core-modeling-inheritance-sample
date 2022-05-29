using Application.Orders.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

//[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;

    private readonly Guid customerId;

    private readonly OrderService orderService;

    public OrderController(ILogger<OrderController> logger,
                           OrderService orderService)
    {

        this.orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.customerId = new Guid("18e11884-d6fa-11ec-af5f-0242ac120002");
    }

    [HttpGet(Name = "Request")]
    public ActionResult Get()
    {
        var order = orderService.GetOrders();

        return Ok(order);
    }

    [HttpPost(Name = "Create")]
    public ActionResult Post()
    {
        orderService.CreateOrder(customerId);

        return Ok();

    }

    [HttpPut(Name = "Update")]
    public ActionResult Put([FromBody] Guid orderId)
    {

        orderService.UpdateItem(orderId);

        return Ok();

    }

    [HttpDelete(Name = "Remove")]
    public ActionResult Delete([FromQuery] Guid orderId)
    {

        orderService.RemoveItem(orderId);

        return Ok();

    }
}
