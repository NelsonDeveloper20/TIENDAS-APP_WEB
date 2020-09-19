using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
using System.Data;
using System.Globalization;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Web_Nestle
{
    public partial class F_MantPromocionN : System.Web.UI.Page
    {

Promociones obj_promocion = new Promociones();
        Dem_Promocion obj = new Dem_Promocion();
        protected void Page_Load(object sender, EventArgs e)
        {
            String miIp = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());// objeto para guardar la ip
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    miIp = ip.ToString();// esta es nuestra ip
                }
            }

            HdnIp.Value = miIp.ToString();
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

                listar();
                listarCombos();
               
                listarPromciones();

                Panel_Listar.Visible = true;
                Panel_Agregar.Visible = false;
                BtnGuardar.Visible = true;
                hdnIdPromocion.Value = "";
                BtnModificar.Visible = false;

                
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("TipoUsuer"), new DataColumn("IdTipoUser") });               
                GridView1.DataSource = dt;
                GridView1.DataBind();
                ViewState["Data"] = dt;
                CargaGrillaCondicion();
            }           

        }
        
        void CargaGrillaCondicion()
        {
            try { 
            DataTable dt = new DataTable();
            //dt.TableName = "DtCondicion";
            dt.Columns.Add(new DataColumn("IdPromCondicion", typeof(Int32)));
            dt.Columns.Add(new DataColumn("IdPromocion", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Cantidad", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
            dt.Columns.Add(new DataColumn("IdCategoria", typeof(String)));
            dt.Columns.Add(new DataColumn("Grupo", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Producto", typeof(String)));
            dt.Columns.Add(new DataColumn("IdProducto", typeof(String)));
            dt.Columns.Add(new DataColumn("IdCondicionM", typeof(String)));

            DataRow datatRow = dt.NewRow();
            dt.Rows.Add(datatRow);//adding row to the datatable
            #region CARGADA GGRILLA
            

            gvDetails.DataSource = dt;
            gvDetails.DataBind();
            gvDetails.Rows[0].Visible = false;

            dt.Rows[0].Delete();
            ViewState["DtCondicion"] = dt;
            Gv_Condicion.DataSource = dt;
            Gv_Condicion.DataBind();


          

            #region validaciones
            DropDownList ddproducto = ((DropDownList)gvDetails.FooterRow.FindControl("DD_Prod_CatIns"));
            DropDownList ddcategoria = ((DropDownList)gvDetails.FooterRow.FindControl("DDCategoriaIns"));
            if (DDtipoPromocion.SelectedValue == "3")
            {
                ddproducto.Visible = true;
                ddcategoria.Visible = false;

            }
            if (DDtipoPromocion.SelectedValue == "1")
            {
                ddproducto.Visible = true;
                ddcategoria.Visible = false;

            }
            else if (DDtipoPromocion.SelectedValue == "2")
            {

                ddproducto.Visible = false;
                ddcategoria.Visible = true;
            }
            if (Gv_Condicion.Rows.Count > 0)
            {
                DDtipoPromocion.Enabled = false;
            }
            else
            {
                DDtipoPromocion.Enabled = true;

            }
            if (DDTipoBonificacion.SelectedValue == "1")
            {
                TxtMontoBonifica.Enabled = false;
            }
            else
            {
                TxtMontoBonifica.Enabled = true;

            }

            #endregion
            #endregion

            #region  CARGA BONIFICACION


        
            DataTable DtBoni = new DataTable();
            //dt.TableName = "DtCondicion";
            DtBoni.Columns.Add(new DataColumn("IdPromocionBonificacion", typeof(Int32)));
            DtBoni.Columns.Add(new DataColumn("IdPromocion", typeof(Int32)));
            DtBoni.Columns.Add(new DataColumn("IdProducto", typeof(String)));
            DtBoni.Columns.Add(new DataColumn("Cantidad", typeof(Int32)));
            DtBoni.Columns.Add(new DataColumn("Stock", typeof(Int32)));
            DtBoni.Columns.Add(new DataColumn("grupo", typeof(Int32)));
            DtBoni.Columns.Add(new DataColumn("Producto", typeof(String)));
            DtBoni.Columns.Add(new DataColumn("IdBoniM", typeof(Int32)));

            DataRow datatRowBoni = DtBoni.NewRow();
            DtBoni.Rows.Add(datatRowBoni);//adding row to the datatable



            GvDemo2.DataSource = DtBoni;
            GvDemo2.DataBind();
            GvDemo2.Rows[0].Visible = false;

            DtBoni.Rows[0].Delete();
            ViewState["DtBonificacion"] = DtBoni;
            Gv_Bonficiacion.DataSource = DtBoni;
            Gv_Bonficiacion.DataBind();

                #endregion
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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




        #region GRUD GRIDVIEW TIPO USUARIO
        protected void Add(object sender, EventArgs e)
        {
            try { 
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
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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

        protected void Delete(object sender, EventArgs e)
        {try { 
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
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try { 

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
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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

        #endregion

    


        #region CRUD DEMO CONDICION

        protected void agregarCondicion(object sender, EventArgs e)
        {
            try { 
            Control control = null;
            if (gvDetails.FooterRow != null)
            {
                control = gvDetails.FooterRow;
            }
            else
            {
                control = gvDetails.Controls[0].Controls[0];
            }
            //string TipoUsuario = (control.FindControl("dd_tipo") as DropDownList).SelectedItem.ToString().Trim();
            //string Id_tipoUserol = (control.FindControl("dd_tipo") as DropDownList).SelectedValue.ToString().Trim();

            TextBox txtcantidad = (TextBox)gvDetails.FooterRow.FindControl("txtCantidad_ins");
            TextBox txtdescripcion = (TextBox)gvDetails.FooterRow.FindControl("txtDescripcion_ins");
            DropDownList ddProdCondicion = (DropDownList)gvDetails.FooterRow.FindControl("DD_Prod_CatIns");
            DropDownList DDCategoria = (DropDownList)gvDetails.FooterRow.FindControl("DDCategoriaIns");
            TextBox TxtGrupo = (TextBox)gvDetails.FooterRow.FindControl("txtGrupo_ins");
            #region VALIDACIONES TXT

            if (txtcantidad.Text == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Cantidad"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);

                return;
            }
            if (txtdescripcion.Text == "")
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

                return;
            }

            if (DDtipoPromocion.SelectedValue == "1")
            {

                if (ddProdCondicion.SelectedValue == "0")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Producto  "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);

                    return;
                }

            }
            if (DDtipoPromocion.SelectedValue == "2")
            {
                if (DDCategoria.SelectedValue == "0")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione  Categoria "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);

                    return;
                }
            }
            if (DDtipoPromocion.SelectedValue == "3")
            {
                if (ddProdCondicion.SelectedValue == "0")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione  Producto "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);

                    return;
                }

            }

            if (TxtGrupo.Text == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Grupo "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            #endregion

            if (DDtipoPromocion.SelectedValue != "3")
            {
                DataTable dtcondicion = (DataTable)ViewState["DtCondicion"];
                Int32 TotaklGrupo = 0;
                Int32 Grupo = 0;
                if (dtcondicion.Rows.Count > 0)
                {
                    var query = from row in dtcondicion.AsEnumerable()
                                group row by row.Field<Int32>("Grupo") into sales
                                where sales.Count() > 1
                                select new
                                {
                                    Name = sales.Key,
                                    CountOfClients = sales.Count()
                                };

                    foreach (var salesman in query)
                    {
                        Grupo = salesman.Name;
                        TotaklGrupo = salesman.CountOfClients;
                    }
                }
                if (TotaklGrupo >= 2 && Convert.ToInt32(TxtGrupo.Text) != Grupo)
                {
                    String Msj = "Debe pertenecer al grupo   " + Grupo.ToString();
                    string menssajeScript = "<script type='text/javascript'>"
                                  + " swal({" +
                          "title: '" + Msj + " '," +
                           " icon: 'warning'," +
                          "  dangerMode: true," +
                     "   })  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);

                    return;
                }
                Int32 count = dtcondicion
                   .AsEnumerable()
                   .Select(r => r.Field<Int32>("Grupo"))
                   .Distinct()
                   .Count();
                if (count >= 2)
                {
                    foreach (GridViewRow row in Gv_Condicion.Rows)
                    {
                        if (row.Cells[4].Text.ToString() == TxtGrupo.Text)
                        {
                            String Msj = "Ya existe grupo " + TxtGrupo.Text.ToString();
                            string menssajeScript = "<script type='text/javascript'>"
                                          + " swal({" +

                                  "title: '" + Msj + " '," +
                                   " icon: 'warning'," +
                                  "  dangerMode: true," +
                             "   })  </script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);

                            return;
                        }


                    }
                }

            }
            else
            {
              /*  foreach (GridViewRow rows in Gv_Condicion.Rows)
                {
                    if (rows.Cells[3].Text == ddProdCondicion.SelectedValue.ToString())
                    {
                        string msj3 = @"<script type='text/javascript'>
                       swal({
                title: "" Ya existe el producto Seleccionado "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);

                        return;
                    }
                }
                */
                Int32 Grupo = 0;
                Int32 Cantidad = 0;
                foreach (GridViewRow row in Gv_Condicion.Rows)
                {
                    Grupo = Convert.ToInt32(row.Cells[4].Text.ToString());
                    Cantidad = Convert.ToInt32(row.Cells[1].Text.ToString());
                }
                if (TxtGrupo.Text == Grupo.ToString())
                {
                    if (txtcantidad.Text != Cantidad.ToString())
                    {
                        string msj3 = @"<script type='text/javascript'>
                       swal({
                title: "" El monto debe ser igual por grupo "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);

                        return;
                    }

                }
            }
            #region
            String Producto = "";
            String Categoria = "";
            String Prod_Cat = "";
            if (DDtipoPromocion.SelectedValue == "1")
            {
                Producto = ddProdCondicion.SelectedValue.ToString();
                Prod_Cat = ddProdCondicion.SelectedItem.ToString();
            }
            else if (DDtipoPromocion.SelectedValue == "2")
            {
                Categoria = DDCategoria.SelectedValue.ToString();
                Prod_Cat = DDCategoria.SelectedItem.ToString();
            }
            if (DDtipoPromocion.SelectedValue == "3")
            {

                Producto = ddProdCondicion.SelectedValue.ToString();
                Prod_Cat = ddProdCondicion.SelectedItem.ToString();

            }
            #endregion

            
            DataTable dt = (DataTable)ViewState["DtCondicion"];
            //DataTable dt = ViewState["DtCondicion"] as DataTable;
            Int32 lastId;
            if (dt.Rows.Count == 0)
            {
                lastId = 1;
                dt.Rows.Add(lastId, 1,
                    Convert.ToInt32(txtcantidad.Text.ToString()),
                    txtdescripcion.Text.ToString().Trim().ToUpper(),
                    Categoria.ToString(), Convert.ToInt32(TxtGrupo.Text), Prod_Cat.ToString(),
                     Producto.ToString());
            }
            else
            {
                String Cod = dt.Rows[dt.Rows.Count - 1]["IdPromCondicion"].ToString();
                if (Cod == "")
                {
                    Cod = "0";
                }
                lastId = Convert.ToInt32(Cod);
                dt.Rows.Add(lastId + 1, 1,
                    Convert.ToInt32(txtcantidad.Text.ToString()),
                    txtdescripcion.Text.ToString().Trim().ToUpper(),
                    Categoria.ToString(), Convert.ToInt32(TxtGrupo.Text), Prod_Cat.ToString(),
                     Producto.ToString());
            }

            gvDetails.DataSource = dt;
            gvDetails.DataBind();
            Gv_Condicion.DataSource = dt;
            Gv_Condicion.DataBind();
            ViewState["DtCondicion"] = dt;
            if (Gv_Condicion.Rows.Count > 0)
            {
                DDtipoPromocion.Enabled = false;
            }else
            {
                DDtipoPromocion.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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


        private void BindEmpDetails()
        {
            try { 
            if (ViewState["DtCondicion"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["DtCondicion"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //add each row into data table   
                        //drCurrentRow = dtCurrentTable.NewRow();
                        //drCurrentRow["EmpId"] = txtEmpId.Text;
                        //drCurrentRow["EmpName"] = txtDeptName.Text;
                        //drCurrentRow["DeptName"] = txtDeptName.Text;
                        //drCurrentRow["EmpAddress"] = txtEmpAddress.Text;
                        //drCurrentRow["EmpSalary"] = txtEmpSalary.Text;
                    }
                    //Remove initial blank row   
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();
                    }
                    //Bind Gridview with latest Row   


                    gvDetails.DataSource = dtCurrentTable;
                    gvDetails.DataBind();
                    Gv_Condicion.DataSource = dtCurrentTable;
                    Gv_Condicion.DataBind();
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
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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


        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try { 
            Int32 IdCondicionDemo = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["IdPromCondicion"].ToString());
            Int32 IdGrupo = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["Grupo"].ToString());

          

            foreach (GridViewRow row in Gv_Bonficiacion.Rows)
                {
                   
                    if(row.Cells[3].Text.ToString() == IdGrupo.ToString())
                        {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""El Grupo Pertnece a una Bonificacion"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                    return;
                }
                }

            DataTable dt = ViewState["DtCondicion"] as DataTable;

            string name = IdCondicionDemo.ToString();
            foreach (DataRow dr in dt.Select($"IdPromCondicion='{name}'"))
            {
                dr.Delete();
            }
            dt.AcceptChanges();

            if(dt.Rows.Count < 1)
            {

                DataRow datatRow = dt.NewRow();
                dt.Rows.Add(datatRow);
                gvDetails.DataSource = dt;
                gvDetails.DataBind();
                gvDetails.Rows[0].Visible = false;

                dt.Rows[0].Delete();
            }else
            {

                gvDetails.DataSource = dt;
                gvDetails.DataBind();
            }


            ViewState["DtCondicion"] = dt;
            Gv_Condicion.DataSource = dt;
            Gv_Condicion.DataBind();
            if (Gv_Condicion.Rows.Count > 0)
            {
                DDtipoPromocion.Enabled = false;
            }
            else
            {
                DDtipoPromocion.Enabled = true;
            }
                //BindEmpDetails();
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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
        protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try { 
            Int32 Id_DemProm = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["IdPromCondicion"].ToString());

            Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]); //
            DropDownList DDProducto = (DropDownList)gvDetails.Rows[e.RowIndex].FindControl("DD_Prod_Catedit");
            DropDownList DDCategoria = (DropDownList)gvDetails.Rows[e.RowIndex].FindControl("DDCategoriaedit");

            TextBox txtcantidad = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtCantidad");
            TextBox txtdescripcion = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtDescripcion");
            TextBox TxtGrupo = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtGrupo");


            #region validaciones
            if (txtcantidad.Text == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Cantidad"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
              
                return;
            }
            if (txtdescripcion.Text == "")
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
               
                return;
            }

            if (DDtipoPromocion.SelectedValue == "1")
            {

                if (DDProducto.SelectedValue == "0")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Producto  "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                 
                    return;
                }

            }
            if (DDtipoPromocion.SelectedValue == "2")
            {
                if (DDCategoria.SelectedValue == "0")
                {
                    string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione  Categoria "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                  
                    return;
                }
            }
            if (TxtGrupo.Text == "")
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Grupo "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
              
                return;
            }
#endregion


            DataTable dtcondicion = (DataTable)ViewState["DtCondicion"];
            Int32 TotaklGrupo = 0;
            Int32 Grupo = 0;
            if (dtcondicion.Rows.Count > 0)
            {
                var query = from row in dtcondicion.AsEnumerable()
                            group row by row.Field<Int32>("Grupo") into sales
                            where sales.Count() > 1
                            select new
                            {
                                Name = sales.Key,
                                CountOfClients = sales.Count()
                            };

                foreach (var salesman in query)
                {
                    Grupo = salesman.Name;
                    TotaklGrupo = salesman.CountOfClients;
                }
            }
            if (TotaklGrupo >= 2 && Convert.ToInt32(TxtGrupo.Text) != Grupo)
            {
                String Msj = "Debe pertenecer al grupo   " + Grupo.ToString();
                string menssajeScript = "<script type='text/javascript'>"
                              + " swal({" +

                      "title: '" + Msj + " '," +
                       " icon: 'warning'," +
                      "  dangerMode: true," +
                 "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);              
                return;
            }
           

            String Producto = "";
            String Categoria = "";
            String Prod_Cat = "";
            if (DDtipoPromocion.SelectedValue == "1")
            {

                Producto = DDProducto.SelectedValue.ToString();
                Prod_Cat = DDProducto.SelectedItem.ToString();

            }
            else if (DDtipoPromocion.SelectedValue == "2")
            {

                Categoria = DDCategoria.SelectedValue.ToString();
                Prod_Cat = DDCategoria.SelectedItem.ToString();
          }
            if (DDtipoPromocion.SelectedValue == "3")
            {

            Producto = DDProducto.SelectedValue.ToString();
            Prod_Cat = DDProducto.SelectedItem.ToString();

            }


                DataTable dt = ViewState["DtCondicion"] as DataTable;
            //dt.Rows[e.RowIndex]["Name"] = name;
            //dt.Rows[e.RowIndex]["Country"] = country;
           
            
            dt.Rows[e.RowIndex]["IdPromCondicion"] = Id_DemProm;
            dt.Rows[e.RowIndex]["IdPromocion"] = 1;
            dt.Rows[e.RowIndex]["Cantidad"] = Convert.ToInt32(txtcantidad.Text.ToString());
            dt.Rows[e.RowIndex]["Descripcion"] = txtdescripcion.Text.ToString().Trim().ToUpper();
            dt.Rows[e.RowIndex]["IdCategoria"] = Categoria.ToString();
            dt.Rows[e.RowIndex]["Grupo"] = Convert.ToInt32(TxtGrupo.Text);
            dt.Rows[e.RowIndex]["Producto"] = Prod_Cat.ToString();
            dt.Rows[e.RowIndex]["IdProducto"] = Producto.ToString();
            dt.Rows[e.RowIndex]["IdCondicionM"] = Id_DemProm;
               

            ViewState["DtCondicion"] = dt;
            gvDetails.EditIndex = -1;
            this.BindEmpDetails();
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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
    
        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            gvDetails.EditIndex = e.NewEditIndex;
            BindEmpDetails();

        }
        protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetails.EditIndex = -1;
            BindEmpDetails();
        }
      
        
        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

          try { 

            if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {

                TextBox txtcod_prod = (TextBox)e.Row.FindControl("txtprod_cat");

                DropDownList ddprod = (DropDownList)e.Row.FindControl("DD_Prod_Catedit");
                ddprod.DataSource = obj_promocion.ListarProducto(1);
                ddprod.DataTextField = "Nombre";
                ddprod.DataValueField = "IdProductoTxt";
                ddprod.DataBind();
                ddprod.Items.Insert(0, new ListItem("Seleccione Producto..", "0"));

                DropDownList ddcategoria = (DropDownList)e.Row.FindControl("DDCategoriaedit");
                ddcategoria.DataSource = obj.listarCatgoriaMaestro();
                ddcategoria.DataTextField = "Nombre";
                ddcategoria.DataValueField = "IdCategoria";
                ddcategoria.DataBind();
                ddcategoria.Items.Insert(0, new ListItem("Seleccione Categoria..", "0"));
                if (DDtipoPromocion.SelectedValue == "3")
                {
                    ddprod.Visible = true;
                    ddcategoria.Visible = false;
                    ddprod.SelectedValue = txtcod_prod.Text.ToString();
                }
                if (DDtipoPromocion.SelectedValue == "1")
                {
                    ddprod.Visible = true;
                    ddcategoria.Visible = false;
                    ddprod.SelectedValue = txtcod_prod.Text.ToString();
                }
                else if (DDtipoPromocion.SelectedValue == "2")
                {
                    ddprod.Visible = false;
                    ddcategoria.Visible = true;
                    ddcategoria.SelectedValue = txtcod_prod.Text.ToString();
                }
            }
            //if (e.Row.RowState == DataControlRowState.Edit) {
            //}
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList ddproducto = (DropDownList)e.Row.FindControl("DD_Prod_CatIns");
                ddproducto.DataSource = obj_promocion.ListarProducto(1);
                ddproducto.DataTextField = "Nombre";
                ddproducto.DataValueField = "IdProductoTxt";
                ddproducto.DataBind();
                ddproducto.Items.Insert(0, new ListItem("Seleccione Producto..", "0"));

                //TextBox LblProd_Boni = (TextBox)e.Row.FindControl("TxtProductPromo");
                //ChkLu.Text = Session["Mustra"].ToString();               
                
                      DropDownList ddcategoria = (DropDownList)e.Row.FindControl("DDCategoriaIns");
                ddcategoria.DataSource = obj.listarCatgoriaMaestro();
                ddcategoria.DataTextField = "Nombre";
                ddcategoria.DataValueField = "IdCategoria";
                ddcategoria.DataBind();
                ddcategoria.Items.Insert(0, new ListItem("Seleccione Categoria..", "0"));

                //DropDownList ddproducto = ((DropDownList)e.Row.FindControl("DD_Prod_CatIns"));
                //DropDownList ddcategoria = ((DropDownList)gvDetails.FooterRow.FindControl("DDCategoriaIns"));
                if (DDtipoPromocion.SelectedValue == "3")
                {
                    ddproducto.Visible = true;
                    ddcategoria.Visible = false;

                }
                if (DDtipoPromocion.SelectedValue == "1")
                {
                    ddproducto.Visible = true;
                    ddcategoria.Visible = false;

                }
                else if (DDtipoPromocion.SelectedValue == "2")
                {

                    ddproducto.Visible = false;
                    ddcategoria.Visible = true;
                }
                if (Gv_Condicion.Rows.Count > 0)
                {
                    DDtipoPromocion.Enabled = false;
                }
                else
                {
                    DDtipoPromocion.Enabled = true;

                }
                if (DDTipoBonificacion.SelectedValue == "1")
                {
                    TxtMontoBonifica.Enabled = false;
                }
                else
                {
                    TxtMontoBonifica.Enabled = true;

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
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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
        #endregion

        #region CRUD BONIFICACION

        protected void agregarBonificacion(object sender, EventArgs e)
        {
            try { 
            Control control = null;
            if (GvDemo2.FooterRow != null)
            {
                control = GvDemo2.FooterRow;
            }
            else
            {
                control = GvDemo2.Controls[0].Controls[0];
            }
            DropDownList DDProducto = (DropDownList)GvDemo2.FooterRow.FindControl("DDProductoi");
            TextBox txtcantidad = (TextBox)GvDemo2.FooterRow.FindControl("txtCantidad_ins2");
            TextBox TxtStock = (TextBox)GvDemo2.FooterRow.FindControl("TxtStock");
            TextBox TxtGrupo = (TextBox)GvDemo2.FooterRow.FindControl("txtGrupo_ins2");

            #region  validaciones

            if (DDProducto.SelectedValue == "0")
            {

                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Producto"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            if (txtcantidad.Text == "")
            {

                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Cantidad"",
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
                title: ""Ingrese Stock"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            if (TxtGrupo.Text == "")
            {

                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Grupo"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Grupo");
            foreach (GridViewRow row in Gv_Condicion.Rows)
            {

                DataRow rows = tabla.NewRow();
                rows["Grupo"] = row.Cells[4].Text.ToString();
                tabla.Rows.Add(rows);
            }
            DataRow[] busca_renglon;
            busca_renglon = tabla.Select("Grupo='" + TxtGrupo.Text.ToString() + "'");

            if (busca_renglon.Length > 0)
            {
                //existe el grupo
            }
            else
            {
                String gr = " en la Condicion";
                String Msj = "No existe Grupo ";
                string menssajeScript = "<script type='text/javascript'>"
                              + " swal({" +

                      "title: '" + Msj + " " + TxtGrupo.Text.ToString() + gr.ToString() + "'," +
                       " icon: 'warning'," +
                      "  dangerMode: true," +
                 "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }

            #endregion
            DataTable dt = (DataTable)ViewState["DtBonificacion"];
            //DataTable dt = ViewState["DtCondicion"] as DataTable;
            Int32 lastId;

            if (dt.Rows.Count == 0)
            {
                lastId = 1;
                dt.Rows.Add(lastId, 1, DDProducto.SelectedValue.ToString(),
                    Convert.ToInt32(txtcantidad.Text.ToString()),
                    Convert.ToInt32(TxtStock.Text.ToString()),
                    Convert.ToInt32(TxtGrupo.Text),
                    DDProducto.SelectedItem.Text.ToString());
            }
            else
            {
                String Cod = dt.Rows[dt.Rows.Count - 1]["IdPromocionBonificacion"].ToString();
                if (Cod == "")
                {
                    Cod = "0";
                }
                lastId = Convert.ToInt32(Cod);
                dt.Rows.Add(lastId + 1, 1, DDProducto.SelectedValue.ToString(),
                    Convert.ToInt32(txtcantidad.Text.ToString()),
                    Convert.ToInt32(TxtStock.Text.ToString()),
                    Convert.ToInt32(TxtGrupo.Text),
                    DDProducto.SelectedItem.Text.ToString());
            }
            //INSERT INTO dbo.Dem_Boni(ip, IdProducto, Cantidad, Stock, grupo, idusuario, Producto)
            //VALUES(@ip, @idproducto, @cantidad, @stock, @grupo, @usuario, @Producto)
          
            GvDemo2.DataSource = dt;
            GvDemo2.DataBind();
            Gv_Bonficiacion.DataSource = dt;
            Gv_Bonficiacion.DataBind();
            ViewState["DtBonificacion"] = dt;
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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
               
        protected void GvDemo2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try { 
            Int32 IdBonficiacion = Convert.ToInt32(GvDemo2.DataKeys[e.RowIndex].Values["IdPromocionBonificacion"].ToString());
            DataTable dt = ViewState["DtBonificacion"] as DataTable;
            string name = IdBonficiacion.ToString();
            foreach (DataRow dr in dt.Select($"IdPromocionBonificacion='{name}'"))
            {
                dr.Delete();
            }
            dt.AcceptChanges();

            if (dt.Rows.Count < 1)
            {

                DataRow datatRow = dt.NewRow();
                dt.Rows.Add(datatRow);
                GvDemo2.DataSource = dt;
                GvDemo2.DataBind();
                GvDemo2.Rows[0].Visible = false;

                dt.Rows[0].Delete();
            }
            else
            {

                GvDemo2.DataSource = dt;
                GvDemo2.DataBind();
            }


            ViewState["DtBonificacion"] = dt;
            Gv_Bonficiacion.DataSource = dt;
            Gv_Bonficiacion.DataBind();
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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
        protected void GvDemo2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try { 
            Int32 Id_DemPromBoni = Convert.ToInt32(GvDemo2.DataKeys[e.RowIndex].Values["IdPromocionBonificacion"].ToString());

            Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]); //
            DropDownList DDProducto = (DropDownList)GvDemo2.Rows[e.RowIndex].FindControl("DDProductoEditar");

            TextBox txtcantidad = (TextBox)GvDemo2.Rows[e.RowIndex].FindControl("TxtCantidadEditIns");
            TextBox TxtStock = (TextBox)GvDemo2.Rows[e.RowIndex].FindControl("TxtStock_ins");
            TextBox TxtGrupo = (TextBox)GvDemo2.Rows[e.RowIndex].FindControl("TxtGrupo_in");

            #region VALIDACIONES
            if (DDProducto.SelectedValue == "0")
            {

                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Seleccione Producto"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            if (txtcantidad.Text == "")
            {

                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Cantidad"",
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
                title: ""Ingrese Stock"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            if (TxtGrupo.Text == "")
            {

                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Ingrese Grupo"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Grupo");
            foreach (GridViewRow row in Gv_Condicion.Rows)
            {

                DataRow rows = tabla.NewRow();
                rows["Grupo"] = row.Cells[4].Text.ToString();
                tabla.Rows.Add(rows);
            }
            DataRow[] busca_renglon;
            busca_renglon = tabla.Select("Grupo='" + TxtGrupo.Text.ToString() + "'");

            if (busca_renglon.Length > 0)
            {
                //existe el grupo
            }
            else
            {
                String gr = " en la Condicion";
                String Msj = "No existe Grupo ";
                string menssajeScript = "<script type='text/javascript'>"
                              + " swal({" +

                      "title: '" + Msj + " " + TxtGrupo.Text.ToString() + gr.ToString() + "'," +
                       " icon: 'warning'," +
                      "  dangerMode: true," +
                 "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                
                return;
            }
            #endregion

            DataTable dt = ViewState["DtBonificacion"] as DataTable;
            //dt.Rows[e.RowIndex]["Name"] = name;
            //dt.Rows[e.RowIndex]["Country"] = country;


            dt.Rows[e.RowIndex]["IdPromocionBonificacion"] = Id_DemPromBoni;
            dt.Rows[e.RowIndex]["IdPromocion"] = 1;
            dt.Rows[e.RowIndex]["IdProducto"] = DDProducto.SelectedValue.ToString();
            dt.Rows[e.RowIndex]["Cantidad"] = Convert.ToInt32(txtcantidad.Text.ToString());
            dt.Rows[e.RowIndex]["Stock"] = Convert.ToInt32(TxtStock.Text.ToString());
            dt.Rows[e.RowIndex]["grupo"] = Convert.ToInt32(TxtGrupo.Text);
            dt.Rows[e.RowIndex]["Producto"] = DDProducto.SelectedItem.Text.ToString();
            dt.Rows[e.RowIndex]["IdBoniM"] = 0;
            


            ViewState["DtBonificacion"] = dt;

            GvDemo2.EditIndex = -1;
            this.BindBonficacion();
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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

        private void BindBonficacion()
        {try { 
            if (ViewState["DtBonificacion"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["DtBonificacion"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                    }
                    //Remove initial blank row   
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();
                    }
                    //Bind Gridview with latest Row   


                    GvDemo2.DataSource = dtCurrentTable;
                    GvDemo2.DataBind();
                    Gv_Bonficiacion.DataSource = dtCurrentTable;
                    Gv_Bonficiacion.DataBind();
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
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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

        protected void GvDemo2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
                {

                    TextBox txtcod_prod = (TextBox)e.Row.FindControl("txtprod_cat2");
                    DropDownList ddprod = (DropDownList)e.Row.FindControl("DDProductoEditar");
                    ddprod.DataSource = obj_promocion.ListarProductopROMOCION(1);
                    ddprod.DataTextField = "Nombre";
                    ddprod.DataValueField = "IdProductoTxt";
                    ddprod.DataBind();
                    ddprod.Items.Insert(0, new ListItem("Seleccione Producto..", "0"));
                    ddprod.SelectedValue = txtcod_prod.Text.ToString();
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList ddprod = (DropDownList)e.Row.FindControl("DDProductoi");
                    ddprod.DataSource = obj_promocion.ListarProductopROMOCION(1);
                    ddprod.DataTextField = "Nombre";
                    ddprod.DataValueField = "IdProductoTxt";
                    ddprod.DataBind();
                    ddprod.Items.Insert(0, new ListItem("Seleccione...", "0"));
                    //TextBox LblProd_Boni = (TextBox)e.Row.FindControl("TxtProductPromo");
                    //ChkLu.Text = Session["Mustra"].ToString();              

                }
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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


        protected void GvDemo2_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GvDemo2.EditIndex = e.NewEditIndex;
            BindBonficacion();
        }

        protected void GvDemo2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvDemo2.EditIndex = -1;
            BindBonficacion();
        }
        #endregion


        #region TODO LISTAR Y  GUARDAR MODIFICAR
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
        #region listar dropdown
        public void listarCombos()
        {
            DDtipoPromocion.DataSource = obj.ListarTipoPromocion();
            DDtipoPromocion.DataTextField = "Descripcion";
            DDtipoPromocion.DataValueField = "idTipoPromocion";
            DDtipoPromocion.DataBind();

            //DDtipoPromocion.Items.Insert(0, new ListItem("Seleccione..."));
        }
        public void listar()
        {

            DDCondicion.DataSource = obj_promocion.ListarCondicion();
            DDCondicion.DataTextField = "Descripcion";
            DDCondicion.DataValueField = "idCondicion";
            DDCondicion.DataBind();
            DDCondicion.Items.Insert(0, new ListItem("Seleccione...", "0"));
            DDTipoCondicion.DataSource = obj_promocion.ListarTipoCondicion();
            DDTipoCondicion.DataTextField = "Descripcion";
            DDTipoCondicion.DataValueField = "idTipoCondicion";
            DDTipoCondicion.DataBind();
            DDTipoCondicion.Items.Insert(0, new ListItem("Seleccione...", "0"));



            DDTipoBonificacion.DataSource = obj_promocion.ListarTipoBonificacion();
            DDTipoBonificacion.DataTextField = "Descripcion";
            DDTipoBonificacion.DataValueField = "IdTipoBonificacion";
            DDTipoBonificacion.DataBind();
            DDTipoBonificacion.Items.Insert(0, new ListItem("Seleccione...", "0"));


            Subir_txt objj = new Subir_txt();
            DDTipoUsuario.DataSource = objj.ListarTipoUsuario();
            DDTipoUsuario.DataTextField = "Descripcion";
            DDTipoUsuario.DataValueField = "IdTipoUsuario";
            DDTipoUsuario.DataBind();
            //DDTipoUsuario.Items.Insert(0, new ListItem("Seleccione..", "0"));

        }
        #endregion

        #region PANEL LISTAR
        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Panel_Listar.Visible = false;
            Panel_Agregar.Visible = true;

            BtnGuardar.Visible = true;
            BtnModificar.Visible = false;
            //
            ChkPrimeroCompra.Checked = false;
            ChkHistorico.Checked = false;

        }
        public void listarPromciones()
        {
            try
            {
                Int32 Estado = 0;
                if (ChkEstado.Checked == true)
                {
                    Estado = 1;

                }
                else
                {
                    Estado = 0;
                }

                DateTime FechaFinal = Convert.ToDateTime(TxtBuscFechFin.Value, new CultureInfo("es-ES"));
                FechaFinal = FechaFinal.AddDays(1);
                string FechaSalida = FechaFinal.ToString("dd/MM/yyyy");
                GvPromociones.DataSource = obj_promocion.ListarPromociones(1, TXtBuscFecInicio.Value.ToString(), FechaFinal.ToString(), Estado);
                GvPromociones.DataBind();
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            listarPromciones();
        }
        #endregion

        #region GUARDAR PORMOCION EN BD
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            #region  VALIDACIONES
            if (gv_insert.Rows.Count < 1)
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Asignar Minimo un tipo de usuario"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
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
                return;
            }


            if (Gv_Condicion.Rows.Count < 1 )
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Ingresar Condiciones"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            if (Gv_Bonficiacion.Rows.Count < 1)
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Ingresar Bonificaciones"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                return;
            }
            #endregion

            Int32 IdPormocion = 0;
            try
            {
               

                //    String FecInicio, String FecFin,Int32 FlatgHistorico,
                // Int32 FlagPrimeraCompra, Int32 IdCondicion, Int32 IdTipoCondicion,
                //Int32 IdTipoPromocion, Int32 TipoBonificacion,Decimal MontoBonificacion, Int32 usuario,
                //Int32 idtipousuario
               
               
                Int32 flagHistorico = 0;
                Int32 FlagPriemraCompra = 0;
                if (ChkPrimeroCompra.Checked == true)
                {
                    FlagPriemraCompra = 1;

                }
                if (ChkHistorico.Checked == true)
                {
                    flagHistorico = 1;

                }
                Decimal MontoBoni = 0;
                if (TxtMontoBonifica.Text == "")
                {
                    MontoBoni = 0;
                }else
                {
                    MontoBoni = Convert.ToDecimal(TxtMontoBonifica.Text.ToString());
                }
                Int32 IdUsuario_ins = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
                IdPormocion = obj_promocion.InsertarPromocion(TxtFechaIni.Value.ToString(), TxtFechaFin.Value.ToString(),flagHistorico,FlagPriemraCompra,
                         Convert.ToInt32(DDCondicion.SelectedValue), Convert.ToInt32(DDTipoCondicion.SelectedValue), Convert.ToInt32(DDtipoPromocion.SelectedValue),
                 Convert.ToInt32(DDTipoBonificacion.SelectedValue), MontoBoni, IdUsuario_ins,
                 Convert.ToInt32(DDTipoUsuario.SelectedValue));
                Hdn_IdPromocion.Value = IdPormocion.ToString();
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
                string menssajeScript = "<script type='text/javascript'>"
                                      + " swal({" +
                              "title: '" + builder.ToString() + LineaError + "'," +
                               " icon: 'warning'," +
                              "  dangerMode: true," +
                         "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }
            try { 
            Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
            

            foreach (GridViewRow row in gv_insert.Rows)
            {
                obj_promocion.InsertarPromocionTipoUser(IdPormocion,Convert.ToInt32(row.Cells[2].Text.ToString()));
            }
            foreach (GridViewRow row in Gv_Condicion.Rows)
            {

                String Categoria = "";
                String Producto = "";
                if(row.Cells[2].Text.ToString().Trim().Replace("&nbsp;", "")=="" || row.Cells[2].Text.ToString().Trim() == "" || row.Cells[2].Text.ToString().Trim() == "0")
                {
                    Producto = row.Cells[3].Text.ToString().Trim().Replace("&nbsp;","");

                }
                if (row.Cells[3].Text.ToString().Trim().Replace("&nbsp;", "") == "" || row.Cells[3].Text.ToString().Trim() == "" || row.Cells[3].Text.ToString().Trim() == "0")
                {
                    Categoria = row.Cells[2].Text.ToString().Trim().Replace("&nbsp;","");
                }

                obj_promocion.InsertarPromocionCondicion(IdPormocion, Producto.ToString().Trim(), Categoria.ToString().Trim(), Convert.ToInt32(row.Cells[4].Text.ToString().Trim()),
                   Convert.ToInt32(row.Cells[1].Text.ToString().Trim()), row.Cells[0].Text.ToString().Trim(), IdUsuario,0);
            }

            foreach (GridViewRow row in Gv_Bonficiacion.Rows)
            {
               

                obj_promocion.InsertarBonificacion(IdPormocion,
                    Convert.ToInt32(row.Cells[3].Text.ToString()),
                    row.Cells[0].Text.ToString(),
                    Convert.ToInt32(row.Cells[1].Text.ToString().Trim()),
                     Convert.ToInt32(row.Cells[2].Text.ToString()),0);
            }
         
            String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Operacion Exitosa"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
            CargaGrillaCondicion();
            listarPromciones();
            TxtFechaIni.Value = "";
            TxtFechaFin.Value = "";
            TxtMontoBonifica.Text = "";
            Panel_Listar.Visible = true;
            Panel_Agregar.Visible = false;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("TipoUsuer"), new DataColumn("IdTipoUser") });
            GridView1.DataSource = dt;
            GridView1.DataBind();
            gv_insert.DataSource = dt;
            gv_insert.DataBind();
            ViewState["Data"] = dt;
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            listarPromciones();
            TxtFechaIni.Value = "";
            TxtFechaFin.Value = "";
            TxtMontoBonifica.Text = "";
            Panel_Listar.Visible = true;
            Panel_Agregar.Visible = false;
            
            BtnGuardar.Visible = true;
            BtnModificar.Visible = false;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("TipoUsuer"), new DataColumn("IdTipoUser") });
            GridView1.DataSource = dt;
            GridView1.DataBind();
            gv_insert.DataSource = dt;
            gv_insert.DataBind();
            ViewState["Data"] = dt;
            CargaGrillaCondicion();
        }

        #endregion

        #region SELECTED CHANGE 

        protected void DDtipoPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {
 try { 
             DropDownList ddproducto = ((DropDownList)gvDetails.FooterRow.FindControl("DD_Prod_CatIns"));
            DropDownList ddcategoria = ((DropDownList)gvDetails.FooterRow.FindControl("DDCategoriaIns"));
            if (Gv_Condicion.Rows.Count > 0)
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""condicion ya ingresada, elimine para cambiar tipo de promocion "",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);              
                return;
            }
            if (DDtipoPromocion.SelectedValue == "1")
            {
                ddproducto.Visible = true;
                ddcategoria.Visible = false;

            }
            else if (DDtipoPromocion.SelectedValue == "2")
            {

                ddproducto.Visible = false;
                ddcategoria.Visible = true;
            }
            if (DDtipoPromocion.SelectedValue == "3")
            {
                ddproducto.Visible = true;
                ddcategoria.Visible = false;

                }
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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
        protected void DDTipoBonificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (DDTipoBonificacion.SelectedValue == "1")
            {
                TxtMontoBonifica.Enabled = false;
                TxtMontoBonifica.Attributes.Add("class", "form-control");
                TxtMontoBonifica.Text = "";
            }
            else
            {
                TxtMontoBonifica.Enabled = true;
            }
        }
        #endregion
        
        #region ROWCOMMANDA , DATABOUND GRIDVIEW MASTER LIST

        private DataTable Getdata1
        {
            get
            {
                DataTable dt = new DataTable();
                dt = obj_promocion.ListarDetalleProciones();
                return dt;
            }
        }
        protected void GvPromociones_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try { 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string pub_id = GvPromociones.DataKeys[e.Row.RowIndex].Value.ToString();
                string id1 = GvPromociones.DataKeys[e.Row.RowIndex].Value.ToString();
               
                GridView grdview = e.Row.FindControl("GridView2") as GridView;
                grdview.DataSource = obj_promocion.ListarDetalleCondicion(Convert.ToInt32(id1));
                grdview.DataBind();
                GridView grdviewBoni = e.Row.FindControl("GvBonfi") as GridView;
                grdviewBoni.DataSource = obj_promocion.ListarDetalleBonificacion(Convert.ToInt32(id1));
                grdviewBoni.DataBind();
                if (e.Row.Cells[15].Text == "0")
                {
                    e.Row.Cells[12].Text = "<img src='http://201.234.124.219/webgesthorario/Iconos/accept.png' width='23px' height='20px'/>";
                    e.Row.Cells[12].Enabled = false;
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
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
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

        
        protected void GvPromociones_RowCommand(object sender, GridViewCommandEventArgs e)
        {try { 
            Int32 Indice = int.Parse(e.CommandArgument.ToString());
            Int32 IdPromocion = int.Parse(GvPromociones.Rows[Indice].Cells[1].Text);
            hdnIdPromocion.Value = IdPromocion.ToString();
            if (e.CommandName == "Eliminar")
            {

                if (GvPromociones.Rows[Indice].Cells[16].Text == "Activo")
                {
                    obj_promocion.EliminarPromocion(IdPromocion, Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));

                    String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Promocion Desactivada"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                    listarPromciones();
                }else
                {
                    obj_promocion.ActivarPromocion(IdPromocion, Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]));

                    String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Promocion Activada"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                    listarPromciones();
                }
                listarPromciones();

            }
            if (e.CommandName == "EnviarPush")
            {

                DataTable dt = new DataTable();
                dt = obj_promocion.DetallePromcion(IdPromocion);

                Int32 idusuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
                foreach (DataRow orow in dt.Rows)
                {
                    String Titulo = "";
                    String Descripcion = Convert.ToString(orow["Descripcion"].ToString());
                    //String mensajeScript = @"<script type='text/javascript'>  enviarnotificacion('" + idusuario + "','" + Titulo + "','" + Descripcion + "')     </script>";
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
                    String Msj = "";
                   string ResponseString = "";
                    HttpWebResponse response = null;
                    try
                    {
                        HttpResponseMessage HttpResponseMessage = null;
                        var request = (HttpWebRequest)WebRequest.Create("http://3.19.108.54/ApiDelcorpTienda/api/NotificacionPromocionTexto?IdUsuario=" + idusuario + "&id=1&titulo=&msj=" + Descripcion + "&rutafoto=");
                        request.Accept = "application/json"; //"application/xml";
                        request.Method = "GET";
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        request.ContentType = "application/json";
                        response = (HttpWebResponse)request.GetResponse();
                        ResponseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        if (response.StatusCode==HttpStatusCode.OK)
                        {
                            Msj = "exito";
                        }
                        else
                        {
                            Msj = "error";

                        }
                      }
                    catch (WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ProtocolError)
                        {
                            response = (HttpWebResponse)ex.Response;
                            ResponseString = "Ocurrió un error: " + response.StatusCode.ToString();
                        }
                        else
                        {    ResponseString = "Ocurrió un error: " + ex.Status.ToString();
                        }
                    }
                   


                }
                
/*
                foreach (DataRow orow in dt.Rows)
                {
                NotificacionMasivaNueva("dwwEvoYJCRU:APA91bHaLW-kiAXPx4PY2tEr9Uz7I9iWKv1BpTCuX0CCz_YiZXM1fj8Bo5I1CfQ0tPnI3JtYBEXgeYYqjmOpkOI_jB_28laZ5lw1YchHTDzKd1v_4YHHQF2DFowQbovnpHPcSMISQqi4",
                1, Convert.ToString(orow["Descripcion"].ToString()));
                }
                */
                Int32 idusuarios = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
                obj_promocion.EstadoNotificacion(IdPromocion, idusuarios);
                /*
                String mensajeScript1 = @"<script type='text/javascript'>
                       swal({
                title: ""Notificacion Enviada"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript1, false);
                */
                listarPromciones();
                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Notificación Enviada Correctamente!"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);
            }
            if (e.CommandName == "Editar")
            {
                DataTable dtprom = new DataTable();
                DataTable dt_tipoUsuario = new DataTable();
                Int32 idusuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);

                DataTable dtCondicion = new DataTable();
                DataTable dtbonficacion = new DataTable();
                dtprom = obj_promocion.PromocionXidV2(IdPromocion);
                dt_tipoUsuario = obj_promocion.listarPromocionTipoUsuario(IdPromocion);
                dtCondicion = obj_promocion.CondicionXidPromocion(IdPromocion);
                dtbonficacion = obj_promocion.promocionBonficiacion(IdPromocion);
                foreach (DataRow row in dtprom.Rows)
                {
                    TxtFechaIni.Value = row["fecInicio"].ToString();
                    TxtFechaFin.Value = row["fecFin"].ToString();
                    //DDTipoUsuario.SelectedValue = row["IdTipoUsuario"].ToString();
                    DDCondicion.SelectedValue = row["IdCondicion"].ToString();
                    DDTipoCondicion.SelectedValue = row["IdTipoCondicion"].ToString();
                    DDtipoPromocion.SelectedValue = row["IdTipoPromocion"].ToString();
                    DDTipoBonificacion.SelectedValue = row["IdTipoBonificacion"].ToString();
                    TxtMontoBonifica.Text = row["MontoBonificacion"].ToString().Replace(",",".");
                    if (row["flagHistorico"].ToString() == "0")
                    {
                        ChkHistorico.Checked = false;
                    }else
                    {
                        ChkHistorico.Checked = true;

                    }
                    if (row["flagPrimeraCompra"].ToString() == "0")
                    {
                        ChkPrimeroCompra.Checked = false;
                    }
                    else
                    {
                        ChkPrimeroCompra.Checked = true;

                    }
                }


                ViewState["DtCondicion"] = dtCondicion;
                gvDetails.DataSource = dtCondicion;
                gvDetails.DataBind();
                Gv_Condicion.DataSource = dtCondicion;
                Gv_Condicion.DataBind();

                ViewState["DtBonificacion"] = dtbonficacion;
                Gv_Bonficiacion.DataSource = dtbonficacion;
                Gv_Bonficiacion.DataBind();
                GvDemo2.DataSource = dtbonficacion;
                GvDemo2.DataBind();
                Panel_Agregar.Visible = true;
                Panel_Listar.Visible = false;


                GridView1.DataSource = dt_tipoUsuario;
                GridView1.DataBind();
                gv_insert.DataSource = dt_tipoUsuario;
                gv_insert.DataBind();
                ViewState["Data"] = dt_tipoUsuario;

                BtnGuardar.Visible = false;
                BtnModificar.Visible = true;



                }
            }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                     && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                     && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                     && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                string Mensaje = ex.Message;
                StringBuilder builder = new StringBuilder(Mensaje);
                builder.Replace("'", "");
                string metodo = frame.GetMethod().Name;
                int LineaError = frame.GetFileLineNumber();
                string menssajeScript = "<script type='text/javascript'>"
                                      + " swal({" +
                              "title: '" + builder.ToString() +" - "+ metodo + "'," +
                               " icon: 'warning'," +
                              "  dangerMode: true," +
                         "   })  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }
        }

        #region enviar notific
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

        #endregion

        #endregion

        #region BUTTON MODIFICAR
        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            if (gv_insert.Rows.Count < 1)
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Asignar Minimo un tipo de usuario"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                
                return;
            }
            #region  Validaciones

            //if (DDTipoUsuario.SelectedValue == "0")
            //{
            //    string msj3 = @"<script type='text/javascript'>
            //           swal({
            //    title: ""Seleccione Tipo Usuario "",
            //    icon: ""warning"",
            //    dangerMode: true,
            //})
            //      </script>";
            //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
            //    
            //    return;
            //}
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
                
                return;
            }


            if (Gv_Condicion.Rows.Count < 1)
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Ingresar Condiciones"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                
                return;
            }
            if (Gv_Bonficiacion.Rows.Count < 1)
            {
                string msj3 = @"<script type='text/javascript'>
                       swal({
                title: ""Debe Ingresar Bonificaciones"",
                icon: ""warning"",
                dangerMode: true,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", msj3, false);
                
                return;
            }
            #endregion
            String Msj = "";
            try
            {

                Int32 flagHistorico = 0;
                Int32 FlagPriemraCompra = 0;
                if (ChkPrimeroCompra.Checked == true)
                {
                    FlagPriemraCompra = 1;

                }
                if (ChkHistorico.Checked == true)
                {
                    flagHistorico = 1;

                }
                String MontoBoni = "";
                if (TxtMontoBonifica.Text == "" || TxtMontoBonifica.Text=="0.00" || TxtMontoBonifica.Text== "0,00")
                {
                    MontoBoni = "0";
                }
                else
                {
                    MontoBoni = Convert.ToString(TxtMontoBonifica.Text.ToString()).Trim();
                }
                Int32 IdUsuario_ins = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
                Msj = obj_promocion.ModificarPromocion(Convert.ToInt32(hdnIdPromocion.Value), TxtFechaIni.Value.ToString(), TxtFechaFin.Value.ToString(), flagHistorico, FlagPriemraCompra,
                         Convert.ToInt32(DDCondicion.SelectedValue), Convert.ToInt32(DDTipoCondicion.SelectedValue), Convert.ToInt32(DDtipoPromocion.SelectedValue),
                 Convert.ToInt32(DDTipoBonificacion.SelectedValue), MontoBoni, IdUsuario_ins,
                 Convert.ToInt32(DDTipoUsuario.SelectedValue));
                Hdn_IdPromocion.Value = hdnIdPromocion.Value.ToString();
        }
            catch (Exception ex)
            {

                StackTrace st = new StackTrace(ex, true);
        StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
             && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
             && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
             && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
        string Mensaje = ex.Message;
        StringBuilder builder = new StringBuilder(Mensaje);
        builder.Replace("'", "");
                int LineaError = frame.GetFileLineNumber();
        string menssajeScript = "<script type='text/javascript'>"
                              + " swal({" +
                      "title: '" + builder.ToString() + LineaError + "'," +
                       " icon: 'warning'," +
                      "  dangerMode: true," +
                 "   })  </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }
            if(Msj == "Modificado")
            {

                try { 

                //obj_promocion.EliminarDetallePromocion(Convert.ToInt32(hdnIdPromocion.Value));
                Int32 IdUsuario = Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
                
                 obj_promocion.CambioEstado(Convert.ToInt32(hdnIdPromocion.Value));
                foreach (GridViewRow row in gv_insert.Rows)
                {
                    obj_promocion.InsertarPromocionTipoUser(Convert.ToInt32(hdnIdPromocion.Value), Convert.ToInt32(row.Cells[2].Text.ToString()));
                }
                obj_promocion.CambioEstadocondi_boni(Convert.ToInt32(hdnIdPromocion.Value));
                foreach (GridViewRow row in Gv_Condicion.Rows)
                {
                     
                    String Categoria = "";
                    String Producto = "";
                    if (row.Cells[2].Text.ToString().Trim().Replace("&nbsp;", "") == "" || row.Cells[2].Text.ToString().Trim() == "" || row.Cells[2].Text.ToString().Trim() == "0")
                    {
                        Producto = row.Cells[3].Text.ToString().Trim().Replace("&nbsp;", "");

                    }
                    if (row.Cells[3].Text.ToString().Trim().Replace("&nbsp;", "") == "" || row.Cells[3].Text.ToString().Trim() == "" || row.Cells[3].Text.ToString().Trim() == "0")
                    {
                        Categoria = row.Cells[2].Text.ToString().Trim().Replace("&nbsp;", "");
                    }
                    Int32 IdCpndicion = 0;
                    if(row.Cells[5].Text=="" || row.Cells[5].Text== "&nbsp;" || row.Cells[5].Text == "0")
                    {
                        IdCpndicion = 0;
                    }else
                    {
                        IdCpndicion =Convert.ToInt32( row.Cells[5].Text.ToString());
                    }
                    obj_promocion.InsertarPromocionCondicion(Convert.ToInt32(hdnIdPromocion.Value), Producto.ToString().Trim(), Categoria.ToString().Trim(), Convert.ToInt32(row.Cells[4].Text.ToString().Trim()),
                       Convert.ToInt32(row.Cells[1].Text.ToString().Trim()), row.Cells[0].Text.ToString().Trim(), IdUsuario, IdCpndicion);
                }

                foreach (GridViewRow row in Gv_Bonficiacion.Rows)
                {

                    Int32 IdBonific = 0;
                    if (row.Cells[4].Text == "" || row.Cells[4].Text == "&nbsp;" || row.Cells[4].Text == "0")
                    {
                        IdBonific = 0;
                    }
                    else
                    {
                        IdBonific = Convert.ToInt32(row.Cells[4].Text.ToString());
                    }
                  
                    obj_promocion.InsertarBonificacion(
                        Convert.ToInt32(hdnIdPromocion.Value), 
                        Convert.ToInt32(row.Cells[3].Text.ToString()), 
                        row.Cells[0].Text.ToString(),
                        Convert.ToInt32(row.Cells[1].Text.ToString().Trim()),
                        Convert.ToInt32(row.Cells[2].Text.ToString()), IdBonific);
                }

                String mensajeScript = @"<script type='text/javascript'>
                       swal({
                title: ""Promocion Modificada"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript, false);

                }
                catch (Exception ex)
                {

                    StackTrace st = new StackTrace(ex, true);
                    StackFrame frame = st.GetFrames().Where(f => !String.IsNullOrEmpty(f.GetFileName())
                         && f.GetILOffset() != StackFrame.OFFSET_UNKNOWN
                         && f.GetNativeOffset() != StackFrame.OFFSET_UNKNOWN
                         && !f.GetMethod().Module.Assembly.GetName().Name.Contains("mscorlib")).First();
                    string Mensaje = ex.Message;
                    StringBuilder builder = new StringBuilder(Mensaje);
                    builder.Replace("'", "");
                    int LineaError = frame.GetFileLineNumber();
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
            listarPromciones();
            TxtFechaIni.Value = "";
            TxtFechaFin.Value = "";
            TxtMontoBonifica.Text = "";
            listarPromciones();
            Panel_Listar.Visible = true;
            Panel_Agregar.Visible = false;
            hdnIdPromocion.Value = "";

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("TipoUsuer"), new DataColumn("IdTipoUser") });
            GridView1.DataSource = dt;
            GridView1.DataBind();
            gv_insert.DataSource = dt;
            gv_insert.DataBind();
            ViewState["Data"] = dt;
        }

        protected void ChkEstado_CheckedChanged(object sender, EventArgs e)
        {
            listarPromciones();
        }
        #endregion


      

        protected void DDProductoEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (GridViewRow row in GvDemo2.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        TextBox TxtStock = (row.Cells[0].FindControl("TxtStock") as TextBox);
            //    DropDownList DDProductoEditar = (row.Cells[0].FindControl("DdEmpresa") as DropDownList);
            //    String idempre = (row.Cells[0].FindControl("DDProductoEditar") as DropDownList).SelectedValue;
            //    DSucursal.DataSource = OBJ.ListarSucursalXEmpresa(Convert.ToInt32(idempre), Convert.ToInt32(Request.Cookies["GestionHorario"]["DL04IdEmpresaMaster"]));
            //    DSucursal.DataTextField = "Nombre";
            //    DSucursal.DataValueField = "idSucursal";
            //    DSucursal.DataBind();
            //        //DdEmpresa_SelectedIndexChanged(sender, e);
            //        //DDPlantillaHorario_SelectedIndexChanged(sender, e);
            //    }
            //}
        }

        protected void DDProductoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            foreach (GridViewRow row in GvDemo2.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox TxtStock = (row.Cells[2].FindControl("TxtStock") as TextBox);
                    DropDownList DDProductoEditar = (row.Cells[0].FindControl("DDProductoi") as DropDownList);
                    String idempre = (row.Cells[0].FindControl("DDProductoi") as DropDownList).SelectedValue;
                    //DSucursal.DataSource = OBJ.ListarSucursalXEmpresa(Convert.ToInt32(idempre), Convert.ToInt32(Request.Cookies["GestionHorario"]["DL04IdEmpresaMaster"]));
                    //DSucursal.DataTextField = "Nombre";
                    //DSucursal.DataValueField = "idSucursal";
                    //DSucursal.DataBind();
                    //DdEmpresa_SelectedIndexChanged(sender, e);
                    //DDPlantillaHorario_SelectedIndexChanged(sender, e);
                }
            }
            }catch(Exception ex)
            {

            }
        }

        protected void BtnPos_Click(object sender, EventArgs e)
        {
            //if (TxtMontoCondicion.Text == "")
            //{
            //    

            //}
            //else
            //{

                //foreach (GridViewRow row in gvDetails.Rows)
                //{
                //    TextBox txtcantidad = ((TextBox)(gvDetails.FooterRow.FindControl("txtCantidad_ins")));
                //    txtcantidad.Text = "0";

                //}

                //TextBox txtcantidad = (TextBox)gvDetails.FooterRow.FindControl("");
                ////TextBox txtcantidad = ((TextBox)gvDetails.FooterRow.FindControl("txtCantidad_ins"));
                //txtcantidad.Text = "0";
                //txtcantidad.Enabled = false;

                //String mensajeScriptnm = @"<script type='text/javascript'>
                //           swal({
                //    title: ""CON POSBACCK"",
                //    icon: ""warning"",
                //    dangerMode: false,
                //})
                //      </script>";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScriptnm, false);
              
                
            //}
           
        }
#endregion

    }
}