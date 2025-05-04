using Shared.DataTransferObject.OrderDtos;

namespace ServiceAbstraction;

public interface IOrderSerivce
{
    Task<OrderToReturnDto> CreateOrder(OrderDto orderDto, string Email);
}
