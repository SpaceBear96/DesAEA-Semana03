using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso03
{
    class ClsDatos
    {
        public SqlConnection LeerCadena()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DAGI8KG\\AGUILAR;Initial Catalog=neptuno;Integrated Security=True");
            return connection;
        }
    }
}
