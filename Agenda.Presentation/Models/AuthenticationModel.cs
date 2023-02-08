namespace Agenda.Presentation.Models
{
    /// <summary>
    /// modelo de dados para as informações do usuário autenticado
    /// que serão gravadas no Cookie de autentificação no AspNet
    /// </summary>
    public class AuthenticationModel
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataHoraAcesso { get; set; }
    }
}