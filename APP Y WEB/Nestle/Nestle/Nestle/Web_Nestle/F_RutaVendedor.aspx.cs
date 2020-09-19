using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
namespace Web_Nestle
{
    public partial class F_RutaVendedor : System.Web.UI.Page
    {
        Pedido obj = new Pedido();
        Ruta objRuta = new Ruta();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                listarUsuario();
                listarRuta();
            }
        }
        void listarUsuario()
        {
            DDUsuario.DataSource = obj.listarUsuario();
            DDUsuario.DataTextField = "Nombre";
            DDUsuario.DataValueField = "CodigoTxt";
            DDUsuario.DataBind();
            DDUsuario.Items.Insert(0, new ListItem("--Todos--", "0"));
        }
        void listarRuta()
        {
            GvRutas.DataSource = objRuta.listarRutaVendedor(DDUsuario.SelectedValue.ToString(), Convert.ToInt32(DDDia.SelectedValue));
            GvRutas.DataBind();
        }

        protected void Bntrefresh_Click(object sender, EventArgs e)
        {
            listarRuta();
        }

        protected void GvRutas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Int32 Columanas = e.Row.Cells.Count;
            //    Int32 TotalColumna = Columanas;// - 1;
            //    for (Int16 i = 0; i < TotalColumna; i++)
            //    {
            //        if (i >= 4)
            //        {
            //            e.Row.Cells[i].Attributes.Add("pointer-events:", "none");  
            //        }
            //    }
            
            //}
        }
    }
}