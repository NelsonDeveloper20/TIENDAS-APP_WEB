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
  public  class Producto
    {

        String connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
        public DataTable listarProductos(String Nombre)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_listarProductosMant", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@Nombre", Nombre);
                adp.Fill(dt);
            }
            return dt;
        }
        public String InsertarProducto(String IdProducto,String Nombre,String Descripcion,Int32 Stock,float Precio, Int32 IdUsuario)
        {
            String msj = "";
            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_insertarProducto", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproductotxt", IdProducto);
                cmd.Parameters.AddWithValue("@nombrepro", Nombre);
                cmd.Parameters.AddWithValue("@descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@precio", Precio);
                cmd.Parameters.AddWithValue("@stockdisponible", Stock);
                cmd.Parameters.AddWithValue("@usucrea", IdUsuario);
                cnm.Open();
                msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return msj;
        }
        public String ModificarProducto(Int32 IdProducto, String IdProductoTxt, String Nombre, String Descripcion, Int32 Stock, float Precio, Int32 IdUsuario)
        {
            String msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarProducto", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                cmd.Parameters.AddWithValue("@idproductotxt", IdProductoTxt);
                cmd.Parameters.AddWithValue("@nombrepro", Nombre);
                cmd.Parameters.AddWithValue("@descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@precio", Precio);
                cmd.Parameters.AddWithValue("@stockdisponible", Stock);
                cmd.Parameters.AddWithValue("@usucrea", IdUsuario);
                cnm.Open();
                msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return msj;
        }
        public String ElimianrProducto(Int32 IdProducto,Int32 IdUsuario)
        {
            String msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cp_EliminarProducto", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                cmd.Parameters.AddWithValue("@usucrea", IdUsuario);
                cnm.Open();
                msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return msj;
        }
        
    }
}
