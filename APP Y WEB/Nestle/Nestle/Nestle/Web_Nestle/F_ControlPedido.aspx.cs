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
    public partial class F_ControlPedido : System.Web.UI.Page
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
                    ultimoCodigo();
                    DateTime thisDay = DateTime.Today;
                    TxtFechaInicio.Value = thisDay.ToString("dd/MM/yyyy");
                    TxtFecFin.Value = thisDay.ToString("dd/MM/yyyy");
                    BtnExportar.Visible = false;
                    BtnExportTxt.Visible = false;
                    BtnExportDetalle.Visible = false;
                    listarUsuario();
                    Buscar();
                    //LblTotalped.Visible = false;

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
        void ultimoCodigo()
        {
            TxtCorrelativo.Value = obj.UltimoCodigo().ToString();
        }
        public void Buscar()
        {
            try
            {
                LblSoles.Text = "";
                LblTotalped.Text = "";
                ultimoCodigo();
                String Totall = "";
                DataTable dt = new DataTable();
                DateTime FechaFinal = Convert.ToDateTime(TxtFecFin.Value, new CultureInfo("es-ES"));
                FechaFinal = FechaFinal.AddDays(1);
                string FechaSalida = FechaFinal.ToString("dd/MM/yyyy");
                dt = obj.ListarPedido(TxtFechaInicio.Value.ToString(), FechaSalida.ToString(), DDUsuario.SelectedValue.ToString().Trim());
                GV_Pedido.DataSource = dt;
                GV_Pedido.DataBind();
                if (GV_Pedido.Rows.Count < 1)
                {
                    BtnExportar.Visible = false;
                    BtnExportTxt.Visible = false;
                    BtnExportDetalle.Visible = false;
                    //LblTotalped.Visible = false;
                }
                else
                {
                    BtnExportTxt.Visible = true;
                    BtnExportDetalle.Visible = true;
                    BtnExportar.Visible = true;


                    LblTotalped.Visible = true;
                }
                LblTotalped.Text = "Total de Pedidos: <span class='badge badge-secondary'>" + dt.Rows.Count.ToString() + "</span>";
            }
            catch (Exception ex)
            {

            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        [System.Web.Services.WebMethod]
        public static Coordenadas ObtenerGps(string IdPedido)
        {


            DataTable Dt = new DataTable();

            String Lat_Ingreso;
            String Long_Ingreso;
            Pedido objj = new Pedido();
            Dt = objj.ListarPedido(Convert.ToInt32(IdPedido));
            Lat_Ingreso = Dt.Rows[0]["Latitud"].ToString();
            Long_Ingreso = Dt.Rows[0]["Longitud"].ToString();
            return new Coordenadas
            {
                _Latitud = Lat_Ingreso,
                _Longitud = Long_Ingreso,
            };
        }
        public class Coordenadas
        {

            public string _Latitud { get; set; }
            public string _Longitud { get; set; }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            GvDetalle.DataSource = dt;
            GvDetalle.DataBind();

            DataTable dt_det = new DataTable();
            dt_det = obj.DetallePedidoXId(Convert.ToInt32(HndIdPedido.Value));
            GvDetalle.Columns[3].FooterText = "TOTAL S/.";
            GvDetalle.Columns[4].FooterText = dt_det.AsEnumerable().Select(x => x.Field<Decimal>("SubTotal")).Sum().ToString();
            GvDetalle.DataSource = dt_det;
            GvDetalle.DataBind();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
            "<script>$('#myModal3').modal('show');</script>", false);


        }
        public void exportar()
        {
            DateTime FechaFinal = Convert.ToDateTime(TxtFecFin.Value, new CultureInfo("es-ES"));
            FechaFinal = FechaFinal.AddDays(1);
            string FechaSalida = FechaFinal.ToString("dd/MM/yyyy");
            GvExport.DataSource = obj.ListarPedido(TxtFechaInicio.Value.ToString(), FechaSalida.ToString(), DDUsuario.SelectedValue.ToString().Trim());
            GvExport.DataBind();
            lblNombre.Text = "CONTROL VENTA DE PEDIDO";
            LblFecha.Text = "FECHA:  " + DateTime.Now.ToString("dd/MM/yyyy");

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Pedido.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            PanelExportarExcel.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();


            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment; filename = Pedido.xls");    
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
        protected void BtnExportar_Click(object sender, EventArgs e)
        {    exportar();        }

        protected void BtnExportar_Click1(object sender, EventArgs e)
        {
            exportar();
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            ultimoCodigo();
            if (TxtCorrelativo.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                swal({
                title: ""Ingrese Codigo Externo"",
                icon: ""warning"",
                dangerMode: false,
                })
                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                return;
            }
            Int32 ConCodigo = 0;

            CodigoExterno = Convert.ToInt32(TxtCorrelativo.Value.ToString());
            CodigoExterno = CodigoExterno - 1;
            DateTime FechaFinal = Convert.ToDateTime(TxtFecFin.Value, new CultureInfo("es-ES"));
            FechaFinal = FechaFinal.AddDays(1);
            string FechaSalida = FechaFinal.ToString("dd/MM/yyyy");
            DataTable dtCebcera = new DataTable();
            dtCebcera = obj.ExporPedidoCabe(TxtFechaInicio.Value.ToString(),
                    FechaSalida.ToString(), Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]), DDUsuario.SelectedValue.ToString().Trim(), ConCodigo);
            //ALMACENO ID DE PEDIDOS
            DataTable dtIdOrden = new DataTable();
            dtIdOrden.Columns.Add("IDOrden", typeof(int));
            foreach (DataRow rows in dtCebcera.Rows)
            {
                DataRow row = dtIdOrden.NewRow();
                row["IDOrden"] = rows["Nro_Pedido_Interno"].ToString();
                dtIdOrden.Rows.Add(row);
            }
            GV_IdPedidos.DataSource = dtIdOrden;
            GV_IdPedidos.DataBind();
            //END
            GvExportTxt.DataSource = dtCebcera;
            GvExportTxt.DataBind();
            DateTime thisDay = DateTime.Now;
            String str, str2, str3, str4;
            str = thisDay.ToString(); //.ToString("dd/MM/yyyy hh:mm:ss");
            str2 = str.Replace("/", "_");
            str3 = str2.Replace(" ", "_");
            str4 = str3.Replace(":", "_");
            str4 = str3.Replace(":", "_");
            String NombreCabecera = "PEDIDO_" + str4 + ".txt";
            String NombreDetalle = "DETALLE_PEDIDO_" + str4 + ".txt";
            String GuardarCabecera = Server.MapPath("~/ExportPedido/" + NombreCabecera);
            String GuardarDetallePedido = Server.MapPath("~/ExportPedido/" + NombreDetalle);

            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(GuardarCabecera))
            {
                String txtFile = string.Empty;
                foreach (GridViewRow row in GvExportTxt.Rows)
                {


                    String TxtCelda = string.Empty;
                    foreach (TableCell cell in row.Cells)
                    {

                        if (cell.Text == "&nbsp;")
                        {
                            cell.Text = "";
                        }
                        TxtCelda += cell.Text + "|";
                    }
                    TxtCelda = TxtCelda.Remove(TxtCelda.Length - 1);
                    txtFile += TxtCelda + "\r\n";
                }
                txtFile = txtFile.Remove(txtFile.Length - 2);
                file.WriteLine(txtFile);
            }
            String IdPedidos = "";
            foreach (GridViewRow rows in GV_IdPedidos.Rows)
            {
                String TxtCelda = string.Empty;
                TxtCelda += rows.Cells[0].Text.ToString() + ",";
                IdPedidos += TxtCelda;
            }
            IdPedidos = IdPedidos.Remove(IdPedidos.Length - 1);
            GvDetalleExport.DataSource = obj.ExporPedidoDetalleXID(IdPedidos.ToString());
            GvDetalleExport.DataBind();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(GuardarDetallePedido))
            {
                String txtFile = string.Empty;
                foreach (GridViewRow row in GvDetalleExport.Rows)
                {

                    String TxtCelda = string.Empty;
                    foreach (TableCell cell in row.Cells)
                    {

                        if (cell.Text == "&nbsp;")
                        {
                            cell.Text = "";
                        }
                        TxtCelda += cell.Text + "|";
                    }
                    TxtCelda = TxtCelda.Remove(TxtCelda.Length - 1);
                    txtFile += TxtCelda + "\r\n";
                }
                txtFile = txtFile.Remove(txtFile.Length - 2);
                String Txt = txtFile.ToString();
                file.WriteLine(txtFile);
            }
        }catch(Exception ex){}
            String stripllamar_N = "<script type='text/javascript'>  window.open('ExportTxt.ashx?filepath="+ NombreCabecera.ToString() + "'); window.open('ExportTxt.ashx?filepath=" + NombreDetalle.ToString() + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", stripllamar_N, false);
            /*
            string txtFile = string.Empty;

            foreach (GridViewRow row in GvExportTxt.Rows)
            {

                String TxtCelda = string.Empty;
                foreach (TableCell cell in row.Cells)
                {

                    if (cell.Text == "&nbsp;")
                    {
                        cell.Text = "";
                    }
                    TxtCelda += cell.Text + "|";
                }
                TxtCelda = TxtCelda.Remove(TxtCelda.Length - 1);
                txtFile += TxtCelda + "\r\n";
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=PEDIDO.txt");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(txtFile);
            Response.Flush();
            Response.End();
            //DETALLE PEDIDO
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
            //"<script>ExportarCabecera();</script>", false);
            */
        }
       #region JAVASCRIPT
        string ExportJavascript(string NombreFuncion, string IdGridview)
        {
            //string sc2 = ExportJavascript("ExportarCabecera", "GvExportTxt");
            //ClientScriptManager cs = Page.ClientScript;
            //cs.RegisterStartupScript(this.GetType(), "ExportarCabecera();", sc2, true);
            string s = "function " + NombreFuncion + "() {" +
                " var userDetails = ''; " +
                " var retString = ''; " +
                " $('#" + IdGridview + " tbody tr').each(function(){  " +
                " var detail=''; " +
                " $(this).find('td').each(function(){ " +
                      " detail+=$(this).html()+'|';" +
                " }); " +
                "detail=detail.substring(0,detail.length-1);" +
                 " detail+=''; " +
                "  userDetails+=detail+'\r\n';" +
                " });" +

                    " var a = document.createElement('a'); " +
                    " var file = new Blob([userDetails], { type: 'text/plain' }); " +
                    " a.href = URL.createObjectURL(file); " +
                    " a.download = 'Pedido.txt'; " +
                    " a.click(); " +
                " } ";
            return s;
        }
        #endregion
  #region
        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            ExportDetalle();
        }
        // Declare variable used to store value of Total
     
        protected void GvDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {

           

        }
#endregion
        #region 
        public void ExportDetalle()
        {
           
            DateTime FechaFinal2 = Convert.ToDateTime(TxtFecFin.Value, new CultureInfo("es-ES"));
            FechaFinal2 = FechaFinal2.AddDays(1);
            string FechaSalida2 = FechaFinal2.ToString("dd/MM/yyyy");
         
            GvDetalleExport.DataSource = obj.ExporPedidoDetalle(TxtFechaInicio.Value.ToString(), FechaSalida2.ToString(),
                Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]), DDUsuario.SelectedValue.ToString().Trim());

            GvDetalleExport.DataBind();



            string txtFile2 = string.Empty;
            foreach (GridViewRow row in GvDetalleExport.Rows)
            {
                String TxtCelda = string.Empty;
                foreach (TableCell cell in row.Cells)
                {
                    if (cell.Text == "&nbsp;")
                    {
                        cell.Text = "";
                    }
                    TxtCelda += cell.Text + "|";
                }
                TxtCelda = TxtCelda.Remove(TxtCelda.Length - 1);
                txtFile2 += TxtCelda + "\r\n";
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=DETALLE_PEDIDO.txt");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(txtFile2);
            Response.Flush();
            Response.End();
        }
        #endregion

        protected void GV_Pedido_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPgTotal = (Label)e.Row.FindControl("lblTotalPrice");
                dPageTotal += Decimal.Parse(lblPgTotal.Text);
            }          
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //if (ViewState["TotalPrice"] != null && dPageTotal != 0)
                //{
                    // PAGE TOTAL.
                    Label lblPageTotal = (Label)e.Row.FindControl("lblPageTotal");
                    lblPageTotal.Text = dPageTotal.ToString("N2");

                LblSoles.Text =  "Total  <span class='badge badge-secondary'>S/. " + dPageTotal.ToString("N2") + "</span>";

                //GRAND TOTAL.
                //Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
                //lblGrandTotal.Text = ViewState["TotalPrice"].ToString();
                //}
            }
        }
        protected void GvExportTxt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {               
              
                Int32 IdPedido;
                DataRowView rowView = (DataRowView)e.Row.DataItem;
                Int32 ConExterno = Convert.ToInt32(rowView["IdPedidoExterno"].ToString());
                Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
                IdPedido = Convert.ToInt32(e.Row.Cells[0].Text.ToString());
                if (ConExterno != 0)
                {
                    e.Row.Cells[0].Text = ConExterno.ToString();
                }
                else
                {

                    CodigoExterno++;
                    e.Row.Cells[0].Text = CodigoExterno.ToString();
                    Int32 CodgioExterno = Convert.ToInt32(e.Row.Cells[0].Text.ToString());
                    obj.UPCodigoExterno(IdPedido, CodgioExterno, IdUsuario);
                }

            }
        }

        // Adición de nombre de columna en archivo de texto.  
        //foreach (TableCell cell in GvExport.HeaderRow.Cells)
        //{
        //    txtFile += cell.Text + "\t\t";
        //}
        //txtFile += "\r\n";
        //Agregar valores de columna de datos en un archivo de texto  

    }
}