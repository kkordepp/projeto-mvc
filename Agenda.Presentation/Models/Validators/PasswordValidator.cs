using System.ComponentModel.DataAnnotations;

namespace Agenda.Presentation.Models.Validators
{
    /// <summary>
    /// classe de validação customizada para campos de senha
    /// </summary>
    public class PasswordValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                // capturando o valor do campo que está sendo validado
                var password = value.ToString();

                return password.Length >= 8  // mínimo de caracteres
                    && password.Length <= 20 // máximo de caracteres
                    && password.Any(char.IsUpper) // pelo menos uma letra maiúscula
                    && password.Any(char.IsLower) // pelo menos uma letra minúscula
                    && password.Any(char.IsDigit) // pelo menos um digito numérico
                    && ( // pelo menos um dos caracteres especiais abaixo
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