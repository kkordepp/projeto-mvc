using System.ComponentModel.DataAnnotations;

namespace Agenda.Presentation.Models
{
    /// <summary>
    /// modelo de dados para a página de recuperação de senha do usuário
    /// </summary>
    public class AccountPasswordModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email de acesso.")]
        public string Email { get; set; }
    }
}