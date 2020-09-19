using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace DB
{
  public  class Stock
    {

        String CN = ConfigurationManager.AppSettings["connectionString"].ToString();

        public String ModificarSotck(Int32 IdAlmacen,Int32 Stock,Int32 IdUsuario)
        {
            String Msj = "";
            using(SqlConnection cnm=new SqlConnection(CN))
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarStock", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlmacen", IdAlmacen);
                cmd.Parameters.AddWithValue("@Stock", Stock);
                cmd.Parameters.AddWithValue("@usuario", IdUsuario);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }
    }
}
