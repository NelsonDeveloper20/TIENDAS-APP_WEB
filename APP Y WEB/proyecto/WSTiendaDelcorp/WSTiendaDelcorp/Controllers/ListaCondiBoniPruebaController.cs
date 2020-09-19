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
    public class ListaCondiBoniPruebaController : ApiController
    {
        // GET: api/ListaCondiBoniPrueba
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaCondiBoniPrueba/5
        public List<CondicionBonificacion> Get(String idUsuario)
        {
            List<CondicionBonificacion> lstCondicionBonificacion = new List<CondicionBonificacion>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListaPromocionesCondisBonisPrueba(idUsuario);


            foreach (DataRow row in dt.Rows)
            {
                CondicionBonificacion objCondicionBonificacion = new CondicionBonificacion();
                objCondicionBonificacion.IdPromocionCondicion = row["IdPromocionCondicion"].ToString();
                objCondicionBonificacion.IdPromocionBonificacion = row["IdPromocionBonificacion"].ToString();
                objCondicionBonificacion.IdPromocion = row["IdPromocion"].ToString();
                objCondicionBonificacion.IdProducto = row["IdProducto"].ToString();
                objCondicionBonificacion.IdCategoria = row["IdCategoria"].ToString();
                objCondicionBonificacion.IdGrupo = row["IdGrupo"].ToString();
                objCondicionBonificacion.Cantidad = row["Cantidad"].ToString();
                objCondicionBonificacion.Descripcion = row["Descripcion"].ToString();
                objCondicionBonificacion.Stock = row["Stock"].ToString();

                lstCondicionBonificacion.Add(objCondicionBonificacion);

            }

            return lstCondicionBonificacion;
        }

        // POST: api/ListaCondiBoniPrueba
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaCondiBoniPrueba/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaCondiBoniPrueba/5
        public void Delete(int id)
        {
        }
    }
}
