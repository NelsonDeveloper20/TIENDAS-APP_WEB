using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace Web_Nestle
{
    public partial class F_CargaPedidoSugeridoCliente : System.Web.UI.Page
    {
        Cliente obj = new Cliente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Page.IsPostBack == false)
            {
                if (Request.Cookies["WebNestle"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                PanelListar.Visible = true;
                PanelSubir.Visible = false;
                ListarClienteSugerido();
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
              
         void ListarClienteSugerido()
        {
            GVCLIENTESUGERIDO.DataSource = obj.ListarClientePedididoSugerido();
            GVCLIENTESUGERIDO.DataBind();
        }
        public void subir()
        {
            if (GvSubir.Rows.Count <1)
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

            Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);         
            String Msj = "";
            try { 
            foreach (GridViewRow row in GvSubir.Rows)
            {
                Msj= obj.SubirPedidoSugeridoCliente(row.Cells[0].Text.ToString(),Convert.ToDouble(row.Cells[1].Text.ToString()),IdUsuario);

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
                String M = "Formato Incorrecto";
                string menssajeScript = "<script type='text/javascript'>"
                                    + " swal({" +

                            "title: '" + M.ToString() + "'," +
                             " icon: 'warning'," +
                            "  dangerMode: false," +
                       "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }
            if (Msj != "")
            {
                
                string menssajeScript = "<script type='text/javascript'>"
                              + " swal({" +

                      "title: '" + Msj + "'," +
                       " icon: 'success'," +
                      "  dangerMode: false," +
                 "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                PanelListar.Visible = true;
                PanelSubir.Visible = false;
                ListarClienteSugerido();
                LblTotal.Text = "";
            }
            else
            {
                string menssajeScript = "<script type='text/javascript'>"
                             + " swal({" +

                     "title: 'ocurrio un error'," +
                      " icon: 'warning'," +
                     "  dangerMode: true," +
                "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
            }
            DataTable dt = new DataTable();
            GvSubir.DataSource = dt;
            GvSubir.DataBind();
            ListarClienteSugerido(); 


        }
        protected void UploadDocument(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt.Columns.Add("IDCLIENTE");
            dt.Columns.Add("MONTO");
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
                        row["IDCLIENTE"] = items[0].ToString();
                        row["MONTO"] =  Double.Parse( items[1].ToString().Replace(".",","));
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

                            "title: '" + "Error en el Txt: " + builder.ToString() + "'," +
                             " icon: 'warning'," +
                            "  dangerMode: false," +
                       "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }



            GvSubir.DataSource = dt;
            GvSubir.DataBind();
            LblTotal.Text = "Total : " + GvSubir.Rows.Count.ToString();
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            subir();
        }

        protected void GVCLIENTESUGERIDO_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVCLIENTESUGERIDO.EditIndex = e.NewEditIndex;
            ListarClienteSugerido();
        }

        protected void GVCLIENTESUGERIDO_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVCLIENTESUGERIDO.EditIndex = -1;
            ListarClienteSugerido();
        }

        protected void GVCLIENTESUGERIDO_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String IdCliente = Convert.ToString(GVCLIENTESUGERIDO.DataKeys[e.RowIndex].Values["IdCliente"].ToString());
            GridViewRow row = GVCLIENTESUGERIDO.Rows[e.RowIndex];
            TextBox TxtMonto = row.FindControl("TxtMonto") as TextBox;

            if (TxtMonto.Text == "")
            {

                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Monto"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                TxtMonto.Focus();
                return;
            }

           
            String Msj = "";
            try
            {
                Msj = obj.ModificarClienteSugerido(IdCliente, Double.Parse(TxtMonto.Text.ToString().Replace(".", ",")),
                Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));
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
                return;
            }
            if (Msj != "")
            {
                string menssajeScript = "<script type='text/javascript'>"
                                   + " swal({" +

                           "title: '" + Msj.ToString() + "'," +
                            " icon: 'success'," +
                           "  dangerMode: false," +
                      "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
            }
            GVCLIENTESUGERIDO.EditIndex = -1;
            ListarClienteSugerido();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            ListarClienteSugerido();
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            PanelListar.Visible = false;
            PanelSubir.Visible = true;
            DataTable dt = new DataTable();
            GvSubir.DataSource = dt;
            GvSubir.DataBind();
            LblTotal.Text = ""; ;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            PanelListar.Visible = true;
            PanelSubir.Visible = false;
            ListarClienteSugerido();
        }
    }
    }