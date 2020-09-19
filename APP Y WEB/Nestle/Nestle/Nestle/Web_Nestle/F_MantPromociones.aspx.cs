using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Globalization;
using System.Net;
using System.IO;

namespace Web_Nestle
{
    public partial class F_MantPromociones : System.Web.UI.Page
    {
        //  String Connection = "Data Source=192.168.2.198;Initial Catalog=BD_NEL_R;User ID=jdextre;Pwd=bgyz0448";
        String Connection = ConfigurationManager.AppSettings["connectionString"].ToString();
        Promociones obj = new Promociones();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request.Cookies["WebNestle"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                if (Page.IsPostBack == false)
                     {

                    DateTime thisDay = DateTime.Today;
                    TXtBuscFecInicio.Value = thisDay.ToString("dd/MM/yyyy");
                    TxtBuscFechFin.Value = thisDay.ToString("dd/MM/yyyy");
                    Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
                    obj.crudoperations("DELETEALL", IdUsuario, "", 0, "", 0, 0, 0, IdUsuario.ToString(), "");
                    listarPromciones();
                    listarPromciones();
                    listar();
                    cargarTrev();
                    BindGridview();
                    Session["Mustra"] = "";
                    Panel_Listar.Visible = true;
                    Panel_Agregar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //        Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);

                //obj.crudoperations("DELETEALL", IdUsuario, "", 0, "", 0, 0, 0, IdUsuario.ToString(), "");
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

                              "title: '" + builder.ToString() + LineaError + "'," +
                               " icon: 'warning'," +
                              "  dangerMode: true," +
                         "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
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
        public void listarPromciones()
        {
            DateTime FechaFinal = Convert.ToDateTime(TxtBuscFechFin.Value, new CultureInfo("es-ES"));
            FechaFinal = FechaFinal.AddDays(1);
            string FechaSalida = FechaFinal.ToString("dd/MM/yyyy");
            //GvPromociones.DataSource = obj.ListarPromociones(1, TXtBuscFecInicio.Value.ToString(),FechaFinal.ToString());
            //GvPromociones.DataBind();
        }
        private DataTable Getdata1
        {
            get
            {
                DataTable dt = new DataTable();
                dt = obj.ListarDetalleProciones();
                return dt;
            }
        }
        protected void GvPromociones_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string pub_id = GvPromociones.DataKeys[e.Row.RowIndex].Value.ToString();
                //string sql = "SELECT pub_id, title, type,price FROM titles  WHERE pub_id='" + pub_id + "'";
                //GridView pubTitle = (GridView)e.Row.FindControl("GridView2");
                //pubTitle.DataSource = getData(sql);
                //pubTitle.DataBind();

                string id1 = GvPromociones.DataKeys[e.Row.RowIndex].Value.ToString();
                DataTable dt = Getdata1.Clone();
                foreach (DataRow dr in Getdata1.Rows)
                {
                    if (dr[0].ToString() == id1)
                    {
                        DataRow newdr = dt.NewRow();
                        newdr[0] = dr[0];
                        newdr[1] = dr[1];
                        newdr[2] = dr[2];
                        newdr[3] = dr[3];
                        newdr[4] = dr[4];
                        newdr[5] = dr[5];
                        newdr[6] = dr[6];
                        dt.Rows.Add(newdr);
                    }
                }
                GridView grdview = e.Row.FindControl("GridView2") as GridView;
                grdview.DataSource = dt;
                grdview.DataBind();
                if (e.Row.Cells[13].Text == "0")
                {
                    e.Row.Cells[11].Text = "<img src='http://201.234.124.219/webgesthorario/Iconos/accept.png' width='23px' height='20px'/>";
                    e.Row.Cells[11].Enabled = false;
                }
               

            }
        }
        #region listar gridview crud
        public void BindGridview()
        {
            DataSet ds = new DataSet();
            ds = obj.listar_prom_boni(Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));
            if (ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                       String nm= Session["Mustra"].ToString();
                              row[2] = nm.ToString();
                        
                    }
                }
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
                GvInsert.DataSource = ds;
                GvInsert.DataBind();

                TextBox lblCreateDate = ((TextBox)gvDetails.FooterRow.FindControl("TxtInsProdProm"));
                lblCreateDate.Text = Session["Mustra"].ToString();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
                int columncount = gvDetails.Rows[0].Cells.Count;
                gvDetails.Rows[0].Cells.Clear();
                gvDetails.Rows[0].Cells.Add(new TableCell());
                gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                gvDetails.Rows[0].Cells[0].Text = "No Records Found";
                gvDetails.Rows[0].Cells[0].Style["display"] = "none";
            }
        }
        #endregion
        #region listar dropdown
        public void listar()
        {

            DDCondicion.DataSource = obj.ListarCondicion();
            DDCondicion.DataTextField = "Descripcion";
            DDCondicion.DataValueField = "idCondicion";
            DDCondicion.DataBind();
            DDCondicion.Items.Insert(0, new ListItem("Seleccione...", "0"));
            DDTipoCondicion.DataSource = obj.ListarTipoCondicion();
            DDTipoCondicion.DataTextField = "Descripcion";
            DDTipoCondicion.DataValueField = "idTipoCondicion";
            DDTipoCondicion.DataBind();
            DDTipoCondicion.Items.Insert(0, new ListItem("Seleccione...", "0"));

            DDTipoProducto.DataSource = obj.ListarProducto(1);
            DDTipoProducto.DataTextField = "Nombre";
            DDTipoProducto.DataValueField = "IdProductoTxt";
            DDTipoProducto.DataBind();
            DDTipoProducto.Items.Insert(0, new ListItem("Seleccione...", "0"));
            DDTipoProducto.Items.Insert(0, new ListItem("...Todos...", "1"));






            DDProdBoni.DataSource = obj.ListarProducto(1);
            DDProdBoni.DataTextField = "Nombre";
            DDProdBoni.DataValueField = "IdProductoTxt";
            DDProdBoni.DataBind();
            DDProdBoni.Items.Insert(0, new ListItem("Seleccione...", "0"));


            DDTipoBonificacion.DataSource = obj.ListarTipoBonificacion();
            DDTipoBonificacion.DataTextField = "Descripcion";
            DDTipoBonificacion.DataValueField = "IdTipoBonificacion";
            DDTipoBonificacion.DataBind();
            DDTipoBonificacion.Items.Insert(0, new ListItem("Seleccione...", "0"));

            //DDtipoPromocion.Items.Insert(0, new ListItem("Todos", "1"));
            DDtipoPromocion.Items.Insert(0, new ListItem("Producto", "1"));
            DDtipoPromocion.Items.Insert(0, new ListItem("Categoria", "2"));
            DDtipoPromocion.Items.Insert(0, new ListItem("Seleccione..", "0"));

            Subir_txt objj = new Subir_txt();
            DDTipoUsuario.DataSource = objj.ListarTipoUsuario();
            DDTipoUsuario.DataTextField = "Descripcion";
            DDTipoUsuario.DataValueField = "IdTipoUsuario";
            DDTipoUsuario.DataBind();
            DDTipoUsuario.Items.Insert(0, new ListItem("Seleccione..", "0"));

        }
        #endregion
        protected void DDtipoPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DDtipoPromocion.Items.Insert(0, new ListItem("Producto", "1"));
            //DDtipoPromocion.Items.Insert(0, new ListItem("Categoria", "2"));
            //if(DDtipoPromocion.SelectedValue== "1")
            //{
            //    producto.Attributes.Add("style", "display:block");
            //    categoria.Attributes.Add("style", "display:block"); 
            //}
            if (DDtipoPromocion.SelectedValue == "1") {
                producto.Attributes.Add("style", "display:block");
                categoria.Attributes.Add("style", "display:none");
            } 
            else if(DDtipoPromocion.SelectedValue == "2")
            {

                categoria.Attributes.Add("style", "display:block");
                producto.Attributes.Add("style", "display:none"); 

               
            }

            BindGridview();

            //Label lblWebsite = ((Label)gvDetails.FooterRow.FindControl("lblWebsite"));
            //lblWebsite.Text = Website;
        }

        #region TREEVIEW SUB CATEGORIAS
        public void cargarTrev()
        {
            int total = 1000;
            SqlConnection Con = new SqlConnection(Connection);
            for (int i = 0; i < total; i++)
            {

                Con.Open();
                SqlCommand Com = Con.CreateCommand();
                Com.CommandText = "Select IdCategoria,Nombre,Imagen from Categoria where IdUp=" + i + " AND Estado=1  order by IdCategoria";
                Com.CommandType = CommandType.Text;
                SqlDataReader r = Com.ExecuteReader();


                while (r.Read())
                {
                    if (i == 0)
                    {
                        String nombre = r["Nombre"].ToString().Trim();
                        String valor = r["IdCategoria"].ToString().Trim();
                        String Imagen = r["Imagen"].ToString().Trim();
                        DDtipoCategoria.Items.Insert(0, new ListItem(nombre, valor));
                        DDtipoCategoria.DataBind();
                    }
                    else
                    {
                    

                    }
                }
                Con.Close();
            }
            DDtipoCategoria.Items.Insert(0, new ListItem("Seleccione...", "0"));
            DDtipoCategoria.Items.Insert(0, new ListItem("Todos...", "1"));

        }

        #endregion

        #region crud gridview

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                Int32 idusuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
                TextBox TxtProdProm = (TextBox)gvDetails.FooterRow.FindControl("TxtInsProdProm");
                TextBox TxtCantProm = (TextBox)gvDetails.FooterRow.FindControl("TxtCanProm");
                DropDownList ddProdBoni = (DropDownList)gvDetails.FooterRow.FindControl("DDProdBoniProd");
                //TextBox TxtProdBoni = (TextBox)gvDetails.FooterRow.FindControl("TxtInsProdBoni");
                TextBox TxtCantBoni = (TextBox)gvDetails.FooterRow.FindControl("TxtIsnCantBoni");
                TextBox TxtStock = (TextBox)gvDetails.FooterRow.FindControl("TxtInsStock");
                TextBox TxtDescripcion = (TextBox)gvDetails.FooterRow.FindControl("TxtInsDescripcion");
                //string status, Int32 IdUsuario, string IdProd_prom, Int32 Cantidad_Prom,
                //String Idprod_boni, Int32 Cantidad_Boni,Int32 Stock, int idPromBoni
                if (TxtCantProm.Text == "")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Cantidad Promocion "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                    BindGridview();
                    return;
                }
                if (TxtCantBoni.Text == "")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""ingrese Monto Bonificacion  "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                    BindGridview();
                    return;
                }
                if (TxtStock.Text == "")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""ingrese Stock  "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                    BindGridview();
                    return;
                }
                if (ddProdBoni.SelectedValue == "0")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Producto Bonificacion "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                    BindGridview();
                    return;
                }
                if (DDtipoPromocion.SelectedValue == "0")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Tipo Promocion  "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                    BindGridview();
                    return;
                }


                if (DDtipoPromocion.SelectedValue == "1" && DDTipoProducto.SelectedValue == "0")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Producto"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                    BindGridview();
                    return;
                }
                if (DDtipoPromocion.SelectedValue == "2" && DDtipoCategoria.SelectedValue == "0")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Categoria  "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                    BindGridview();
                    return;
                }
                obj. crudoperations("INSERT",idusuario, TxtProdProm.Text,Convert.ToInt32(TxtCantProm.Text),
                   ddProdBoni.SelectedItem.ToString(),
                    Convert.ToInt32(TxtCantBoni.Text), Convert.ToInt32(TxtStock.Text), 0, ddProdBoni.SelectedValue.ToString(), TxtDescripcion.Text.ToString().Trim().ToUpper()); gvDetails.EditIndex = -1;
                BindGridview();

                TextBox lblCreateDate = ((TextBox)gvDetails.FooterRow.FindControl("TxtInsProdProm"));
                lblCreateDate.Text = TxtProdProm.Text.ToString();
            }
        }
        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDetails.EditIndex = e.NewEditIndex;
            BindGridview();
        }
        protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetails.EditIndex = -1;
            BindGridview();
        }
        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetails.PageIndex = e.NewPageIndex;
            BindGridview();
        }
        protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idpromboni = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["idPromBoni"].ToString());
            TextBox TxtrProdPromo = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("TxtProductPromo");
            TextBox TxtCantProm = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("TxtCantProm");
            DropDownList TxtProdBoni = (DropDownList)gvDetails.Rows[e.RowIndex].FindControl("TxtProdBoni");
            TextBox TxtCantBoni = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("TxtCantBoni");
            TextBox TxtStock = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("TxtStock");
            Int32 idusuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
            TextBox TxtDescripcion = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("TxtDescripcion");

            if (TxtCantProm.Text == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""ingrese Cantidad Promocion  "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            if (TxtCantBoni.Text == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""ingrese Cantidad Bonificacion  "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            if (TxtStock.Text == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""ingrese Stock "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }

            obj.crudoperations("UPDATE", idusuario, TxtrProdPromo.Text, Convert.ToInt32(TxtCantProm.Text), TxtProdBoni.SelectedItem.ToString(),
                   Convert.ToInt32(TxtCantBoni.Text), Convert.ToInt32(TxtStock.Text), idpromboni, TxtProdBoni.SelectedValue.ToString(), TxtDescripcion.Text.Trim().ToUpper()); gvDetails.EditIndex = -1;
            BindGridview();

        }
        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdBoniProm = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["idPromBoni"].ToString());
            string idusuario = gvDetails.DataKeys[e.RowIndex].Values["idusuario"].ToString();    
                   
            obj.crudoperations("DELETE",Convert.ToInt32(idusuario), "", 0, "",     0, 0, IdBoniProm, idusuario,"");
            gvDetails.EditIndex = -1;
            BindGridview();

            TextBox lblCreateDate = ((TextBox)gvDetails.FooterRow.FindControl("TxtInsProdProm"));
            lblCreateDate.Text = Session["Mustra"].ToString();
        }

        protected void grvMergeHeader_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                
                HeaderCell = new TableCell();
                HeaderCell.Text = "Promocion Producto-Categoria";
                HeaderCell.ColumnSpan = 3;
                HeaderCell.Style.Value = " text-align: center;font-size: 12px;height: 4px; background: #0078D7;color:white;border-radius:75px 72px 0px 0px;  -moz-border-radius: 12px 12px 0px 0px;            -webkit-border-radius: 12px 12px 0px 0px;border: 0px solid #000000;text-align: -webkit-center;";

                HeaderGridRow.Cells.Add(HeaderCell);
                HeaderCell = new TableCell();
                HeaderCell.Text = "Bonificacion";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Value = " text-align: center;font-size: 12px;height: 4px; background: #0078D7;color:white;border-radius:75px 72px 0px 0px;  -moz-border-radius: 12px 12px 0px 0px;            -webkit-border-radius: 12px 12px 0px 0px;border: 0px solid #000000;text-align: -webkit-center;";

                HeaderGridRow.Cells.Add(HeaderCell);
                
                gvDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);


            }
        }

        #endregion

        #region databound
        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList ddprod = (DropDownList)e.Row.FindControl("DDProdBoniProd");
                ddprod.DataSource = obj.ListarProducto(1);
                ddprod.DataTextField = "Nombre";
                ddprod.DataValueField = "IdProductoTxt";
                ddprod.DataBind();
                ddprod.Items.Insert(0, new ListItem("Seleccione...", "0"));
                
                //TextBox LblProd_Boni = (TextBox)e.Row.FindControl("TxtProductPromo");
                //ChkLu.Text = Session["Mustra"].ToString();               

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //Label LblProd_Boni = (Label)e.Row.FindControl("LblProducPromo");
                //if (GvInsert.Rows.Count > 0)
                //{

                //    LblProd_Boni.Text = Session["Mustra"].ToString();
                //}

                //if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                //{
                //    DropDownList ddList = (DropDownList)e.Row.FindControl("DDprod_EditBoni");
                //    //bind dropdown-list
                //    DataTable dt = obj.ListarProducto(1);
                //    ddList.DataSource = dt;
                //    ddList.DataTextField = "Nombre";
                //    ddList.DataValueField = "IdProductoTxt";
                //    ddList.DataBind();
                //    DataRowView dr = e.Row.DataItem as DataRowView;
                //    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                //    ddList.SelectedValue = dr["IdProdcuto_Categoria"].ToString();

                //    //DropDownList ddlSelectEmpres = (e.Row.FindControl("DDprod_EditBoni") as DropDownList);
                //    //String IdEmp = (e.Row.FindControl("idprox") as Label).Text;
                //    //ddlSelectEmpres.Items.FindByValue(IdEmp).Selected = true;

                //    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                //    TextBox txt = (TextBox)e.Row.FindControl("TxtInsProdProm");
                //    txt.Text = Session["Mustra"].ToString();

                //}
            }
            //DropDownList ddprod_edit = (DropDownList)e.Row.FindControl("DDprod_EditBoni");
            //        ddprod_edit.DataSource = obj.ListarProducto(1);
            //        ddprod_edit.DataTextField = "Nombre";
            //        ddprod_edit.DataValueField = "IdProductoTxt";
            //        ddprod_edit.DataBind();
            //        DropDownList ddlSelectEmpres = (e.Row.FindControl("DDprod_EditBoni") as DropDownList);
            //        String IdEmp = (e.Row.FindControl("idprox") as Label).Text;
            //        ddlSelectEmpres.Items.FindByValue(IdEmp).Selected = true;
                
            
            


            }

        #endregion
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            ////Response.Write("<script>alert('"+ TxtFechaIni.Value.ToString()+" | " + TxtFechaFin.Value.ToString() + "')</script>");
            ////return;
            //Hdn_IdPromocion.Value = 27.ToString();
            if (DDTipoUsuario.SelectedValue == "0")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Tipo Usuario "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                BindGridview();
                return;
            }
            if (TxtFechaIni.Value == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Fecha Inicio "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                BindGridview();
                return;
            }
            if (TxtFechaFin.Value == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Fecha Fin "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                BindGridview();
                return;
            }
            if (DDCondicion.SelectedValue == "0")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Condicion "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                BindGridview();
                return;
            }
            if (DDTipoCondicion.SelectedValue == "0")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Tipo Condicion "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                BindGridview();
                return;
            }

            if (DDTipoBonificacion.SelectedValue == "0")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Tipo Bonificacion "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                BindGridview();
                return;
            }
            if (DDTipoBonificacion.SelectedValue != "1")
            {
                if (TxtMontoBonifica.Text == "")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""ingrese Monto Bonificacion  "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                    BindGridview();
                    return;
                }
            }
            
            if (DDtipoPromocion.SelectedValue == "0")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Tipo Promocion "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                BindGridview();
                return;
            }

          
            if (DDtipoPromocion.SelectedValue == "1" && DDTipoProducto.SelectedValue=="0") {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Producto "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                BindGridview();
                return;
            }
            if (DDtipoPromocion.SelectedValue == "2" && DDtipoCategoria.SelectedValue == "0")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Categoria "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                BindGridview();
                return;
            }

            if (GvInsert.Rows.Count < 1)
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Ingresar Bonificaciones"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                BindGridview();
                return;
            }

            String Producto_dd = "";
            String Categoria_dd = "";
            if (DDtipoPromocion.SelectedValue == "1")
            {
                Producto_dd = DDTipoProducto.SelectedValue.ToString();
                Categoria_dd = "";
            }
            if (DDtipoPromocion.SelectedValue == "2" )
            {
                Categoria_dd = DDtipoCategoria.SelectedValue.ToString();
                Producto_dd = "";
            }

            //DDtipoPromocion.Items.Insert(0, new ListItem("Seleccione..", "0"));
            //DDtipoPromocion.Items.Insert(0, new ListItem("Todos", "1"));
            //DDtipoPromocion.Items.Insert(0, new ListItem("Producto", "2"));
            //DDtipoPromocion.Items.Insert(0, new ListItem("Categoria", "3")); 
            //DDtipoPromocion.Items.Insert(0, new ListItem("Producto", "1"));
            //DDtipoPromocion.Items.Insert(0, new ListItem("Categoria", "2"));

            Int32 IdPormocion = 0;
            try
            {
            if (TxtMontoBonifica.Text == "")
            {
                TxtMontoBonifica.Text = "0";
            }
           //IdPormocion=  obj.InsertarPromocion(TxtFechaIni.Value.ToString(),TxtFechaFin.Value.ToString(),
           // Convert.ToInt32(DDCondicion.SelectedValue), Convert.ToInt32(DDTipoCondicion.SelectedValue), Convert.ToInt32(DDtipoPromocion.SelectedValue),
           // Convert.ToInt32(DDTipoBonificacion.SelectedValue), Categoria_dd, Producto_dd, Convert.ToDecimal(TxtMontoBonifica.Text.ToString()), Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]),
           // Convert.ToInt32(DDTipoUsuario.SelectedValue));
           // Hdn_IdPromocion.Value = IdPormocion.ToString();
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
                      "title: '" + builder.ToString() + LineaError + "'," +
                       " icon: 'warning'," +
                      "  dangerMode: true," +
                 "   })  </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }
            foreach (GridViewRow row in GvInsert.Rows)
            {
            //obj.InsertarPromocionCondicion(IdPormocion, Convert.ToInt32(row.Cells[0].Text.ToString()),
            //Convert.ToString(row.Cells[1].Text.ToString().Trim().Replace("&nbsp;", "")), Convert.ToString(row.Cells[2].Text.ToString()),
            //Convert.ToInt32(row.Cells[3].Text.ToString()), Convert.ToInt32(row.Cells[4].Text.ToString().Trim()));               
            }
           
            Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
            obj.crudoperations("DELETEALL", IdUsuario, "", 0, "", 0, 0, 0, IdUsuario.ToString(), "");
            String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Operacion Exitosa"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);

            listar();
            cargarTrev();
            BindGridview();
            TxtFechaIni.Value = "";
            TxtFechaFin.Value = "";
            TxtMontoBonifica.Text = "";
            Session["Mustra"] = "";
            listarPromciones();
            Panel_Listar.Visible = true;
            Panel_Agregar.Visible = false;
            Response.Redirect("F_MantPromociones.aspx");

        }
        



        public String NotificacionMasivaNueva(String token, Int32 id, String mensaje)
        {

            var result = "-1";
            var webAddr = "https://fcm.googleapis.com/fcm/send";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=AAAAPKenxWY:APA91bE35FXYhLyXkXSSAsxouJQUu2qu1uhuzSlyiUETfi2AZqPSlgWzs--JJWg3iuBooM904U3lHMrxxqwACs3S54afYjCUODc2uOIayV2-WNf134VowucE8yEDYNEWQ_M6DN3r3bnx");
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string strNJson = "{ \"to\": \" " + token + "\", " +
                " \"data\": { " +
                            " \"id\": \"" + id + "\"," +
                            " \"msj\": \"" + mensaje + "\",},}";

                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
        protected void DDTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridview();
            TextBox lblCreateDate = ((TextBox)gvDetails.FooterRow.FindControl("TxtInsProdProm"));

            if(DDTipoProducto.SelectedValue == "0")
            {

            }else if(DDTipoProducto.SelectedValue== "1")
            {
                lblCreateDate.Text = "Todos los Productos";
                Session["Mustra"] = "Todos los Productos";
            }
            else
            {
                Session["Mustra"] = DDTipoProducto.SelectedItem.ToString();
                lblCreateDate.Text = DDTipoProducto.SelectedItem.ToString();
            }
            try
            {
                foreach (GridViewRow row in gvDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        row.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text = Session["Mustra"].ToString();

                    }
                }
            }
            catch (Exception ex) { }
        }

        protected void DDtipoCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridview();
            TextBox lblCreateDate = ((TextBox)gvDetails.FooterRow.FindControl("TxtInsProdProm"));

            if (DDtipoCategoria.SelectedValue == "0")
            {

            }
            else if (DDtipoCategoria.SelectedValue == "1")
            {
                lblCreateDate.Text = "Todas las Categorias";
                Session["Mustra"] = "Todas las Categorias";
            }
            else
            {
                Session["Mustra"] = DDtipoCategoria.SelectedItem.ToString();
                lblCreateDate.Text = DDtipoCategoria.SelectedItem.ToString();
            }
            try { 
              foreach (GridViewRow row in gvDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        row.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text = Session["Mustra"].ToString();

                    }
                }
            }catch(Exception ex) { }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("F_MantPromociones.aspx");
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Panel_Listar.Visible = false;
            Panel_Agregar.Visible = true; BindGridview();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            listarPromciones();
        }

        protected void GvPromociones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 Indice = int.Parse(e.CommandArgument.ToString());
            Int32 IdPromocion = int.Parse(GvPromociones.Rows[Indice].Cells[1].Text);
            if (e.CommandName == "Eliminar")
            {

                obj.EliminarPromocion(IdPromocion, Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));

                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Promocion Eliminado"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
            }
            if (e.CommandName == "EnviarPush")
            {

                DataTable dt = new DataTable();
                dt =obj.DetallePromcion(IdPromocion);
                foreach (DataRow orow in dt.Rows)
                {
                    //Response.Write("<script>alert('" + orow["Descripcion"].ToString() + "')</script>");
                    NotificacionMasivaNueva("dwwEvoYJCRU:APA91bHaLW-kiAXPx4PY2tEr9Uz7I9iWKv1BpTCuX0CCz_YiZXM1fj8Bo5I1CfQ0tPnI3JtYBEXgeYYqjmOpkOI_jB_28laZ5lw1YchHTDzKd1v_4YHHQF2DFowQbovnpHPcSMISQqi4",
                   1, Convert.ToString(orow["Descripcion"].ToString()));
                }

                obj.EstadoNotificacion(IdPromocion, Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));

                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Notificacion Enviada"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);

                listarPromciones();
                //foreach (DataRow item in dt.Rows)
                //{

                //}
                //Usuario OBJ = new Usuario();
                //int resultado = OBJ.EliminarUsuario(idUsuario, 5);//POner el usuario de session que modificara

                //if (resultado > 0)
                //{
                //    listarPromciones();
                //    ClientScript.RegisterStartupScript(Page.GetType(), "Mensaje", "<script type='text/javascript'>alert('Se Elimino el usuario');</script>");
                //    return;
                //}

                //NotificacionMasivaNueva("flFpPVItOzs:APA91bH3U5GBdwRCoc73asP0eo_7AC9PTs6e8qXlO3FkXJ57C9vKyZAAhVo9UPMnCBhPkvw10dk20mvSChLDxjDuZ0jCI_iFOJm1iGw8R3iI5Dw2JZ51qfTcpGPPv-RMgfHKHFTNEfY8",
                //     1, Convert.ToString(row.Cells[1].Text.ToString()));
            }
        }

        protected void DDTipoBonificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridview();
            if (DDTipoBonificacion.SelectedValue == "1")
            {
                TxtMontoBonifica.Enabled = false;
              

            }else
            {
                TxtMontoBonifica.Enabled = true;

            }
        }
    }
}