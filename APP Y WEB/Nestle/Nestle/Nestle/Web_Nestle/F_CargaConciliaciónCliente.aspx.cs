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
    public partial class F_CargaConciliaciónCliente : System.Web.UI.Page
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
                DataTable dt = new DataTable();
                GvSubir.DataSource = dt;
                GvSubir.DataBind();

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
            try
            {

                DataTable DtLis = new DataTable();
                DtLis.Columns.Add("idPedido", typeof(Int32));
                DtLis.Columns.Add("Producto", typeof(String));
                DtLis.Columns.Add("cantidad", typeof(Int32));
                DtLis.Columns.Add("Precio", typeof(Decimal));
                DtLis.Columns.Add("Usuario", typeof(Int32));

                foreach (GridViewRow row in GvSubir.Rows)
                {
                    DataRow drog = DtLis.NewRow();

                    drog["idPedido"] = Convert.ToInt32(row.Cells[0].Text.ToString());
                    drog["Producto"] = row.Cells[1].Text.ToString().ToString();
                    drog["cantidad"] = Convert.ToInt32(row.Cells[2].Text.ToString());
                    drog["Precio"] = Decimal.Parse(row.Cells[3].Text.ToString());
                    drog["Usuario"] = IdUsuario;
                    DtLis.Rows.Add(drog);

                }
                Msj = obj.subiconciliacion(DtLis);
                //foreach (GridViewRow row in GvSubir.Rows)
                //{
                //    Msj = obj.SubirConciliacion(Convert.ToInt32(row.Cells[0].Text.ToString()),
                //     row.Cells[1].Text.ToString(),
                //       Convert.ToInt32(row.Cells[2].Text.ToString()), Decimal.Parse(row.Cells[3].Text.ToString()),
                //       IdUsuario);
                //}
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

                            "title: '" +   builder.ToString() + "'," +
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
               
                LblTotal.Text = "";
            }
            else
            {
                string menssajeScript = "<script type='text/javascript'>"
                             + " swal({" +

                     "title: '" + Msj + "'," +
                      " icon: 'warning'," +
                     "  dangerMode: true," +
                "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
            }
            DataTable dt = new DataTable();
            GvSubir.DataSource = dt;
            GvSubir.DataBind();


        }
        protected void UploadDocument(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt.Columns.Add("IdPedidoMarket");
            dt.Columns.Add("IdProducto");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Precio");
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
                        row["IdPedidoMarket"] = items[0].ToString();
                        row["IdProducto"] =  items[1].ToString();
                        row["Cantidad"] = Int32.Parse(items[2].ToString());
                        row["Precio"] = Decimal.Parse(items[3].ToString().Replace(".", ","));
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
       
    }
    }