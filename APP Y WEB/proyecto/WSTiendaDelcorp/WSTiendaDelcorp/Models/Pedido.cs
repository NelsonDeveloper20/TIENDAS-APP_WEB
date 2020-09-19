using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class Pedido
    {
        public String IdPedido { get; set; }
        public String IdUsuario { get; set; }
        public String NomCliente { get; set; }
        public String IdCondicionVenta { get; set; }
        public String IdUsuarioVenta { get; set; }
        public String TotalPagar { get; set; }
        public String Cantidad { get; set; }
        public String Latitud { get; set; }
        public String Longitud { get; set; }
        public String Fecha { get; set; }
        public String FecCrea { get; set; }
}
}