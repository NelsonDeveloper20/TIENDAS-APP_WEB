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
    public class ListaPromoCabeceraController : ApiController
    {
        // GET: api/ListaPromoCabecera
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaPromoCabecera/5
        public List<PromocionCabecera> Get(String idUsuario)
        {
            List<PromocionCabecera> lstPromocionCabecera = new List<PromocionCabecera>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListaPromocionesCabecera(idUsuario);


            foreach (DataRow row in dt.Rows)
            {
                PromocionCabecera objPromocionCabecera = new PromocionCabecera();
                objPromocionCabecera.IdPromocion = row["IdPromocion"].ToString();
                objPromocionCabecera.flagHistorico = row["flagHistorico"].ToString();
                objPromocionCabecera.IdCondicion = row["IdCondicion"].ToString();
                objPromocionCabecera.IdTipoCondicion = row["IdTipoCondicion"].ToString();
                objPromocionCabecera.IdTipoPromocion = row["IdTipoPromocion"].ToString();
                objPromocionCabecera.IdTipoBonificacion = row["IdTipoBonificacion"].ToString();
                objPromocionCabecera.MontoBonificacion = row["MontoBonificacion"].ToString();
                objPromocionCabecera.IdTipoUsuario = row["IdTipoUsuario"].ToString(); 

                lstPromocionCabecera.Add(objPromocionCabecera);

            }

            return lstPromocionCabecera;
        }


        // POST: api/ListaPromoCabecera
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaPromoCabecera/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaPromoCabecera/5
        public void Delete(int id)
        {
        }
    }
}
