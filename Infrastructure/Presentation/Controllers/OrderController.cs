using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.OrderDtos;

namespace Presentation.Controllers;

public class OrderController(IServiceManager serviceManager) : ApiControllerBase
{
    #region CreateOrder
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto orderDto)
    {
        var order = await serviceManager.OrderService.CreateOrder(orderDto, GetEmailFromToken());
        return Ok(order);
    }

    #endregion
}
