using Shared.DataTransferObject.OrderDtos;

namespace ServiceAbstraction;

public interface IOrderSerivce
{
    Task<OrderToReturnDto> CreateOrder(OrderDto orderDto, string Email);
    Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync();
    Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync(string Email);
    Task<OrderToReturnDto> GetOrderById(Guid id);
}
