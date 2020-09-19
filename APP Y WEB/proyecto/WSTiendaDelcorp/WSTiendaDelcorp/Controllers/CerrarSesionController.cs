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
    public class CerrarSesionController : ApiController
    {
        // GET: api/CerrarSesion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CerrarSesion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CerrarSesion
        public IHttpActionResult Post(Usuario objUsuario)
        {
            ParametrosSalida respuesta = new ParametrosSalida();
            DataTable dt = new DataTable();
             
            try
            {
                Db obj = new Db(); 
                respuesta = obj.cerrarSesion(objUsuario.User, objUsuario.token);
  
            }
            catch (Exception e)
            {
                respuesta.FlagIndicador = "1";
                respuesta.MsgValidacion = e.Message;
            }

            return CreatedAtRoute("DefaultApi", new { Id = 1 }, respuesta);

        }

        // PUT: api/CerrarSesion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CerrarSesion/5
        public void Delete(int id)
        {
        }
    }
}
