using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DB;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Globalization;

namespace Web_Nestle
{
    public partial class F_MetaBodegaVendedor : System.Web.UI.Page
    {
        Usuario obj = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                if (Page.IsPostBack == false)
            {
                if (Request.Cookies["WebNestle"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                Panel_Listar.Visible = true;
                    PanelAgregar.Visible = false;
                DateTime thisDay = DateTime.Today;
                TxtFecha.Value = thisDay.ToString("MM/yyyy");
                    TxtMesBuscar.Value = thisDay.ToString("MM/yyyy");
                listarMeta();
                    busar(); DataTable dt = new DataTable();
                    GvSubir.DataSource = dt;
                    GvSubir.DataBind();
                }
            }
            catch (Exception ex) { }

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
        public void listarMeta()
        {
            Subir_txt objj = new Subir_txt();
            DataTable dtTipo = new DataTable();
            dtTipo = objj.ListarTipoUsuario();
            DDTipoUusario.DataSource = dtTipo;
            DDTipoUusario.DataTextField = "Descripcion";
            DDTipoUusario.DataValueField = "IdTipoUsuario";
            DDTipoUusario.DataBind();
            DDTipoUusario.Items.Insert(0, new ListItem("--Seleccione--", "0"));


            DDBuscar.DataSource = dtTipo;
            DDBuscar.DataTextField = "Descripcion";
            DDBuscar.DataValueField = "IdTipoUsuario";
            DDBuscar.DataBind();
            DDBuscar.Items.Insert(0, new ListItem("--Todos--", "0"));
            
           

        }
        public void busar()
        {
            DataTable dt = new DataTable();
            Int32 IdDistribuidor = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdEmpresaMaster"]);
            dt = obj.ListarMetaMensual(IdDistribuidor, Convert.ToInt32(DDBuscar.SelectedValue), "01/" + TxtMesBuscar.Value.ToString());
            GV_MetaMensual.DataSource = dt;
            GV_MetaMensual.DataBind();
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (GvSubir.Rows.Count < 1)
            {

                String mensajeScriptnm = @"<script type='text/javascript'>
                swal({
                title: ""Seleccione  Txt"",
                icon: ""warning"",
                dangerMode: false,
                })
                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                FileUpload1.Focus();
                return;
            }
            String Msj = "";
            if (DDTipoUusario.SelectedValue == "0")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Tipo Usuario"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
           
            if (TxtFecha.Value == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Fecha"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);

                return;
            }
            DateTime dttim = DateTime.ParseExact("01/"+TxtFecha.Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            String fecha = dttim.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        
            Int32 IdDistribuidor = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdEmpresaMaster"]);
            Int32 usuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
            try {
                foreach (GridViewRow row in GvSubir.Rows)
                {
                    Msj = obj.InsertMetaUsuario(IdDistribuidor, row.Cells[0].Text.ToString(),
                        Convert.ToInt32(DDTipoUusario.SelectedValue), fecha,
                      float.Parse(row.Cells[1].Text.ToString()), usuario);

                }

                //Msj = obj.InsertMetaUsuario(IdDistribuidor, Convert.ToInt32(DDTipoUusario.SelectedValue),
                //    "01/"+TxtFecha.Value.ToString(),float.Parse(TxtMonto.Value.ToString()), usuario);

                if (Msj == "Exito")
                {
                    string error = @"<script type='text/javascript'>
                       swal({
                title: ""Operacion Exitosa"",
              icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", error, false);
                    listarMeta();
                    busar();
                    Panel_Listar.Visible = true;
                    PanelAgregar.Visible = false;
                    DataTable dt = new DataTable();
                    GvSubir.DataSource = dt;
                    GvSubir.DataBind();
                    listarMeta();
                    LblTotal.Text = "";
                }
                else
                {
                    string menssajeScript = "<script type='text/javascript'>"
                                     + " swal({" +

                             "title: '" +DDTipoUusario.SelectedItem.ToString() +" "+ Msj.ToString() + "'," +
                              " icon: 'warning'," +
                             "  dangerMode: true," +
                        "   })  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);


                }
                listarMeta();

            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                string menssajeScript = "<script type='text/javascript'>"
                                      + " swal({" +

                              "title: '" + builder.ToString() + "'," +
                               " icon: 'warning'," +
                              "  dangerMode: true," +
                         "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);


                return;
            }
            busar();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            
            PanelAgregar.Visible = false;
            Panel_Listar.Visible = true;
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {

          
            PanelAgregar.Visible = true;
            Panel_Listar.Visible = false;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            busar(); 
        }

        protected void GV_MetaMensual_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_MetaMensual.PageIndex = e.NewPageIndex;
            busar();
        }

        protected void GV_MetaMensual_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GV_MetaMensual.EditIndex = e.NewEditIndex;
            busar();
        }

        protected void GV_MetaMensual_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GV_MetaMensual.EditIndex = -1;
            busar();
        }

        protected void GV_MetaMensual_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 IdMeta = Convert.ToInt32(GV_MetaMensual.DataKeys[e.RowIndex].Values["ID"].ToString());
            GridViewRow row = GV_MetaMensual.Rows[e.RowIndex];
            TextBox tXTmONTO = row.FindControl("tXTmONTO") as TextBox;

            if (tXTmONTO.Text == "")
            {

                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Monto"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                tXTmONTO.Focus();
                return;
            }
            String Msj = "";
            try
            {
                Msj = obj.ModificarMeta(IdMeta,float.Parse(tXTmONTO.Text.Replace(".", ",")), Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));
        }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
        StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
             && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
             && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
             && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

        string MachineName = System.Environment.MachineName;
        string UserName = System.Environment.UserName.ToUpper();
        string Mensaje = ex.Message;
        StringBuilder builder = new StringBuilder(Mensaje);
        builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
        string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
        string Clase = frame.GetMethod().DeclaringType.Name;
        string metodo = frame.GetMethod().Name;
        String M = "Formato Incorrecto";
        string menssajeScript = "<script type='text/javascript'>"
                            + " swal({" +

                    "title: '" + M.ToString() + "'," +
                     " icon: 'warning'," +
                    "  dangerMode: false," +
               "   })  </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
            }  if(Msj != "")
            {
                string menssajeScript = "<script type='text/javascript'>"
                                   + " swal({" +

                           "title: '" + Msj.ToString() + "'," +
                            " icon: 'success'," +
                           "  dangerMode: false," +
                      "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
            }
            GV_MetaMensual.EditIndex = -1;
            busar();
        }
        protected void UploadDocument(object sender, EventArgs e)
        {
            String Msj = "";
            if (DDTipoUusario.SelectedValue == "0")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Tipo Usuario"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }

            if (TxtFecha.Value == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Fecha"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);

                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("IDUSUARIO");
            dt.Columns.Add("MONTO");
            dt.Columns.Add("FECHA");
            dt.Columns.Add("TIPOUSUARIO");
            try
            {
                string csvPath = Server.MapPath("~/Archivos/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(csvPath);
                string[] allLines = File.ReadAllLines(csvPath);
                {
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        string[] items = allLines[i].Split(new char[] { '|' });
                        DataRow row = dt.NewRow();
                        row["IDUSUARIO"] = items[0].ToString();
                        row["MONTO"] = Decimal.Parse(items[1].ToString().Replace(".", ","));
                       row["FECHA"] = TxtFecha.Value.ToString();
                        row["TIPOUSUARIO"] = DDTipoUusario.SelectedItem.ToString();
                        dt.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();

                string MachineName = System.Environment.MachineName;
                string UserName = System.Environment.UserName.ToUpper();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
                string Proyecto = frame.GetMethod().Module.Assembly.GetName().Name;
                string Clase = frame.GetMethod().DeclaringType.Name;
                string metodo = frame.GetMethod().Name;
                string menssajeScript = "<script type='text/javascript'>"
                                    + " swal({" +

                            "title: '" + builder.ToString() + "'," +
                             " icon: 'warning'," +
                            "  dangerMode: false," +
                       "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
            }



            GvSubir.DataSource = dt;
            GvSubir.DataBind();
            LblTotal.Text = "Total : " + GvSubir.Rows.Count.ToString();
        }
    }
}