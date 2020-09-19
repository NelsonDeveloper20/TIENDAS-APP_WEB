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
    public partial class F_CargaProducto : System.Web.UI.Page
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
                ListarTipos();

                PanelListar.Visible = true;
                PanelSubirNuevo.Visible = false;
                listar();
            }
       }
        public void listar()
        {
            GvListaProductos.DataSource =obj.listarProductosCargados();
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
            { this.MasterPageFile = "~/MenuPrincipal.master"; }
        }
        public void ListarTipos()
        {
            DDFabricante.DataSource = obj.ListarFabricante();
            DDFabricante.DataTextField = "Descripcion";
            DDFabricante.DataValueField = "idFabricante";
            DDFabricante.DataBind();
            DDFabricante.Items.Insert(0, new ListItem("Seleccione...", "0"));

            DDTipo.DataSource = obj.ListarTipoUsuario();
            DDTipo.DataTextField = "Descripcion";
            DDTipo.DataValueField = "IdTipoUsuario";
            DDTipo.DataBind();
            DDTipo.Items.Insert(0, new ListItem("Seleccione..", "0"));
        }

        public void subir()
        {
            if (Gv_Producto.Rows.Count <1)
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
            Int32 IdDistribuidor =  Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdEmpresaMaster"]);
            Int32 IdUsuario =  Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
            //obj.UpdateProducto(IdDistribuidor, IdUsuario);



            DataTable DtLis = new DataTable();
            DtLis.Columns.Add("IdProductoTxt", typeof(string));
            DtLis.Columns.Add("NombrePro", typeof(string));
            DtLis.Columns.Add("Precio", typeof(String));
            DtLis.Columns.Add("StockDisponible", typeof(Int32));

            foreach (GridViewRow row in Gv_Producto.Rows)
            {
                DataRow drog = DtLis.NewRow();

                drog["IdProductoTxt"] = Convert.ToString(row.Cells[0].Text.ToString());
                drog["NombrePro"] = row.Cells[1].Text.ToString();
                drog["Precio"] = Convert.ToString(row.Cells[2].Text.ToString());
                drog["StockDisponible"] = Convert.ToInt32(row.Cells[3].Text.ToString());
                DtLis.Rows.Add(drog);

            }
            obj.insertarProducto(Convert.ToInt32(DDFabricante.SelectedValue), 1, IdUsuario, 1, DtLis);
            //foreach (GridViewRow row in Gv_Producto.Rows)
            //{
            //    //    Int32 IdProcuto, Int32 IdFabricante,Int32 TipoUsuario, Int32 Stock,String NombreProducto,
            //    //float Precio, String Imagen,Int32 Usuario, Int32 Estado
            //   // 12077014 | SUBL Bombon CajE 24 20x8g | 9.46 | 788
            //    obj.insertarProducto(Convert.ToString(row.Cells[0].Text.ToString()),Convert.ToInt32(DDFabricante.SelectedValue),1,
            //        Convert.ToInt32(row.Cells[3].Text.ToString()), row.Cells[1].Text.ToString(),
            //        Convert.ToString(row.Cells[2].Text.ToString()),
            //        "IMG", IdUsuario, 1);
            //}
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
            listar();
            PanelSubirNuevo.Visible = false;
            PanelListar.Visible = true;
        }
        protected void UploadDocument(object sender, EventArgs e)
        {
          /*  if (DDFabricante.SelectedValue == "0")
            {

                String mensajeScriptnm = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Fabricante"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
                DDFabricante.Focus();
                return;
            }
            */
            //if (DDTipo.SelectedValue == "0")
            //{

            //    String mensajeScriptnm = @"<script type='text/javascript'>
            //           swal({
            //    title: ""Seleccione Tipo Usuario"",
            //    icon: ""warning"",
            //    dangerMode: false,
            //})
            //      </script>";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
            //    DDTipo.Focus();
            //    return;
            //}
           
                DataTable dt = new DataTable();
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Precio");
                dt.Columns.Add("Stock");
                dt.Columns.Add("Fabricante");
                dt.Columns.Add("TipoUsuario");
            String Fabricante = "1";
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
                        row["Fabricante"] = Fabricante.ToString();
                        row["TipoUsuario"] = 1.ToString();
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

            Gv_Producto.DataSource = dt;
            Gv_Producto.DataBind();
            LblTotal.Text = "Total Producto: " + Gv_Producto.Rows.Count.ToString();
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