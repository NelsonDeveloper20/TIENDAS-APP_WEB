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
    public partial class F_MantenimientoUsuario : System.Web.UI.Page
    {
        Usuario Obj_usu = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (IsPostBack == false)
            {
               
                PanelAgregar.Visible = false;
                PanelListar.Visible = true;
                CargaSubPerfil();
                ListarEmpresaCombo();
                ////Empresa = validaUsuario();
               
                ListarUsuario();
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
        public void ListarEmpresaCombo()
        {
           
            DataTable dt = new DataTable();
            //Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdEmpresaMaster"])
            dt = Obj_usu.ListarEmpresa();
            ddlEmpresa.DataSource = dt;
            ddlEmpresa.DataTextField = "NombreCliente";
            ddlEmpresa.DataValueField = "idCliente";
            ddlEmpresa.DataBind();


        }
        public void CargaSubPerfil()
        {
            SubPerfil OBJ = new SubPerfil();
            DataTable dt = new DataTable();

            dt = OBJ.ListarSubPerfil(1);
            ddlSubPerfil.DataSource = dt;
            ddlSubPerfil.DataTextField = "Descripcion";
            ddlSubPerfil.DataValueField = "IdSubPerfil";
            ddlSubPerfil.DataBind();

            ddlSubPerfil.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
        }
        

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            if (txtNombre.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Nombre"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                txtNombre.Focus();
                return;
            }
            if (txtUsuario.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Usuario"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                txtUsuario.Focus();
                return;
            }
            if (txtContraseña.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Contraseña"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                txtContraseña.Focus();
                return;
            }


            if (ddlSubPerfil.SelectedValue == "0")
            {
                String mensajeScriptnms = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Seleccionar tipo de perfil web"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnms, false);
                ddlSubPerfil.Focus();
                return;
            }



            //  Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdEmpresaMaster"])
            Usuario OBJ = new Usuario();
                // String CodigoTxt,Int32 TipoUsuario,Int32 TipoAcceso,Int32 IdEmpresa,String Direccion
                int idUsuario = OBJ.AgregarUsuario(Convert.ToInt32(ddlSubPerfil.SelectedValue), 1, txtNombre.Value,
                    txtAPMaterno.Value, txtApPaterno.Value, txtUsuario.Value, txtContraseña.Value,
                    Convert.ToInt32(ddlEstado.SelectedValue), Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"])  );
                
            if (idUsuario > 0)
            {
                ListarUsuario();
                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Registrado Correctamente"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);

              
              
            }
            PanelAgregar.Visible = false;
            PanelListar.Visible = true;

            hdIdUsuario.Value = "";
            txtNombre.Value = "";
            txtApPaterno.Value = "";
            txtAPMaterno.Value = "";
            txtUsuario.Value = "";
            txtContraseña.Value = "";
            ListarUsuario();
        }
        private void ListarUsuario()
        {
            Int32 estado = 0;
            if (chksuc.Checked == true)
            {
                estado = 1;
            }
            else if (chksuc.Checked == false)
            {
                estado = 0;
            }
           
            DataTable dt = new DataTable();
            Usuario OBJ = new Usuario();
            dt = OBJ.ListarUsuarios(Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdEmpresaMaster"]), estado,TxtBuscarG.Value.ToString());
            grUsuario.DataSource = dt;
            grUsuario.DataBind();

        }
        protected void btnMOdificar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Nombre"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                txtNombre.Focus();
                return;
            }
            if (txtUsuario.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Usuario"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                txtUsuario.Focus();
                return;
            }
            if (txtContraseña.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Contraseña"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                txtContraseña.Focus();
                return;
            }
            
                if (ddlSubPerfil.SelectedValue == "0")
                {
                    String mensajeScriptnms = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Seleccionar tipo de perfil web"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnms, false);
                    ddlSubPerfil.Focus();
                    return;
                }

                
            Usuario OBJ = new Usuario();
            //Se debe reemplazar el usucrea y el idusuario
            int idUsuario = OBJ.ModificarUsuario(Convert.ToInt32(hdIdUsuario.Value), Convert.ToInt32(ddlSubPerfil.SelectedValue),
                txtNombre.Value, txtAPMaterno.Value, txtApPaterno.Value, 
                txtUsuario.Value, txtContraseña.Value, Convert.ToInt32(ddlEstado.SelectedValue),
                Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));
            if (idUsuario > 0)
            {
                ListarUsuario();
                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Se Modifico Correctamente el usuario"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);

                PanelAgregar.Visible = false;
                PanelListar.Visible = true;

                hdIdUsuario.Value = "";
                txtNombre.Value = "";
                txtApPaterno.Value = "";
                txtAPMaterno.Value = "";
                txtUsuario.Value = "";
                txtContraseña.Value = "";
                ListarUsuario();

            }
        }

        protected void grUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Indice = int.Parse(e.CommandArgument.ToString());
            int idUsuario = int.Parse(grUsuario.Rows[Indice].Cells[0].Text);
            if (e.CommandName == "Eliminar")
            {

                Usuario OBJ = new Usuario();
                int resultado = OBJ.EliminarUsuario(idUsuario, 5);//POner el usuario de session que modificara

                if (resultado > 0)
                {
                    ListarUsuario();
                    ClientScript.RegisterStartupScript(Page.GetType(), "Mensaje", "<script type='text/javascript'>alert('Se Elimino el usuario');</script>");
                    return;
                }

            }

            if (e.CommandName == "Editar")
            {
                DataTable dt = new DataTable();

                Usuario OBJ = new Usuario();
                dt = OBJ.ListarUsuariosXID(idUsuario);

                foreach (DataRow item in dt.Rows)
                {
                    if (item["IdSubPerfil"].ToString().ToString() != "")
                    {

                        ddlSubPerfil.SelectedValue = item["IdSubPerfil"].ToString().ToString();
                    }
                    txtNombre.Value = item["Nombre"].ToString().ToString();
                    txtApPaterno.Value = item["ApellidoPaterno"].ToString().ToString();
                    txtAPMaterno.Value = item["ApellidoMaterno"].ToString().ToString();
                    txtUsuario.Value = item["Usuario"].ToString().ToString();
                    txtContraseña.Value = item["Clave"].ToString().ToString();
                    ddlEstado.SelectedValue = item["EstadoInt"].ToString().ToString();
                }
                //--Botones 
                
                btnModificar_fr.Visible = true;
                btnRegistro_frm.Visible = false;
                //hidden iddireccion
                hdIdUsuario.Value = idUsuario.ToString();

                PanelAgregar.Visible = true;
                PanelListar.Visible = false;
                //ClientScript.RegisterStartupScript(Page.GetType(), "Mensaje", "<script type='text/javascript'>alert('Se Actualizo la direccion correctamente');</script>");
                //return;

            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            PanelAgregar.Visible = false;
            PanelListar.Visible = true;

            hdIdUsuario.Value = "";
            txtNombre.Value = "";
            txtApPaterno.Value = "";
            txtAPMaterno.Value = "";
            txtUsuario.Value = "";
            txtContraseña.Value = "";
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            ListarUsuario();
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            PanelAgregar.Visible = true;
            PanelListar.Visible = false;
            
            btnModificar_fr.Visible = false;
            btnRegistro_frm.Visible = true;

        
        }
        protected void chksuc_CheckedChanged(object sender, EventArgs e)
        {

        }
      
    }
}