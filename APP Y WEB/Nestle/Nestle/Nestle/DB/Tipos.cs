using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace DB
{
  public  class Tipos
    {      String connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
        public DataTable ListarTipoVehiculo()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarTipoVehiculo", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;             
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarTipoServicio()
        {
            DataTable dt = new DataTable();
            using(SqlDataAdapter adp=new SqlDataAdapter("SP_ListarTipoServicio", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            return dt;
        }
        public DataTable ListarTipoDocumento()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarTipoDocumento", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarMarca()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarMarca", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarPropiedad()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_listarPropiedad", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarTipoCombustible()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarTipoCombustible", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);

            }
            return dt;
        }


        public DataTable ListarTipoPago(Int32 IdMaster)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarTipoPago", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdMaster", IdMaster);
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarDiaSemana(Int32 IdMaster)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarDiasSemana", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdMaster", IdMaster);
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable listarTipoTransporte(Int32 IdMaster)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarTipoTransporte", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdMaster", IdMaster);
                adp.Fill(dt);

            }
            return dt;
        }
        public DataTable ListarTipoTarifa(Int32 IdMaster)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adp = new SqlDataAdapter("CC_ListarTipoTarifa", connectionString))
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@IdMaster", IdMaster);
                adp.Fill(dt);

            }
            return dt;
        }
    }
}
