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
    public class ListaPromoCabeceraV3Controller : ApiController
    {
        // GET: api/ListaPromoCabeceraV3
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaPromoCabeceraV3/5
        public List<PromocionCabeceraV3> Get(String idUsuario)
        {
            List<PromocionCabeceraV3> lstPromocionCabecera = new List<PromocionCabeceraV3>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListaPromocionesCabeceraV3(idUsuario);


            foreach (DataRow row in dt.Rows)
            {
                PromocionCabeceraV3 objPromocionCabecera = new PromocionCabeceraV3();
                objPromocionCabecera.IdPromocion = row["IdPromocion"].ToString();
                objPromocionCabecera.flagHistorico = row["flagHistorico"].ToString();
                objPromocionCabecera.IdCondicion = row["IdCondicion"].ToString();
                objPromocionCabecera.IdTipoCondicion = row["IdTipoCondicion"].ToString();
                objPromocionCabecera.MontoCondicion1 = row["MontoCondicion1"].ToString();
                objPromocionCabecera.MontoCondicion2 = row["MontoCondicion2"].ToString();
                objPromocionCabecera.MontoCondicion3 = row["MontoCondicion3"].ToString();
                objPromocionCabecera.MontoCondicion4 = row["MontoCondicion4"].ToString();
                objPromocionCabecera.MontoCondicion5 = row["MontoCondicion5"].ToString();
                objPromocionCabecera.IdTipoPromocion = row["IdTipoPromocion"].ToString();
                objPromocionCabecera.IdTipoBonificacion = row["IdTipoBonificacion"].ToString();
                objPromocionCabecera.MontoBonificacion = row["MontoBonificacion"].ToString();
                objPromocionCabecera.IdTipoUsuario = row["IdTipoUsuario"].ToString();
                objPromocionCabecera.flagPrimeraCompra = row["flagPrimeraCompra"].ToString();

                lstPromocionCabecera.Add(objPromocionCabecera);

            }

            return lstPromocionCabecera;
        }

        // POST: api/ListaPromoCabeceraV3
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaPromoCabeceraV3/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaPromoCabeceraV3/5
        public void Delete(int id)
        {
        }
    }
}
