﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSTiendaDelcorp.Models;

namespace WSTiendaDelcorp.Controllers
{
    public class ListaPromoCabeceraV2Controller : ApiController
    {
        // GET: api/ListaPromoCabeceraV2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaPromoCabeceraV2/5
        public List<PromocionCabeceraV2> Get(String idUsuario)
        {
            List<PromocionCabeceraV2> lstPromocionCabecera = new List<PromocionCabeceraV2>();

            Db obj = new Db();
            DataTable dt = new DataTable();
            dt = obj.ListaPromocionesCabeceraV2(idUsuario);


            foreach (DataRow row in dt.Rows)
            {
                PromocionCabeceraV2 objPromocionCabecera = new PromocionCabeceraV2();
                objPromocionCabecera.IdPromocion = row["IdPromocion"].ToString();
                objPromocionCabecera.flagHistorico = row["flagHistorico"].ToString();
                objPromocionCabecera.IdCondicion = row["IdCondicion"].ToString();
                objPromocionCabecera.IdTipoCondicion = row["IdTipoCondicion"].ToString();
                objPromocionCabecera.IdTipoPromocion = row["IdTipoPromocion"].ToString();
                objPromocionCabecera.IdTipoBonificacion = row["IdTipoBonificacion"].ToString();
                objPromocionCabecera.MontoBonificacion = row["MontoBonificacion"].ToString();
                objPromocionCabecera.IdTipoUsuario = row["IdTipoUsuario"].ToString();
                objPromocionCabecera.flagPrimeraCompra = row["flagPrimeraCompra"].ToString();

                lstPromocionCabecera.Add(objPromocionCabecera);

            }

            return lstPromocionCabecera;
        }

        // POST: api/ListaPromoCabeceraV2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaPromoCabeceraV2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaPromoCabeceraV2/5
        public void Delete(int id)
        {
        }
    }
}
