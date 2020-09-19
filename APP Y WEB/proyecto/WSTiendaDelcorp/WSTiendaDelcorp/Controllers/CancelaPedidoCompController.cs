using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSTiendaDelcorp.Models;

namespace WSTiendaDelcorp.Controllers
{
    public class CancelaPedidoCompController : ApiController
    {
        // GET: api/CancelaPedidoComp
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CancelaPedidoComp/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CancelaPedidoComp
        public IHttpActionResult Post(CancelaPedidoComp obju)
        {
            ParametrosSalida respuesta = new ParametrosSalida();

            try
            {
                Db obj = new Db();

                respuesta = obj.cancelaPedidoComp(obju.IdUsuario, obju.IdPedido);

            }
            catch (Exception e)
            {
                respuesta.FlagIndicador = "1";
                respuesta.MsgValidacion = e.Message;
            }

            return CreatedAtRoute("DefaultApi", new { Id = 1 }, respuesta);
        }

        // PUT: api/CancelaPedidoComp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CancelaPedidoComp/5
        public void Delete(int id)
        {
        }
    }
}
