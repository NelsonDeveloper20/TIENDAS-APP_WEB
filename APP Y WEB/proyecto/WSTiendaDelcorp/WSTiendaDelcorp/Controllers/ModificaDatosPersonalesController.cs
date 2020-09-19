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
    public class ModificaDatosPersonalesController : ApiController
    {
        // GET: api/ModificaDatosPersonales
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ModificaDatosPersonales/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ModificaDatosPersonales
        public IHttpActionResult Post(DatosPersonales datos)
        {
            ParametrosSalida respuesta = new ParametrosSalida();
            DataTable dt = new DataTable();


            try
            {
                Db obj = new Db();

                respuesta = obj.modificaDatos(datos.CodigoTxt, datos.Nombre, datos.Paterno, datos.Materno,
                    datos.Celular, datos.Telefono, datos.dni, datos.ruc, datos.RazonSocial,datos.Direccion, datos.Correo);


            }
            catch (Exception e)
            {
                respuesta.FlagIndicador = "1";
                respuesta.MsgValidacion = e.Message;
            }

            return CreatedAtRoute("DefaultApi", new { Id = 1 }, respuesta);

        }

        // PUT: api/ModificaDatosPersonales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ModificaDatosPersonales/5
        public void Delete(int id)
        {
        }
    }
}
