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
    public partial class F_MantenimientoFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //try
            //{
            //    if (IsPostBack == false)
            //    {
            //        if (Request.Cookies["WebNestle"] == null)
            //        {
            //            //HttpCookie cookie = Request.Cookies["localization"];
            //            //string locale = cookie.Values["locale"].ToString();


            //            Response.Redirect("FrmMensajeLogin.aspx");
            //        }
            PanelAgregar.Visible = false;
                    PanelListar.Visible = true;
                    ListarFormulario();
            //--botones default
            btnModificar_fr.Visible = false;

            //    }
            //}
            //catch (Exception)
            //{

            //}
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
        public int operacion;
        public int totalItemSeleccionados = 0;


        protected void GridView_Clientes_DataBound(object sender, EventArgs e)
        {
        }

        public void GridView_Clientes_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }
        public void GridView_Clientes_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }
        protected void GridView_Clientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
          
        }

        protected void btnQuitarSeleccionados_Click(object sender, EventArgs e)
        {

        }
        protected void chk_OnCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {

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
            if (txtRuta.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Ruta"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                txtRuta.Focus();
                return;
            }
            if (txtGrupo.Value == "")
            {

                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Grupo"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                txtGrupo.Focus();
                return;
            }

            Formulario OBJ = new Formulario();
            //Se debe reemplazar el usucrea y el idusuario
            int idFormulario = OBJ.AgregarFormulario(txtNombre.Value, txtRuta.Value, txtGrupo.Value, Convert.ToInt32(ddlEstado.SelectedValue), 5);
            if (idFormulario > 0)
            {
                ListarFormulario();
                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Se registro Correctamente el Formulario"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                return;
            }
        }
        private void ListarFormulario()
        {
            try
            {
                DataTable dt = new DataTable();
                Formulario OBJ = new Formulario();

                dt = OBJ.ListarFormulario();
                grFormulario.DataSource = dt;
                grFormulario.DataBind();

            }
            catch (Exception ex)
            {

            }
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
            if (txtRuta.Value == "")
            {
                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Ruta"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                txtRuta.Focus();
                return;
            }
            if (txtGrupo.Value == "")
            {

                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Debe ingresar Grupo"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                txtGrupo.Focus();
                return;
            }

            Formulario OBJ = new Formulario();
            //Se debe reemplazar el usucrea y el idusuario

            int idFormulario = OBJ.ModificarFormulario(Convert.ToInt32(hdIdFormulario.Value), txtNombre.Value, txtRuta.Value, txtGrupo.Value, Convert.ToInt32(ddlEstado.SelectedValue), 5);
            if (idFormulario > 0)
            {
                ListarFormulario();
                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Se Modifico Correctamente el Formulario"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                PanelAgregar.Visible = false;
                PanelListar.Visible = true;
                txtNombre.Value = "";
                txtRuta.Value = "";
                txtGrupo.Value = "";
                return;
            }
        }

        protected void grFormulario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Indice = int.Parse(e.CommandArgument.ToString());
            int idFormulario = int.Parse(grFormulario.Rows[Indice].Cells[0].Text);
            if (e.CommandName == "Eliminar")
            {

                Formulario OBJ = new Formulario();

                int resultado = OBJ.EliminarFormulario(idFormulario, 5);//POner el usuario de session que modificara
                if (resultado > 0)
                {
                    ListarFormulario();
                    ClientScript.RegisterStartupScript(Page.GetType(), "Mensaje", "<script type='text/javascript'>alert('Se Elimino el Formulario');</script>");
                    return;
                }

            }

            if (e.CommandName == "Editar")
            {
                DataTable dt = new DataTable();

                Formulario OBJ = new Formulario();

                dt = OBJ.ListarFormularioXID(idFormulario);
                foreach (DataRow item in dt.Rows)
                {

                    txtNombre.Value = item["Nombre"].ToString().ToString();
                    txtRuta.Value = item["Ruta"].ToString().ToString();
                    txtGrupo.Value = item["Grupo"].ToString().ToString();
                    ddlEstado.SelectedValue = item["EstadoInt"].ToString().ToString();
                }
                //--Botones 
                btnModificar_fr.Visible = true;

                btnRegistro.Visible = false;
                //hidden iddireccion
                hdIdFormulario.Value = idFormulario.ToString();
                PanelAgregar.Visible = true;
                PanelListar.Visible = false;

                //ClientScript.RegisterStartupScript(Page.GetType(), "Mensaje", "<script type='text/javascript'>alert('Se Actualizo la direccion correctamente');</script>");
                //return;

            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            btnModificar_fr.Visible = false;
            btnRegistro.Visible = true;
            hdIdFormulario.Value = "";
            PanelAgregar.Visible = false;
            PanelListar.Visible = true;
            txtNombre.Value = "";
            txtRuta.Value = "";
            txtGrupo.Value = "";
        }

        protected void grFormulario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grFormulario.PageIndex = e.NewPageIndex;
            ListarFormulario();
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            PanelAgregar.Visible = true;
            PanelListar.Visible = false;
            btnModificar_fr.Visible = false;
            btnRegistro.Visible = true;
        }
    }
}