using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DB
{
   public class Promociones  {
        
       // String connectionString = "Data Source=192.168.2.198;Initial Catalog=BD_NEL_R;User ID=jdextre;Pwd=bgyz0448";

      String connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();

        public DataTable DetallePromcion(Int32 IdPromocion)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("cc_DetallePromocion", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@idPromocion", IdPromocion);
                adp.Fill(dt);
            }
            return dt;
        }
        public String EliminarPromocion(Int32 IdPromocion, Int32 IdUsuario)
        {
            String Msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CC_EliminarPromocion", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPromocion", IdPromocion);
                cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }
        public String ActivarPromocion(Int32 IdPromocion, Int32 IdUsuario)
        {
            String Msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CC_ActivarPromocion", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPromocion", IdPromocion);
                cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }
        public DataTable ListarPromociones(Int32 id,String FecInicio,String fecFin,Int32 Estado)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("CC_LIstarPromocion", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@Id", id);
                adp.SelectCommand.Parameters.AddWithValue("@fecInicio", FecInicio);
                adp.SelectCommand.Parameters.AddWithValue("@FecFin", fecFin);
                adp.SelectCommand.Parameters.AddWithValue("@Estado", Estado);
                adp.Fill(dt);

            }
            return dt;
        }


    public DataTable ListarDetalleProciones()
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("cc_ListarPromocion_Detalle", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);

            }
            return dt;
        }


        public DataTable ListarDetalleCondicion(Int32 idpromocion)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarCondiciondet", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@idpromocion", idpromocion);
                adp.Fill(dt);

            }
            return dt;
        }

        public DataTable ListarDetalleBonificacion(Int32 idpromocion)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarBonificacionDet", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@idpromocion", idpromocion);
                adp.Fill(dt);

            }
            return dt;
        }

        public DataTable ListarTipoCondicion()
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("cc_listarTipoCondicion", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            return dt;
        }

       
             public DataSet listar_prom_boni(Int32 Id)
        {
            DataSet dt = new DataSet();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_listarProm_Boni", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdUsuario", Id);
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarProducto(Int32 Id)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarProducto", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@Id", Id);
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarProductopROMOCION(Int32 Id)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarProductoPromocion", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@Id", Id);
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarCondicion()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_listarCondicon", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarTipoBonificacion()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("sp_ListarTipoBonificacion", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);

            }
            return dt;
        }
        public void crudoperations(string status, Int32 IdUsuario, string IdProd_prom, Int32 Cantidad_Prom,
          String Idprod_boni, Int32 Cantidad_Boni, Int32 Stock, int idPromBoni,string idproducto,String Descripcion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("crudoperations", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "INSERT")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@idPromBoni", idPromBoni);
                    cmd.Parameters.AddWithValue("@idusuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@idprodprom", IdProd_prom);
                    cmd.Parameters.AddWithValue("@cantidadprom", Cantidad_Prom);
                    cmd.Parameters.AddWithValue("@idprodboni", Idprod_boni);
                    cmd.Parameters.AddWithValue("@cantidadboni", Cantidad_Boni);
                    cmd.Parameters.AddWithValue("@stockboni", Stock);
                    cmd.Parameters.AddWithValue("@IdProdcuto_Categoria", idproducto);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                }
                else if (status == "UPDATE")
                {

                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@idPromBoni", idPromBoni);
                    cmd.Parameters.AddWithValue("@idusuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@idprodprom", IdProd_prom);
                    cmd.Parameters.AddWithValue("@cantidadprom", Cantidad_Prom);
                    cmd.Parameters.AddWithValue("@idprodboni", Idprod_boni);
                    cmd.Parameters.AddWithValue("@cantidadboni", Cantidad_Boni);
                    cmd.Parameters.AddWithValue("@stockboni", Stock);
                    cmd.Parameters.AddWithValue("@IdProdcuto_Categoria", idproducto);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                }
                else if (status == "DELETE")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@idusuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@idPromBoni", idPromBoni);
                }
                else if (status == "DELETEALL")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@idusuario", IdUsuario);
                }
                
                cmd.ExecuteNonQuery();
            }
        }
        public Int32 InsertarPromocion(String FecInicio,String FecFin,Int32 FlatgHistorico,
            Int32 FlagPrimeraCompra, Int32 IdCondicion,Int32 IdTipoCondicion,
            Int32 IdTipoPromocion,Int32 TipoBonificacion,Decimal MontoBonificacion,Int32 usuario,
            Int32 idtipousuario)
        {
            Int32 IdPromocion = 0;
            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_Ins_Promocion",cnm);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@fecinicio", FecInicio);
                cmd.Parameters.AddWithValue("@fecfin", FecFin);

                cmd.Parameters.AddWithValue("@flaghistorico", FlatgHistorico);
                cmd.Parameters.AddWithValue("@flagprimeracompra", FlagPrimeraCompra);

                cmd.Parameters.AddWithValue("@idcondicion", IdCondicion);
                cmd.Parameters.AddWithValue("@idtipocondicion", IdTipoCondicion);
                cmd.Parameters.AddWithValue("@idtipopromocion", IdTipoPromocion);
                cmd.Parameters.AddWithValue("@idtipobonificacion", TipoBonificacion);
                cmd.Parameters.AddWithValue("@montobonificacion", MontoBonificacion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@idtipousuario", idtipousuario);
                cnm.Open();
                IdPromocion = Convert.ToInt32(cmd.ExecuteScalar());
                cnm.Close();
            }
            return IdPromocion;
        }
        public String InsertarPromocionTipoUser(Int32 IdPromcoion,Int32 IdTipoUser)
        {
            String Msj = "";
            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_IsnPromocionTipoUser", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPromocion", IdPromcoion);
                cmd.Parameters.AddWithValue("@IdTipoUsuario", IdTipoUser);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();

            }
            return Msj;
        }
        public String InsertarNotificacionTipoUser(Int32 IdNotificacion, Int32 IdTipoUser)
        {
            String Msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_IsnNotificacionTipoUser", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdNotificacion", IdNotificacion);
                cmd.Parameters.AddWithValue("@IdTipoUsuario", IdTipoUser);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();

            }
            return Msj;
        }
        public String CambioEstado(Int32 IdPromocion)
        {
            String Msj = "";
            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_estadoPromocionTipoUsuario",cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPromocion", IdPromocion);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
            }
            return Msj;
        }
        public String CambioEstadocondi_boni(Int32 IdPromocion)
        {
            String Msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_estadoProm_condi_Boni",cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPromocion", IdPromocion);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
            }
            return Msj;
        }
        public String ModificarPromocion(Int32 IdPromocion, String FecInicio, String FecFin, Int32 FlatgHistorico,
           Int32 FlagPrimeraCompra, Int32 IdCondicion, Int32 IdTipoCondicion,
           Int32 IdTipoPromocion, Int32 TipoBonificacion, String MontoBonificacion, Int32 usuario,
           Int32 idtipousuario)
        {
            String Msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_Modif_Promocion", cnm);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idPromocion", IdPromocion);
                cmd.Parameters.AddWithValue("@fecinicio", FecInicio);
                cmd.Parameters.AddWithValue("@fecfin", FecFin);

                cmd.Parameters.AddWithValue("@flaghistorico", FlatgHistorico);
                cmd.Parameters.AddWithValue("@flagprimeracompra", FlagPrimeraCompra);

                cmd.Parameters.AddWithValue("@idcondicion", IdCondicion);
                cmd.Parameters.AddWithValue("@idtipocondicion", IdTipoCondicion);
                cmd.Parameters.AddWithValue("@idtipopromocion", IdTipoPromocion);
                cmd.Parameters.AddWithValue("@idtipobonificacion", TipoBonificacion);
                cmd.Parameters.AddWithValue("@montobonificacion", MontoBonificacion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@idtipousuario", idtipousuario);
                //cmd.Parameters.AddWithValue("@estado", Estado);
                cnm.Open();
                Msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }
        public String EstadoNotificacion(Int32 idpromocion, Int32 Usuario)
        {
            String Msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cm = new SqlCommand("CC_UpNotificacion", cnm);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@IdPromcion", idpromocion);
                cm.Parameters.AddWithValue("@usuario", Usuario);
                cnm.Open();
                Msj = Convert.ToString(cm.ExecuteScalar());
                cnm.Close();
            }
            return Msj;
        }
        public DataTable PromocionXid(String ip, Int32 IdPromocion,Int32 IdUsuario)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("cc_PromocionXID", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@ip", ip);
                adp.SelectCommand.Parameters.AddWithValue("@IdPromocion", IdPromocion);
                adp.SelectCommand.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable PromocionXidV2(Int32 IdPromocion)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_PromocionXIDV2", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdPromocion", IdPromocion);
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable promocionBonficiacion(Int32 IdPromocion)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("cc_promocionBonificacionXid", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdPromocion", IdPromocion);
                adp.Fill(dt);
            }
            return dt;
        }
        public String InsertarPromocionCondicion(Int32 IdPromocion,
            String IdProducto,String IdCategoria,Int32 IdGrupo,Int32 Cantidad,String Descripcion,Int32 Usuario, Int32 IdPromocionCondicion
            )
        {
            String msj = "";
            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsPromocionCondicion", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpromocion", IdPromocion);
                cmd.Parameters.AddWithValue("@idproducto", IdProducto);
                cmd.Parameters.AddWithValue("@idcategoria", IdCategoria);
                cmd.Parameters.AddWithValue("@idgrupo", IdGrupo);
                cmd.Parameters.AddWithValue("@cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@usuario", Usuario);
                cmd.Parameters.AddWithValue("@IdPromocionCondicion", IdPromocionCondicion);
                cnm.Open();
                msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return msj;

        }
        public String EliminarDetallePromocion(Int32 IdPromocion)
        {
            string Msj = "";
            using(SqlConnection cnm=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CC_EliminarDetPromocion");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpromocion", IdPromocion);
                Msj = Convert.ToString(cmd.ExecuteScalar());
            }
            return Msj;
        }
        public DataTable listarPromocionTipoUsuario(Int32 IdPromocion)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("CC_PromoccionTipoUser", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdPromocion", IdPromocion);
                adp.Fill(dt);
            }
            return dt;
        }

        public DataTable CondicionXidPromocion(Int32 IdPromocion)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_PromocionCondicionXid", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdPromocion", IdPromocion);
                adp.Fill(dt);
            }
            return dt;
        }

        public String InsertarBonificacion(Int32 IdPromocion,
        Int32 Grupo,String IdProducto,Int32 Cantidad,Int32 Stock, Int32 IdPromocionBonificacion
         )
        {
            String msj = "";
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ins_Bonificacion", cnm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpromocion", IdPromocion);
                cmd.Parameters.AddWithValue("@idgrupo", Grupo);
                cmd.Parameters.AddWithValue("@idproducto", IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@stock", Stock);
                cmd.Parameters.AddWithValue("@IdPromocionBonificacion", IdPromocionBonificacion);
                cnm.Open();
                msj = Convert.ToString(cmd.ExecuteScalar());
                cnm.Close();
            }
            return msj;

        }

    }
}
