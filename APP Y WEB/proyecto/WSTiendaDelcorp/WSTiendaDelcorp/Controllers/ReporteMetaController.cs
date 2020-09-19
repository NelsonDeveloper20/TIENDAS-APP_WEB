using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSTiendaDelcorp.Models;

namespace WSTiendaDelcorp.Controllers
{
    public class ReporteMetaController : ApiController
    {
        // GET: api/ReporteMeta
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ReporteMeta/5
        public ReporteMeta  Get(String idUsuario)
        {
            ReporteMeta objReporteMeta = new ReporteMeta();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ReporteMeta(idUsuario);


            foreach (DataRow row in dt.Rows)
            { 
                objReporteMeta.IdMetaMensual = row["IdMetaMensual"].ToString();
                objReporteMeta.Fecha = row["Fecha"].ToString();
                objReporteMeta.Meta = row["Meta"].ToString();
                objReporteMeta.CantDiasMes = row["CantDiasMes"].ToString();
                objReporteMeta.MontoDiario = row["MontoDiario"].ToString();
                objReporteMeta.MetaHastaHoy = row["MetaHastaHoy"].ToString();
                objReporteMeta.MontoHastaHoy = row["MontoHastaHoy"].ToString(); 
                objReporteMeta.cantVentas = row["cantVentas"].ToString();
                objReporteMeta.DiaHoy = row["DiaHoy"].ToString();
                objReporteMeta.porcenActual = row["porcenActual"].ToString();

            }

            return objReporteMeta;
        }

        // POST: api/ReporteMeta
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ReporteMeta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReporteMeta/5
        public void Delete(int id)
        {
        }
    }
}
