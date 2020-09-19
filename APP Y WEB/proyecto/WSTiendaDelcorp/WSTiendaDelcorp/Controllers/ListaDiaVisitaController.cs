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
    public class ListaDiaVisitaController : ApiController
    {
        // GET: api/ListaDiaVisita
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaDiaVisita/5
        public List<DiaVisita> Get(String idUsuario )
        {
            List<DiaVisita> lstDiaVisita = new List<DiaVisita>();

            Db obj = new Db();
            DataTable dt = new DataTable();
              dt = obj.ListaDiaVisita(idUsuario);


             foreach (DataRow row in dt.Rows)
             {
                 DiaVisita objDiaVisita = new DiaVisita();
                 objDiaVisita.CodigoEmpleado = row["CodigoEmpleado"].ToString();
                 objDiaVisita.DiasVisita = row["DiasVisita"].ToString(); 

                 lstDiaVisita.Add(objDiaVisita);

             } 
/*
            DiaVisita objDiaVisita = new DiaVisita();
            objDiaVisita.CodigoEmpleado = "";
            objDiaVisita.DiasVisita = "";
            lstDiaVisita.Add(objDiaVisita);
                 */
            return lstDiaVisita;
        }


        // POST: api/ListaDiaVisita
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaDiaVisita/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaDiaVisita/5
        public void Delete(int id)
        {
        }
    }
}
