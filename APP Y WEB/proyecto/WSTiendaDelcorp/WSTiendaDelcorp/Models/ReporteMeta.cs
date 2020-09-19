using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class ReporteMeta
    {
        public String IdMetaMensual { get; set; }
        public String Fecha { get; set; }
        public String Meta { get; set; }
        public String CantDiasMes { get; set; }
        public String MontoDiario { get; set; }
        public String MetaHastaHoy { get; set; }
        public String MontoHastaHoy { get; set; }
        public String cantVentas { get; set; }
        public String DiaHoy { get; set; }
        public String porcenActual { get; set; }

    }
}