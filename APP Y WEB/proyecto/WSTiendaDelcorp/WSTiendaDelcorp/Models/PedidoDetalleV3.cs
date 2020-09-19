using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class PedidoDetalleV3
    {
        public String IdUsuario { get; set; }
        public String CodigoTxt { get; set; }
        public String IdCondicionVenta { get; set; }
        public String IdUsuarioVenta { get; set; }
        public String TotalPagar { get; set; }
        public String Items { get; set; }
        public String Latitud { get; set; }
        public String Longitud { get; set; }
        public String FlagTipoRegistro { get; set; }
        public String Fecha { get; set; }
        public String IdOrigen { get; set; }

        public String IdProductoTxt { get; set; }
        public String NombrePro { get; set; }
        public String Precio { get; set; }
        public String Cantidad { get; set; }
        public String SubTotal { get; set; }
        public String Imagen { get; set; }

        public String IdPromocion { get; set; }
        public String IdCondicion { get; set; }
        public String IdBonificacion { get; set; }
    }
}