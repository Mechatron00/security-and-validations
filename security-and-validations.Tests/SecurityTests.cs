using security_and_validations.Models;
using System.ComponentModel.DataAnnotations;

namespace security_and_validations.Tests
{
    public class SecurityTests
    {
        [Fact]
        public void Invalid_Email_Should_Fail_Validation()
        {
            var model = new LoginRequest
            {
                Email = "bad-email",
                Password = "Password123"
            };

            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, results, true);

            Assert.False(valid);
        }
    }
}