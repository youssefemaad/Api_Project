using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Models;
using DomainLayer.Models.ProductModule;

namespace DomainLayer.orderModule;

public class Order : BaseEntity<Guid>
{
    public string UserEmail { get; set; } = default!;
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public OrderAddress Address { get; set; } = default!;
    public DeliveryMethod DeliveryMethod { get; set; } = default!;
    public int DeliveryMethodId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = [];
    public decimal Subtotal { get; set; }
    public decimal GetTotal() => Subtotal + DeliveryMethod.Price;

}
