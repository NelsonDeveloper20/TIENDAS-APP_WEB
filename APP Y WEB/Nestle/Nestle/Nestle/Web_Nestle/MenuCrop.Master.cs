using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.Data;
namespace Web_Nestle
{
    public partial class MenuCrop : System.Web.UI.MasterPage
    {
        public DataTable dt = new DataTable();
        public string LinkActual;
        public string IpMaquina;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            string TIPOACCESO;

            HdnIdUsuioo.Text = Request.Cookies["WebNestle"]["DLIdUsuario"].ToString();
            Formulario obj = new Formulario();
           dt = obj.ListaAccesoUsuario(Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));
            if (dt.Rows.Count > 0)
            {
                LblNombre.Text = Request.Cookies["WebNestle"]["DLNombre"];
                HdnIdUsuioo.Text = Request.Cookies["WebNestle"]["DLIdUsuario"].ToString();

            }

        }



    }
}