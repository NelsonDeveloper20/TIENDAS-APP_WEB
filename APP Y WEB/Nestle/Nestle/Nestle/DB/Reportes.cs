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
  public  class Reportes
    {
        String CN = ConfigurationManager.AppSettings["connectionString"].ToString();

        public DataTable RtptGraficoVenta(String FechaInicio,String FechaFin,
            Int32 Dia,String IdVendedor,String IdBodega,Int32 tipofiltro)
        {
            Int32 CantSemanas = 0;

          
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter adp=new SqlDataAdapter("Rpt_GraficVentaV2", CN))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@FecInicio", FechaInicio);
                adp.SelectCommand.Parameters.AddWithValue("@FecFin", FechaFin);
                adp.SelectCommand.Parameters.AddWithValue("@Dia", Dia);
                adp.SelectCommand.Parameters.AddWithValue("@Vendedor", IdVendedor);
                adp.SelectCommand.Parameters.AddWithValue("@Bodega", IdBodega);
                    adp.SelectCommand.Parameters.AddWithValue("@TipoFiltro", tipofiltro);

                    adp.Fill(dt);
            }
            }catch (Exception ex) { }
            return dt;
        }
        public DataTable ListarTipoFiltro()
        {
            DataTable dt = new DataTable();
            try
            {
                using(SqlDataAdapter adp=new SqlDataAdapter("cc_ListarTipoFiltro", CN))
                {
                    adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adp.Fill(dt);
                }
            }catch (Exception ex)
            {

            }
            return dt;
        }

    }
}
