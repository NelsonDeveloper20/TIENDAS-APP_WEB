using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class PedidoComplementarioDetalle
    {
        public String IdPedido { get; set; }
        public String IdProducto { get; set; }
        public String IdCategoria { get; set; }
        public String IdCategoriaPadre { get; set; }
        public String IdFabricante { get; set; }
        public String NombrePro { get; set; }
        public String Descripcion { get; set; }
        public String Precio { get; set; }
        public String Peso { get; set; }
        public String Imagen { get; set; }
        public String IdAlmacen { get; set; }
        public String Stock { get; set; }
        public String CantComprada { get; set; }
        public String CantSugerido { get; set; }
    }
}