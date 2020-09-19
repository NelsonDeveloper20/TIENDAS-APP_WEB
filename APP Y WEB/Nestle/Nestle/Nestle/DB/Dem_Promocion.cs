using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DB
{
public   class Dem_Promocion
    {

  String connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();


        public void crudoperations(String Ip,string status, Int32 IdUsuario,Int32 idpromcondicion, Int32 Cantidad,String Descripcion,
            String IdCat_Prod,Int32 Grupo,String Producto_item,String IdProducto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {


                con.Open();
                SqlCommand cmd = new SqlCommand("ins_condicion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "INSERT")
                {
                    cmd.Parameters.AddWithValue("@ip", Ip);
                    cmd.Parameters.AddWithValue("@usuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("@descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", IdCat_Prod);
                    cmd.Parameters.AddWithValue("@grupo", Grupo);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@Producto", Producto_item);
                    cmd.Parameters.AddWithValue("@IdProducto", IdProducto);

                }
                else if (status == "UPDATE")
                {
                    //SET Cantidad = @cantidad, Descripcion = @descripcion, IdCategoria = @IdCategoria, Grupo = @grupo, 
                    //idusuario = @usuario,    Producto = @Producto, IdProducto = @IdProducto
                    //WHERE IdPromCondicion = @idpromcondicion
                    cmd.Parameters.AddWithValue("@ip", Ip);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("@descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", IdCat_Prod);
                    cmd.Parameters.AddWithValue("@grupo", Grupo);
                    cmd.Parameters.AddWithValue("@usuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@Producto", Producto_item);
                    cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                    cmd.Parameters.AddWithValue("@idpromcondicion", idpromcondicion);
                }
                else if (status == "DELETE")
                {
                    cmd.Parameters.AddWithValue("@ip", Ip);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@idpromcondicion", idpromcondicion);
                    cmd.Parameters.AddWithValue("@usuario", IdUsuario);
                }
                else if (status == "DELETE_ALL")
                {
                    cmd.Parameters.AddWithValue("@ip", Ip);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@usuario", IdUsuario);
                    
                }

                cmd.ExecuteNonQuery();
            }
        }
    public DataSet ListarDemCondicion(Int32 Idusuario)
        {
            DataSet dt = new DataSet();
            using(SqlDataAdapter adp=new SqlDataAdapter("SELECT* FROM dbo.Dem_Condicion WHERE idusuario="+ Idusuario + " ", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable count_grupo(Int32 grupo,Int32 idusuario)
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("cc_countGrupo",connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@idusuario", idusuario);
                adp.SelectCommand.Parameters.AddWithValue("@Grupo", idusuario);
                adp.Fill(dt);

                
            }
            return dt;
        }
        public Int32 counDistintos(Int32 grupo, Int32 idusuario)
        {
            Int32 Count = 0;
            using (SqlConnection cnm=new SqlConnection(connectionString))
            {


                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT Grupo) FROM Dem_Condicion WHERE idusuario="+ idusuario + " ", cnm);
                cmd.CommandType = CommandType.Text;
                cnm.Open();
                Count = Convert.ToInt32(cmd.ExecuteScalar());
                cnm.Close();


            }
            return Count;
        }
        public Int32 Repr(Int32 grupo, Int32 idusuario)
        {
            Int32 Count = 0;
            using (SqlConnection cnm = new SqlConnection(connectionString))
            {


                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Dem_Condicion WHERE idusuario=" + idusuario + " AND Grupo= "+grupo+" ", cnm);
                cmd.CommandType = CommandType.Text;
                cnm.Open();
                Count = Convert.ToInt32(cmd.ExecuteScalar());
                cnm.Close();


            }
            return Count;
        }
        
        public DataSet Listardeo_Boni(Int32 Idusuario)
        {
            DataSet dt = new DataSet();
            using (SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM dbo.Dem_Boni WHERE idusuario=" + Idusuario + " ", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(dt);

            }
            return dt;
        }
        public void CrudOperationBoni(String Ip, string status, Int32 IdUsuario, Int32 IdPromocionBoni,
            String Producto,Int32 Cantidad,Int32 Stock,Int32 Grupo,String Producto_item)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {


                con.Open();
                SqlCommand cmd = new SqlCommand("ins_Boni", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "INSERT")
                {
                    cmd.Parameters.AddWithValue("@ip", Ip);
                    cmd.Parameters.AddWithValue("@usuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@idproducto", Producto);
                    cmd.Parameters.AddWithValue("@cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("@stock", Stock);
                    cmd.Parameters.AddWithValue("@grupo", Grupo);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@Producto", Producto_item);

                }
                if (status == "UPDATE")
                {
                    cmd.Parameters.AddWithValue("@ip", Ip);
                    cmd.Parameters.AddWithValue("@usuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@idproducto", Producto);
                    cmd.Parameters.AddWithValue("@cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("@stock", Stock);
                    cmd.Parameters.AddWithValue("@grupo", Grupo);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@Producto", Producto_item);
                    cmd.Parameters.AddWithValue("@IdPromocionBonificacion", IdPromocionBoni);

                }
                else if (status == "DELETE")
                {
                    cmd.Parameters.AddWithValue("@ip", Ip);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@IdPromocionBonificacion", IdPromocionBoni);
                    cmd.Parameters.AddWithValue("@usuario", IdUsuario);
                }
                else if (status == "DELETE_ALL")
                {
                    cmd.Parameters.AddWithValue("@ip", Ip);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@usuario", IdUsuario);

                }

                cmd.ExecuteNonQuery();
            }
        }
       public DataTable listarCatgoriaMaestro()
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("SELECT * from Categoria where IdUp=0 AND Estado=1  order BY Nombre ASc	", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarTipoPromocion()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("SELECT * from TipoPromocion where  Estado=1 ", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(dt);

            }
            return dt;
        }
    }
}
