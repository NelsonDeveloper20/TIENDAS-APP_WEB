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
    public class ReporteEficienciaController : ApiController
    {
        // GET: api/ReporteEficiencia
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ReporteEficiencia/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ReporteEficiencia
        public IHttpActionResult Post(Usuario objUsuario)
        {
            ParametrosSalida respuesta = new ParametrosSalida();
            DataTable dt = new DataTable();


            try
            {
                Db obj = new Db();

                respuesta = obj.ReporteEficiencia(objUsuario.User );
                   

            }
            catch (Exception e)
            {
                respuesta.FlagIndicador = "1";
                respuesta.MsgValidacion = e.Message;
            }

            return CreatedAtRoute("DefaultApi", new { Id = 1 }, respuesta);

        }

        // PUT: api/ReporteEficiencia/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReporteEficiencia/5
        public void Delete(int id)
        {
        }
    }
}
