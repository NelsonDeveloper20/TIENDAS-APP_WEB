using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class CondicionBonificacion
    {
        public String IdPromocionCondicion { get; set; }
        public String IdPromocionBonificacion { get; set; }
        public String IdPromocion { get; set; }
        public String IdProducto { get; set; }
        public String IdCategoria { get; set; }
        public String IdGrupo { get; set; }
        public String Cantidad { get; set; }
        public String Descripcion { get; set; }
        public String Stock { get; set; }


    }
}