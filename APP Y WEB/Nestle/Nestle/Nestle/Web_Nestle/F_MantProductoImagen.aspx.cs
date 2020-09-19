using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;
namespace Web_Nestle
{
    public partial class F_MantProductoImagen : System.Web.UI.Page
    {
        Fotos Obj = new Fotos();
      public  DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //try { 
            if (Page.IsPostBack == false)
            {
                if (Request.Cookies["WebNestle"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                listar();
            //string sc1 = FuncCopyItem("addContact", "funct_rh", "nm");
            //    ClientScriptManager cs = Page.ClientScript;
            //    cs.RegisterStartupScript(this.GetType(), "addContact", sc1, true);
            }
            //}catch(Exception EX)
            //{

            //}
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
        public void listar()
        {
          
            Int32 Id_Img = 1;
            String Img = "img_";
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    Img += i.ToString();
                }
            }

            GV_prodImage.DataSource = Obj.ListarProductoFoto(1, TxtBuscarG.Value.ToString());
            GV_prodImage.DataBind();
            DataList1.DataSource = Obj.ListarProductoFoto(1, TxtBuscarG.Value.ToString());
            DataList1.DataBind();

        }
        protected void GvModif_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)

            {
            }
        }
      



        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            //NELSONNNNN YA CASI :)
            String Msj = "";
            String Ruta_Save = Server.MapPath("~/ProductoImagen/");
            String filename = "";
            foreach (GridViewRow row in GV_prodImage.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {


                    FileUpload FlFoto1 = (FileUpload)row.FindControl("FileUpload1");
                    if (FlFoto1.FileName != "")
                    {
                        int alto;
                        int ancho;
                        

                        String ruta = row.Cells[2].Controls.OfType<FileUpload>().FirstOrDefault().FileName;
                        FileUpload FlFoto = (FileUpload)row.FindControl("FileUpload1");
                        String IdTxt = row.Cells[0].Controls.OfType<Label>().FirstOrDefault().Text;
                        Msj = Obj.ModificarProductoImg(row.Cells[0].Controls.OfType<Label>().FirstOrDefault().Text.ToString(),
                            IdTxt + Path.GetFileName(FlFoto.FileName), Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]), 1);
                        // SaveAs method of PostedFile property used
                        // to save the file at specified rooted path
                       
                        FlFoto1.PostedFile.SaveAs(Server.MapPath("~/ProductoImagen/") + IdTxt + FlFoto1.PostedFile.FileName);
                        System.Drawing.Image img;
                        Bitmap imagen = new Bitmap(Server.MapPath("~/ProductoImagen/") + IdTxt + FlFoto1.PostedFile.FileName);
                        ancho = imagen.Width;
                        alto = imagen.Height;
                        img = ResizeImage(imagen, 312, 198);
                        img.Save(Server.MapPath("~/ProductoImagen/Z-") + IdTxt + FlFoto1.PostedFile.FileName);
                        //img.Save(Server.MapPath(Server.MapPath(Ruta_Save + IdTxt + Path.GetFileName(FlFoto.FileName))));
                        //FlFoto.SaveAs(Ruta_Save + IdTxt + Path.GetFileName(FlFoto.FileName));

                    }
                  


                    
                }

                if (Msj == "Modificado")
                {
                    string error = @"<script type='text/javascript'>
                       swal({
                title: ""Operacion Exitosa"",
              icon: ""success"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", error, false);
                }
            }


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
        string FuncCopyItem(string name, string source, string destiny)
        {

            String idImage = "#img-upload";
            String Id_FileUpload = "#imgInp";
            string s = " $(document).ready(function () {  function   readURL" + name + "() {" +
                " if (input.files && input.files[0]) { " +
                " var reader = new FileReader();" +
                " reader.onload = function(e) {" +
                " $('#img-upload').attr('src', e.target.result);" +
                     " $('"+ idImage + "').attr('src', e.target.result);" +
                " } " +
                         " reader.readAsDataURL(input.files[0]); " +
                         " } " +
                                " }" +

                        " $('" + Id_FileUpload + "').change(function() { " +
                                " readURL(this); " +
                                        " }); });   ";
            return s;
        }
        protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = -1;
            listar();
        }
        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int id = Convert.ToInt16(DataList1.DataKeys[e.Item.ItemIndex].ToString());
            //bu.user_delete(id);
            //listar();

        }
        protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
        {
           
            DataList1.EditItemIndex = e.Item.ItemIndex;
            listar();

        }
        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
         
            String Id_Product = DataList1.DataKeys[e.Item.ItemIndex].ToString();
            FileUpload FlFoto = DataList1.Items[e.Item.ItemIndex].FindControl("FileUpload2") as FileUpload;
            
            String Msj = "";
            String Ruta_Save = Server.MapPath("~/ProductoImagen/");
            String filename = "";          
                    if (FlFoto.FileName != "")
                    {
                        int alto;
                        int ancho;                        
                        Msj = Obj.ModificarProductoImg(Id_Product,
                          "Z-"+ Id_Product + Path.GetFileName(FlFoto.FileName), 1, 1);
                        // SaveAs method of PostedFile property used
                        // to save the file at specified rooted path
                        FlFoto.PostedFile.SaveAs(Server.MapPath("~/ProductoImagen/") + Id_Product + FlFoto.PostedFile.FileName);
                        System.Drawing.Image img;
                        Bitmap imagen = new Bitmap(Server.MapPath("~/ProductoImagen/") + Id_Product + FlFoto.PostedFile.FileName);
                        ancho = imagen.Width;
                        alto = imagen.Height;
                        img = ResizeImage(imagen, 312, 198);
                        img.Save(Server.MapPath("~/ProductoImagen/Z-") + Id_Product + FlFoto.PostedFile.FileName);
                //img.Save(Server.MapPath(Server.MapPath(Ruta_Save + IdTxt + Path.GetFileName(FlFoto.FileName))));
                //FlFoto.SaveAs(Ruta_Save + IdTxt + Path.GetFileName(FlFoto.FileName));

            }else if  (FlFoto.FileName == "")
                
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Imagen "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }

            DataList1.EditItemIndex = -1;
                listar();
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
                }
            
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }
    }
}