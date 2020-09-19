using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSTiendaDelcorp.Models;

namespace WSTiendaDelcorp.Controllers
{
    public class VisitaController : ApiController
    {
        // GET: api/Visita
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Visita/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Visita
        public IHttpActionResult Post(Visita objVisita)
        {
            ParametrosSalida respuesta = new ParametrosSalida();

            try
            {
                Db obj = new Db();

                respuesta = obj.InsertaVisita(objVisita.IdCliente,objVisita.IdVendedor);

            }
            catch (Exception e)
            {
                respuesta.FlagIndicador = "1";
                respuesta.MsgValidacion = e.Message;
            }

            return CreatedAtRoute("DefaultApi", new { Id = 1 }, respuesta);
        }

        // PUT: api/Visita/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Visita/5
        public void Delete(int id)
        {
        }
    }
}
