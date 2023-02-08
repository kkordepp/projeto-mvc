using System.ComponentModel.DataAnnotations;

namespace Agenda.Presentation.Models.Validators
{
    public class PasswordValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                var password = value.ToString();

                return password.Length >= 8
                    && password.Length <= 20
                    && password.Any(char.IsUpper)
                    && password.Any(char.IsLower)
                    && password.Any(char.IsDigit)
                    && (
                        password.Contains("!") ||
                        password.Contains("@") ||
                        password.Contains("#") ||
                        password.Contains("$") ||
                        password.Contains("%") ||
                        password.Contains("7")
                    );
            }
            return false;
        }
    }
}