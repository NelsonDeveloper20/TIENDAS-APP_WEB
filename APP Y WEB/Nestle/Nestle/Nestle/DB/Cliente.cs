using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace DB
{
 public   class Cliente
    {
        
        String CN = ConfigurationManager.AppSettings["connectionString"].ToString();

       
        public DataTable ListarClientePedididoSugerido()
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("cc_ListarPedidoSugeridoCliente", CN))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            return dt;
        }

        public String ModificarClienteSugerido(String IdCliente, Double Monto,Int32 Idusuario)
        {
            String Msj = "";
            using(SqlConnection cnm=new SqlConnection(CN))
            {
                SqlCommand cmd = new SqlCommand("SP_ModificarPedidoSugeridoCliente", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmd.Parameters.AddWithValue("@Monto", Monto);
                cmd.Parameters.AddWithValue("@UsuCrea", Idusuario);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();

            }
            return Msj;
        }
        public String SubirPedidoSugeridoCliente(String IdCliente, Double Monto, Int32 Idusuario)
        {
            String Msj = "";
            using (SqlConnection cnm = new SqlConnection(CN))
            {
                SqlCommand cmd = new SqlCommand("SP_SubirPedidoSugeridoCliente", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmd.Parameters.AddWithValue("@Monto", Monto);
                cmd.Parameters.AddWithValue("@UsuCrea", Idusuario);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();

            }
            return Msj;
        }
        public String subiconciliacion(DataTable dtconciliacion)
        {
            String Msj = "";
            try
            {
                using (SqlConnection cnm = new SqlConnection(CN))
                {
                    SqlCommand cmd = new SqlCommand("CC_SubirConciliacionV2", cnm);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@List", dtconciliacion);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    cnm.Open();
                    cmd.CommandTimeout = 0;
                    Msj = Convert.ToString(cmd.ExecuteScalar());
                    cnm.Close();
                }


            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                Msj = builder.ToString();
            }


            return Msj;
        }

        public String SubirConciliacion(Int32 IdPedido,String IdProducto,Int32 Cantidad,Decimal Precio, Int32 IdUsuario)
        {
            String Msj = "";
         
                using (SqlConnection cnm = new SqlConnection(CN))
                {
                    SqlCommand cmd = new SqlCommand("CC_SubirConciliacion", cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idPedido", IdPedido);
                    cmd.Parameters.AddWithValue("@Producto", IdProducto);
                    cmd.Parameters.AddWithValue("@cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", Precio);
                    cmd.Parameters.AddWithValue("@Usuario", IdUsuario);
                    cnm.Open();
                    Msj = Convert.ToString(cmd.ExecuteScalar());
                    cnm.Close();

                }
        
            return Msj;

        }
        

            
    }
}
