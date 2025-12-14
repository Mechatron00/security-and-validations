using System.ComponentModel.DataAnnotations;

namespace security_and_validations.Models
{
    public class LoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }
    }
}
