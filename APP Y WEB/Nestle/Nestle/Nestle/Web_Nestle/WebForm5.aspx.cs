using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Nestle
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        Pedido obj = new Pedido();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            dp1.Value = thisDay.ToString("yyyy-mm-dd");


            GridView1.DataSource = obj.ReporteVendedorDistribuidor("","");

            GridView1.DataBind();
            
        }
    }
}