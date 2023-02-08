using System.ComponentModel.DataAnnotations;

namespace Agenda.Presentation.Models
{
    public class AccountPasswordModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email de acesso.")]
        public string Email { get; set; }
    }
}