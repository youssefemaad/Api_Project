namespace Shared.DataTransferObject.OrderDtos;

public class DeliveryMethodDto
{
    public int Id { get; set; }
    public string ShortName { get; set; } = default!;
    public string DeliveryTime { get; set; } = default!;
    public decimal Price { get; set; }
    public string Description { get; set; } = default!;
}
