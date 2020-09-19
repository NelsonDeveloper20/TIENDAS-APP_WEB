using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
namespace Web_Nestle
{
    public partial class F_MantenimientoPerfilFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (IsPostBack == false)
            {
                if (Request.Cookies["WebNestle"] == null)
                {
                    //HttpCookie cookie = Request.Cookies["localization"];
                    //string locale = cookie.Values["locale"].ToString();


                    Response.Redirect("FrmMensajeLogin.aspx");
                }
                CargaPerfiles();
                ddlPerfiles.SelectedIndex = 0;
                ListarFormulario();
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
        private void ListarFormulario()
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                Formulario OBJ = new Formulario();


                dt = OBJ.FormularioIdPerfilNoSeleccionados(Convert.ToInt32(ddlPerfiles.SelectedValue));
                lblTotalUsuario.Text = dt.Rows.Count.ToString();
                ddlFormulariosNoAgregados.DataSource = dt;
                ddlFormulariosNoAgregados.DataTextField = "NombreRuta";
                ddlFormulariosNoAgregados.DataValueField = "IdFormulario";
                ddlFormulariosNoAgregados.DataBind();

                dt2 = OBJ.FormularioIdPerfilSeleccionados(Convert.ToInt32(ddlPerfiles.SelectedValue));

                //lblTotalUsuario.Text = dt.Rows.Count.ToString();
                ddlFormulariosAsignado.DataSource = dt2;
                ddlFormulariosAsignado.DataTextField = "NombreRuta";
                ddlFormulariosAsignado.DataValueField = "IdFormulario";
                ddlFormulariosAsignado.DataBind();

                //if (dt.Rows.Count > 0)
                //{
                //    grFormulario.DataSource = dt;
                //    grFormulario.DataBind();
                //}

            }
            catch (Exception ex)
            {

            }
        }





        public void CargaPerfiles()
        {
            Perfil OBJ = new Perfil();

            DataTable dt = new DataTable();

            dt = OBJ.ListarPerfiles();
            ddlPerfiles.DataSource = dt;
            ddlPerfiles.DataTextField = "Descripcion";
            ddlPerfiles.DataValueField = "IdPerfil";
            ddlPerfiles.DataBind();
            ddlPerfiles.Items.Insert(0, new ListItem("Seleccione", "0"));

        }



        protected void ddlPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {

            Formulario obj = new Formulario();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            int IdFormulario;
            int x = 0;
            string msgerror = "";

            try
            {


                Formulario OBJ = new Formulario();

                bool Flag = OBJ.IngresarFormulariosNuevosExistentes(Convert.ToInt32(ddlPerfiles.SelectedValue));


                ddlFormulariosNoAgregados.ClearSelection();
                ddlFormulariosAsignado.ClearSelection();

                ddlFormulariosNoAgregados.Items.Clear();
                ddlFormulariosAsignado.Items.Clear();
                dt = OBJ.FormularioIdPerfilNoSeleccionados(Convert.ToInt32(ddlPerfiles.SelectedValue));


                lblTotalUsuario.Text = dt.Rows.Count.ToString();
                ddlFormulariosNoAgregados.DataSource = dt;
                ddlFormulariosNoAgregados.DataTextField = "NombreRuta";
                ddlFormulariosNoAgregados.DataValueField = "IdFormulario";
                ddlFormulariosNoAgregados.DataBind();
                dt2 = OBJ.FormularioIdPerfilSeleccionados(Convert.ToInt32(ddlPerfiles.SelectedValue));


                ddlFormulariosAsignado.DataSource = dt2;
                ddlFormulariosAsignado.DataTextField = "NombreRuta";
                ddlFormulariosAsignado.DataValueField = "IdFormulario";
                ddlFormulariosAsignado.DataBind();

            }
            catch (Exception ex)
            {
                msgerror = ex.Message;
                //ScriptManager.RegisterStartupScript(UpdatePanel1, Page.GetType(), "Script", "<script language='javascript'>alert('Algunos formularios no fueron registrados, Por favor primero Ingreselos');</script>", false);
            }
        }

        protected void grFormulario_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }


        private void Procesar()
        {

            if (Request.Cookies["WebNestle"] == null
                  || Request.Cookies["WebNestle"]["DLIdUsuario"] == null
                  || Request.Cookies["WebNestle"]["DLUsuario"] == null

                )
            {
                Response.Redirect("FrmMensajeLogin.aspx");
            }

            Formulario objt = new Formulario();
            DataTable dt = new DataTable();
            int x = 0;
            int IdFormulario;
            int EstadoFormulario;
            DataTable flag = new DataTable();
            int IdPerfil;
            string msgerror = "";
            try
            {


                bool Flag = objt.IngresarFormulariosNuevosExistentes(Convert.ToInt32(ddlPerfiles.SelectedValue));

                var items = new System.Collections.ArrayList(ddlFormulariosAsignado.Items);
                string values = Request.Form[ddlFormulariosAsignado.UniqueID];

                string text = "";


                for (int i = 0; i < ddlFormulariosAsignado.Items.Count; i++)
                {
                    int idFormularioPerfil = Convert.ToInt32(ddlFormulariosAsignado.Items[i].Value);

                    objt.ActualizarEstadoFormularioPerfilAsignados(Convert.ToInt32(ddlPerfiles.SelectedValue), idFormularioPerfil, Convert.ToInt32(Request.Cookies["WebNestle"]["IdUsuario"]));
                }
                for (int i = 0; i < ddlFormulariosNoAgregados.Items.Count; i++)
                {
                    int idFormularioPerfil = Convert.ToInt32(ddlFormulariosNoAgregados.Items[i].Value);

                    objt.ActualizarEstadoFormularioPerfilNoAsignados(Convert.ToInt32(ddlPerfiles.SelectedValue), idFormularioPerfil, Convert.ToInt32(Request.Cookies["WebNestle"]["IdUsuario"]));
                }
                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Operacion Satisfactoria"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
               // ScriptManager.RegisterStartupScript(UpdatePanel1, Page.GetType(), "Script", "<script language='javascript'>alert('Operacion Satisfactoria');setTimeout('location.reload(true);', 50); </script>", false);

            }
            catch (Exception ex)
            {
                msgerror = ex.Message;
                ScriptManager.RegisterStartupScript(UpdatePanel1, Page.GetType(), "Script", "<script language='javascript'>alert('Se produjo un error" + msgerror + "');</script>", false);
            }
        }
        protected void btnRegistro_Click1(object sender, EventArgs e)
        {
            Procesar();
        }

        protected void btnagregar_Click(object sender, EventArgs e)
        {
            while (ddlFormulariosNoAgregados.GetSelectedIndices().Length > 0)
            {
                ddlFormulariosAsignado.Items.Add(ddlFormulariosNoAgregados.SelectedItem);
                ddlFormulariosNoAgregados.Items.Remove(ddlFormulariosNoAgregados.SelectedItem);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            while (ddlFormulariosAsignado.GetSelectedIndices().Length > 0)
            {
                ddlFormulariosNoAgregados.Items.Add(ddlFormulariosAsignado.SelectedItem);
                ddlFormulariosAsignado.Items.Remove(ddlFormulariosAsignado.SelectedItem);
            }
        }
    }
}