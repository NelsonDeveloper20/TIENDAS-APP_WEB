using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DB;
namespace Xpress
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                Response.Cookies["WebNestle"].Expires = DateTime.Now.AddDays(-5);
                Response.Cookies["WebNestle"]["DLIdUsuario"] = "";
                Response.Cookies["WebNestle"]["DLUsuario"] = "";
                Response.Cookies["WebNestle"]["DLNombre"] = "";
                Response.Cookies["WebNestle"]["DLApe"] = "";
                Response.Cookies["WebNestle"]["DLIdCliente"] = "";
                Response.Cookies["WebNestle"]["DLApellidoPaterno"] = "";
                Response.Cookies["WebNestle"]["DLIdPerfil"] = "";
                Response.Cookies["WebNestle"]["DLIdSubPerfil"] = "";
                Response.Cookies["WebNestle"]["DLIdEmpresaMaster"] = "";
                Response.Cookies["WebNestle"]["DLTipoAcceso"] = "";
            }
        }

        protected void btnRegistro_Click1(object sender, EventArgs e)
        {
          
            if (txtuser.Value.Trim() == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Usuario"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
               txtuser.Focus();
                return;
            }
            if (txtpassword.Value.Trim() == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Contraseña"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                txtpassword.Focus();
                return;
            }


            Usuario obj = new Usuario();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            dt = obj.ValidarAccesoUsuario(txtuser.Value.Trim(), txtpassword.Value.Trim());

            if (dt.Rows.Count > 0)
            {

                Response.Cookies["WebNestle"]["DLIdUsuario"] = dt.Rows[0]["IdUsuario"].ToString();
                Response.Cookies["WebNestle"]["DlFormMaster"] = dt.Rows[0]["idTipoMaster"].ToString();
                Response.Cookies["WebNestle"]["DLUsuario"] = dt.Rows[0]["Usuario"].ToString();
                Response.Cookies["WebNestle"]["DLNombre"] = dt.Rows[0]["Nombre"].ToString();
                Response.Cookies["WebNestle"]["DLApe"] = dt.Rows[0]["ApellidoPaterno"].ToString();
                Response.Cookies["WebNestle"]["DLIdCliente"] = dt.Rows[0]["idCliente"].ToString();
                Response.Cookies["WebNestle"]["DLApellidoPaterno"] = dt.Rows[0]["ApellidoPaterno"].ToString();
                Response.Cookies["WebNestle"]["DLIdPerfil"] = dt.Rows[0]["IdPerfil"].ToString();
                Response.Cookies["WebNestle"]["DLIdSubPerfil"] = dt.Rows[0]["IdSubPerfil"].ToString();
                Response.Cookies["WebNestle"]["DLIdEmpresaMaster"] = dt.Rows[0]["IdDistribuidor"].ToString();
                Response.Cookies["WebNestle"]["DLTipoAcceso"] = "FrmLoginBO";

                Response.Redirect("Home.aspx");
            }
            else
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Acceso Negado"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
               return;
            }
        }
    }
}