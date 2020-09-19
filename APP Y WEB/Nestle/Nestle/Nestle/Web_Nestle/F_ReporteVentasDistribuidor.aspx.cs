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
    public partial class F_ReporteVentasDistribuidor : System.Web.UI.Page
    {
        Pedido obj = new Pedido();
        Double grdTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try {
                if (Page.IsPostBack == false)
                {
                    DateTime thisDay = DateTime.Today;
                    TxtFechaInicio.Value = thisDay.ToString("dd/MM/yyyy");
                    TxtFecFin.Value = thisDay.ToString("dd/MM/yyyy");
                    BtnExportar.Visible = false;

                    listas();
                    Buscar();


                }
            } catch (Exception es)
            {

            }

        }
        void listas()
        {
            DDVendedor.DataSource = obj.ListaVendedor();
            DDVendedor.DataTextField = "Nombre";
            DDVendedor.DataValueField = "ID";
            DDVendedor.DataBind();
            DDVendedor.Items.Insert(0, new ListItem("--TODOS--", "0"));
            //LsVendedor.DataSource = obj.ListaVendedor();
            //LsVendedor.DataTextField = "Nombre";
            //LsVendedor.DataValueField = "ID";
            //LsVendedor.DataBind();
            //LsVendedor.Items.Insert(0, new ListItem("--TODOS--", "0"));
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
            try
            {
               
                DateTime FechaFinal = Convert.ToDateTime(TxtFecFin.Value, new CultureInfo("es-ES"));
                FechaFinal = FechaFinal.AddDays(1);
                string FechaSalida = FechaFinal.ToString("dd/MM/yyyy");
                GvReporte.DataSource = obj.ListarReporteVentaDistribuidor(TxtFechaInicio.Value.ToString(), FechaSalida.ToString(),
                    Convert.ToString(DDVendedor.SelectedValue));
                GvReporte.DataBind();
                if (GvReporte.Rows.Count < 1)
                {
                    BtnExportar.Visible = false;
                }
                else
                {
                    BtnExportar.Visible = true;
                }
            }catch(Exception ex) { }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Buscar();
        }
      
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //GvDetalle.DataSource = dt;
            //GvDetalle.DataBind();

            //DataTable dt_det = new DataTable();
            //dt_det= obj.DetallePedidoXId(Convert.ToInt32(HndIdPedido.Value));
            //GvDetalle.Columns[3].FooterText = "TOTAL S/.";
            //GvDetalle.Columns[4].FooterText = dt_det.AsEnumerable().Select(x => x.Field<Decimal>("SubTotal")).Sum().ToString();
            //GvDetalle.DataSource = dt_det;
            //GvDetalle.DataBind();        

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
            //"<script>$('#myModal3').modal('show');</script>", false);


        }
        public void exportar()
        {
            
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename = ReporteVenta.xls");    
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite =
            new HtmlTextWriter(stringWrite);
            GvReporte.RenderControl(htmlWrite);
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
      

    }
}