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
   public class SubPerfil
    {
        string connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
        public DataTable ListarSubPerfil(Int32 idUsuario)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CC_CSubPerfil";
                cmd.Connection = cn;
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                //cmd.Parameters.Add("@Ruc", SqlDbType.VarChar, 15).Value = Ruc;
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

        public DataTable ListarCliente()
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CCliente";
                cmd.Connection = cn;
                //cmd.Parameters.Add("@Ruc", SqlDbType.VarChar, 15).Value = Ruc;
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


        public DataTable ListarCanal()
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CCanal";
                cmd.Connection = cn;
                //cmd.Parameters.Add("@Ruc", SqlDbType.VarChar, 15).Value = Ruc;
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
