using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.Globalization;
using System.Data;

namespace Web_Nestle
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Pedido obj = new Pedido();
        public DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                DateTime FechaFinal = Convert.ToDateTime("04/04/2019", new CultureInfo("es-ES"));
                FechaFinal = FechaFinal.AddDays(1);
                string FechaSalida = FechaFinal.ToString("dd/MM/yyyy");
                //GV_Pedido.DataSource = obj.ListarPedido("04/01/2019", FechaSalida.ToString());
                //GV_Pedido.DataBind();
            }
            Formulario objj = new Formulario();
            dt = objj.ListaAccesoUsuario(Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));
            if (dt.Rows.Count > 0)
            {
                LblNombre.Text = Request.Cookies["WebNestle"]["DLNombre"];

            }
        }
        public void Buscar()
        {

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            GvDetalle.DataSource = dt;
            GvDetalle.DataBind();

            GvDetalle.DataSource = obj.DetallePedidoXId(Convert.ToInt32(HndIdPedido.Value));
            GvDetalle.DataBind();
            //Calculate Sum and display in Footer Row
            decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("SubTota"));
            GvDetalle.FooterRow.Cells[3].Text = "Total";
            GvDetalle.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            GvDetalle.FooterRow.Cells[4].Text = total.ToString("N2");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
            "<script>$('#myModal3').modal('show');</script>", false);


        }
        public void exportar()
        {
            DateTime FechaFinal = Convert.ToDateTime(TxtFecFin.Value, new CultureInfo("es-ES"));
            FechaFinal = FechaFinal.AddDays(1);
            string FechaSalida = FechaFinal.ToString("dd/MM/yyyy");
            //GvExport.DataSource = obj.ListarPedido(TxtFechaInicio.Value.ToString(), FechaSalida.ToString());
            //GvExport.DataBind();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename = Pedido.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite =
            new HtmlTextWriter(stringWrite);
            GvExport.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void BtnExportar_Click(object sender, EventArgs e)
        {
            exportar();
        }

        protected void BtnExportar_Click1(object sender, EventArgs e)
        {
            exportar();
        }

        protected void Btn_hABER_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            GvDetalle.DataSource = dt;
            GvDetalle.DataBind();
            String nm = HndIdPedido.Value.ToString();
            GvDetalle.DataSource = obj.DetallePedidoXId(Convert.ToInt32(HndIdPedido.Value));
            GvDetalle.DataBind();
            //Calculate Sum and display in Footer Row
            decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("SubTota"));
            GvDetalle.FooterRow.Cells[3].Text = "Total";
            GvDetalle.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            GvDetalle.FooterRow.Cells[4].Text = total.ToString("N2");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
          "<script>showPopupFalta();</script>", false);
        }
        protected void GV_Pedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AcctioFalta")
            {
                Int32 Indice = Int32.Parse(e.CommandArgument.ToString());
                Int32 IdMarcacion = Int32.Parse(GV_Pedido.Rows[Indice].Cells[0].Text);
                //Int32 idTrabajdor = Int32.Parse(GV_Pedido.Rows[Indice].Cells[1].Text);
                //Mostrar Popup 
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
         "<script>showPopupFalta();</script>", false);

            }
        }
    }
}