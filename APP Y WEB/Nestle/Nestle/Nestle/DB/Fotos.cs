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
   public class Fotos
    {

      String Connection = ConfigurationManager.AppSettings["connectionString"].ToString();
        public DataTable ListarProductoFoto(Int32 IdDistribuidor,String nombre)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_ListarProductoImagen", Connection))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdDistriubuidor", IdDistribuidor);
                adp.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
                adp.Fill(dt);
            }
            return dt;
        }



    

        public String ModificarProductoImg(String IdTxt,String Image,Int32 Usuario,Int32 Distribuidor)
        {
            String Msj = "";

            using(SqlConnection cnm=new SqlConnection(Connection))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarImageProd", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProductoTxt", IdTxt);
                cmd.Parameters.AddWithValue("@Imagen", Image);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Distribuidor", Distribuidor);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }

            return Msj;
        }
    }
}
