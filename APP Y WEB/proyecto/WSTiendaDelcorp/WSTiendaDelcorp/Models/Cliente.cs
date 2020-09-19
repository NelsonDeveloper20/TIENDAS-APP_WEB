using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class Cliente
    {
        public String CodigoTxt { get; set; }
        public String Nombre { get; set; }
        public String Paterno { get; set; }
        public String Materno { get; set; }
        public String Direccion { get; set; }
        public String Latitud { get; set; }
        public String Longitud { get; set; }
        public String DiasVisita { get; set; }
        public String ActivaTotalClientes { get; set; }
        public String VisitadoHoy { get; set; }
    }
}