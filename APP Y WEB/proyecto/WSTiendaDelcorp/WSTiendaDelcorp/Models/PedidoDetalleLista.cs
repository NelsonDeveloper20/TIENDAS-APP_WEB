using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class PedidoDetalleLista
    { 
        public String IdPedidoDetalle { get; set; }
        public String IdProducto { get; set; }
        public String NombrePro { get; set; }
        public String Precio { get; set; }
        public String Cantidad { get; set; }
        public String SubTotal { get; set; }
        public String Imagen { get; set; }
    }
}