namespace DomainLayer.orderModule;

public class ProductItemOrder
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = default!;
    public string PictureUrl { get; set; } = default!;
}
