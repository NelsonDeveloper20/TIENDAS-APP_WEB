using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace DB
{
  public  class Pedido
    {
    // String connectionString = "Data Source=192.168.2.198;Initial Catalog=BD_NEL_R;User ID=jdextre;Pwd=bgyz0448";

     String connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
        public DataTable listarUsuario()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("ccListarUsuarios", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable listarUsuarioClientes(String CodigoVendedor)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("ccListarUsuariosClientesv2", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdVendedor", CodigoVendedor);
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable ListarPedido(String FecInicio,String FecFin,String idusuario)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("CC_ListarPedido", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@FechaInicio", FecInicio);
                adp.SelectCommand.Parameters.AddWithValue("@FechaFin", FecFin);
                adp.SelectCommand.Parameters.AddWithValue("@idusuario", idusuario);
                adp.Fill(dt);

            }
            return dt;
        }
        public Int32 UltimoCodigo()
        {
            Int32 ultimoCodigo = 0;
            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cc_UltimoCodigoExterno", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cnm.Open();
                ultimoCodigo = Convert.ToInt32(cmd.ExecuteScalar());
                cnm.Close();
            }
            return ultimoCodigo;
        }

        public DataTable ReporteVendedorDistribuidor(String FecInicio,  String idusuario)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("Rpt_ReporteVendedorVisistas", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@fecha", FecInicio);
                adp.SelectCommand.Parameters.AddWithValue("@idvendedor", idusuario);
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable ListarReporteVentaDistribuidor(String FecInicio, String FecFin,String IdVendedor)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_ReporteVentasDistribuidor", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@FechaInicio", FecInicio);
                adp.SelectCommand.Parameters.AddWithValue("@FechaFin", FecFin);
                adp.SelectCommand.Parameters.AddWithValue("@IdVendedor", IdVendedor);
                adp.Fill(dt);

            }
            return dt;
        }

        public DataTable ExporPedidoCabe(String FecInicio,String FecFin,Int32 IsUsuario,String idusuario,Int32 ConCodigo)
        {
            
                  DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarPedidoExport", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@FechaInicio", FecInicio);
                adp.SelectCommand.Parameters.AddWithValue("@FechaFin", FecFin);
                adp.SelectCommand.Parameters.AddWithValue("@usuario", IsUsuario);
                adp.SelectCommand.Parameters.AddWithValue("@idusuario", idusuario);
                adp.SelectCommand.Parameters.AddWithValue("@ConCodigo", ConCodigo);
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ExporPedidoDetalle(String FecInicio, String FecFin, Int32 IsUsuario,String idusuario)
        {

            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarPedidoDetalleExport", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@FechaInicio", FecInicio);
                adp.SelectCommand.Parameters.AddWithValue("@FechaFin", FecFin);
                adp.SelectCommand.Parameters.AddWithValue("@usuario", IsUsuario);
                adp.SelectCommand.Parameters.AddWithValue("@idusuario", idusuario);
                //adp.SelectCommand.Parameters.AddWithValue("@IdPedidos", IdPedidos);
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ExporPedidoDetalleXID(String IdPedidos)
        {

            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarPedidoDetalleExportXID", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdPedidos", IdPedidos);
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarPedido(Int32 IdPedido)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ObtenerCoordenada", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdPedido", IdPedido);
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable DetallePedidoXId(Int32 IdPedido)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarDatallePedido", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdPedido", IdPedido);
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListaVendedor()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_listaUser", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);

            }
            return dt;
        }
        public String UPCodigoExterno(Int32 IdPedido, Int32 codigoExterno,Int32 IdUsuario)
        {
            String Count = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_upCodigoExterno", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPedido", IdPedido);
                cmd.Parameters.AddWithValue("@codigoExterno", codigoExterno);
                cmd.Parameters.AddWithValue("@idusuario", IdUsuario);
                cnm.Open();
                Count = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();

            }
            return Count;
        }
 
    }
}
