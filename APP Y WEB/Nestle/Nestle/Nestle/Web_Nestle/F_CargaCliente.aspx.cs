using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.Data;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace Web_Nestle
{
    public partial class F_CargaCliente : System.Web.UI.Page
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
            if (Gv_Producto.Rows.Count <1)
            {

                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Cliente. Txt"",
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
       //     obj.CambiarEstadoCliente(IdDistribuidor, IdUsuario);
            foreach (GridViewRow row in Gv_Producto.Rows)
            {
                //Int32 IdDistribuidor, String CodigoCliente,String Nombre,
                //String Direccion,String CodigoCanal, String Tipo,String Parm1,
                //String Param2, String Param3, String Param4, String Param5,
                //String Param6, String Param7, String Param8, String Param9, Int32 Usuario,Int32 Estado)

                obj.InsertarCliente(IdDistribuidor, row.Cells[0].Text.ToString(), row.Cells[1].Text.ToString(),
                     row.Cells[2].Text.ToString(), row.Cells[3].Text.ToString(), row.Cells[4].Text.ToString(),
                      row.Cells[5].Text.ToString(), row.Cells[6].Text.ToString(), row.Cells[7].Text.ToString(),
                       row.Cells[8].Text.ToString(), row.Cells[9].Text.ToString(), row.Cells[10].Text.ToString(),
                        row.Cells[11].Text.ToString(), row.Cells[12].Text.ToString(), row.Cells[13].Text.ToString(),
                        IdUsuario, 1);



            }
            String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Operacion Exitosa"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
            DataTable dt = new DataTable();
            Gv_Producto.DataSource = dt;
            Gv_Producto.DataBind();

        }
        protected void UploadDocument(object sender, EventArgs e)
        {
            //    Int32 IdDistribuidor, String CodigoCliente,String Nombre,
            //    String Direccion,String CodigoCanal, String Tipo,String Parm1, String Param2,
            //String Param3, String Param4, String Param5, String Param6,Int32 Usuario, Int32 Estado
            DataTable dt = new DataTable();
            dt.Columns.Add("Cod_Cliente");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Cod_Canal");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Param1");
            dt.Columns.Add("Param2");
            dt.Columns.Add("Param3");
            dt.Columns.Add("Param4");
            dt.Columns.Add("Param5");
            dt.Columns.Add("Param6");
            dt.Columns.Add("Param7");
            dt.Columns.Add("Param8");
            dt.Columns.Add("Param9");
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
                    row["Cod_Cliente"] = items[0].ToString();
                    row["Nombre"] = items[1].ToString();
                    row["Direccion"] = items[2].ToString();
                    row["Cod_Canal"] = items[3].ToString();
                    row["Tipo"] = items[4].ToString();
                    row["Param1"] = items[5].ToString();
                    row["Param2"] = items[6].ToString();
                    row["Param3"] = items[7].ToString();
                    row["Param4"] = items[8].ToString();
                    row["Param5"] = items[9].ToString();
                    row["Param6"] = items[10].ToString();
                    row["Param7"] = items[11].ToString();
                    row["Param8"] = items[12].ToString();
                    row["Param9"] = items[13].ToString();
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

                            "title: '" +"Error en el Txt: "+ builder.ToString() + "'," +
                             " icon: 'warning'," +
                            "  dangerMode: false," +
                       "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                    return;

            }

    Gv_Producto.DataSource = dt;
            Gv_Producto.DataBind();
            LblTotal.Text = "Total Cliente: " + Gv_Producto.Rows.Count.ToString();
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