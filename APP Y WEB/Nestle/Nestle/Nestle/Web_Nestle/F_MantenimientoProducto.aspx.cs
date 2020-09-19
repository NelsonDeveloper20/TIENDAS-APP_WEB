using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.Diagnostics;
using System.Text;

namespace Web_Nestle
{
    public partial class F_MantenimientoProducto : System.Web.UI.Page
    {
        Producto obj = new Producto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                listarProducto();
            }
        }
        void listarProducto()
        {
            gridSample.DataSource = obj.listarProductos(TxtNombre.Value.ToString().Trim());
            gridSample.DataBind();
        }
        protected void gridSample_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridSample.EditIndex = -1;
            listarProducto();
        }
        protected void gridSample_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridSample.EditIndex = e.NewEditIndex;
            listarProducto();
        }
        protected void gridSample_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 IdProducto = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Values["IdProducto"].ToString());
            GridViewRow row = gridSample.Rows[e.RowIndex];
            Label LblTxt = row.FindControl("LblTxt") as Label;
            TextBox TxtNombren = row.FindControl("TxtNombre") as TextBox;
            TextBox Txtdescripcion = row.FindControl("Txtdescripcion") as TextBox;
            TextBox TxtPrecio = row.FindControl("TxtPrecio") as TextBox;
            TextBox TxtStock = row.FindControl("TxtStock") as TextBox;


            TxtPrecio.Text= TxtPrecio.Text.Replace('.', ',');


            #region VALIDACIONES
            if (TxtNombren.Text == "")
            {

                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Nombre Producto"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                TxtNombren.Focus();
                return;
            }
            if (Txtdescripcion.Text == "")
            {
                Txtdescripcion.Text = "";
            //    String mensajeScript = @"<script type='text/javascript'>
            //           swal({
            //    title: ""Ingrese Nombre Producto"",
            //    icon: ""warning"",
            //    dangerMode: false,
            //})
            //      </script>";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
            //    Txtdescripcion.Focus();
            //    return;
            }

            if (TxtPrecio.Text == "")
            {
                TxtPrecio.Text = "0";
            }
            if (TxtStock.Text == "")
            {
                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Stock"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                TxtStock.Focus();
                return;
            }
            #endregion



            String Msj = "";
            try
            {
Msj = obj.ModificarProducto(IdProducto, LblTxt.Text.ToString().Trim(), TxtNombren.Text.ToString().Trim().ToUpper(),
Txtdescripcion.Text.ToString().Trim().ToUpper(), Convert.ToInt32(TxtStock.Text.ToString()), float.Parse(TxtPrecio.Text.ToString()),
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
                String MSJ1 = builder.ToString();
                string menssajeScript2 = "<script type='text/javascript'>"
                                    + " swal({" +

                            "title: '" + MSJ1.ToString() + "'," +
                             " icon: 'success'," +
                            "  dangerMode: false," +
                       "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript2, false);
                return;
            }

            string menssajeScript = "<script type='text/javascript'>"
                                + " swal({" +

                        "title: '" + Msj.ToString() + "'," +
                         " icon: 'success'," +
                        "  dangerMode: false," +
                   "   })  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
          
            gridSample.EditIndex = -1;
            listarProducto();
        }
        protected void gridSample_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
           
        }
        protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int customerID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
            Int32 Id = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Values["IdProducto"].ToString());
            String Msj = obj.ElimianrProducto(Id, Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));

            if (Msj != "")
            {
                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Elkiminado Correctamente"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);

            }
            listarProducto();
        }


        protected void gridSample_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridSample.FooterRow;
                TextBox TxtCodigoProdInsert = row.FindControl("TxtCodigoProdInsert") as TextBox;
                TextBox TxtNombreInsert = row.FindControl("TxtNombreInsert") as TextBox;
                TextBox TxtDescripcionInsert = row.FindControl("TxtDescripcionInsert") as TextBox;
                TextBox TxtPrecioInsert = row.FindControl("TxtPrecioInsert") as TextBox;
                TextBox TxtStockInsert = row.FindControl("TxtStockInsert") as TextBox;

                #region VALIDACIONES
                if (TxtCodigoProdInsert.Text == "")
                {

                    String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese CodigoTxt"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                    TxtCodigoProdInsert.Focus();
                    return;
                }
                if (TxtNombreInsert.Text == "")
                {
                    String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Nombre Producto"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                    TxtNombreInsert.Focus();
                    return;
                }
               
                if (TxtPrecioInsert.Text == "")
                {
                    TxtPrecioInsert.Text = "0";
                }
                if (TxtStockInsert.Text == "")
                {
                    String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Stock"",
                icon: ""warning"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                    TxtStockInsert.Focus();
                    return;
                }
                #endregion
                TxtPrecioInsert.Text = TxtPrecioInsert.Text.Replace('.', ',');
                String Msj = "";
                try { 
                Msj = obj.InsertarProducto(TxtCodigoProdInsert.Text.ToString().Trim(), TxtNombreInsert.Text.ToString().Trim().ToUpper(),
                    TxtDescripcionInsert.Text.ToString().Trim().ToUpper(),Convert.ToInt32(TxtStockInsert.Text.ToString()),float.Parse(TxtPrecioInsert.Text.ToString()),
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
                String MSJ1 = builder.ToString();
                string menssajeScript2 = "<script type='text/javascript'>"
                                    + " swal({" +

                            "title: '" + MSJ1.ToString() + "'," +
                             " icon: 'warning'," +
                            "  dangerMode: false," +
                       "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript2, false);
            }               
                
                if (Msj != "Insertado")
                {
                    string menssajeScript = "<script type='text/javascript'>"
                                    + " swal({" +
                            "title: '" + Msj.ToString() + "'," +
                             " icon: 'warning'," +
                            "  dangerMode: false," +
                       "   })  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                }
                else
                {
                    string menssajeScript = "<script type='text/javascript'>"
                                  + " swal({" +
                          "title: '" + Msj.ToString() + "'," +
                           " icon: 'success'," +
                          "  dangerMode: false," +
                     "   })  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                }
                listarProducto();
            }
        }

        protected void gridSample_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridSample.PageIndex = e.NewPageIndex;
            listarProducto();
        }

        protected void BtnBu_Click(object sender, EventArgs e)
        {
            listarProducto();
        }
    }
}