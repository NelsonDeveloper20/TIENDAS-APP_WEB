using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.Data;
using System.Text.RegularExpressions;

namespace Web_Nestle
{
    public partial class F_MantenimientoUsuarioCliente : System.Web.UI.Page
    {
        Usuario Obj_usu = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (IsPostBack == false)
            {
               
                PanelAgregar.Visible = false;
                PanelListar.Visible = true;
               // CargaSubPerfil();
                ListarEmpresaCombo();
                ////Empresa = validaUsuario();
               
                ListarUsuario();
            }
            }
            catch (Exception ex)
            {

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
            Subir_txt OBJJ = new Subir_txt();
            DDTipo.DataSource = OBJJ.ListarTipoUsuario();
            DDTipo.DataTextField = "Descripcion";
            DDTipo.DataValueField = "IdTipoUsuario";
            DDTipo.DataBind();
            DDTipo.Items.Insert(0, new ListItem("Seleccione..", "0"));

            DataTable dt = new DataTable();
            //Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdEmpresaMaster"])
            dt = Obj_usu.ListarEmpresa();
            ddlEmpresa.DataSource = dt;
            ddlEmpresa.DataTextField = "NombreCliente";
            ddlEmpresa.DataValueField = "idCliente";
            ddlEmpresa.DataBind();
            Subir_txt objk = new Subir_txt();
            DDTipoUsuario.DataSource = objk.ListarTipoUsuario3();
            DDTipoUsuario.DataTextField = "Descripcion";
            DDTipoUsuario.DataValueField = "IdTipoUsuario";
            DDTipoUsuario.DataBind();
            DDTipoUsuario.Items.Insert(0, new ListItem("Seleccione...","0"));



            DDTipoAcceso.DataSource = Obj_usu.listarTipoAcceso();
            DDTipoAcceso.DataTextField = "Desripcion";
            DDTipoAcceso.DataValueField = "IdTipoAcceso";
            DDTipoAcceso.DataBind();
            DDTipoAcceso.Items.Insert(0, new ListItem("Seleccione...", "0"));


        }
        public void CargaSubPerfil()
        {
            //SubPerfil OBJ = new SubPerfil();
            //DataTable dt = new DataTable();

            //dt = OBJ.ListarSubPerfil(1);
            //ddlSubPerfil.DataSource = dt;
            //ddlSubPerfil.DataTextField = "Descripcion";
            //ddlSubPerfil.DataValueField = "IdSubPerfil";
            //ddlSubPerfil.DataBind();
            //ddlSubPerfil.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
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

            if (DDTipoUsuario.SelectedValue == "0")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Seleccionar Tipo Usuario"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                DDTipoUsuario.Focus();
                return;
            }
           
                if (DDTipoAcceso.SelectedValue == "0") { 
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Seleccionar Tipo Acceso"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                    DDTipoAcceso.Focus();
                return;
                }
                if (ddlEmpresa.SelectedValue == "0")
                {

                    String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Seleccionar Empresa"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                    ddlEmpresa.Focus();
                    return;
                }
            

            Int32 IdtipoUsuario =Convert.ToInt32(DDTipoUsuario.SelectedValue);
            Int32 IdTipoAcceso = Convert.ToInt32(DDTipoAcceso.SelectedValue);
            //Int32 IdPerfilUsuario = Convert.ToInt32(ddlSubPerfil.SelectedValue);


            //  Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdEmpresaMaster"])
            Usuario OBJ = new Usuario();


            if (TxtCodigoTxt.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Codigo Txt"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                TxtCodigoTxt.Focus();
                return;
            }

            Int32 flagvalidadato=0;
            if (ChkValida.Checked == true)
            {
                flagvalidadato = 0;
            }else
            {
                flagvalidadato = 1;
            }

            String Msj = "";
            Msj = OBJ.InsertarUsuariosApp(Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdEmpresaMaster"]), TxtCodigoTxt.Value.ToString().Trim(),
                Convert.ToInt32(DDTipoUsuario.SelectedValue), Convert.ToInt32(DDTipoAcceso.SelectedValue), Convert.ToInt32(ddlEmpresa.SelectedValue)
                , txtNombre.Value.ToString().Trim().ToUpper(), txtApPaterno.Value.ToString().Trim().ToUpper(), txtAPMaterno.Value.ToString().Trim().ToUpper(),
                txtUsuario.Value.ToString().Trim().ToUpper(), txtContraseña.Value.ToString().Trim().ToUpper(), TxtDireccion.Value.ToString(),
                TxtCodigoCanal.Value.ToString(), TxtGiro.Value.ToString(), Convert.ToInt32(ddlEstado.SelectedValue), Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]), flagvalidadato);


                
            if (Msj == "insertado")
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

                hdIdUsuario.Value = "";
                txtNombre.Value = "";
                txtApPaterno.Value = "";
                txtAPMaterno.Value = "";
                txtUsuario.Value = "";
                txtContraseña.Value = "";
                PanelAgregar.Visible = false;
                PanelListar.Visible = true;
                ListarUsuario();
                return;
            }else
            {
                string menssajeScript = "<script type='text/javascript'>"
                          + " swal({" +

                  "title: '" + Msj.ToString() + "'," +
                   " icon: 'warning'," +
                  "  dangerMode: true," +
             "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }

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

            String input = TxtBuscarG.Value;
            String pattern = " ";
            String replacement = "%";
            String result = Regex.Replace(input, pattern, replacement);

            DataTable dt = new DataTable();
            Usuario OBJ = new Usuario();
            GvApp.DataSource = OBJ.ListarUsuarioApp(Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdEmpresaMaster"]), estado, result.ToString(),
              Convert.ToInt32(DDTipo.SelectedValue));
            GvApp.DataBind();

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


            if (DDTipoUsuario.SelectedValue == "0")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Seleccionar Tipo Usuario"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                DDTipoUsuario.Focus();
                return;
            }

            if (TxtCodigoTxt.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Codigo Txt"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                TxtCodigoTxt.Focus();
                return;
            }




            if (DDTipoAcceso.SelectedValue == "0")
                {
                    String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Seleccionar Tipo Acceso"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                    DDTipoAcceso.Focus();
                    return;
                }
                if (ddlEmpresa.SelectedValue == "0")
                {

                    String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Seleccionar Empresa"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                    ddlEmpresa.Focus();
                    return;
                }
            if (TxtCodigoTxt.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Codigo Txt"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                TxtCodigoTxt.Focus();
                return;
            }


            Int32 IdtipoUsuario = Convert.ToInt32(DDTipoUsuario.SelectedValue);
            Int32 IdTipoAcceso = Convert.ToInt32(DDTipoAcceso.SelectedValue);
            //Int32 IdPerfilUsuario = Convert.ToInt32(ddlSubPerfil.SelectedValue);
            Int32 IdEmpresa = Convert.ToInt32(ddlEmpresa.SelectedValue);
            Usuario OBJ = new Usuario();
            //Se debe reemplazar el usucrea y el idusuario
            Int32 flagvalidadato = 0;
            if (ChkValida.Checked == true)
            {
                flagvalidadato = 0;
            }
            else
            {
                flagvalidadato = 1;
            }

            String Msj = "";
            Msj = OBJ.ModificarUsuariosApp(Convert.ToInt32(hdIdUsuario.Value), TxtCodigoTxt.Value.ToString().Trim(),
                Convert.ToInt32(DDTipoUsuario.SelectedValue), Convert.ToInt32(DDTipoAcceso.SelectedValue), Convert.ToInt32(ddlEmpresa.SelectedValue)
                , txtNombre.Value.ToString().Trim().ToUpper(), txtApPaterno.Value.ToString().Trim().ToUpper(), txtAPMaterno.Value.ToString().Trim().ToUpper(),
                txtUsuario.Value.ToString().Trim().ToUpper(), txtContraseña.Value.ToString().Trim().ToUpper(), TxtDireccion.Value.ToString(),
                TxtCodigoCanal.Value.ToString(), TxtGiro.Value.ToString(), Convert.ToInt32(ddlEstado.SelectedValue), Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]), flagvalidadato);

           
            if (Msj == "Modificado")
            {
               
                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Se Modifico Correctamente el usuario"",
                icon: ""success"",
                dangerMode: false,
                   })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                hdIdUsuario.Value = "";
                hdIdUsuario.Value = "";
                hDNcODIGOtXT.Value = "";
                txtNombre.Value = "";
                txtApPaterno.Value = "";
                txtAPMaterno.Value = "";
                txtUsuario.Value = "";
                txtContraseña.Value = "";
                ListarUsuario();
                TxtDireccion.Value = "";
                TxtCodigoTxt.Value = "";
                TxtCodigoCanal.Value = "";
                TxtGiro.Value = "";
                PanelAgregar.Visible = false;
                PanelListar.Visible = true;
                return;

            }
            else
            {
                string menssajeScript = "<script type='text/javascript'>"
                          + " swal({" +

                  "title: '" + Msj.ToString() + "'," +
                   " icon: 'warning'," +
                  "  dangerMode: true," +
             "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }
            ListarUsuario();
        }

      
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            PanelAgregar.Visible = false;
            PanelListar.Visible = true;
            hdIdUsuario.Value = "";
            hdIdUsuario.Value = "";
            hDNcODIGOtXT.Value = "";
            txtNombre.Value = "";
            txtApPaterno.Value = "";
            txtAPMaterno.Value = "";
            txtUsuario.Value = "";
            txtContraseña.Value = "";
            ListarUsuario();
            TxtDireccion.Value = "";
            TxtCodigoTxt.Value = "";
            TxtCodigoCanal.Value = "";
            TxtGiro.Value = "";
            txtContraseña.Value = ""; TxtCodigoTxt.Disabled = false;
        }
        

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            PanelAgregar.Visible = true;
            PanelListar.Visible = false;


            btnModificar_fr.Visible = false;
            btnRegistro_frm.Visible = true;
            hdIdUsuario.Value = "";
            hdIdUsuario.Value = "";
            hDNcODIGOtXT.Value = "";
            txtNombre.Value = "";
            txtApPaterno.Value = "";
            txtAPMaterno.Value = "";
            txtUsuario.Value = "";
            txtContraseña.Value = "";
            ListarUsuario();
            TxtDireccion.Value = "";
            TxtCodigoTxt.Value = "";
            TxtCodigoCanal.Value = "";
            TxtGiro.Value = "";
            TxtCodigoTxt.Disabled = false;
            //tipoperfilweb.Attributes.Add("style", "display:block");
        }

        protected void chksuc_CheckedChanged(object sender, EventArgs e)
        {
            ListarUsuario();
        }

        protected void DDTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DDTipoUsuario.SelectedValue == "3")
            {
                //ddlSubPerfil.Visible = true;
                DDTipoAcceso.Visible = false;
                //codigoTXt.Attributes.Add("style", "display:none");
            }
            else
            {
                DDTipoAcceso.Visible = true;
                //ddlSubPerfil.Visible = false;
                //codigoTXt.Attributes.Add("style", "display:block");
            }
        }

      
        protected void GvApp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try { 
            int Indice = int.Parse(e.CommandArgument.ToString());
            int idUsuario = int.Parse(GvApp.Rows[Indice].Cells[0].Text);
            if (e.CommandName == "Eliminar")
            {

                Usuario OBJ = new Usuario();
                int resultado = OBJ.EliminarUsuario(idUsuario, Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));

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
                dt = OBJ.listUsuXid(idUsuario);
                foreach (DataRow item in dt.Rows)
                {


                    hDNcODIGOtXT.Value= item["CodigoTxt"].ToString().ToString();
                    DDTipoUsuario.SelectedValue= item["IdTipoUsuario"].ToString().ToString();
                    DDTipoAcceso.SelectedValue= item["IdTipoAcceso"].ToString().ToString();
                    ddlEmpresa.SelectedValue= item["IdEmpresa"].ToString().ToString();
                    txtNombre.Value = item["Nombre"].ToString().ToString();
                    txtApPaterno.Value = item["Paterno"].ToString().ToString();
                    txtAPMaterno.Value = item["Materno"].ToString().ToString();
                    txtUsuario.Value = item["Usuario"].ToString().ToString();
                    TxtDireccion.Value = item["Direccion"].ToString().ToString();
                    ddlEstado.SelectedValue = item["Estado"].ToString().ToString();
                    TxtCodigoTxt.Value = item["CodigoTxt"].ToString();
                    TxtGiro.Value = item["Giro"].ToString();
                    TxtCodigoCanal.Value = item["CodigoCanal"].ToString();
                    HdnContras.Value = item["Clave"].ToString();
                    txtContraseña.Value = item["Clave"].ToString();
                    TxtCodigoTxt.Disabled = true;
                        if (item["FlagValidaDatos"].ToString() == "0")
                        {
                            ChkValida.Checked = true;
                        }else
                        {
                            ChkValida.Checked = false;
                        }
                }
                //--Botones                 

                //tipoperfilweb.Attributes.Add("style", "display:none");
                btnModificar_fr.Visible = true;
                btnRegistro_frm.Visible = false;
                //hidden iddireccion
                hdIdUsuario.Value = idUsuario.ToString();

                PanelAgregar.Visible = true;
                PanelListar.Visible = false;
                //ClientScript.RegisterStartupScript(Page.GetType(), "Mensaje", "<script type='text/javascript'>alert('Se Actualizo la direccion correctamente');</script>");
                //return;

            }
            }catch(Exception ex)
            {

            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            ListarUsuario();
        }

        protected void GvApp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvApp.PageIndex = e.NewPageIndex;
            ListarUsuario();
        }
    }
}