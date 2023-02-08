using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Data.Configurations
{
    public class SqlServerConfiguration
    {
        public static string GetConnectionString
            => @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDAgenda;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}