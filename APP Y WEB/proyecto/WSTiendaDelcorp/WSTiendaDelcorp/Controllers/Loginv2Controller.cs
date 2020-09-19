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
    public class Loginv2Controller : ApiController
    {
        // GET: api/Loginv2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Loginv2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Loginv2
        public IHttpActionResult Post(Usuario objUsuario)
        {
            ParametrosSalida respuesta = new ParametrosSalida();
            DataTable dt = new DataTable();
            

            try
            {
                Db obj = new Db();

                respuesta = obj.ValidaUsuariov2(objUsuario.User, objUsuario.Clave, objUsuario.token);

                if (respuesta.FlagIndicador.Equals("0") && !respuesta.Param6.Equals(objUsuario.token) )
                {  
                    obj.NotificacionMasivaNueva(respuesta.Param6, 10, "SESION TERMINADA", "", "");
                }

            }
            catch (Exception e)
            {
                respuesta.FlagIndicador = "1";
                respuesta.MsgValidacion = e.Message;
            }

            return CreatedAtRoute("DefaultApi", new { Id = 1 }, respuesta);

        }

        // PUT: api/Loginv2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Loginv2/5
        public void Delete(int id)
        {
        }
    }
}
