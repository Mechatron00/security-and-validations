using System.ComponentModel.DataAnnotations;

namespace security_and_validations.Models
{
    public class VaultItem
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string SecretData { get; set; }

        public int OwnerId { get; set; }
    }
}
