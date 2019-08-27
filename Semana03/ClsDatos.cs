using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace Semana03
{
    public class ClsDatos
    {
        public SqlConnection LeerCadena()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DAGI8KG\\AGUILAR;Initial Catalog=neptuno;Integrated Security=True");
            return connection;
        }
        public DataTable ListaPedidoFechas(DateTime x, DateTime y)
        {
            using (SqlConnection connection = LeerCadena())
            {
                SqlDataAdapter sqlData = new SqlDataAdapter("USP_FECHAFECHA", connection);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("@FEC1", x);
                sqlData.SelectCommand.Parameters.AddWithValue("@FEC2", y);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                return dataTable;
            }

        }

        public DataTable ListaDetalle(int x)
        {
            using (SqlConnection connection = LeerCadena())
            {
                SqlDataAdapter sqlData = new SqlDataAdapter("usp_detalle", connection);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("@IdPedido", x);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                return dataTable;
            }

        }

        public double PedidoTotal(Int32 idpedido)
        {
            using (SqlConnection connection = LeerCadena())
            {
                connection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("usp_total", connection);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("@IdPedido", idpedido);
                sqlData.SelectCommand.Parameters.Add("@Total", SqlDbType.Money).Direction =
                    ParameterDirection.Output;
                sqlData.SelectCommand.ExecuteScalar();
                Int32 total = Convert.ToInt32(sqlData.SelectCommand.Parameters["@Total"].Value);
                return total;
            }
        }

    }
}
