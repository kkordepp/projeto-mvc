﻿namespace Agenda.Presentation.Models
{
    public class AuthenticationModel
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataHoraAcesso { get; set; }
    }
}