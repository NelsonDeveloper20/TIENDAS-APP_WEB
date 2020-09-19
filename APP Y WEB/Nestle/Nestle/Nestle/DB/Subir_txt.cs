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
    public class Subir_txt
    {
        //String Connection = "Data Source=192.168.2.198;Initial Catalog=BD_NEL_R;User ID=jdextre;Pwd=bgyz0448";
        //  :) nelson
        string Connection = ConfigurationManager.AppSettings["connectionString"].ToString();
        public DataTable ListarFabricante()
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("CC_ListarFabricante", Connection))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable listarProductosCargados()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_listarProductosCargadosVendedor", Connection))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable listarProductosCargadosBodega()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_listarProductosCargadosBodega", Connection))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable ListarTipoUsuario()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarTipoUsuario", Connection))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable ListarTipoUsuario3()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarTipoUsuario2", Connection))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            return dt;
        }    

        public String insertarProducto(Int32 IdFabricante, Int32 TipoUsuario,  Int32 Usuario, Int32 Estado,DataTable DtProducto)
        {
            String Msj = "";
            try
            {
                using(SqlConnection cnm=new SqlConnection(Connection))
                {
                    SqlCommand cmd = new SqlCommand("SP_SubirProducto", cnm);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idfabricante", IdFabricante);
                    cmd.Parameters.AddWithValue("@idtipousuario", TipoUsuario);
                    cmd.Parameters.AddWithValue("@usuario", Usuario);
                    cmd.Parameters.AddWithValue("@estado", Estado);
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@ListaProducto", DtProducto);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    cnm.Open();
                    Msj = Convert.ToString(cmd.ExecuteScalar());
                    cnm.Close();
                }


            }
            catch (Exception ex)
            {


                //Msj = "Stock Sumado con el actual";
            }
         

            return Msj;
        }
        public String SubirProductoPrecioTipoCliente(Int32 IdTipoCliente,  Int32 IdUsuario, DataTable dtlist)
        {
            String Msj = "";
            try
            {
                using (SqlConnection cnm = new SqlConnection(Connection))
                {
                    SqlCommand cmd = new SqlCommand("SP_SubirClientePrecio", cnm);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTipoCliente", IdTipoCliente);
                    cmd.Parameters.AddWithValue("@idusuario", IdUsuario); 
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@List", dtlist);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    cnm.Open();
                    Msj = Convert.ToString(cmd.ExecuteScalar());
                    cnm.Close();
                }


            }
            catch (Exception ex)
            {


                //Msj = "Stock Sumado con el actual";
            }


            return Msj;
        }
        public DataTable ListarTipoUSuario()
        {
            DataTable DT = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("cc_ListarTipoUsuario", Connection))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(DT);

            }
            return DT;
        }
        //public string insertarProducto(String IdProcuto, Int32 IdFabricante, Int32 TipoUsuario, Int32 Stock, String NombreProducto,
        //    String Precio,String Imagen, Int32 Usuario,Int32 Estado)
        //{
        //    string ms = "nesl";
        //    using (SqlConnection cn = new SqlConnection(Connection))
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_SubirProducto", cn);
        //        cn.Open();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@idproductotxt", IdProcuto);
        //        cmd.Parameters.AddWithValue("@idfabricante", IdFabricante);
        //        cmd.Parameters.AddWithValue("@idtipousuario", TipoUsuario);
        //        cmd.Parameters.AddWithValue("@stockdisponible", Stock);
        //        cmd.Parameters.AddWithValue("@nombrepro", NombreProducto);
        //        cmd.Parameters.AddWithValue("@precio", Precio);
        //        cmd.Parameters.AddWithValue("@imagen", Imagen);
        //        cmd.Parameters.AddWithValue("@usuario", Usuario);
        //        cmd.Parameters.AddWithValue("@estado", Estado);
        //        cmd.ExecuteNonQuery();
        //        cn.Close();
        //    }
        //    return ms;
        //}
        public string UpdateProducto(Int32 IdDistribuidor, Int32 Usuario)
        {
            string ms = "";
            using (SqlConnection cn = new SqlConnection(Connection))
            {
                SqlCommand cmd = new SqlCommand("SP_CambiarEstadoProducto", cn);
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDistribuidor", IdDistribuidor);
                cmd.Parameters.AddWithValue("@IdUsuario", Usuario);
                cmd.ExecuteScalar();
                cn.Close();
            }
            return ms;
        }
        public string insertarRuta(String codcliente, String codempleado, String dias_visita,Int32 Usuario,Int32 Estado)
        {
            string ms = "";
            using (SqlConnection cn = new SqlConnection(Connection))
            {
                
                SqlCommand cmd = new SqlCommand("SP_SubirRuta", cn);
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigocliente", codcliente);
                cmd.Parameters.AddWithValue("@codigoempleado", codempleado);
                cmd.Parameters.AddWithValue("@diasvisita", dias_visita);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@estado", Estado);
               ms=Convert.ToString(cmd.ExecuteScalar());
                cn.Close();
            }
            return ms;
        }
        public String insertarRutaV2(Int32 IdUsuario, Int32 Estado, DataTable DtRuta)
        {
            String Msj = "";
            try
            {
                using (SqlConnection cnm = new SqlConnection(Connection))
                {
                    SqlCommand cmd = new SqlCommand("SP_SubirRutaV2", cnm);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@estado", Estado);
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@ListaRuta", DtRuta);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    cnm.Open();
                    Msj = Convert.ToString(cmd.ExecuteScalar());
                    cnm.Close();
                }


            }
            catch (Exception ex)
            {

            }

            return Msj;
        }
        public String CambiarEstadoStock(Int32 IdFabricante,Int32 Usuario)
        {
            String msj = "";
            using(SqlConnection cnm=new SqlConnection(Connection))
            {
                SqlCommand cmd = new SqlCommand("SP_cambioEstadoAlmacenStock", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFaricante", IdFabricante);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cnm.Open();
                msj = Convert.ToString(cmd.ExecuteScalar());
            }
            return msj;
        }
        public String CambiarEstadoRuta(Int32 IdDistribuidor, Int32 Usuario)
        {
            String msj = "";
            using (SqlConnection cnm = new SqlConnection(Connection))
            {
                SqlCommand cmd = new SqlCommand("Sp_CambiarEstadoRuta", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDistribuidor", IdDistribuidor);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cnm.Open();
                msj = Convert.ToString(cmd.ExecuteScalar());
            }
            return msj;
        }
        public String CambiarEstadoCliente(Int32 IdFabricante, Int32 Usuario)
        {
            String msj = "";
            using (SqlConnection cnm = new SqlConnection(Connection))
            {
                SqlCommand cmd = new SqlCommand("Sp_CambiarEstadoCliente", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDistribuidor", IdFabricante);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cnm.Open();
                msj = Convert.ToString(cmd.ExecuteScalar());
            }
            return msj;
        }
        //public string InsertarStock(String IdALmacen, String IdProductoTxt, Int32 Stock, Int32 Usuario, Int32 Estado,Int32 idfabricante)
        //{
        //    string ms = "";
        //    using (SqlConnection cn = new SqlConnection(Connection))
        //    {

        //        SqlCommand cmd = new SqlCommand("SP_SubirStock", cn);
        //        cn.Open();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@IdAlmacen", IdALmacen);
        //        cmd.Parameters.AddWithValue("@idproductotxt", IdProductoTxt);
        //        cmd.Parameters.AddWithValue("@stock", Stock);
        //        cmd.Parameters.AddWithValue("@Usuario", Usuario);
        //        cmd.Parameters.AddWithValue("@estado", Estado);
        //        cmd.Parameters.AddWithValue("@IdFabricante", idfabricante);
        //        ms = Convert.ToString(cmd.ExecuteScalar());
        //        cn.Close();
        //    }
        //    return ms;
        //}
        #region SUBIR TXT STOCK
  

        public String SubirStockAlmacen(Int32 IdUsuario,Int32 IdFabricante,Int32 Estado, DataTable DtListaAlmacen)
        {
            String Msj = "";  
            SqlConnection cn = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand();
            try
            {
               
                    SqlDataAdapter da = new SqlDataAdapter();
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_SiSumarOSubir";
                    cmd.Connection = cn;
                    cmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = IdUsuario;
                    cmd.Parameters.Add("@estado", SqlDbType.Int).Value = Estado;
                    cmd.Parameters.Add("@IdFabricante", SqlDbType.Int).Value = IdFabricante;
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@ListaAlmacen", DtListaAlmacen);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    Msj = Convert.ToString(cmd.ExecuteScalar());
                    cn.Close();
               

            }
            catch (Exception ex)
            {

              
                Msj = "Stock Sumado con el actual";
            }
            finally
            {
                cn.Close();
            }
           

            return Msj;
        }
        #endregion

        public string InsertarCliente(Int32 IdDistribuidor,String CodigoCliente,String Nombre,
            String Direccion,String CodigoCanal,String Tipo,String Parm1,String Param2,
            String Param3, String Param4, String Param5, String Param6, String Param7, String Param8, String Param9, Int32 Usuario,Int32 Estado)
        {
            string ms = "nesl";
            using (SqlConnection cn = new SqlConnection(Connection))
            {
                SqlCommand cmd = new SqlCommand("SP_SubirCliente", cn);
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddistribuidor", IdDistribuidor);
                cmd.Parameters.AddWithValue("@codigocliente", CodigoCliente);
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@direccion", Direccion);
                cmd.Parameters.AddWithValue("@codigocanal", CodigoCanal);
                cmd.Parameters.AddWithValue("@tipo", Tipo);
                cmd.Parameters.AddWithValue("@parametro1", Parm1);
                cmd.Parameters.AddWithValue("@parametro2", Param2);
                cmd.Parameters.AddWithValue("@parametro3", Param3);
                cmd.Parameters.AddWithValue("@parametro4", Param4);
                cmd.Parameters.AddWithValue("@parametro5", Param5);
                cmd.Parameters.AddWithValue("@parametro6", Param6);
                cmd.Parameters.AddWithValue("@parametro7", Param7);
                cmd.Parameters.AddWithValue("@parametro8", Param8);
                cmd.Parameters.AddWithValue("@parametro9", Param9);
                cmd.Parameters.AddWithValue("@usuario", Usuario);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            return ms;
        }
        public String Subir(Int32 IdPedido,String IdProducto,Int32 Cantidad,Int32 IdUsuario)
        {
            String Msj = "";
            using(SqlConnection cnm=new SqlConnection(Connection))
            {
                SqlCommand cmd = new SqlCommand("", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPedido", IdPedido);
                cmd.Parameters.AddWithValue("@Producto", IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Usuario", IdUsuario);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();

            }
            return Msj;
        }


        

    
    }
}
