using Agenda.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Reports.Interfaces
{
    public interface IContatosReport
    {
        byte[] CreateReport(List<Contato> contatos, Usuario usuario);
    }
}