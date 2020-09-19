using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class ProductoV2
    {
        public String IdProductoCategoria { get; set; }
        public String IdProductoTxt { get; set; }
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
        public String visible { get; set; }
    }
}