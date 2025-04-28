namespace DomainLayer.Exceptions;

public sealed class BasketNotFoundException(string id): NotFoundException($"Basket With Id {id} is Not Found")
{
}
