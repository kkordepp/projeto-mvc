using System.ComponentModel.DataAnnotations;

namespace Agenda.Presentation.Models
{
    public class ContatosRelatorioModel
    {
        [Required(ErrorMessage = "Por favor, selecione o formato do relatório.")]
        public string Formato { get; set; }
    }
}