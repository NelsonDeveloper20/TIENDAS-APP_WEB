using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class Categoria
    {
        public String IdCategoria  { get; set; } 
        public String IdUp { get; set; } 
        public String Stock { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public String Precio { get; set; }
        public String Peso { get; set; }
        public String Imagen { get; set; }
    }
}