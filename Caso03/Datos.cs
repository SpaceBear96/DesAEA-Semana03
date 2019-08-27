using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso03
{
    class Datos
    {
        ClsDatos cn = new ClsDatos();
        public SqlDataReader Listaclientes() {
            try {
                SqlConnection cn1 = cn.LeerCadena();
            }
        } 
    }
}
