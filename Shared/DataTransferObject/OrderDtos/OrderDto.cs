using Shared.DataTransferObject.IdentityModuleDto;

namespace Shared.DataTransferObject.OrderDtos;

public class OrderDto
{
    public string BasketId { get; set; } = default!;
    public int DeliveryMethodId { get; set; }
    public AddressDto Address { get; set; } = default!;
}
