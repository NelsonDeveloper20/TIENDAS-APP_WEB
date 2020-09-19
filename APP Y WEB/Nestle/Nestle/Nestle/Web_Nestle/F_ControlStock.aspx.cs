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
    public partial class F_ControlStock : System.Web.UI.Page
    {
        Control_stock obj = new Control_stock();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try {
            if (Page.IsPostBack == false)
            {
                   
                BtnExportar.Visible = false;
                Buscar();
                    

            }
            }catch (Exception es)
            {

            }

        }
        protected void GvPedido_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string pub_id = GvPromociones.DataKeys[e.Row.RowIndex].Value.ToString();
                try
                {
                    Label txtstoxk = (e.Row.FindControl("LBlStock") as Label);
                    if (txtstoxk.Text == "0")
                    {
                        e.Row.Attributes.Add("class", "pinta_rojo");
                        //e.Row.Cells[3].ForeColor = System.Drawing.Color.Red; 

                    }
                }catch(Exception ex) { }


            }
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

            GV_Pedido.DataSource = obj.ListarStock(TxtBuscarG.Value.ToString());
            GV_Pedido.DataBind();
            if (GV_Pedido.Rows.Count < 1)
            {
                BtnExportar.Visible = false;
            }
            else
            {

                BtnExportar.Visible = true;
            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Buscar();
        }     
    
        public void exportar()
        {

            GridView1.DataSource = obj.ListarStock(TxtBuscarG.Value.ToString());
            GridView1.DataBind();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename = Stock.xls");    
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite =
            new HtmlTextWriter(stringWrite);
            GridView1.RenderControl(htmlWrite);
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

        protected void GV_Pedido_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GV_Pedido.EditIndex = e.NewEditIndex;
            Buscar();
        }

        protected void GV_Pedido_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GV_Pedido.EditIndex = -1;
            Buscar();
        }

        protected void GV_Pedido_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 IdALmacen = Convert.ToInt32(GV_Pedido.DataKeys[e.RowIndex].Values["ID"].ToString());
            GridViewRow row = GV_Pedido.Rows[e.RowIndex];
            TextBox TxtStock = row.FindControl("TxtStock") as TextBox;
            Int32 Stock = 0;
            if (TxtStock.Text == "")
            {
                Stock = 0;

            }
            else
            {
                Stock = Convert.ToInt32(TxtStock.Text.ToString());
            }
            Stock obj = new DB.Stock();

            obj.ModificarSotck(IdALmacen, Stock, Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));
            String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Stock Modificado"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
            GV_Pedido.EditIndex = -1;
            Buscar();
           
        }
    }
}