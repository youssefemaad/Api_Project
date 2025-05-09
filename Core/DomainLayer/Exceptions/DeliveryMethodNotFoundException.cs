namespace DomainLayer.Exceptions;

public sealed class DeliveryMethodNotFoundException(int deliveryMethodId)
    : NotFoundException($"Delivery method with id: {deliveryMethodId} was not found.")
{
}
