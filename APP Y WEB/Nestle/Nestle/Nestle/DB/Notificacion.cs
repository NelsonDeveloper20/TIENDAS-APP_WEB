using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DB
{

  public  class Notificacion
    {

  String connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
    public DataTable ListarNotificacion(String titutlo)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("CC_ListarNotifiaciones", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@Titulo", titutlo);
                adp.Fill(dt);

            }
            return dt;
        }

        public Int32 InsertarNotificaciones(String Titutlo, String Descripcion,String Imagen, Int32 Usuario)
        {
            Int32  IdNotificacion =0;

            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CC_InsertarNotificacion", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@titulo", Titutlo);
                cmd.Parameters.AddWithValue("@descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@imagen", Imagen);
                cmd.Parameters.AddWithValue("@usuario", Usuario);
                cnm.Open();
                IdNotificacion = Convert.ToInt32(cmd.ExecuteScalar());
                cnm.Close();
            }
            return IdNotificacion;
        }
        public DataTable NotificacionXid(Int32 Id)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("cc_notificacionXid", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@id", Id);
                adp.Fill(dt);

            }
            return dt;

        }

        public String EnviarNotifi(Int32 idnotificacion,Int32 Idusuario)
        {
            String Msj = "";
            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EnviarNotificacion",cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", idnotificacion);
                cmd.Parameters.AddWithValue("@usumodifica", Idusuario);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }
    }
}
