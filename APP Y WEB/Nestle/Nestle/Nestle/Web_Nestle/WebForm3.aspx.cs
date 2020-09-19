using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Reflection;
using DB;

namespace Web_Nestle
{
   
    public partial class WebForm3 : System.Web.UI.Page
    {
        Pedido obj = new Pedido();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Item"), new DataColumn("Price") });
                dt.Rows.Add("Shirt", 199);
                dt.Rows.Add("Football", 020);
                dt.Rows.Add("Shirt", 566);
                dt.Rows.Add("Disc", 099);
                dt.Rows.Add("Watch", 54);
                dt.Rows.Add("Clock", 890);
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }

            GridView1.DataSource = obj.ReporteVendedorDistribuidor("", "");

            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String valor = e.Row.Cells[0].Text.ToString().Trim();
                Int32 PorVisitar = Convert.ToInt32(e.Row.Cells[2].Text.ToString().Trim());
                Int32 Visitados = Convert.ToInt32(e.Row.Cells[3].Text.ToString().Trim());
                Decimal Total = (Visitados * 100 / PorVisitar);

                e.Row.Cells[6].Text = Total.ToString();//  Total.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=Export.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    Panel1.RenderControl(hw);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}
            Response.Write("<script> window.open('F_ControlPedido.aspx','_blank'); </script>");
            Response.Write("<script> window.open('F_ControlStock.aspx','_blank'); </script>");
            //for (int i = 0; i < 3; i++)
            //{

            //    Response.Clear();
            //    Response.AddHeader("content-disposition", "attachment;filename=Export.xls");
            //    Response.Charset = "";
            //    Response.ContentType = "application/vnd.ms-excel";
            //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            //    Panel1.RenderControl(htmlWrite);
            //    Response.Write(stringWrite.ToString());
            //    Response.End();

            //}


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
          
        }
    }
}