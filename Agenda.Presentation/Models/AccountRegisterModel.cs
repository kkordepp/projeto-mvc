using Agenda.Presentation.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Presentation.Models
{
    /// <summary>
    /// modelo de dados para capturar os campos do formulário de cadastro do usuário
    /// </summary>
    public class AccountRegisterModel
    {
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,150}$",
            ErrorMessage = "Por favor, informe um nome válido de 6 a 150 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe seu nome.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email.")]
        public string Email { get; set; }

        [PasswordValidator(ErrorMessage = "Informe de 8 a 20 caracteres, com pelo menos uma letra maiúscula, " +
            "uma letra minúscula, e um caractere especial.")]
        [Required(ErrorMessage = "Por favor, informe sua senha.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem, por favor verifique.")]
        [Required(ErrorMessage = "Por favor, confirme sua senha.")]
        public string SenhaConfirmacao { get; set; }
    }
}