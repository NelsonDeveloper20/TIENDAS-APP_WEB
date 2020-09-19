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
    public class DatosPersonalesController : ApiController
    {
        // GET: api/DatosPersonales
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DatosPersonales/5
        public Int32 Get(String IdUsuario)
        {

            return 1;

        }

        // POST: api/DatosPersonales
        public IHttpActionResult Post(Cliente cliente)
        {
            ParametrosSalida respuesta = new ParametrosSalida();
            DataTable dt = new DataTable();


            try
            {
                Db obj = new Db();

                respuesta = obj.ObtenDatos(cliente.CodigoTxt);
                 

            }
            catch (Exception e)
            {
                respuesta.FlagIndicador = "1";
                respuesta.MsgValidacion = e.Message;
            }

            return CreatedAtRoute("DefaultApi", new { Id = 1 }, respuesta);

        }

        // PUT: api/DatosPersonales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DatosPersonales/5
        public void Delete(int id)
        {
        }
    }
}
