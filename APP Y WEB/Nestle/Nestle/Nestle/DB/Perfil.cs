using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DB
{
   public class Perfil
    {
        string connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();

        public DataTable ListarPerfiles()
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CPerfil";
                cmd.Connection = cn;
                da.SelectCommand = cmd;
                da.Fill(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return dt;
        }
    }
}
