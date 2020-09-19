using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Text;
using System.Reflection;
using DB;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Web_Nestle
{
   
    public partial class F_MantCategorias : System.Web.UI.Page
    {

  String Connection = ConfigurationManager.AppSettings["connectionString"].ToString();

        //  String Connection = "Data Source=192.168.2.198;Initial Catalog=BD_NEL_R;User ID=jdextre;Pwd=bgyz0448";

        private DataTable dt;
        Categoria obj = new Categoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Page.IsPostBack == false)
            {
              
                cargarTrev(); 
                treeViewProductos.Attributes.Add("onclick", "fireCheckChanged()");
                //string script = @"<script type=text/javascript> MotsrarUl()</script>";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "myScript", script, false);
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
        public void cargarTrev()
        {
            Int32 total = obj.CountCategoria();
            SqlConnection Con = new SqlConnection(Connection);
            for (int i = 0; i < total; i++)
            {              

                Con.Open();
                SqlCommand Com = Con.CreateCommand();
                Com.CommandText = "Select IdCategoria,Nombre,( SELECT valorTexto FROM Parametros WHERE idParametro=2)+ Imagen as Imagen from Categoria  where IdUp=" + i + " AND Estado=1  order by IdCategoria";
                Com.CommandType = CommandType.Text;
                SqlDataReader r = Com.ExecuteReader();
                while (r.Read())
                {
                    if (i == 0)
                    {
                        String nombre = r["Nombre"].ToString().Trim();
                        String valor = r["IdCategoria"].ToString().Trim();
                        String Imagen = r["Imagen"].ToString().Trim();
                        treeViewProductos.Nodes.Add(AddNode(nombre, valor, Imagen));
                    }
                    else
                    {
                        String nombre = r["Nombre"].ToString().Trim();
                        String valor = r["IdCategoria"].ToString().Trim();
                        String Imagen = r["Imagen"].ToString().Trim();
                        TreeNode nodo = BuscarNodo(treeViewProductos.Nodes, i.ToString());
                        nodo.ChildNodes.Add(AddNode(nombre, valor, Imagen));
                        //TreeView1.Nodes[1].ChildNodes.Add(AddNode("Onion", "10"));
                    }
                }
                Con.Close();
            }
        }
        private TreeNode AddNode(string text, string value,string imagen)
        {
            return new TreeNode
            {
                Text = text  ,
                Value = value,
                ImageUrl= imagen,
                ToolTip = value,          
                SelectAction = TreeNodeSelectAction.None,
                Expanded = false
                
              
                
            };
        }
        TreeNode BuscarNodo(TreeNodeCollection collec, string value)
        {
            TreeNode nodo = new TreeNode();
            for (int i = 0; i < collec.Count; i++)
            {
                if (collec[i].Value.Equals(value))
                    return nodo = collec[i];
                else
                {
                    if (collec[i].ChildNodes.Count > 0)
                        nodo = BuscarNodo(collec[i].ChildNodes, value);
                    if (nodo.Value.Equals(value)) return nodo;
                }
                nodo.Collapse();
            }
            return nodo;
        }

        protected void check_changed(object sender, TreeNodeEventArgs e)
        {
            string clickedNode = e.Node.Text;
            System.Diagnostics.Debugger.Break();
            //System.Diagnostics.Debugger.Break();
            txtnomCategoria.Value = clickedNode;
        }
        public static System.Drawing.Image ResizeImage(System.Drawing.Image srcImage, int newWidth, int newHeight)
        {
            using (Bitmap imagenBitmap =
               new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(
                   Convert.ToInt32(srcImage.HorizontalResolution),
                   Convert.ToInt32(srcImage.HorizontalResolution));

                using (Graphics imagenGraphics =
                        Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode =
                       SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode =
                       InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode =
                       PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage,
                       new Rectangle(0, 0, newWidth, newHeight),
                       new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                       GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    srcImage = System.Drawing.Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }



       
        protected void Submit(object sender, EventArgs e)
        {
            String Msj="";
            
            if (FileUpload2.HasFile == false)
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Imagen"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            if (txtnomCategoria.Value == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Nombre  De Sub Categoria "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            //Response.Write("<script>alert('"+HdnId_Up.Value.ToString()+"')</script>");
            //return;
            //String Msj = "";
            //string message = "Selected nodes:";
            //Int32 IdUp=0;
            //foreach (TreeNode node in treeViewProductos.CheckedNodes)
            //{
            //    message += node.Text + " " + node.Value + "";
            //    IdUp =Convert.ToInt32(node.Value);
            //}
            //            txtnomCategoria.Value = message;
            int alto;
            int ancho;
            try
            {
                FileUpload2.PostedFile.SaveAs(Server.MapPath("~/CategoriaImagen/") + "sub_" + HdnId_Up.Value.ToString() + FileUpload2.PostedFile.FileName);
                System.Drawing.Image img;
                Bitmap imagen = new Bitmap(Server.MapPath("~/CategoriaImagen/") + "sub_" + HdnId_Up.Value.ToString() + FileUpload2.PostedFile.FileName);
                ancho = imagen.Width;
                alto = imagen.Height;
                img = ResizeImage(imagen, 312, 198);
                img.Save(Server.MapPath("~/CategoriaImagen/Z-") + "sub_" + HdnId_Up.Value.ToString() + FileUpload2.PostedFile.FileName);
            }catch(Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                string Mensaje = ex.Message;
                String Mess = "Imagen demasiado pesado";
                string menssajeScript = "<script type='text/javascript'>"
                                      + " swal({" +
                              "title: '" + Mess.ToString() + "'," +
                               " icon: 'warning'," +
                              "  dangerMode: true," +
                         "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }
                Msj = obj.InsertarCategorias(Convert.ToInt32( HdnId_Up.Value.ToString()), txtnomCategoria.Value.ToString().ToUpper(), "Z-" + "sub_" + HdnId_Up.Value.ToString() + Path.GetFileName(FileUpload2.FileName),
                Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));
            string error = @"<script type='text/javascript'>
                       swal({
                title: ""Insertado Correctamente"",
              icon: ""success"",
                dangerMode: false,
            })
                  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", error, false);

            treeViewProductos.Nodes.Clear();
            cargarTrev();
        }
    
        protected void treeViewProductos_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            while (treeViewProductos.CheckedNodes.Count > 0)
            {
                treeViewProductos.CheckedNodes[0].Checked = false;
               
            }
            String Nodee = "";
            //foreach (TreeNode node in treeViewProductos.Nodes)
            //{
               
            //    node.Checked = false;
            //    foreach (TreeNode item1 in node.ChildNodes)
            //    {
            //        item1.Checked = false;

            //        foreach (TreeNode item2 in item1.ChildNodes)
            //        {
            //            item2.Checked = false;
            //        }
            //    }
            //}
            //string clickedNode = e.Node.Text;
            //System.Diagnostics.Debugger.Break();
            //System.Diagnostics.Debugger.Break();
          //  txtnomCategoria.Value = clickedNode;
            //TxtNombreCategoria.Text = "change";
        }

        #region METODO SERVICIE obtenerCateg
        [System.Web.Services.WebMethod]   // Marcamos el método como uno web
        public static List<Categorias> obtenerCateg(String idup)
        {

            List<Categorias> Ubicaciones = new List<Categorias>();
            DataTable dt = new DataTable();
            Categoria objj = new Categoria();
            dt = objj.obtnerIdup(Convert.ToInt32(idup));
            foreach (DataRow row in dt.Rows)
            {
                Categorias Serv = new Categorias();
                Serv.Id = Convert.ToInt32(row["IdCategoria"].ToString());
                Serv.Nombre = row["Nombre"].ToString();
                Serv.Imagen = row["Imagen"].ToString();
                Ubicaciones.Add(Serv);
            }

            return Ubicaciones;
        }
        public class Categorias
        {
            public int Id { get; set; }
            public String Nombre { get; set; }
            public String Imagen { get; set; }
        }
        #endregion

        #region BUTTON REGISTRAR NUEVO CATEGORIA

        protected void BtnNuevo_Cate_Click(object sender, EventArgs e)
        {
            String msj = "";

            if (FlImg_Nuevo.HasFile==false)
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Imagen"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            if (txtNuevoCate.Value == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Nombre De Categoria "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            String Ruta_Save = Server.MapPath("~/CategoriaImagen/");
            String NombreCategoria = txtNuevoCate.Value.ToString().Trim().Substring(2, 3);
          
                int alto;
                int ancho;
            try
            {


                FlImg_Nuevo.PostedFile.SaveAs(Server.MapPath("~/CategoriaImagen/") + NombreCategoria + FlImg_Nuevo.PostedFile.FileName);
                System.Drawing.Image img;
                Bitmap imagen = new Bitmap(Server.MapPath("~/CategoriaImagen/") + NombreCategoria + FlImg_Nuevo.PostedFile.FileName);
                ancho = imagen.Width;
                alto = imagen.Height;
                img = ResizeImage(imagen, 312, 198);
                img.Save(Server.MapPath("~/CategoriaImagen/Z-") + NombreCategoria + FlImg_Nuevo.PostedFile.FileName);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                string Mensaje = ex.Message;
                String Mess = "Imagen demasiado pesado";
                string menssajeScript = "<script type='text/javascript'>"
                                      + " swal({" +
                              "title: '" + Mess.ToString() +"'," +
                               " icon: 'warning'," +
                              "  dangerMode: true," +
                         "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }
            msj = obj.NuevoCategoria(1,txtNuevoCate.Value.ToString().Trim().ToUpper(), 
               "Z-" + NombreCategoria + Path.GetFileName(FlImg_Nuevo.FileName), Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));

          


            if (msj == "INSERTADO")
            {
                string error = @"<script type='text/javascript'>
                       swal({
                title: ""Insertado Correctamente"",
              icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", error, false);
                treeViewProductos.Nodes.Clear();
                cargarTrev();
            }
            treeViewProductos.Nodes.Clear();
            cargarTrev();
            txtNuevoCate.Value = "";
            txtcategoria.Value = "";
            HdnId_Up.Value = "";
            
            //FlImg_Nuevo.Dispose();
        }

        #endregion

        #region BUTTONS 
        protected void BntModificarCate_Click(object sender, EventArgs e)
        {
            string Msj = "";            
            if (txtcategoria.Value == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Nombre De Categoria "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                txtcategoria.Focus();
                return;
            }
   
            //ModificarCategoria(Int32 IdCategoria, String Nombre, String Imagen, Int32 IdUsuario)

            String Ruta_Save = Server.MapPath("~/CategoriaImagen/");
            String NombreCategoria = HdnId_Up.Value.ToString();

            int alto;
            int ancho;
            try
            {
                if (imgInp.HasFile == false)
                {
                    Msj = obj.ModificarCategoria(Convert.ToInt32(HdnId_Up.Value), txtcategoria.Value.ToString().Trim().ToUpper(),
                    HdnFoto.Value.ToString(), Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));
                
                }
                else
                {
                    try
                    {
                        imgInp.PostedFile.SaveAs(Server.MapPath("~/CategoriaImagen/") + NombreCategoria + imgInp.PostedFile.FileName);
                        System.Drawing.Image img;
                        Bitmap imagen = new Bitmap(Server.MapPath("~/CategoriaImagen/") + NombreCategoria + imgInp.PostedFile.FileName);
                        ancho = imagen.Width;
                        alto = imagen.Height;
                        img = ResizeImage(imagen, 312, 198);
                        img.Save(Server.MapPath("~/CategoriaImagen/Z-") + NombreCategoria + imgInp.PostedFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        StackTrace st = new StackTrace(ex, true);
                        string Mensaje = ex.Message;
                        String Mess = "Imagen demasiado pesado";
                        string menssajeScript = "<script type='text/javascript'>"
                                              + " swal({" +
                                      "title: '" + Mess.ToString() + "'," +
                                       " icon: 'warning'," +
                                      "  dangerMode: true," +
                                 "   })  </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                        return;
                    }
                    Msj = obj.ModificarCategoria(Convert.ToInt32(HdnId_Up.Value), txtcategoria.Value.ToString().Trim().ToUpper(),
                    "Z-" + NombreCategoria + Path.GetFileName(imgInp.FileName), Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));

                   
                }
            }catch(Exception ex)
            {
                txtcategoria.Value = "";
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

                              "title: '" + builder.ToString() +" | "+ LineaError.ToString()+ "'," +
                               " icon: 'warning'," +
                              "  dangerMode: true," +
                         "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                
                return;
            }

            if (Msj == "Modificado")
            {
                string error = @"<script type='text/javascript'>
                       swal({
                title: ""Modificado Correctamente"",
              icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", error, false);
                cargarTrev();
            }
            treeViewProductos.Nodes.Clear();
            cargarTrev();
            txtNuevoCate.Value = "";
            txtcategoria.Value = "";
            HdnId_Up.Value = "";


        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            String Msj = "";
            Msj = obj.EliminarCategoria(Convert.ToInt32(HdnId_Up.Value), Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));
            if (Msj == "Modificado")
            {
                string error = @"<script type='text/javascript'>
                       swal({
                title: ""Eliminado Correctamente"",
              icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", error, false);


                treeViewProductos.Nodes.Clear();
                cargarTrev();

            }
            else
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ocurrio un error "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);

            }
          

        }
        public void clear(TreeNodeCollection nodes)
        {
            foreach (TreeNode tn in nodes)
            {
                tn.Checked = false;
                clear(tn.ChildNodes);
            }
        }
        #endregion

    }
}
