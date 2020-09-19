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
    public partial class F_CargaStock : System.Web.UI.Page
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
                if (Request.Cookies["WebNestle"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                ListarTipos();
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
        public void ListarTipos()
        {
            DDFabricante.DataSource = obj.ListarFabricante();
            DDFabricante.DataTextField = "Descripcion";
            DDFabricante.DataValueField = "idFabricante";
            DDFabricante.DataBind();
            DDFabricante.Items.Insert(0, new ListItem("Seleccione...", "0"));
            
        }

        public void subir()
        {
            if (GvStock.Rows.Count <1)
            {

                String mensajeScriptnm = @"<script type='text/javascript'>
                swal({
                title: ""Seleccione Stock Txt"",
                icon: ""warning"",
                dangerMode: false,
                })
                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                FileUpload1.Focus();
                return;
            }          

            Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
            //obj.CambiarEstadoStock(Convert.ToInt32(DDFabricante.SelectedValue), IdUsuario);
            DataTable DtLis = new DataTable();
            DtLis.Columns.Add("IdAlmacen", typeof(string));
            DtLis.Columns.Add("IdProductoTxt", typeof(string));
            DtLis.Columns.Add("Stock", typeof(Int32));
          
            foreach (GridViewRow row in GvStock.Rows)
            {
                DataRow drog = DtLis.NewRow();

                drog["IdAlmacen"] = row.Cells[0].Text.ToString();
                drog["IdProductoTxt"] = row.Cells[1].Text.ToString();
                drog["Stock"] = Convert.ToInt32(row.Cells[2].Text.ToString());
                DtLis.Rows.Add(drog);

            }

            String Msj = "";
            Msj = obj.SubirStockAlmacen(IdUsuario, Convert.ToInt32(DDFabricante.SelectedValue), 1, DtLis);
            //foreach (GridViewRow row in GvStock.Rows)
            //{
            

            //    obj.InsertarStock(row.Cells[0].Text.ToString(),row.Cells[1].Text.ToString(),Convert.ToInt32(row.Cells[2].Text.ToString()),
            //    IdUsuario, 1,Convert.ToInt32(DDFabricante.SelectedValue));

            //}
            if(Msj != "")
            {

              

                
                string menssajeScript = "<script type='text/javascript'>"
                              + " swal({" +

                      "title: '" + Msj + "'," +
                       " icon: 'success'," +
                      "  dangerMode: false," +
                 "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
            }else
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
            GvStock.DataSource = dt;
            GvStock.DataBind();
            DtLis.Rows.Clear();

        }
        protected void UploadDocument(object sender, EventArgs e)
        {
            if (DDFabricante.SelectedValue == "0")
            {
                string menssajeScript = "<script type='text/javascript'>"
                           + " swal({" +

                   "title: 'Seleccione Fabricante'," +
                    " icon: 'warning'," +
                   "  dangerMode: true," +
              "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo_Almacen");
            dt.Columns.Add("Codigo_ProductoTxt");
            dt.Columns.Add("Stock");
            dt.Columns.Add("Fabricante");
            try { 
            string csvPath = Server.MapPath("~/Archivos/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);
            string[] allLines = File.ReadAllLines(csvPath);
            {
                for (int i = 0; i < allLines.Length; i++)
                {
                    string[] items = allLines[i].Split(new char[] { '|' });
                    DataRow row = dt.NewRow();
                    row["Codigo_Almacen"] = items[0].ToString();
                    row["Codigo_ProductoTxt"] = items[1].ToString();
                    row["Stock"] = items[2].ToString();
                    row["Fabricante"] = DDFabricante.SelectedItem;
                    dt.Rows.Add(row);
                }
            }
        }catch(Exception ex)
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
    GvStock.DataSource = dt;
            GvStock.DataBind();
            LblTotal.Text = "Total Stock: " + GvStock.Rows.Count.ToString();
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