using Agenda.Presentation.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Presentation.Models
{
    /// <summary>
    /// modelo de dados para a view de login
    /// </summary>
    public class AccountLoginModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor informe seu email de acesso.")]
        public string Email { get; set; }

        [PasswordValidator(ErrorMessage = "Senha inválida.")]
        [Required(ErrorMessage = "Por favor, informe sua senha de acesso.")]
        public string Senha { get; set; }
    }
}