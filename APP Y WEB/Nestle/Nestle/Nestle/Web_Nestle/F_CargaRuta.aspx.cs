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
    public partial class F_CargaRuta : System.Web.UI.Page
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
        public void subir()
        {
            if (GV_RUTA.Rows.Count <1)
            {

                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Ruta Txt"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                FileUpload1.Focus();
                return;
            }

            Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
            Int32 IdDistribuidor = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdEmpresaMaster"]);
            //obj.CambiarEstadoRuta(IdDistribuidor, IdUsuario);
            DataTable DtLis = new DataTable();
            DtLis.Columns.Add("CodigoCliente", typeof(String));
            DtLis.Columns.Add("CodigoEmpleado", typeof(String));
            DtLis.Columns.Add("DiasVisita", typeof(String));

            foreach (GridViewRow row in GV_RUTA.Rows)
            {

                DataRow drog = DtLis.NewRow();

                drog["CodigoCliente"] = Convert.ToString(row.Cells[0].Text.ToString());
                drog["CodigoEmpleado"] = row.Cells[1].Text.ToString();
                drog["DiasVisita"] = Convert.ToString(row.Cells[2].Text.ToString());
                DtLis.Rows.Add(drog);

                //obj.insertarRuta(row.Cells[0].Text.ToString(),
                //    row.Cells[1].Text.ToString(),
                //    row.Cells[2].Text.ToString(),
                //    IdUsuario, 1);

            }
            obj.insertarRutaV2(Convert.ToInt32(IdUsuario), 1, DtLis);
            String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Operacion Exitosa"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
            DataTable dt = new DataTable();
            GV_RUTA.DataSource = dt;
            GV_RUTA.DataBind();

        }
        protected void UploadDocument(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo_Cliente");
            dt.Columns.Add("Codigo_Empleado");
            dt.Columns.Add("Dias_Visita");
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
                    row["Codigo_Cliente"] = items[0].ToString();
                    row["Codigo_Empleado"] = items[1].ToString();
                    row["Dias_Visita"] = items[2].ToString();
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

            GV_RUTA.DataSource = dt;
            GV_RUTA.DataBind();
            LblTotal.Text = "Total Rutas: " + GV_RUTA.Rows.Count.ToString();
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
         
            subir();
            //string csvPath = Server.MapPath("~/Archivos/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            //FileUpload1.SaveAs(csvPath);

            //Subir_txt obj = new Subir_txt();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Codigo");
            //dt.Columns.Add("Nombre");
            //dt.Columns.Add("Precio");
            //dt.Columns.Add("Stock");

            //string textline2 = "";
            //string[] allLines = File.ReadAllLines(csvPath);
            //{
            //    for (int i = 1; i < allLines.Length; i++)
            //    {
            //        string[] items = allLines[i].Split(new char[] { '|' });
            //        obj.insertar(items[0].ToString(), items[1].ToString(), items[2].ToString(), items[3].ToString());
            //        DataRow row = dt.NewRow();
            //        row["Codigo"] = items[0].ToString();
            //        row["Nombre"] = items[1].ToString();
            //        row["Precio"] = items[2].ToString();
            //        row["Stock"] = items[3].ToString();
            //        dt.Rows.Add(row);
            //    }
            //}

            //Gv_Producto.DataSource = dt;
            //Gv_Producto.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("The file could not be read:");
            //    Console.WriteLine(ex.Message);
            //}
        }

      

       
    }
    }