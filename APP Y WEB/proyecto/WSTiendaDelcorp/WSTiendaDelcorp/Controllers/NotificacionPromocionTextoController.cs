using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WSTiendaDelcorp.Controllers
{
    public class NotificacionPromocionTextoController : ApiController
    {
        // GET: api/NotificacionPromocionTexto
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NotificacionPromocionTexto/5
        public string Get(String IdUsuario, int id,  String msj )
        {
            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListaUsuarioToken(IdUsuario);

            foreach (DataRow row in dt.Rows)
            { 
                obj.NotificacionTexto(row["token"].ToString(), id,msj ); 
            }

            return "value";
        }

        // POST: api/NotificacionPromocionTexto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/NotificacionPromocionTexto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/NotificacionPromocionTexto/5
        public void Delete(int id)
        {
        }
    }
}
