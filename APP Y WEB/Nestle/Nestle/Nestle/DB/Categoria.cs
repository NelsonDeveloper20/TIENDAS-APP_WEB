using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DB
{
  public  class Categoria
    {

        String connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
        public Int32 CountCategoria()
        {
            Int32 Count = 0;
            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CC_Count", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cnm.Open();
                Count = Convert.ToInt32(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Count;
        }
        public Int32 ListarHijos(Int32 IdCategoria)
        {
            Int32 idpadre = 0;
            using(SqlConnection cnm =new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cc_hijos", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCategoria", IdCategoria);
                cnm.Open();
                idpadre = Convert.ToInt32(cmd.ExecuteScalar());
                cnm.Close();
               
            }
            return idpadre;
        }

        //   String connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
        public DataTable ListarProducto(Int32 Id,String nombre)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("CC_LISTARProductos", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@Id", Id);
                adp.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
                adp.Fill(dt);
            }
            return dt;
        }

    
              public DataTable ListarProductoCategoriExsitente(Int32 Id,String nombre)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarProductoCategoriaExistente", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@id", Id);
                adp.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable listarCate()
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("SELECT c.IdCategoria AS MenuNumber,c.IdUp AS ParentNumber,c.Nombre AS MenuName,C.IdFabricante AS Uri, 'nn' AS Icon  FROM Categoria c", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(dt);

            }
            return dt;
        }
 
        public String InsertarCategorias(Int32 IdUp,String Nombre,String Image,Int32 UsuaCrea)
        {
            String Msj = "";

            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertarCategoria",cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idup", IdUp);
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@Imagen", Image);
                cmd.Parameters.AddWithValue("@UsuCrea", UsuaCrea);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
            }
            return Msj;

        }
        public DataTable obtnerIdup(Int32 IdCategoria)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("cc_obtenercategIdUp",connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                adp.Fill(dt);
            }
            return dt;
        }
        public String MenuMaster(Int32 IdUsuario,Int32 IdMasterMenu)
        {
            String Msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_UpdatMenuForm", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                cmd.Parameters.AddWithValue("@idtipoMaster", IdMasterMenu);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
            }
            return Msj;
        }
        public String NuevoCategoria(Int32 IdFabricante,String Nombre,String Imagen,Int32 Usuario)
        {
            String Msj = "";
            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarNuevaCategoria", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFabricante", IdFabricante);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Imagen", Imagen);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }

     
        public string ModificarCategoria(Int32 IdCategoria,String Nombre,String Imagen,Int32 IdUsuario)
        {
            String Msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_ModificarCateg", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Imagen", Imagen);
                cmd.Parameters.AddWithValue("@Usuario", IdUsuario);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }

        

        public String EliminarCategoria(Int32 iDcATEGORIA,Int32 Usuario)
        {
            String Msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_EliminarCategoria", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCtegoria", iDcATEGORIA);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }

        public DataTable ListarSubCategoria(Int32 IdDistribuidor)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("",connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("", IdDistribuidor);
                adp.Fill(dt);
            }
            return dt;
        }


    
       public string ModificarProductoCategoria(String IdTxt, Int32 IdCategoria,Int32 IdPadre, Int32 IdFabricante, Int32 usuario)
        {
            String Msj = "";
            try
            {
                using (SqlConnection cnm = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_Modif_ProductoCategoria", cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProductoTxt", IdTxt);
                    cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                    cmd.Parameters.AddWithValue("@IdCategoriaPadre", IdPadre);
                    cmd.Parameters.AddWithValue("@IdFabricante", IdFabricante);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cnm.Open();
                    Msj = Convert.ToString(cmd.ExecuteScalar());
                    cnm.Close();
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");

                Msj = builder.ToString();
                return Msj;
            }
            return Msj;
        }
        public string InsertarProductoCategoria(String IdTxt,Int32 IdCategoria,Int32 IdPadre, Int32 IdFabricante,Int32 usuario)
        {
            String Msj = "";
            try
            {
                using (SqlConnection cnm = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_Ins_ProductoCategoria", cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProductoTxt", IdTxt);
                    cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                    cmd.Parameters.AddWithValue("@IdCategoriaPadre", IdPadre);
                    cmd.Parameters.AddWithValue("@IdFabricante", IdFabricante);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cnm.Open();
                    Msj = Convert.ToString(cmd.ExecuteScalar());
                    cnm.Close();
                }
            }catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
             
                Msj ="sql "+ builder.ToString();
                return Msj;
            }
            return Msj;
        }
    }
}
