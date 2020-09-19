using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class Promocion
    {
        public String IdPromocion { get; set; }
        public String flagHistorico { get; set; }
        public String IdCondicion { get; set; }
        public String IdTipoCondicion { get; set; }
        public String IdTipoPromocion { get; set; }
        public String IdTipoBonificacion { get; set; }
        public String IdCategoria { get; set; }
        public String IdProductoPromo { get; set; }
        public String MontoBonificacion { get; set; }
        public String IdPromocionCondicion { get; set; }
        public String CantidadCondi { get; set; }
        public String Descripcion { get; set; }
        public String IdPromocionBonificacion { get; set; }
        public String IdProductoBoni { get; set; }
        public String CantidadBoni { get; set; }
        public String Stock { get; set; }
        public String NombrePro { get; set; }
        public String Imagen { get; set; }
    }
}