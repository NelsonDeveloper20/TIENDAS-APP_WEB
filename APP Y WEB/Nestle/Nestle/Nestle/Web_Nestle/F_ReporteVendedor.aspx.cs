using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.Data;
using System.IO;
using System.Globalization;

namespace Web_Nestle
{
    public partial class F_ReporteVendedor : System.Web.UI.Page
    {
        Pedido obj = new Pedido();
        Decimal dPageTotal;

        Int32 CodigoExterno = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                if (Page.IsPostBack == false)
                {
                    DateTime thisDay = DateTime.Today;
                    TxtFechaInicio.Value = thisDay.ToString("dd/MM/yyyy");
                    BtnExportar.Visible = false;
                    listarUsuario();
                    Buscar();
                }
            }
            catch (Exception es)
            {

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
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Int32 IdFormMaster = Convert.ToInt32(Request.Cookies["WebNestle"]["DlFormMaster"].ToString());
            if (IdFormMaster == 2)
            {
                this.MasterPageFile = "~/Menu_Header.master";
            }
            else
            { this.MasterPageFile = "~/MenuPrincipal.master"; }
        }
        public void Buscar()
        {
            //try
            //{
            String Totall = "";
            DataTable dt = new DataTable();
            dt = obj.ReporteVendedorDistribuidor(TxtFechaInicio.Value.ToString(), DDUsuario.SelectedValue.ToString().Trim());
            GvReporte.DataSource = dt;
            GvReporte.DataBind();
                if (GvReporte.Rows.Count < 1)
                {
                BtnExportar.Visible = false;
               
                }
                else
                {                  
                BtnExportar.Visible = true;
                }
            //}catch(Exception ex)
            //{

            //}

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Buscar();
        }
     
        public void exportar()
        {

            GvExport.DataSource = obj.ReporteVendedorDistribuidor(TxtFechaInicio.Value.ToString(),DDUsuario.SelectedValue.ToString().Trim());
            GvExport.DataBind();
            lblNombre.Text = "REPORTE VENTA POR VENDEDOR";
            LblFecha.Text = "FECHA:  " + DateTime.Now.ToString("dd/MM/yyyy");

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=ReporteVendedor.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            PanelExportarExcel.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();


            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment; filename = ReporteVendedor.xls");    
            //Response.ContentType = "application/vnd.xls";
            //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWrite =
            //new HtmlTextWriter(stringWrite);
            //GvExport.RenderControl(htmlWrite);
            //Response.Write(stringWrite.ToString());
            //Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        

        protected void BtnExportar_Click1(object sender, EventArgs e)
        {
            exportar();
        }
     
        // Declare variable used to store value of Total
     
        protected void GvDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {          

        }

        protected void GvReporte_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String valor = e.Row.Cells[0].Text.ToString().Trim();
                Int32 PorVisitar =Convert.ToInt32(e.Row.Cells[2].Text.ToString().Trim());
                Int32 Visitados = Convert.ToInt32(e.Row.Cells[3].Text.ToString().Trim());
                Decimal Total = (Visitados * 100/ PorVisitar);
             /*   LiteralControl ltr = new LiteralControl();
                TableCell slice1 = new TableCell();
                var deg = 360 / 100 * Total;
                slice1.Style.Value = " '-moz-transform': 'rotate(' " + deg + "'deg)';'-webkit-transform': 'rotate('  " + deg + " 'deg)';'-o-transform': 'rotate('  " + deg + " 'deg)';    'transform': 'rotate('  " + deg + " 'deg)'";
               TableCell fill1 = new TableCell();
                fill1.Style.Value = "'-moz-transform': 'rotate(' " + deg + " 'deg)';'-webkit-transform': 'rotate(' " + deg + " 'deg)';'-o-transform': 'rotate('  " + deg + " 'deg)';    'transform': 'rotate('  " + deg + " 'deg)'";
                
                String sle = "";
                String fill = "";
                if (Total > 50)
                {
                    sle = "slice gt50";
                    fill = "pie fill";
                }
                else
                {
                    sle = "slice";
                    fill = "";
                }

                String PasarValor = @"<div class='percent'>" + Total.ToString() + "%</div><div class='pieBack'></div>" +
      @"<div class='"+ sle + " gt50'>"+
    @"<div class='pie' style='transform: rotate(" + deg + "deg);'>" +
@"</div><div class='"+ fill + "' style='transform: rotate(" + deg + "deg);'></div></div>";

                */
                e.Row.Cells[6].Text = Total.ToString();//  Total.ToString();
            }

        }
    }
}