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
 public   class Formulario
    {
        string connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();

        public DataTable ListaAccesoUsuario(Int32 IdUsuario)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            //try
            //{
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CAccesoUusario";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
                da.SelectCommand = cmd;
                da.Fill(dt);
                cn.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    cn.Close();
            //}
            return dt;
        }
        public int AgregarFormulario(string Nombre,
                                       string Ruta, string Grupo, int Estado, int Usucrea)
        {
            int IdDierccion = 0;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_IFormulario";
                cmd.Connection = cn;

                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 120).Value = Nombre;
                cmd.Parameters.Add("@Ruta", SqlDbType.VarChar, 400).Value = Ruta;
                cmd.Parameters.Add("@Grupo", SqlDbType.VarChar, 50).Value = Grupo;
                cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;
                cmd.Parameters.Add("@Usucrea", SqlDbType.Int).Value = Usucrea;

                IdDierccion = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                cn.Close();

            }
            catch (Exception ex)
            {
                IdDierccion = 0;
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return IdDierccion;
        }
        public int ModificarFormulario(int IdFormulario, string Nombre,
                                      string Ruta, string Grupo, int Estado, int UsuModifica)
        {
            int idFormulario = 0;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MFormulario";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdFormulario", SqlDbType.Int).Value = IdFormulario;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 120).Value = Nombre;
                cmd.Parameters.Add("@Ruta", SqlDbType.VarChar, 400).Value = Ruta;
                cmd.Parameters.Add("@Grupo", SqlDbType.VarChar, 50).Value = Grupo;
                cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;
                cmd.Parameters.Add("@UsuModifica", SqlDbType.Int).Value = UsuModifica;

                idFormulario = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                cn.Close();

            }
            catch (Exception ex)
            {
                idFormulario = 0;
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return idFormulario;
        }

        public int EliminarFormulario(int IdFormulario, int UsuModifica)
        {
            int resultado = 0;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DFormulario";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdFormulario", SqlDbType.Int).Value = IdFormulario;
                cmd.Parameters.Add("@UsuModifica", SqlDbType.Int).Value = UsuModifica;
                resultado = Convert.ToInt32(cmd.ExecuteScalar().ToString());
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
            return resultado;
        }


        public DataTable ListarFormularioXID(int IdFormulario)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CFormularioXID";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdFormulario", SqlDbType.Int).Value = IdFormulario;
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


        public DataTable ListarFormulario()
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CFormulario";
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


        public DataTable ListarPerfilFormulario()
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CFormulario";
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



        public DataTable FormularioXPerfil(int IdPerfil, int IdFormulario)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CFormularioXPerfil";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
                cmd.Parameters.Add("@IdFormulario", SqlDbType.Int).Value = IdFormulario;
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
        public DataTable FormularioIdPerfilNoSeleccionados(int IdPerfil)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CFormularioIdPerfilNoSeleccionados";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
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
        public DataTable FormularioIdPerfilSeleccionados(int IdPerfil)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CFormularioIdPerfilSeleccionados";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
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
        public bool ActualizarEstadoFormularioPerfil(int IdPerfil, int IdFormulario, int Estado, int UsuModifica)
        {
            bool retorno = false;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UFormularioPerfil";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
                cmd.Parameters.Add("@IdFormulario", SqlDbType.Int).Value = IdFormulario;
                cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;
                cmd.Parameters.Add("@UsuModifica", SqlDbType.Int).Value = UsuModifica;
                cmd.ExecuteNonQuery();
                cn.Close();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return retorno;
        }
        public bool ActualizarEstadoFormularioPerfilAsignados(int IdPerfil, int IdFormulario, int UsuModifica)
        {
            bool retorno = false;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UFormularioPerfilAsignado";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
                cmd.Parameters.Add("@IdFormulario", SqlDbType.Int).Value = IdFormulario;
                cmd.Parameters.Add("@UsuModifica", SqlDbType.Int).Value = UsuModifica;
                cmd.ExecuteNonQuery();
                cn.Close();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return retorno;
        }
        public bool ActualizarEstadoFormularioPerfilNoAsignados(int IdPerfil, int IdFormulario, int UsuModifica)
        {
            bool retorno = false;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UFormularioPerfilNoAsignado";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
                cmd.Parameters.Add("@IdFormulario", SqlDbType.Int).Value = IdFormulario;
                cmd.Parameters.Add("@UsuModifica", SqlDbType.Int).Value = UsuModifica;
                cmd.ExecuteNonQuery();
                cn.Close();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return retorno;
        }



        public bool AgregarFormularioPerfil(int IdPerfil, int IdFormulario, int Estado, int UsuCrea)
        {

            bool retorno = false;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_IFormularioPerfil";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
                cmd.Parameters.Add("@IdFormulario", SqlDbType.Int).Value = IdFormulario;
                cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;
                cmd.Parameters.Add("@UsuCrea", SqlDbType.Int).Value = UsuCrea;
                cmd.ExecuteNonQuery();
                cn.Close();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return retorno;
        }

        public bool IngresarFormulariosNuevosExistentes(int IdPerfil)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            bool retorno = false;
            //try
            //{
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_IFormularioPerfilValida";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
                cmd.ExecuteNonQuery();
                cn.Close();
                retorno = true;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    cn.Close();
            //}
            return retorno;
        }

    }
}
