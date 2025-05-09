using DomainLayer.Models;

namespace DomainLayer.orderModule;

public class OrderItem : BaseEntity<int>
{
    public ProductItemOrder Product { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }   
}
