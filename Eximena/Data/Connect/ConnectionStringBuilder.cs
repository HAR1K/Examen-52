using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Eximena.Data.Connect
{
    internal class ConnectionStringBuilder
    {
        public static string Connection() 
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = "(local)",
                InitialCatalog = "Eximenna",
                IntegratedSecurity = true,
                TrustServerCertificate = true
            }.ConnectionString;
        }
    }
}
