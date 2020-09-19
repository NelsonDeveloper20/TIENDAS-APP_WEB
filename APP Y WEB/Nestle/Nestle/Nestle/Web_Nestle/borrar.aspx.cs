using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Nestle
{
    public partial class borrar : System.Web.UI.Page
    {
        Decimal dPageTotal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
   
        private void BindData()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C3NG1OP\SQLEXPRESS01;Initial Catalog=db_TiendaEmpresasss;User ID=nelsonr;Pwd=Bgyz0448"))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT *FROM Books";
                    con.Open();

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);

                    // CALCULATE THE TOTAL PRICE AND HOLD THE VALUE IN A "VIEWSTATE".
                    if (ViewState["TotalPrice"] == null)
                    {
                        Decimal dPrice = 0;
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dPrice += dt.Rows[i].Field<Decimal>(2);
                        }
                        ViewState["TotalPrice"] = dPrice;
                    }
                    // BIND QUERY RESULT WITH THE GRIDVIEW.
                    grd.DataSource = dt; grd.DataBind();
                }
            }
        }

        // GRIDVIEW PAGING.
        protected void grd_PageIndexChanging(object sender,
            System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            BindData();
        }

        // CALCULATE AND SHOW PAGE TOTAL AND GRAND TOTAL WHILE BINDING THE ROWS.
        protected void grd_RowDataBound(object sender,
            System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            // GET THE RUNNING TOTAL OF PRICE FOR EACH PAGE.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPgTotal = (Label)e.Row.FindControl("lblTotalPrice");
                dPageTotal += Decimal.Parse(lblPgTotal.Text);
            }

            // FINALLY, SHOW THE RUNNING AND GRAND TOTAL ON EACH PAGE.
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (ViewState["TotalPrice"] != null && dPageTotal != 0)
                {
                    // PAGE TOTAL.
                    Label lblPageTotal = (Label)e.Row.FindControl("lblPageTotal");
                    lblPageTotal.Text = dPageTotal.ToString("N2");

                    //GRAND TOTAL.
                    Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
                    lblGrandTotal.Text = ViewState["TotalPrice"].ToString();
                }
            }
        }
    }
}