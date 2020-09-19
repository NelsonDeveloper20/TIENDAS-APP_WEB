using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WSTiendaDelcorp.Models;

namespace WSTiendaDelcorp
{
    public class Db
    {
        string connectionString = ConfigurationManager.AppSettings["CN"].ToString();


        public ParametrosSalida InsertaVisita(String IdCliente, String IdVendedor)
        {
            String flag = "", mensaje = "";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                //cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_InsertaVisita";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@IdVendedor", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                cmd.Parameters["@IdCliente"].Value = IdCliente;
                cmd.Parameters["@IdVendedor"].Value = IdVendedor;

                cn.Open();
                cmd.ExecuteNonQuery();

                flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return new ParametrosSalida(flag, mensaje);
        }
        public ParametrosSalida cancelaPedidoComp(String IdUsuario, String IdPedido)
        {
            String flag = "", mensaje = "";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                //cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_CancelaPedidoComp";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@IdPedido", SqlDbType.Int);
                cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                cmd.Parameters["@IdUsuario"].Value = IdUsuario;
                cmd.Parameters["@IdPedido"].Value = IdPedido;

                cn.Open();
                cmd.ExecuteNonQuery();

                flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return new ParametrosSalida(flag, mensaje);
        }
        public ParametrosSalida ObtenDatos(String IdUsuario)
        {
            String flag = "", mensaje = "", Nombre = "", Paterno = "", Materno = "", Celular = "", Telefono = "", dni = "",
            ruc = "", RazonSocial = "", Direccion = "", Correo = "";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                //cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_ObtenDatos";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Paterno", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Materno", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@dni", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ruc", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                cmd.Parameters["@IdUsuario"].Value = IdUsuario;

                cn.Open();
                cmd.ExecuteNonQuery();

                flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                Nombre = cmd.Parameters["@Nombre"].Value.ToString();
                Paterno = cmd.Parameters["@Paterno"].Value.ToString();
                Materno = cmd.Parameters["@Materno"].Value.ToString();
                Celular = cmd.Parameters["@Celular"].Value.ToString();
                Telefono = cmd.Parameters["@Telefono"].Value.ToString();
                dni = cmd.Parameters["@dni"].Value.ToString();
                ruc = cmd.Parameters["@ruc"].Value.ToString();
                RazonSocial = cmd.Parameters["@RazonSocial"].Value.ToString();
                Direccion = cmd.Parameters["@Direccion"].Value.ToString();
                Correo = cmd.Parameters["@Correo"].Value.ToString();
            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return new ParametrosSalida(flag, mensaje, Nombre, Paterno, Materno, Celular, Telefono, dni, ruc, RazonSocial, Direccion, Correo);
        }
        public ParametrosSalida modificaDatos(String CodigoTxt, String Nombre, String Paterno, String Materno, String Celular, String Telefono
                                            , String dni, String ruc, String RazonSocial, String Direccion, String Correo)
        {
            String flag = "", mensaje = "";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                //cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_ModificaDatos";
                cmd.Connection = cn;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@Paterno", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Materno", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@dni", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@ruc", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 200);
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 500);
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 200);
                cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                cmd.Parameters["@CodigoTxt"].Value = CodigoTxt;
                cmd.Parameters["@Nombre"].Value = Nombre;
                cmd.Parameters["@Paterno"].Value = Paterno;
                cmd.Parameters["@Materno"].Value = Materno;
                cmd.Parameters["@Celular"].Value = Celular;
                cmd.Parameters["@Telefono"].Value = Telefono;
                cmd.Parameters["@dni"].Value = dni;
                cmd.Parameters["@ruc"].Value = ruc;
                cmd.Parameters["@RazonSocial"].Value = RazonSocial;
                cmd.Parameters["@Direccion"].Value = Direccion;
                cmd.Parameters["@Correo"].Value = Correo;

                cn.Open();
                cmd.ExecuteNonQuery();

                flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return new ParametrosSalida(flag, mensaje);
        }
        public ParametrosSalida ValidaUsuario(String Usuario, String Clave, String token)
        {

            String flag = "", mensaje = "", idUsuario = "", nombre = "", idTipoUsuario = "", idTipoAcceso = "", CodigoTxt = "";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                //cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_ValidaUsuario";
                cmd.Connection = cn;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 6);
                cmd.Parameters.Add("@token", SqlDbType.VarChar, 500);
                cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IdTipoUsu", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IdTipoAcc", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters["@Usuario"].Value = Usuario;
                cmd.Parameters["@Clave"].Value = Clave;
                cmd.Parameters["@token"].Value = token;

                cn.Open();
                cmd.ExecuteNonQuery();

                flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                idUsuario = cmd.Parameters["@idUsuario"].Value.ToString();
                CodigoTxt = cmd.Parameters["@CodigoTxt"].Value.ToString();
                nombre = cmd.Parameters["@Nombre"].Value.ToString();
                idTipoUsuario = cmd.Parameters["@IdTipoUsu"].Value.ToString();
                idTipoAcceso = cmd.Parameters["@IdTipoAcc"].Value.ToString();
            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return new ParametrosSalida(flag, mensaje, idUsuario, CodigoTxt, nombre, idTipoUsuario, idTipoAcceso);
        }
        public ParametrosSalida ValidaUsuariov2(String Usuario, String Clave, String token)
        {

            String flag = "", mensaje = "", idUsuario = "", nombre = "", idTipoUsuario = "", idTipoAcceso = "", CodigoTxt = "", tokencerrar = "", FlagValidaDatos = "";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                //cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_ValidaUsuario2";
                cmd.Connection = cn;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 6);
                cmd.Parameters.Add("@token", SqlDbType.VarChar, 500);
                cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IdTipoUsu", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IdTipoAcc", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@tokenCerrarSesion", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@FlagValidaDatos", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters["@Usuario"].Value = Usuario;
                cmd.Parameters["@Clave"].Value = Clave;
                cmd.Parameters["@token"].Value = token;

                cn.Open();
                cmd.ExecuteNonQuery();

                flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                idUsuario = cmd.Parameters["@idUsuario"].Value.ToString();
                CodigoTxt = cmd.Parameters["@CodigoTxt"].Value.ToString();
                nombre = cmd.Parameters["@Nombre"].Value.ToString();
                idTipoUsuario = cmd.Parameters["@IdTipoUsu"].Value.ToString();
                idTipoAcceso = cmd.Parameters["@IdTipoAcc"].Value.ToString();
                tokencerrar = cmd.Parameters["@tokenCerrarSesion"].Value.ToString();
                FlagValidaDatos = cmd.Parameters["@FlagValidaDatos"].Value.ToString();
            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return new ParametrosSalida(flag, mensaje, idUsuario, CodigoTxt, nombre, idTipoUsuario, idTipoAcceso, tokencerrar, FlagValidaDatos);
        }


        public ParametrosSalida obtenDatosVendedor(String Usuario)
        {

            String flag = "", mensaje = "", nombre = "", celular = "";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                //cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_obtenDatosVendedor";
                cmd.Connection = cn;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@celular", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters["@Usuario"].Value = Usuario;

                cn.Open();
                cmd.ExecuteNonQuery();

                flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                nombre = cmd.Parameters["@nombre"].Value.ToString();
                celular = cmd.Parameters["@celular"].Value.ToString();
            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return new ParametrosSalida(flag, mensaje, nombre, celular);
        }


        public ParametrosSalida cerrarSesion(String Usuario, String token)
        {

            String flag = "", mensaje = "";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                //cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_CerrarSesion";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@token", SqlDbType.VarChar, 500);
                cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                cmd.Parameters["@IdUsuario"].Value = Usuario;
                cmd.Parameters["@token"].Value = token;

                cn.Open();
                cmd.ExecuteNonQuery();

                flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return new ParametrosSalida(flag, mensaje);
        }
        public ParametrosSalida ReporteEficiencia(String IdUsuario)
        {

            String flag = "", mensaje = "", totalClientes = "", clienteVisitados = "", clientesConPedidos = "", totalPedidos = ""
                , totalPedidosBodega = "", avanceRuta = "", MontoTotalVenta = "", totalItems = ""
                , clienteUltimoPedido = "", fechaUltimoPedido = "";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {

                //cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ReporteEficiencia";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@totalClientes", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@clienteVisitados", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@clientesConPedidos", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@totalPedidos", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@totalPedidosBodega", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@avanceRuta", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MontoTotalVenta", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@totalItems", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@clienteUltimoPedido", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@fechaUltimoPedido", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                cmd.Parameters["@IdUsuario"].Value = IdUsuario;

                cn.Open();
                cmd.ExecuteNonQuery();

                flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                totalClientes = cmd.Parameters["@totalClientes"].Value.ToString();
                clienteVisitados = cmd.Parameters["@clienteVisitados"].Value.ToString();
                clientesConPedidos = cmd.Parameters["@clientesConPedidos"].Value.ToString();
                totalPedidos = cmd.Parameters["@totalPedidos"].Value.ToString();
                totalPedidosBodega = cmd.Parameters["@totalPedidosBodega"].Value.ToString();
                avanceRuta = cmd.Parameters["@avanceRuta"].Value.ToString();
                MontoTotalVenta = cmd.Parameters["@MontoTotalVenta"].Value.ToString();
                totalItems = cmd.Parameters["@totalItems"].Value.ToString();
                clienteUltimoPedido = cmd.Parameters["@clienteUltimoPedido"].Value.ToString();
                fechaUltimoPedido = cmd.Parameters["@fechaUltimoPedido"].Value.ToString();
            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return new ParametrosSalida(flag, mensaje, totalClientes, clienteVisitados, clientesConPedidos, totalPedidos
                , totalPedidosBodega, avanceRuta, MontoTotalVenta, totalItems, clienteUltimoPedido, fechaUltimoPedido);
        }

        /***************************************************************************************************************/



        public ParametrosSalida InsertarPedido(String IdUsuario,
                                    String CodigoTxt,
                                    Int32 IdCondicionVenta,
                                    String IdUsuarioVenta,
                                    String TotalPagar,
                                    Int32 Items,
                                    String Latitud,
                                    String Longitud,
                                    Int32 FlagTipoRegistro,
                                    String Fecha,
                                    DataTable dt
                                   )
        {
            String flag = "", mensaje = "", IdPedido = "";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            int IdOrdenes = 0;
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_InsertaPedido";
                cmd.Connection = cn;


                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = IdUsuario;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
                cmd.Parameters.Add("@IdCondicionVenta", SqlDbType.Int).Value = IdCondicionVenta;
                cmd.Parameters.Add("@IdUsuarioVenta", SqlDbType.VarChar, 50).Value = IdUsuarioVenta;
                cmd.Parameters.Add("@TotalPagar", SqlDbType.VarChar, 50).Value = TotalPagar;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Items;
                cmd.Parameters.Add("@Latitud", SqlDbType.VarChar, 100).Value = Latitud;
                cmd.Parameters.Add("@Longitud", SqlDbType.VarChar, 100).Value = Longitud;
                cmd.Parameters.Add("@FlagTipoRegistro", SqlDbType.Int).Value = FlagTipoRegistro;
                cmd.Parameters.Add("@Fecha", SqlDbType.VarChar, 50).Value = Fecha;
                cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IdPedido", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@List", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;

                cmd.ExecuteScalar();
                cn.Close();

                flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                IdPedido = cmd.Parameters["@IdPedido"].Value.ToString();
            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return new ParametrosSalida(flag, mensaje, IdPedido);
        }
        public DataTable InsertarPedidoComp(String IdPed,
                                        String IdUsuario,
                                    String CodigoTxt,
                                    Int32 IdCondicionVenta,
                                    String IdUsuarioVenta,
                                    String TotalPagar,
                                    Int32 Items,
                                    String Latitud,
                                    String Longitud,
                                    Int32 FlagTipoRegistro,
                                    String Fecha,
                                    DataTable dt
                                   )
        {
            String flag = "", mensaje = "", IdPedido = "";

            SqlConnection cn = new SqlConnection(connectionString);
            DataTable dtt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            int IdOrdenes = 0;
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_InsertaPedidoComp";
                cmd.Connection = cn;

                cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPed;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = IdUsuario;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
                cmd.Parameters.Add("@IdCondicionVenta", SqlDbType.Int).Value = IdCondicionVenta;
                cmd.Parameters.Add("@IdUsuarioVenta", SqlDbType.VarChar, 50).Value = IdUsuarioVenta;
                cmd.Parameters.Add("@TotalPagar", SqlDbType.VarChar, 50).Value = TotalPagar;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Items;
                cmd.Parameters.Add("@Latitud", SqlDbType.VarChar, 100).Value = Latitud;
                cmd.Parameters.Add("@Longitud", SqlDbType.VarChar, 100).Value = Longitud;
                cmd.Parameters.Add("@FlagTipoRegistro", SqlDbType.Int).Value = FlagTipoRegistro;
                cmd.Parameters.Add("@Fecha", SqlDbType.VarChar, 50).Value = Fecha;
                // cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                // cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                // cmd.Parameters.Add("@IdPedido", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@List", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;

                //cmd.ExecuteScalar();
                da.SelectCommand = cmd;
                da.Fill(dtt);
                cn.Close();

                // flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                // mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                // IdPedido = cmd.Parameters["@IdPedido"].Value.ToString();
            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return dtt; //new ParametrosSalida(flag, mensaje, IdPedido);
        }
        public DataTable InsertarPedidoV2(String IdUsuario,
                                    String CodigoTxt,
                                    Int32 IdCondicionVenta,
                                    String IdUsuarioVenta,
                                    String TotalPagar,
                                    Int32 Items,
                                    String Latitud,
                                    String Longitud,
                                    Int32 FlagTipoRegistro,
                                    String Fecha,
                                    DataTable dt
                                   )
        {
            String flag = "", mensaje = "", IdPedido = "";

            SqlConnection cn = new SqlConnection(connectionString);
            DataTable dtt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            int IdOrdenes = 0;
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_InsertaPedidoV2";
                cmd.Connection = cn;


                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = IdUsuario;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
                cmd.Parameters.Add("@IdCondicionVenta", SqlDbType.Int).Value = IdCondicionVenta;
                cmd.Parameters.Add("@IdUsuarioVenta", SqlDbType.VarChar, 50).Value = IdUsuarioVenta;
                cmd.Parameters.Add("@TotalPagar", SqlDbType.VarChar, 50).Value = TotalPagar;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Items;
                cmd.Parameters.Add("@Latitud", SqlDbType.VarChar, 100).Value = Latitud;
                cmd.Parameters.Add("@Longitud", SqlDbType.VarChar, 100).Value = Longitud;
                cmd.Parameters.Add("@FlagTipoRegistro", SqlDbType.Int).Value = FlagTipoRegistro;
                cmd.Parameters.Add("@Fecha", SqlDbType.VarChar, 50).Value = Fecha;

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@List", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;

                //cmd.ExecuteScalar();
                da.SelectCommand = cmd;
                da.Fill(dtt);
                cn.Close();


            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return dtt; //new ParametrosSalida(flag, mensaje, IdPedido);
        }

        public DataTable InsertarPedidoV3(String IdUsuario,
                                    String CodigoTxt,
                                    Int32 IdCondicionVenta,
                                    String IdUsuarioVenta,
                                    String TotalPagar,
                                    Int32 Items,
                                    String Latitud,
                                    String Longitud,
                                    Int32 FlagTipoRegistro,
                                    String Fecha,
                                    String IdOrigen,
                                    DataTable dt
                                   )
        {
            String flag = "", mensaje = "", IdPedido = "";

            SqlConnection cn = new SqlConnection(connectionString);
            DataTable dtt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            int IdOrdenes = 0;
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_InsertaPedidoV4";
                cmd.Connection = cn;


                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = IdUsuario;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
                cmd.Parameters.Add("@IdCondicionVenta", SqlDbType.Int).Value = IdCondicionVenta;
                cmd.Parameters.Add("@IdUsuarioVenta", SqlDbType.VarChar, 50).Value = IdUsuarioVenta;
                cmd.Parameters.Add("@TotalPagar", SqlDbType.VarChar, 50).Value = TotalPagar;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Items;
                cmd.Parameters.Add("@Latitud", SqlDbType.VarChar, 100).Value = Latitud;
                cmd.Parameters.Add("@Longitud", SqlDbType.VarChar, 100).Value = Longitud;
                cmd.Parameters.Add("@FlagTipoRegistro", SqlDbType.Int).Value = FlagTipoRegistro;
                cmd.Parameters.Add("@Fecha", SqlDbType.VarChar, 50).Value = Fecha;
                cmd.Parameters.Add("@IdOrigen", SqlDbType.Int).Value = IdOrigen;

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@List", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;

                //cmd.ExecuteScalar();
                da.SelectCommand = cmd;
                da.Fill(dtt);
                cn.Close();


            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return dtt; //new ParametrosSalida(flag, mensaje, IdPedido);
        }

        public DataTable InsertarPedidoV4(String IdUsuario,
                                    String CodigoTxt,
                                    Int32 IdCondicionVenta,
                                    String IdUsuarioVenta,
                                    String TotalPagar,
                                    Int32 Items,
                                    String Latitud,
                                    String Longitud,
                                    Int32 FlagTipoRegistro,
                                    String Fecha,
                                    String IdOrigen,
                                    DataTable dt
                                   )
        {
            String flag = "", mensaje = "", IdPedido = "";

            SqlConnection cn = new SqlConnection(connectionString);
            DataTable dtt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            int IdOrdenes = 0;
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_InsertaPedidoV3";
                cmd.Connection = cn;


                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = IdUsuario;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
                cmd.Parameters.Add("@IdCondicionVenta", SqlDbType.Int).Value = IdCondicionVenta;
                cmd.Parameters.Add("@IdUsuarioVenta", SqlDbType.VarChar, 50).Value = IdUsuarioVenta;
                cmd.Parameters.Add("@TotalPagar", SqlDbType.VarChar, 50).Value = TotalPagar;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Items;
                cmd.Parameters.Add("@Latitud", SqlDbType.VarChar, 100).Value = Latitud;
                cmd.Parameters.Add("@Longitud", SqlDbType.VarChar, 100).Value = Longitud;
                cmd.Parameters.Add("@FlagTipoRegistro", SqlDbType.Int).Value = FlagTipoRegistro;
                cmd.Parameters.Add("@Fecha", SqlDbType.VarChar, 50).Value = Fecha;
                cmd.Parameters.Add("@IdOrigen", SqlDbType.Int).Value = IdOrigen;

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@List", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;

                //cmd.ExecuteScalar();
                da.SelectCommand = cmd;
                da.Fill(dtt);
                cn.Close();


            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return dtt; //new ParametrosSalida(flag, mensaje, IdPedido);
        }
        public DataTable InsertarPedidoV5(String IdUsuario,
                                    String CodigoTxt,
                                    Int32 IdCondicionVenta,
                                    String IdUsuarioVenta,
                                    String TotalPagar,
                                    Int32 Items,
                                    String Latitud,
                                    String Longitud,
                                    Int32 FlagTipoRegistro,
                                    String Fecha,
                                    String IdOrigen,
                                    DataTable dt
                                   )
        {
            String flag = "", mensaje = "", IdPedido = "";

            SqlConnection cn = new SqlConnection(connectionString);
            DataTable dtt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            int IdOrdenes = 0;
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_InsertaPedidoV5";
                cmd.Connection = cn;


                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = IdUsuario;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
                cmd.Parameters.Add("@IdCondicionVenta", SqlDbType.Int).Value = IdCondicionVenta;
                cmd.Parameters.Add("@IdUsuarioVenta", SqlDbType.VarChar, 50).Value = IdUsuarioVenta;
                cmd.Parameters.Add("@TotalPagar", SqlDbType.VarChar, 50).Value = TotalPagar;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Items;
                cmd.Parameters.Add("@Latitud", SqlDbType.VarChar, 100).Value = Latitud;
                cmd.Parameters.Add("@Longitud", SqlDbType.VarChar, 100).Value = Longitud;
                cmd.Parameters.Add("@FlagTipoRegistro", SqlDbType.Int).Value = FlagTipoRegistro;
                cmd.Parameters.Add("@Fecha", SqlDbType.VarChar, 50).Value = Fecha;
                cmd.Parameters.Add("@IdOrigen", SqlDbType.Int).Value = IdOrigen;

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@List", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;

                //cmd.ExecuteScalar();
                da.SelectCommand = cmd;
                da.Fill(dtt);
                cn.Close();


            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return dtt; //new ParametrosSalida(flag, mensaje, IdPedido);
        }

        public DataTable InsertarPedidoV6(String IdUsuario,
                                    String CodigoTxt,
                                    Int32 IdCondicionVenta,
                                    String IdUsuarioVenta,
                                    String TotalPagar,
                                    Int32 Items,
                                    String Latitud,
                                    String Longitud,
                                    Int32 FlagTipoRegistro,
                                    String Fecha,
                                    String IdOrigen,
                                    DataTable dt
                                   )
        {
            String flag = "", mensaje = "", IdPedido = "";

            SqlConnection cn = new SqlConnection(connectionString);
            DataTable dtt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            int IdOrdenes = 0;
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_InsertaPedidoV6";
                cmd.Connection = cn;


                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = IdUsuario;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
                cmd.Parameters.Add("@IdCondicionVenta", SqlDbType.Int).Value = IdCondicionVenta;
                cmd.Parameters.Add("@IdUsuarioVenta", SqlDbType.VarChar, 50).Value = IdUsuarioVenta;
                cmd.Parameters.Add("@TotalPagar", SqlDbType.VarChar, 50).Value = TotalPagar;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Items;
                cmd.Parameters.Add("@Latitud", SqlDbType.VarChar, 100).Value = Latitud;
                cmd.Parameters.Add("@Longitud", SqlDbType.VarChar, 100).Value = Longitud;
                cmd.Parameters.Add("@FlagTipoRegistro", SqlDbType.Int).Value = FlagTipoRegistro;
                cmd.Parameters.Add("@Fecha", SqlDbType.VarChar, 50).Value = Fecha;
                cmd.Parameters.Add("@IdOrigen", SqlDbType.Int).Value = IdOrigen;

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@List", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;

                //cmd.ExecuteScalar();
                da.SelectCommand = cmd;
                da.Fill(dtt);
                cn.Close();


            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return dtt; //new ParametrosSalida(flag, mensaje, IdPedido);
        }
        public DataTable InsertarPedidoP(String IdUsuario,
                                    String CodigoTxt,
                                    Int32 IdCondicionVenta,
                                    String IdUsuarioVenta,
                                    String TotalPagar,
                                    Int32 Items,
                                    String Latitud,
                                    String Longitud,
                                    Int32 FlagTipoRegistro,
                                    String Fecha,
                                    String IdOrigen,
                                    DataTable dt
                                   )
        {
            String flag = "", mensaje = "", IdPedido = "";

            SqlConnection cn = new SqlConnection(connectionString);
            DataTable dtt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            int IdOrdenes = 0;
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_InsertaPedidoP";
                cmd.Connection = cn;


                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = IdUsuario;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
                cmd.Parameters.Add("@IdCondicionVenta", SqlDbType.Int).Value = IdCondicionVenta;
                cmd.Parameters.Add("@IdUsuarioVenta", SqlDbType.VarChar, 50).Value = IdUsuarioVenta;
                cmd.Parameters.Add("@TotalPagar", SqlDbType.VarChar, 50).Value = TotalPagar;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Items;
                cmd.Parameters.Add("@Latitud", SqlDbType.VarChar, 100).Value = Latitud;
                cmd.Parameters.Add("@Longitud", SqlDbType.VarChar, 100).Value = Longitud;
                cmd.Parameters.Add("@FlagTipoRegistro", SqlDbType.Int).Value = FlagTipoRegistro;
                cmd.Parameters.Add("@Fecha", SqlDbType.VarChar, 50).Value = Fecha;
                cmd.Parameters.Add("@IdOrigen", SqlDbType.Int).Value = IdOrigen;

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@List", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;

                //cmd.ExecuteScalar();
                da.SelectCommand = cmd;
                da.Fill(dtt);
                cn.Close();


            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return dtt; //new ParametrosSalida(flag, mensaje, IdPedido);
        }
        /***************************************************************************************************************/

        public DataTable ListaDiaVisita(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ProxDiaVisita";
                cmd.Connection = cn;
                cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ListaPedidoComplementario(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_ListaPedidoComplementario";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ListaTokenVendedores(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaTokenVendedores";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ListaPedidoDetalleLista(String IdPedido)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaDetallePedido";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdPedido", SqlDbType.VarChar, 50).Value = IdPedido;
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
        public DataTable ListaUsuarioTokenIdNotificacion(String idUsuario, String idNotificacion)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaUsuarioTokenIdNotificacion";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
                cmd.Parameters.Add("@idNotificacion", SqlDbType.Int).Value = idNotificacion;
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
        public DataTable ListaUsuarioToken(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaUsuarioToken";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ListarPromociones(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListarPromociones";
                cmd.Connection = cn;
                cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ListarCategoriasProductos(String idUsuario, String CodigoTxt)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_ListarCategorias";
                cmd.Connection = cn;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
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
        public DataTable ListaPromocionesCondisBonis(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaPromocionesCondisBonis";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ListaPromocionesCondisBonisPrueba(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaPromocionesCondisBonisPrueba";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ListaPromocionesCabecera(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaPromocionesCabecera";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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

        public DataTable ListaPromocionesCabeceraV3(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaPromocionesCabeceraV3";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ListaPromocionesCabeceraV2(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaPromocionesCabeceraV2";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ListaPromocionesCabeceraVPrueba(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaPromocionesCabeceraVPrueba";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ReporteMeta(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ReporteMeta";
                cmd.Connection = cn;
                cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ListarProductos(String idUsuario, String CodigoTxt)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_ListarProductos";
                cmd.Connection = cn;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
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
        public DataTable ListarProductosV2(String idUsuario, String CodigoTxt)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_ListarProductosV2";
                cmd.Connection = cn;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
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
        public DataTable ListarProductoSugerido(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_PedidoSugerido";
                cmd.Connection = cn;
                cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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
        public DataTable ListarPedidoComplementarioDetalle(String IdPedido)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_ListaDetallePedidoComp";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
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
        public DataTable ListarPedidos(String idUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaPedidos";
                cmd.Connection = cn;
                cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
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

        public DataTable ListarPedidos(String idUsuario, String fecInicio, String fecFinal)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "App_ListaPedidosXFecha";
                cmd.Connection = cn;
                cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar, 50).Value = idUsuario;
                cmd.Parameters.Add("@fecInicio", SqlDbType.VarChar, 50).Value = fecInicio;
                cmd.Parameters.Add("@fecFinal", SqlDbType.VarChar, 50).Value = fecFinal;
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
        public DataTable ListaClientesRuta(String idUsuario, String CodigoTxt)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APP_listaClientesRuta";
                cmd.Connection = cn;
                cmd.Parameters.Add("@CodigoTxt", SqlDbType.VarChar, 50).Value = CodigoTxt;
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



        public String NotificacionMasivaNueva(String token, Int32 id, String titulo, String msj, String rutafoto)
        {

            var result = "-1";
            var webAddr = "https://fcm.googleapis.com/fcm/send";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=AAAAPKenxWY:APA91bE35FXYhLyXkXSSAsxouJQUu2qu1uhuzSlyiUETfi2AZqPSlgWzs--JJWg3iuBooM904U3lHMrxxqwACs3S54afYjCUODc2uOIayV2-WNf134VowucE8yEDYNEWQ_M6DN3r3bnx");
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string strNJson = "{ \"to\": \" " + token + "\", " +
                " \"data\": { " +
                            " \"id\": \"" + id + "\"," +
                            " \"titulo\": \"" + titulo + "\"," +
                            " \"msj\": \"" + msj + "\"," +
                            " \"rutafoto\": \"" + rutafoto + "\",},}";

                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
        public String NotificacionTexto(String token, Int32 id, String msj)
        {

            var result = "-1";
            var webAddr = "https://fcm.googleapis.com/fcm/send";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=AAAAPKenxWY:APA91bE35FXYhLyXkXSSAsxouJQUu2qu1uhuzSlyiUETfi2AZqPSlgWzs--JJWg3iuBooM904U3lHMrxxqwACs3S54afYjCUODc2uOIayV2-WNf134VowucE8yEDYNEWQ_M6DN3r3bnx");
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string strNJson = "{ \"to\": \" " + token + "\", " +
                " \"data\": { " +
                            " \"id\": \"" + id + "\"," +
                            " \"titulo\": \"" + "" + "\"," +
                            " \"msj\": \"" + msj + "\"," +
                            " \"rutafoto\": \"" + "" + "\",},}";

                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }


        public ParametrosSalida RegistarCliente(
             String Nombre,
    String Paterno,
    String Materno,
    String Celular,
    String Telefono,
    String dni,
    String ruc,
    String RazonSocial,
    String Direccion,
    String Referencia,
    String Latitud,
    String Longitud,
    String Correo,
    String usuario,
    String clave,
    String IdTxtVendedor
         )
        {
            String flag = "", mensaje = "";
            try
            {
                using (SqlConnection cnm = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("APP_RegistrarNuevoCliente", cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Paterno", Paterno);
                    cmd.Parameters.AddWithValue("@Materno", Materno);
                    cmd.Parameters.AddWithValue("@Celular", Celular);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@ruc", ruc);
                    cmd.Parameters.AddWithValue("@RazonSocial", RazonSocial);
                    cmd.Parameters.AddWithValue("@Direccion", Direccion);
                    cmd.Parameters.AddWithValue("@Referencia", Referencia);
                    cmd.Parameters.AddWithValue("@Latitud", Latitud);
                    cmd.Parameters.AddWithValue("@Longitud", Longitud);
                    cmd.Parameters.AddWithValue("@Correo", Correo);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.Parameters.AddWithValue("@IdTxtVendedor", IdTxtVendedor);
                    cmd.Parameters.Add("@FlagIndicador", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cnm.Open();
                    cmd.ExecuteNonQuery();
                    flag = cmd.Parameters["@FlagIndicador"].Value.ToString();
                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();

                }



            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }
            return new ParametrosSalida(flag, mensaje);
        }
        public ParametrosSalida ObtenDatosCliente(String IdUsuario)
        {
            String flag = "", mensaje = "";

            String Nombre = "";
            String Paterno = "";
            String Materno = "";
            String Celular = "";
            String Telefono = "";
            String dni = "";
            String ruc = "";
            String RazonSocial = "";
            String Direccion = "";
            String Latitud = "";
            String Longitud = "";
            String Correo = "";
            String usuario = "";
            String clave = "";


            try
            {
                using (SqlDataAdapter adp = new SqlDataAdapter("APP_ObtenDatosCliente", connectionString))
                {
                    DataTable dt = new DataTable();
                    adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adp.SelectCommand.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    adp.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        Nombre = row["IdSede"].ToString();
                        Paterno = row["IdSede"].ToString();
                        Materno = row["IdSede"].ToString();
                        Celular = row["IdSede"].ToString();
                        Telefono = row["IdSede"].ToString();
                        dni = row["IdSede"].ToString();
                        ruc = row["IdSede"].ToString();
                        RazonSocial = row["IdSede"].ToString();
                        Direccion = row["IdSede"].ToString();
                        Latitud = row["IdSede"].ToString();
                        Longitud = row["IdSede"].ToString();
                        Correo = row["IdSede"].ToString();
                        usuario = row["IdSede"].ToString();
                        clave = row["IdSede"].ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                flag = "1";
                mensaje = ex.Message;
            }


            return new ParametrosSalida(flag, mensaje, Nombre, Paterno, Materno, Celular, Telefono, dni, ruc, RazonSocial, Direccion, Latitud, Longitud, Correo, usuario, clave);

        }

    }
}