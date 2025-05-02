using Shared.DataTransferObject.IdentityModuleDto;

namespace ServiceAbstraction
{
    public interface IAuthenticationService
    {
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<bool> CheckEmailAsync(string Email);
        Task<AddressDto> GetCurrentUserAddressAsync(string Email);
        Task<AddressDto> UpdateCurrentUserAddressAsync(string email, AddressDto addressDto);
        Task<UserDto> GetCurrentUserAsync(string Email);
    }
}