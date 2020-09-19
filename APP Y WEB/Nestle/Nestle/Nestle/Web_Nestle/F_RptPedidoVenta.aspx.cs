using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.Data;
using System.Globalization;

namespace Web_Nestle
{
    public partial class F_RptPedidoVenta : System.Web.UI.Page
    {
        Pedido objp = new Pedido();

        Reportes obj = new Reportes();
        protected void Page_Load(object sender, EventArgs e)
        {try
            {

            if (Page.IsPostBack == false)
            {
                DateTime thisDay = DateTime.Today;
                TxtFechaInicio.Value = thisDay.ToString("dd/MM/yyyy");
                TxtFecFin.Value = thisDay.ToString("dd/MM/yyyy");
                listarUsuario();
                mostrar();
                //pnlFiltro.Visible = false;
            }

            }catch(Exception ex)
            {

            }
        }
        void listarUsuario()
        {
            DDUsuario.DataSource = objp.listarUsuario();
            DDUsuario.DataTextField = "Nombre";
            DDUsuario.DataValueField = "CodigoTxt";
            DDUsuario.DataBind();
            DDUsuario.Items.Insert(0, new ListItem("--Todos--", "0"));

            DDBodega.Items.Insert(0, new ListItem("--Todos--", "0"));

            DDTipoFiltro.DataSource = obj.ListarTipoFiltro();
            DDTipoFiltro.DataTextField = "Descripcion";
            DDTipoFiltro.DataValueField = "idTipoFiltroDia";
            DDTipoFiltro.DataBind();
            
        }
        public void mostrar()
        {

            DataTable dt = new DataTable();

            DateTime FechaFinal = Convert.ToDateTime(TxtFecFin.Value, new CultureInfo("es-ES"));
            FechaFinal = FechaFinal.AddDays(1);
            string FechaSalida = FechaFinal.ToString("dd/MM/yyyy");
            dt = obj.RtptGraficoVenta(TxtFechaInicio.Value.ToString(), FechaSalida.ToString(),
                Convert.ToInt32(DDDia.SelectedValue.ToString()),
                DDUsuario.SelectedValue.ToString(), DDBodega.SelectedValue.ToString(),Convert.ToInt32(DDTipoFiltro.SelectedValue));

            Decimal monto_n = 0;
            Decimal UltimosTres = 0;
            Decimal TotalSugerido = 0;
            Decimal MontoVenta = 0;
            try { 
            foreach (DataRow row in dt.Rows)
            {
                
                UltimosTres = Convert.ToDecimal(row["MontoSugerido"].ToString());
                TotalSugerido = Convert.ToDecimal(row["Monto"].ToString());
                MontoVenta = Convert.ToDecimal(row["MontoTotal"].ToString());
                    try { 
                monto_n = Convert.ToDecimal(row["Procent"].ToString());
                    }catch(Exception ex) { }

                }
            }catch(Exception ex)
            {

            }
            String msj = "rpt";
            string script = @"<script type=text/javascript> porcentaje('" + monto_n + "','" + UltimosTres + "','" + TotalSugerido + "','" + MontoVenta + "')</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "piechart", script, false);
        }
        protected void BntBuscar_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        protected void DDUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDUsuario.SelectedValue != "0")
            {
                DDBodega.DataSource = objp.listarUsuarioClientes(DDUsuario.SelectedValue.ToString());
                DDBodega.DataTextField = "Nombre";
                DDBodega.DataValueField = "CodigoTxt";
                DDBodega.DataBind();
                DDBodega.Items.Insert(0, new ListItem("--Todos--", "0"));
            }
      
        }

        protected void DDDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DDDia.SelectedValue != "0")
            {
                pnlFiltro.Visible = false;
                PnlDia.Attributes.Remove("class");
                PnlDia.Attributes.Add("class", "form-group col-md-12");
            }
            else
            {
                pnlFiltro.Visible = true;

                PnlDia.Attributes.Remove("class");
                PnlDia.Attributes.Add("class", "form-group col-md-6");
            }
        }
    }
}