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
  public  class Usuario
    {
        string connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
       //String connectionString = "Data Source=192.168.2.198;Initial Catalog=BD_NEL_R;User ID=jdextre;Pwd=bgyz0448";
        public String InsertMetaUsuario(Int32 IdDistribuidor,String idvendedor, Int32 TipoUsuario,String Fecha,
     float Monto,     Int32 UsuaCrea)
        {
            String Msj = "";
            using (SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_Ins_MetaMensual", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDistribuidor", IdDistribuidor);
                cmd.Parameters.AddWithValue("@IdVendedor", idvendedor);
                cmd.Parameters.AddWithValue("@TipoUsuario", TipoUsuario);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@Monto", Monto);
                cmd.Parameters.AddWithValue("@UsuCrea", UsuaCrea);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }
     public String ModificarMeta(Int32 IdMeta,float Monto,Int32 Usuario)
        {
            String Msj = "";
            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarMetaMensual", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMatea", IdMeta);
                cmd.Parameters.AddWithValue("@Monto", Monto);
                cmd.Parameters.AddWithValue("@UsuModifica", Usuario);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;

        }


        
        public DataTable ListarMetaMensual(Int32 IdMaster,Int32 TipoUsuario,String Fecha)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("CC_ListarMetaMensual", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdDistribuidor", IdMaster);
                adp.SelectCommand.Parameters.AddWithValue("@TipoUsuario", TipoUsuario);
                adp.SelectCommand.Parameters.AddWithValue("@Fecha", Fecha);

                adp.Fill(dt);

            }
            return dt;
        }
        //NELS.......
        public DataTable LlistTipoUsuario()
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("CC_ListarTipoUsu", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);

            }
            return dt;

        }
        public DataTable listarTipoAcceso()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_listartipoacceso", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);

            }
            return dt;
        }
        
             public DataTable ListarEmpresa()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_listarEmpresa", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);

            }
            return dt;
        }
        public int AgregarUsuario(int IdSubPerfil,int IdEmpresaMaster, string Nombre,
                                       string ApellidoMaterno, string ApellidoPaterno, string Usuario,
                                       string Clave, int Estado, int Usucrea)
        {
            int IdDierccion = 0;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {

               
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_IUsuario";
                cmd.Connection = cn;

                cmd.Parameters.Add("@IdSubPerfil", SqlDbType.Char, 6).Value = IdSubPerfil;
                cmd.Parameters.Add("@IdDistribuidor", SqlDbType.Int).Value = IdEmpresaMaster;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 200).Value = Nombre;
                cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 50).Value = ApellidoMaterno;
                cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 50).Value = ApellidoPaterno;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 12).Value = Usuario;
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 12).Value = Clave;
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

        public DataTable BuscarSupervisor(String Nombre, Int32 idUsuario)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarSupervisor";
                cmd.Connection = cn;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = Nombre;
                cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = idUsuario;
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
        //NELSON
        public DataTable ListaSupervisores(Int32 IdUsuario)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("SP_ListaSupervisores", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@idusuario", IdUsuario);
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable DetalleSucSup(Int32 IdSuper)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter())
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SP_DetalleSucSuper", IdSuper);
                adp.Fill(dt);
            }
            return dt;
        }
        //END
        public int AgregarUsuarioExterno(int IdSubPerfil, string Nombre,
                                       string ApellidoMaterno, string ApellidoPaterno, string Usuario,
                                       string Clave, int Estado, int Usucrea)
        {
            int IdDierccion = 0;
            try
            {
                SqlConnection cn = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_IUsuario";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdSubPerfil", SqlDbType.Char, 6).Value = IdSubPerfil;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 200).Value = Nombre;
                cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 50).Value = ApellidoMaterno;
                cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 50).Value = ApellidoPaterno;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 12).Value = Usuario;
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 12).Value = Clave;
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
            return IdDierccion;
        }
        //nelson R:)
        public String InsertarUsuariosApp(   Int32 iddistribuidor,String codigotxt,
            Int32 idtipousuario,Int32 idtipoacceso ,Int32 idempresa ,String nombre,String paterno,
            String materno,String usuario,String clave ,String direccion,String codigocanal ,
            String giro ,Int32 estado ,Int32 usucrea,Int32 FlagValidaDatos)
        {
            String Msj = "";
            using (SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_insUsuarioApp", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddistribuidor", iddistribuidor);
                cmd.Parameters.AddWithValue("@codigotxt ", codigotxt);
                cmd.Parameters.AddWithValue("@idtipousuario ", idtipousuario);
                cmd.Parameters.AddWithValue("@idtipoacceso ", idtipoacceso);
                cmd.Parameters.AddWithValue("@idempresa ", idempresa);
                cmd.Parameters.AddWithValue("@nombre ", nombre);
                cmd.Parameters.AddWithValue("@paterno ", paterno);
                cmd.Parameters.AddWithValue("@materno ", materno);
                cmd.Parameters.AddWithValue("@usuario ", usuario);
                cmd.Parameters.AddWithValue("@clave ", clave);
                cmd.Parameters.AddWithValue("@direccion ", direccion);
                cmd.Parameters.AddWithValue("@codigocanal ", codigocanal);
                cmd.Parameters.AddWithValue("@giro ", giro);
                cmd.Parameters.AddWithValue("@estado ", estado);
                cmd.Parameters.AddWithValue("@usucrea ", usucrea);
                cmd.Parameters.AddWithValue("@FlagValidaDatos", FlagValidaDatos);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }
        public String ModificarUsuariosApp(Int32 idUsuario, String codigotxt,
           Int32 idtipousuario, Int32 idtipoacceso, Int32 idempresa, String nombre, String paterno,
           String materno, String usuario, String clave, String direccion, String codigocanal,
           String giro, Int32 estado, Int32 usucrea,Int32 FlagValidaDatos)
        {
            String Msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpUsuarioApp", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@codigotxt ", codigotxt);
                cmd.Parameters.AddWithValue("@idtipousuario ", idtipousuario);
                cmd.Parameters.AddWithValue("@idtipoacceso ", idtipoacceso);
                cmd.Parameters.AddWithValue("@idempresa ", idempresa);
                cmd.Parameters.AddWithValue("@nombre ", nombre);
                cmd.Parameters.AddWithValue("@paterno ", paterno);
                cmd.Parameters.AddWithValue("@materno ", materno);
                cmd.Parameters.AddWithValue("@usuario ", usuario);
                cmd.Parameters.AddWithValue("@clave ", clave);
                cmd.Parameters.AddWithValue("@direccion ", direccion);
                cmd.Parameters.AddWithValue("@codigocanal ", codigocanal);
                cmd.Parameters.AddWithValue("@giro ", giro);
                cmd.Parameters.AddWithValue("@estado ", estado);
                cmd.Parameters.AddWithValue("@usucrea ", usucrea);
                cmd.Parameters.AddWithValue("@FlagValidaDatos", FlagValidaDatos);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }

        //


        public int ModificarUsuario(int IdUsuario,  int IdSubPerfil, string Nombre,
                                       string ApellidoMaterno, string ApellidoPaterno, string Usuario,
                                       string Clave, int Estado, int Usucrea
                                      )
        {
            int IdDierccion = 0;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();

                
       
            //String codigotxt VARCHAR(50)=NULL,
            //String idtipousuario INT,
            //String idtipoacceso INT,
            //String idempresa INT,
            //String Direccion VARCHAR(100),
            
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MUsuario";
                cmd.Connection = cn;
                

                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
                cmd.Parameters.Add("@IdSubPerfil", SqlDbType.Char, 6).Value = IdSubPerfil;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 200).Value = Nombre;
                cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 50).Value = ApellidoMaterno;
                cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 50).Value = ApellidoPaterno;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 12).Value = Usuario;
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 12).Value = Clave;
                cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;
                cmd.Parameters.Add("@UsuModifica", SqlDbType.Int).Value = Usucrea;

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
        public int EliminarUsuario(int IdUsuario, int UsuModifica)
        {
            int resultado = 0;
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DUsuario";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
                cmd.Parameters.Add("@UsuMoficica", SqlDbType.Int).Value = UsuModifica;
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

        public DataTable ListarUsuarios(int idEmpresa,Int32 estado,String nombre)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CC_CUsuario";
                cmd.Connection = cn;
                cmd.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = estado;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre;
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

        public DataTable validaUsuario(int IdUsuario)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_validaUsuario";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
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

        //nels
        public DataTable listUsuXid(Int32 IduUSARIO)
        {
            DataTable DT = new DataTable();
            using(SqlDataAdapter ADP=new SqlDataAdapter("CC_ListartUsuXId", connectionString))
            {
                ADP.SelectCommand.CommandType = CommandType.StoredProcedure;
                ADP.SelectCommand.Parameters.AddWithValue("@Id", IduUSARIO);
                ADP.Fill(DT);
            }
            return DT;
        }
     
        public DataTable ListarUsuarioApp(Int32 IdEmpresa,Int32 Estado,String Nombre,Int32 tipousuario)
        {
            DataTable DT = new DataTable();
            using (SqlDataAdapter ADP = new SqlDataAdapter("CC_CUsuarioapp", connectionString))
            {
                ADP.SelectCommand.CommandType = CommandType.StoredProcedure;
                ADP.SelectCommand.Parameters.AddWithValue("@idEmpresa", IdEmpresa);
                ADP.SelectCommand.Parameters.AddWithValue("@estado", Estado);
                ADP.SelectCommand.Parameters.AddWithValue("@Nombre", Nombre);
                ADP.SelectCommand.Parameters.AddWithValue("@idtipoUsuario", tipousuario);         
                ADP.Fill(DT);
            }
            return DT;
        }
        public DataTable ListarUsuariosXID(int IdUsuario)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            //try
            //{ 
            SqlDataAdapter da = new SqlDataAdapter();
            cn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CUsuarioPorId";
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
        public DataTable ListarUsuarioExternoXID(int IdUsuario)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CUsuarioExternoPorId";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
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
        public DataTable ValidarAccesoUsuario(string Usuario, string Clave)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ValidarUsuarioWeb";
                cmd.Connection = cn;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 20).Value = Clave;
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



        public int ModificarUsuarioExterno(int IdUsuario, int IdSubPerfil, string Nombre,
                                       string ApellidoMaterno, string ApellidoPaterno, int UsuModifica
                                       , string TelefonoFijo, string Celular,
                                       int Sexo, string RazonSocial, string Ruc, string Correo, string FechaNacimiento)
        {
            int IdUsuarioExterno = 0;
            try
            {
                SqlConnection cn = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MUsuarioExterno";
                cmd.Connection = cn;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
                cmd.Parameters.Add("@IdSubPerfil", SqlDbType.Char, 6).Value = IdSubPerfil;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 200).Value = Nombre;
                cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 50).Value = ApellidoMaterno;
                cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 50).Value = ApellidoPaterno;
                cmd.Parameters.Add("@UsuModifica", SqlDbType.Int).Value = UsuModifica;

                cmd.Parameters.Add("@TelefonoFijo", SqlDbType.VarChar, 40).Value = TelefonoFijo;
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar, 40).Value = Celular;
                cmd.Parameters.Add("@Sexo", SqlDbType.Int).Value = Sexo;
                cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 400).Value = RazonSocial;
                cmd.Parameters.Add("@Ruc", SqlDbType.VarChar, 16).Value = Ruc;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 200).Value = Correo;
                cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar, 40).Value = FechaNacimiento;



                IdUsuarioExterno = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                cn.Close();

            }
            catch (Exception ex)
            {
                IdUsuarioExterno = 0;
                throw ex;
            }
            return IdUsuarioExterno;
        }


    }
}
