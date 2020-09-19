using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WSTiendaDelcorp.Controllers
{
    public class NotificaNuevaPromocionController : ApiController
    {
        // GET: api/NotificaNuevaPromocion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NotificaNuevaPromocion/5
        public string Get( String IdUsuario,int id,String titulo,String msj,String rutafoto,String idNotificacion)
        {
            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListaUsuarioTokenIdNotificacion(IdUsuario, idNotificacion);

            foreach (DataRow row in dt.Rows)
            { 

                obj.NotificacionMasivaNueva(row["token"].ToString(), id, titulo, msj, rutafoto);

            }
             
            return "value";
        }

        // POST: api/NotificaNuevaPromocion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/NotificaNuevaPromocion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/NotificaNuevaPromocion/5
        public void Delete(int id)
        {
        }
    }
}
