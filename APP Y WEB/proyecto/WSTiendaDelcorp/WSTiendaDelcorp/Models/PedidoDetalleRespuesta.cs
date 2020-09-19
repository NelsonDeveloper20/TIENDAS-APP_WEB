using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class PedidoDetalleRespuesta
    { 
        public String IdProductoTxt { get; set; } 
        public String NombrePro { get; set; } 
        public String Precio { get; set; } 
        public String Cantidad { get; set; } 
        public String SubTotal { get; set; } 
        public String IdPromocion { get; set; } 
        public String IdCondicion { get; set; } 
        public String IdBonificacion { get; set; } 
        public String Imagen { get; set; }
         
    }
}