using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DB
{
  public  class Ruta
    {
        String CN = ConfigurationManager.AppSettings["connectionString"].ToString(); 
        public DataTable listarRutaVendedor(String CodigoTXT,Int32 IdDia)
        { DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("cc_listardiasVisitaVendedor", CN))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@idVendedor", CodigoTXT);
                adp.SelectCommand.Parameters.AddWithValue("@IdVisita", IdDia);
                adp.Fill(dt);
            }
            return dt;
        }

    }
}
