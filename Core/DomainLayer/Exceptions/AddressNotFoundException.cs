namespace DomainLayer.Exceptions;

public sealed class AddressNotFoundException(string email) : NotFoundException($"Address not found for user with email: {email}")
{
}
