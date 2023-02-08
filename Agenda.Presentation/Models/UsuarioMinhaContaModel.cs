using Agenda.Presentation.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Presentation.Models
{
    public class UsuarioMinhaContaModel
    {
        [PasswordValidator(ErrorMessage = "Informe de 8 a 20 caracteres, com pelo menos uma letra maiúscula, " +
            "uma letra minúscula, e um caractere especial.")]
        [Required(ErrorMessage = "Por favor, informe sua nova senha.")]
        public string NovaSenha { get; set; }

        [Compare("NovaSenha", ErrorMessage = "As senhas não conferem, por favor verifique.")]
        [Required(ErrorMessage = "Por favor, confirme sua nova senha.")]
        public string NovaSenhaConfirmacao { get; set; }
    }
}