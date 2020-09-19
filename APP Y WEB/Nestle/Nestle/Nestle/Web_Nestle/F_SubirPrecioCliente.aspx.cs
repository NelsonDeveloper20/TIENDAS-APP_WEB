using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace Web_Nestle
{
    public partial class F_SubirPrecioCliente : System.Web.UI.Page
    {

        Subir_txt obj = new Subir_txt();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Page.IsPostBack == false)
            { 
                 
                PanelListar.Visible = true;
                PanelSubirNuevo.Visible = false;
                DataTable dt = new DataTable();
                Gv_Producto.DataSource = dt;
                Gv_Producto.DataBind();
                listar(); 
            }
        }
        public void listar()
        {
            DDTipoUsuario.DataSource = obj.ListarTipoUSuario();
            DDTipoUsuario.DataTextField = "Descripcion";
            DDTipoUsuario.DataValueField = "IdTipoUsuario";
            DDTipoUsuario.DataBind();
            DDTipoUsuario.Items.Insert(0, new ListItem("--Seleccione--","0"));
            GvListaProductos.DataSource = obj.listarProductosCargadosBodega();
            GvListaProductos.DataBind();
            LblTotalproducto.Text = GvListaProductos.Rows.Count.ToString();
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
            {this.MasterPageFile = "~/MenuPrincipal.master";}
        }  
        public void subir()
        {
            if (Gv_Producto.Rows.Count < 1)
            {

                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Producto Txt"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                FileUpload1.Focus();
                return;
            } 
            Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
        
            DataTable DtLis = new DataTable();
            DtLis.Columns.Add("IdProductoTxt", typeof(string));
            DtLis.Columns.Add("NombrePro", typeof(string));
            DtLis.Columns.Add("Precio", typeof(String));
            DtLis.Columns.Add("StockDisponible", typeof(Int32));

            Int32 IdTipoUsuario = 0;
            foreach (GridViewRow row in Gv_Producto.Rows)
            {
                DataRow drog = DtLis.NewRow(); 
                
                drog["IdProductoTxt"] = Convert.ToString(row.Cells[0].Text.ToString());
                drog["NombrePro"] = row.Cells[1].Text.ToString();
                drog["Precio"] = Convert.ToString(row.Cells[2].Text.ToString());
                drog["StockDisponible"] = Convert.ToInt32(row.Cells[3].Text.ToString());
                IdTipoUsuario = Convert.ToInt32(row.Cells[4].Text.ToString());
                DtLis.Rows.Add(drog);
            }
            String Msj = "";
           Msj= obj.SubirProductoPrecioTipoCliente(IdTipoUsuario, IdUsuario, DtLis);          
           
            string menssajeScript = "<script type='text/javascript'>"
                               + " swal({" +
                       "title: '" + "" + Msj.ToString() + "'," +
                        " icon: 'success'," +
                       "  dangerMode: false," +
                  "   })  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
            DataTable dt = new DataTable();
            Gv_Producto.DataSource = dt;
            Gv_Producto.DataBind();
            LblTotal.Text = "";
            listar();
            PanelSubirNuevo.Visible = false;
            PanelListar.Visible = true;
        }
        protected void UploadDocument(object sender, EventArgs e)
        {
          /*  if (DDTipoUsuario.SelectedValue == "0")
            {

                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Tipo Cliente"",
                icon: ""warning"",
                dangerMode: false,
            });
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                DDTipoUsuario.Focus();
                return;
            } 
            */
            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Stock");
            dt.Columns.Add("TipoUsuarioValor");
            dt.Columns.Add("TipoUsuario"); 
            try
            {
                string csvPath = Server.MapPath("~/Archivos/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(csvPath);

                string[] allLines = File.ReadAllLines(csvPath, System.Text.Encoding.Default);
                {
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        string[] items = allLines[i].Split(new char[] { '|' });
                        DataRow row = dt.NewRow();
                        row["Codigo"] = items[0].ToString();
                        row["Nombre"] = items[1].ToString();
                        row["Precio"] = items[2].ToString();
                        row["Stock"] = items[3].ToString();
                        row["TipoUsuarioValor"] = "2";// DDTipoUsuario.SelectedValue.ToString();
                        row["TipoUsuario"] = "BODEGA";// DDTipoUsuario.SelectedItem.ToString();
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

            Gv_Producto.DataSource = dt;
            Gv_Producto.DataBind();
            LblTotal.Text = "Total Producto: " + Gv_Producto.Rows.Count.ToString();
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            subir();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            PanelListar.Visible = true;
            PanelSubirNuevo.Visible = false;
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            PanelListar.Visible = false;
            PanelSubirNuevo.Visible = true;
            DataTable dt = new DataTable();
            Gv_Producto.DataSource = dt;
            Gv_Producto.DataBind();
        }

        protected void Bntrefresh_Click(object sender, EventArgs e)
        {
            listar();
        }
    }
}