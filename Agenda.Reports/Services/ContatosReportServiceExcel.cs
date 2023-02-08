using Agenda.Data.Entities;
using Agenda.Reports.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Reports.Services
{
    public class ContatosReportServiceExcel : IContatosReport
    {
        public byte[] CreateReport(List<Contato> contatos, Usuario usuario)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excelPackage = new ExcelPackage())
            {
                var sheet = excelPackage.Workbook.Worksheets.Add("Contatos");

                sheet.Cells["A1"].Value = "Relatório de contatos";

                sheet.Cells["A3"].Value = "Nome do usuário:";
                sheet.Cells["B3"].Value = usuario.Nome;

                sheet.Cells["A4"].Value = "Email do usuário:";
                sheet.Cells["B4"].Value = usuario.Email;

                sheet.Cells["A5"].Value = "Data e Hora de geração:";
                sheet.Cells["B5"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                sheet.Cells["A7"].Value = "Nome do contato";
                sheet.Cells["B7"].Value = "Email do contato";
                sheet.Cells["C7"].Value = "Telefone do contato";
                sheet.Cells["D7"].Value = "Data de nascimento do contato";
                sheet.Cells["E7"].Value = "Tipo do contato";

                var linha = 8;
                foreach (var item in contatos)
                {
                    sheet.Cells[$"A{linha}"].Value = item.Nome;
                    sheet.Cells[$"B{linha}"].Value = item.Email;
                    sheet.Cells[$"C{linha}"].Value = item.Telefone;
                    sheet.Cells[$"D{linha}"].Value = item.DataNascimento.ToString("dd/MM/yyyy");
                    sheet.Cells[$"E{linha}"].Value = item.Tipo == 1 ? "Amigos" : item.Tipo == 2 ? "Trabalho" : item.Tipo == 3 ? "Família" : "Outros";

                    linha++;
                }

                sheet.Cells["A:E"].AutoFitColumns();

                return excelPackage.GetAsByteArray();
            }
        }
    }
}