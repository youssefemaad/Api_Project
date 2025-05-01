namespace DomainLayer.Exceptions;

public sealed class UnAuthorizedException(string msg = "Invalid Email Or Password") : Exception($"{msg}")
{
}
