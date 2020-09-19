using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class PedidoComplementario
    {
        public String IdPedido { get; set; }
        public String IdUsuario { get; set; }
        public String nomUsuario { get; set; }
        public String montoComprado { get; set; }
        public String montoSugerido { get; set; }
        public String celular { get; set; }
    }
}