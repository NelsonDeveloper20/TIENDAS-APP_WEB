using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DB
{
 public   class Control_stock
    {

  String connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();

    public DataTable ListarStock(String nombre)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("CC_Stock", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@Producto", nombre);
                adp.Fill(dt);

            }
            return dt;
        }

    }
}
