using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class PromocionCabeceraV3
    {
        public String IdPromocion { get; set; }
        public String flagHistorico { get; set; }
        public String IdCondicion { get; set; }
        public String IdTipoCondicion { get; set; }
        public String MontoCondicion1 { get; set; }
        public String MontoCondicion2 { get; set; }
        public String MontoCondicion3 { get; set; }
        public String MontoCondicion4 { get; set; }
        public String MontoCondicion5 { get; set; }
        public String IdTipoPromocion { get; set; }
        public String IdTipoBonificacion { get; set; }
        public String MontoBonificacion { get; set; }
        public String IdTipoUsuario { get; set; }
        public String flagPrimeraCompra { get; set; }
    }
}