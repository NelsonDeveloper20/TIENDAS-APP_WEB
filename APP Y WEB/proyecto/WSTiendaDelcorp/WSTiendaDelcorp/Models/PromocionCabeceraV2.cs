using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class PromocionCabeceraV2
    {
        public String IdPromocion { get; set; }
        public String flagHistorico { get; set; }
        public String IdCondicion { get; set; }
        public String IdTipoCondicion { get; set; }
        public String IdTipoPromocion { get; set; }
        public String IdTipoBonificacion { get; set; }
        public String MontoBonificacion { get; set; }
        public String IdTipoUsuario { get; set; }  
        public String flagPrimeraCompra { get; set; }
    }
}