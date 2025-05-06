using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.OrderDtos;

namespace Presentation.Controllers;

[Authorize]
public class OrderController(IServiceManager serviceManager) : ApiControllerBase
{
    #region CreateOrder

    [HttpPost]
    public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto orderDto)
    {
        var order = await serviceManager.OrderService.CreateOrder(orderDto, GetEmailFromToken());
        return Ok(order);
    }

    #endregion

    #region Get Delivery Methods

    [AllowAnonymous]
    [HttpGet("DeliveryMethods")]
    public async Task<ActionResult<IEnumerable<DeliveryMethodDto>>> GetDeliveryMethods()
    {
        var deliveryMethods = await serviceManager.OrderService.GetDeliveryMethodsAsync();
        return Ok(deliveryMethods);

    }

    #endregion

    #region Get Orders By Email

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetOrdersByEmail()
    {
        var email = GetEmailFromToken();
        var orders = await serviceManager.OrderService.GetAllOrdersAsync(email);
        return Ok(orders);
    }

    #endregion

    #region Get Order By Id


    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderToReturnDto>> GetOrderById(Guid id)
    {
        var order = await serviceManager.OrderService.GetOrderById(id);
        return Ok(order);
    }

    #endregion
}
