using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject.IdentityModuleDto
{
    public class LoginDto
    {
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
