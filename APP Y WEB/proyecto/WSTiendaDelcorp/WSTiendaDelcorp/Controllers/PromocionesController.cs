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
    public class PromocionesController : ApiController
    {
        // GET: api/Promociones
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Promociones/5
        public List<Promocion> Get(String idUsuario)
        {
            List<Promocion> lstPromocion = new List<Promocion>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListarPromociones(idUsuario);
             
            foreach (DataRow row in dt.Rows)
            {
                Promocion objPromocion = new Promocion();
                objPromocion.IdPromocion = row["IdPromocion"].ToString();
                objPromocion.flagHistorico = row["flagHistorico"].ToString();
                objPromocion.IdCondicion = row["IdCondicion"].ToString();
                objPromocion.IdTipoCondicion = row["IdTipoCondicion"].ToString();
                objPromocion.IdTipoPromocion = row["IdTipoPromocion"].ToString();
                objPromocion.IdTipoBonificacion = row["IdTipoBonificacion"].ToString();
                objPromocion.IdCategoria = row["IdCategoria"].ToString();
                objPromocion.IdProductoPromo = row["IdProductoPromo"].ToString();
                objPromocion.MontoBonificacion = row["MontoBonificacion"].ToString();
                objPromocion.IdPromocionCondicion = row["IdPromocionCondicion"].ToString();
                objPromocion.CantidadCondi = row["CantidadCondi"].ToString();
                objPromocion.Descripcion = row["Descripcion"].ToString();
                objPromocion.IdPromocionBonificacion = row["IdPromocionBonificacion"].ToString();
                objPromocion.IdProductoBoni = row["IdProductoBoni"].ToString();
                objPromocion.CantidadBoni = row["CantidadBoni"].ToString();
                objPromocion.Stock = row["Stock"].ToString();
                objPromocion.NombrePro = row["NombrePro"].ToString();
                objPromocion.Imagen = row["Imagen"].ToString();

                lstPromocion.Add(objPromocion); 
            }

            return lstPromocion;
        }

        // POST: api/Promociones
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Promociones/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Promociones/5
        public void Delete(int id)
        {
        }
    }
}
