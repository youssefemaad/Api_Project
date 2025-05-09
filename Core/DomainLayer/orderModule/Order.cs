using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Models;
using DomainLayer.Models.ProductModule;

namespace DomainLayer.orderModule;

public class Order : BaseEntity<Guid>
{
    public Order()
    {
    }
    public Order(string userEmail, OrderAddress address, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subtotal)
    {
        UserEmail = userEmail;
        Address = address;
        DeliveryMethod = deliveryMethod;
        Items = items;
        Subtotal = subtotal;
    }

    public string UserEmail { get; set; } = default!;
    public OrderAddress Address { get; set; } = default!;
    public DeliveryMethod DeliveryMethod { get; set; } = default!;
    public ICollection<OrderItem> Items { get; set; } = [];
    public decimal Subtotal { get; set; }

    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public int DeliveryMethodId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public decimal GetTotal() => Subtotal + DeliveryMethod.Price;
}
