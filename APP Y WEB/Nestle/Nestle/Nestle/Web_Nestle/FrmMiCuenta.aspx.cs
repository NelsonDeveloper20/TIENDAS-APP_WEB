using DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Nestle
{
    public partial class FrmMiCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Page.IsPostBack == false)
            {
                misdatos();

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

        public void misdatos() {
            DataTable dt = new DataTable();
            Usuario OBJ = new Usuario();
            dt = OBJ.ListarUsuariosXID(Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));

            foreach (DataRow item in dt.Rows)
            {
                //if (item["IdSubPerfil"].ToString().ToString() != "")
                //{

                //    ddlSubPerfil.SelectedValue = item["IdSubPerfil"].ToString().ToString();
                //}
                LblNombre.Text= item["Nombre"].ToString().ToString().ToUpper() +" " + item["ApellidoPaterno"].ToString().ToString().ToUpper();
                TxtNombre.Value = item["Nombre"].ToString().ToString();
                TxtPaterno.Value = item["ApellidoPaterno"].ToString().ToString();
                TxtMaterno.Value = item["ApellidoMaterno"].ToString().ToString();
                TxtUsuario.Value = item["Usuario"].ToString().ToString();
                TxtPassword.Value = item["Clave"].ToString().ToString();

            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Nombre"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                TxtNombre.Focus();
                return;
            }
            if (TxtPaterno.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Apellido Paterno"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                TxtPaterno.Focus();
                return;
            }
            if (TxtMaterno.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Apellido Materno"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                TxtMaterno.Focus();
                return;
            }
            if (TxtUsuario.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Usuario"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                TxtPassword.Focus();
                return;
            }
            if (TxtPassword.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Contraseña"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                TxtPassword.Focus();
                return;
            }
            
            Usuario OBJ = new Usuario();
            
            int idUsuario = OBJ.ModificarUsuario(Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]),
                Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdSubPerfil"]), TxtNombre.Value,
                TxtPaterno.Value, TxtPaterno.Value, TxtUsuario.Value, 
                TxtPassword.Value, 1,
                Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));
            if (idUsuario > 0)
            {

                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Se Modificó Correctamente"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                misdatos();

            }
            misdatos();
        }

        #region METODO SERVICIE M  NELSON :)
        [System.Web.Services.WebMethod]   // Marcamos el método como uno web
      
        public static List<Usuario_dato> Modfic_master(String idUsuario, Int32 IdMasterMenu)
    {

            List<Usuario_dato> datosuser = new List<Usuario_dato>();
            String Msj = "";
            Categoria objj = new Categoria();
            Msj = objj.MenuMaster(Convert.ToInt32(idUsuario), Convert.ToInt32(IdMasterMenu));
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Mensjae");

            DataRow row1 = tabla.NewRow();
            row1["Mensjae"] = Msj.ToString().Trim();
            tabla.Rows.Add(row1);
            foreach (DataRow row in tabla.Rows)
            {
                Usuario_dato Serv = new Usuario_dato();
                Serv.Mensaje = row["Mensjae"].ToString();
                datosuser.Add(Serv);
            }

            return datosuser;
        }
        public class Usuario_dato
        {
            public int Id { get; set; }
            public String Nombre { get; set; }
            public String Imagen { get; set; }
            public String Mensaje { get; set; }
        }
        #endregion
    }
}