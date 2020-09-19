using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Diagnostics;
using DB;
namespace Web_Nestle
{
    public partial class F_SendPromociones : System.Web.UI.Page
    {
        Notificacion obj = new Notificacion();
        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (Request.Cookies["WebNestle"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Page.IsPostBack == false)
            {


                PanelAgregar.Visible = false;
                panelListar.Visible = true;

                ListarNotficaciones(TxtBuscarG.Value.ToString().Trim());
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("TipoUsuer"), new DataColumn("IdTipoUser") });
                GridView1.DataSource = dt;
                GridView1.DataBind();
                ViewState["Data"] = dt;
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
        public void ListarNotficaciones(String Titulo)
        {
            GvNofiticacion.DataSource = obj.ListarNotificacion(Titulo.ToString().Trim());
            GvNofiticacion.DataBind();
        }
        protected void GvPromociones_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string pub_id = GvPromociones.DataKeys[e.Row.RowIndex].Value.ToString();
               
                //if (e.Row.Cells[13].Text == "0")
                //{
                //    e.Row.Cells[11].Text = "<img src='http://201.234.124.219/webgesthorario/Iconos/accept.png' width='23px' height='20px'/>";
                //    e.Row.Cells[11].Enabled = false;
                //}


            }
        }
        protected void GvPromociones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 Indice = int.Parse(e.CommandArgument.ToString());
            Int32 IdNotificacion = int.Parse(GvNofiticacion.Rows[Indice].Cells[0].Text);

            if (e.CommandName == "EnviarPush")
            {
                String Msj = "";
                DataTable dt = new DataTable();
                dt = obj.NotificacionXid(IdNotificacion);
                String Titulo = "";
                    String Descripcion = "";
                String Imagen = "";
                foreach (DataRow item in dt.Rows)
                {
                    Titulo = item["Titulo"].ToString().ToString();
                    Descripcion = item["Descripcion"].ToString().ToString();
                    Imagen = item["Imagen"].ToString().ToString();

                }
                Int32 idusuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
                Msj = obj.EnviarNotifi(IdNotificacion, idusuario);
                if(Msj== "Enviado")
                {

                    String mensajeScript = @"<script type='text/javascript'>  enviarnotificacion('" + idusuario + "','" + Titulo + "','" + Descripcion + "','" + Imagen + "','" + IdNotificacion + "')     </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);


                }
                TxtBuscarG.Value = "";
                ListarNotficaciones(TxtBuscarG.Value.ToString().Trim());

            }
         
        }



        #region Metodo que recorta tamaño del imagen
        static byte[] CropImage(string sImagePath, int iWidth, int iHeight, int iX, int iY)
        {
            try
            {
                using (System.Drawing.Image oOriginalImage = System.Drawing.Image.FromFile(sImagePath))
                {
                    using (System.Drawing.Bitmap oBitmap = new System.Drawing.Bitmap(iWidth, iHeight))
                    {
                        oBitmap.SetResolution(oOriginalImage.HorizontalResolution, oOriginalImage.VerticalResolution);
                        using (System.Drawing.Graphics Graphic = System.Drawing.Graphics.FromImage(oBitmap))
                        {
                            Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                            Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            Graphic.DrawImage(oOriginalImage, new System.Drawing.Rectangle(0, 0, iWidth, iHeight), iX, iY, iWidth, iHeight, System.Drawing.GraphicsUnit.Pixel);
                            MemoryStream oMemoryStream = new MemoryStream();
                            oBitmap.Save(oMemoryStream, oOriginalImage.RawFormat);
                            return oMemoryStream.GetBuffer();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        #endregion

        #region Resize imagen
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

        #endregion

        #region GUARDAR EN BD
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (TxtTitulo.Value == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Titulo"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            if (TxtDescripcion.Text == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Descripcion"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }

            if (UploasIMg.HasFile == false)
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
            System.Drawing.Bitmap LaImagen = new System.Drawing.Bitmap(UploasIMg.PostedFile.InputStream);
            if (((LaImagen.Width != 350) || (LaImagen.Height != 625)))
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""El tamaño del imagen debe ser:  horizontal: 350 pixeles - Vertical: 625 pixeles"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            Int32 IdNotificacion = 0;
            int alto;
            int ancho;
            DateTime thisDay = DateTime.Now;
            String str, str2, str3, str4;
            str = thisDay.ToString(); //.ToString("dd/MM/yyyy hh:mm:ss");
            str2 = str.Replace("/", "_");
            str3 = str2.Replace(" ", "_");
            str4 = str3.Replace(":", "_");
            //Response.Write("<script>alert('" + str4.ToString() + "')</script>");
            try
            {
                UploasIMg.PostedFile.SaveAs(Server.MapPath("~/NotificacionImagen/") + str4.ToString() + UploasIMg.PostedFile.FileName);
                System.Drawing.Image img;
                Bitmap imagen = new Bitmap(Server.MapPath("~/NotificacionImagen/") + str4.ToString() + UploasIMg.PostedFile.FileName);
                ancho = imagen.Width;
                alto = imagen.Height;
                img = ResizeImage(imagen, 350, 625);
                img.Save(Server.MapPath("~/NotificacionImagen/Z-") + str4.ToString() + UploasIMg.PostedFile.FileName);
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
            //TxtTitulo.Value.ToString()+ 
            IdNotificacion = obj.InsertarNotificaciones(TxtTitulo.Value.ToString().Trim().ToUpper(), TxtDescripcion.Text.ToString().ToUpper().Trim(),
                "Z-" + str4.ToString() + Path.GetFileName(UploasIMg.FileName),
            Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));

            Promociones obj_promocion = new Promociones();
            Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
            if (IdNotificacion != 0)
            {

                foreach (GridViewRow row in gv_insert.Rows)
                {
                    obj_promocion.InsertarNotificacionTipoUser(IdNotificacion, Convert.ToInt32(row.Cells[2].Text.ToString()));
                }
            }
            string mensaje = @"<script type='text/javascript'>
                       swal({
                title: ""Insertado Correctamente"",
              icon: ""success"",
                dangerMode: false,
            })
                  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensaje, false);

            PanelAgregar.Visible = false;
            panelListar.Visible = true;
            TxtBuscarG.Value = "";
            ListarNotficaciones(TxtBuscarG.Value.ToString().Trim());
        }

        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            PanelAgregar.Visible = false;
            panelListar.Visible = true;
            TxtBuscarG.Value = "";
            TxtDescripcion.Text = "";
            TxtTitulo.Value = "";
            ListarNotficaciones(TxtBuscarG.Value.ToString().Trim());
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("TipoUsuer"), new DataColumn("IdTipoUser") });
            GridView1.DataSource = dt;
            GridView1.DataBind();
            gv_insert.DataSource = dt;
            gv_insert.DataBind();
            ViewState["Data"] = dt;
        }

        protected void LinkButton1_DataBinding(object sender, EventArgs e)
        {
            panelListar.Visible = false;
            PanelAgregar.Visible = true;
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            panelListar.Visible = false;
            TxtBuscarG.Value = "";
            TxtDescripcion.Text = "";
            TxtTitulo.Value = "";
            PanelAgregar.Visible = true;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("TipoUsuer"), new DataColumn("IdTipoUser") });
            GridView1.DataSource = dt;
            GridView1.DataBind();
            gv_insert.DataSource = dt;
            gv_insert.DataBind();
            ViewState["Data"] = dt;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            ListarNotficaciones(TxtBuscarG.Value.ToString().Trim());
        }
        #region GRUD GRIDVIEW TIPO USUARIO
        protected void Add(object sender, EventArgs e)
        {
            Control control = null;
            if (GridView1.FooterRow != null)
            {
                control = GridView1.FooterRow;
            }
            else
            {
                control = GridView1.Controls[0].Controls[0];
            }
            string TipoUsuario = (control.FindControl("dd_tipo") as DropDownList).SelectedItem.ToString().Trim();
            string Id_tipoUserol = (control.FindControl("dd_tipo") as DropDownList).SelectedValue.ToString().Trim();

            foreach (GridViewRow row in gv_insert.Rows)
            {

                if (row.Cells[2].Text.ToString() == Id_tipoUserol.ToString())
                {


                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ya Existe Tipo Usuario"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                 
                    return;
                }
            }
            DataTable dt = ViewState["Data"] as DataTable;
            int lastId;
            if (dt.Rows.Count == 0)
            {
                lastId = 1;
                dt.Rows.Add(lastId, TipoUsuario, Id_tipoUserol);
            }
            else
            {
                lastId = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["Id"].ToString());
                dt.Rows.Add(lastId + 1, TipoUsuario, Id_tipoUserol);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            gv_insert.DataSource = dt;
            gv_insert.DataBind();
            ViewState["Data"] = dt;
        }

        protected void Delete(object sender, EventArgs e)
        {
            string id = ((sender as LinkButton)).CommandArgument;
            DataTable dt = ViewState["Data"] as DataTable;
            DataRow dr = dt.Select("Id=" + id)[0];
            dt.Rows.Remove(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            gv_insert.DataSource = dt;
            gv_insert.DataBind();
            ViewState["Data"] = dt;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                Subir_txt objj = new Subir_txt();
                DropDownList ddtipuser = (DropDownList)e.Row.FindControl("dd_tipo");
                ddtipuser.DataSource = objj.ListarTipoUsuario();
                ddtipuser.DataTextField = "Descripcion";
                ddtipuser.DataValueField = "IdTipoUsuario";
                ddtipuser.DataBind();
                ddtipuser.Items.Insert(0, new ListItem("Seleccione..", "0"));
                ddtipuser.DataBind();
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {

                Subir_txt objj = new Subir_txt();
                DropDownList ddtipuser = (DropDownList)e.Row.FindControl("dd_tipo");
                ddtipuser.DataSource = objj.ListarTipoUsuario();
                ddtipuser.DataTextField = "Descripcion";
                ddtipuser.DataValueField = "IdTipoUsuario";
                ddtipuser.DataBind();
                ddtipuser.Items.Insert(0, new ListItem("Seleccione..", "0"));
                ddtipuser.DataBind();
            }
        }

        #endregion
    }
}