using DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Nestle
{
    public partial class F_MantProductoCategoria : System.Web.UI.Page
    {
//String Connection = "Data Source=192.168.2.198;Initial Catalog=BD_NEL_R;User ID=jdextre;Pwd=bgyz0448";
  String Connection = ConfigurationManager.AppSettings["connectionString"].ToString();
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
                ListarProducto();
                listarProductoModif();
                MultiView1.ActiveViewIndex = 0;
                cargarTrevnodes();
                treeViewProductos.Attributes.Add("onclick", "fireCheckChanged()");
                TrevModifi.Attributes.Add("onclick", "fireCheckChanged_modif()");
            }
           
            //foreach (ListItem item in drpDistricts.Items)
            //{
            //    if (item.Value.ToString() == "0")
            //    {
            //        item.Attributes.Add("Style", "color:maroon");
            //        item.Attributes.Add("Disabled", "true");
            //    }
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
        protected void treeViewProductos_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            while (treeViewProductos.CheckedNodes.Count > 0)
            {
                treeViewProductos.CheckedNodes[0].Checked = false;

            }
            String Nodee = "";
        }

        


        public void cargarTrevnodes()
        {
            Int32 total = obj.CountCategoria();
            SqlConnection Con = new SqlConnection(Connection);
            for (int i = 0; i < total; i++)
            {
                //NELSON :) R
                String Consulta= @"WITH CTE(IdCategoria, Nombre, OrderString,IdUp,Imagen,Estado) AS
(SELECT IdCategoria, Nombre,    cast(cast(IdCategoria as char(5)) as varchar(max)) OrderString,IdUp,Imagen,estado
FROM    Categoria
WHERE    IdUp = 0
UNION ALL
SELECT    p.IdCategoria,  p.Nombre ,     c.OrderString,p.IdUp,p.Imagen,p.Estado
FROM    Categoria p
JOIN    CTE c ON c.IdCategoria = p.IdUp 
)
SELECT  IdCategoria, Nombre,(SELECT valorTexto FROM Parametros WHERE idParametro=2)+Imagen as Imagen,OrderString,IdUp
FROM  CTE 
where IdUp=" + i + " AND Estado=1"+
" ORDER BY   IdCategoria";
                Con.Open();
                SqlCommand Com = Con.CreateCommand();
                Com.CommandText = Consulta; // "Select IdCategoria,Nombre,( SELECT valorTexto FROM Parametros WHERE idParametro=2)+ Imagen as Imagen from Categoria  where IdUp=" + i + " AND Estado=1  order by IdCategoria";
                Com.CommandType = CommandType.Text;
                SqlDataReader r = Com.ExecuteReader();
                while (r.Read())
                {
                    if (i == 0)
                    {
                        String nombre = r["Nombre"].ToString().Trim();
                        String valor = r["IdCategoria"].ToString().Trim();
                        String Imagen = r["Imagen"].ToString().Trim();
                        Int32 PadreId =Convert.ToInt32(r["OrderString"].ToString().Trim());
                        Int32 hijos = obj.ListarHijos(Convert.ToInt32(valor));
                        treeViewProductos.Nodes.Add(AddNode(nombre, valor, Imagen, hijos, PadreId));
                        TrevModifi.Nodes.Add(AddNode(nombre, valor, Imagen, hijos, PadreId));
                    }
                    else
                    {
                        String nombre = r["Nombre"].ToString().Trim();
                        String valor = r["IdCategoria"].ToString().Trim();
                        String Imagen = r["Imagen"].ToString().Trim();
                        Int32 PadreId = Convert.ToInt32(r["OrderString"].ToString().Trim());
                        Int32 hijos = obj.ListarHijos(Convert.ToInt32(valor));
                        TreeNode nodo = BuscarNodo(treeViewProductos.Nodes, i.ToString());
                        TreeNode nodo2 = BuscarNodo(TrevModifi.Nodes, i.ToString());
                        nodo.ChildNodes.Add(AddNode(nombre, valor, Imagen, hijos, PadreId));
                        nodo2.ChildNodes.Add(AddNode(nombre, valor, Imagen, hijos, PadreId));
                        //TreeView1.Nodes[1].ChildNodes.Add(AddNode("Onion", "10"));
                    }
                }
                Con.Close();
            }
        }
        private TreeNode AddNode(string text, string value, string imagen,Int32 hijos,Int32 PadreId)
        {
            bool chkhijo = false;
            if (hijos > 0)
            {
                chkhijo = false;
            }else
            {
                chkhijo = true;
            }
            return new TreeNode
            {
                Text =text,
                Value = value,              
                ToolTip = PadreId + "_" + value,
                SelectAction = TreeNodeSelectAction.None,
                Expanded = false,
                ShowCheckBox= chkhijo
               
                //NavigateUrl="nels",
                //ImageUrl = PadreId.ToString(),
                //ImageToolTip
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
            //txtnomCategoria.Value = clickedNode;
        }

        #region listar
        public void ListarProducto()
        {
            GVPRODUCTO.DataSource = obj.ListarProducto(1, TxtBuscarG.Value.ToString());
            GVPRODUCTO.DataBind();
           
        }
        public void listarProductoModif()
        {
            GvModificar.DataSource = obj.ListarProductoCategoriExsitente(1, TxtBuscarModific.Value.ToString());
            GvModificar.DataBind();
        }
        #endregion
        #region TREEVIEW SUB CATEGORIAS
        public void cargarTrev()
        {
            Int32 total = obj.CountCategoria();
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
                    String ID_Padre = "";
                    if (i == 0)
                    {
                    
                        String nombre = r["Nombre"].ToString().Trim();
                        String valor = r["IdCategoria"].ToString().Trim();
                        String Imagen = r["Imagen"].ToString().Trim();
                        //AddNode(nombre, valor, Imagen);
                        ID_Padre= r["IdCategoria"].ToString().Trim();
                        
                    }
                    else
                    {
                        String nombre =  r["Nombre"].ToString().Trim();
                        String valor = r["IdCategoria"].ToString().Trim();
                        String Imagen = r["Imagen"].ToString().Trim();
                       // TreeNode nodo = BuscarNodo();
                        //AddNode(nombre, valor, Imagen);
                        //DDCategoria.Items.Insert(0, new ListItem(nombre, valor));
                        //DDCategoria.DataBind();
                        //DDModif.Items.Insert(0, new ListItem(nombre, valor));
                        //DDModif.DataBind();
                   

                    }
                }
                Con.Close();
            }
            //DDCategoria.Items.Insert(0, new ListItem("..Seleccione...", "0"));
            //DDModif.Items.Insert(0, new ListItem("...Seleccione...", "0"));

        }      
  


        protected void OnCheckedChanged(object sender, EventArgs e)
        {

            bool isUpdateVisible = false;
            CheckBox chk = (sender as CheckBox);
            if (chk.ID == "chkAll")
            {
                foreach (GridViewRow row in GVPRODUCTO.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        row.Cells[4].Controls.OfType<CheckBox>().FirstOrDefault().Checked = chk.Checked;
                    }
                }
            }
           
        }
        protected void OnCheckedChanged2(object sender, EventArgs e)
        {

            bool isUpdateVisible = false;
            CheckBox chk = (sender as CheckBox);
            if (chk.ID == "chkAll2")
            {
                foreach (GridViewRow row in GvModificar.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        row.Cells[5].Controls.OfType<CheckBox>().FirstOrDefault().Checked = chk.Checked;
                    }
                }
            }

        }
        #endregion

        #region BUTTON GUARDAR
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
             if (HdnId_Up.Value == "0")
            {
                string mensajeScript1 = @"<script type='text/javascript'>
                            swal({
                     title: ""Seleccione Categoria"",
                     icon: ""warning"",
                     dangerMode: true,
                 })
                       </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript1, false);
                return;
            }
            
            String Msj = "";
            Int32 Chekedd = 0;
            try
            {
                Int32 Cont = 0;
                foreach (GridViewRow row in GVPRODUCTO.Rows)
                {
                    CheckBox chekCabec = ((CheckBox)(GVPRODUCTO.Rows[row.RowIndex].FindControl("chkselec")));
                    if ((chekCabec.Checked == true))
                    {
                        Cont++;
                    }

                }
                 if (Cont == 1)
                  {

                    //Nels :)
                    //Se ha marcado check a un solo producto  NR :)
                  }
                  else if (Cont > 1)
                  {
                       //  Se ha marcado check a mas de un producto NR
                       //ningun proceso
                   //   return;

                  }
                  else
                  {
                    // No se ha marcado check a ningun producto NR 
                    string mensajeScript1 = @"<script type='text/javascript'>
                            swal({
                     title: ""Ningun Poducto Seleccionado"",
                     icon: ""warning"",
                     dangerMode: true,
                 })
                       </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript1, false);
                    return;
                  }
                  

             

                foreach (GridViewRow row in GVPRODUCTO.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        bool isChecked = row.Cells[4].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                        if (isChecked)
                        {

                            String IdTxt = row.Cells[0].Text.ToString();
                            String Categoria = HdnId_Up.Value.ToString();
                            String IdPadre = Hd_IdPadre.Value.ToString();
                            String NombrePorducto = row.Cells[1].Text.ToString();
                            Int32 IdFabricante = Convert.ToInt32(row.Cells[5].Text.ToString());
                        Int32 idusuario =  Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
                          Msj = obj.InsertarProductoCategoria(Convert.ToString(IdTxt), Convert.ToInt32(Categoria),
                              Convert.ToInt32(IdPadre),
                              IdFabricante, idusuario);
                        }
                    }
                }
                if(Msj== "insertado")
                {
                    string mensajeScript1 = @"<script type='text/javascript'>
                       swal({
                title: ""OPERACION  EXITOSA"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", mensajeScript1, false);

                   
                }
           
            ListarProducto();

        }catch (Exception ex)
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

                      "title: '" + builder.ToString() + "'," +
                       " icon: 'warning'," +
                      "  dangerMode: true," +
                 "   })  </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);
                return;
            }
    //NELSON :)
}
        #endregion

        #region BUTTONES    
        protected void btnModificar_Click(object sender, EventArgs e)
        {

          
            if (HdnModif.Value == "")
            {
              string mensajeScript1 = @"<script type='text/javascript'>
                            swal({
                     title: ""Seleccione Categoria"",
                     icon: ""warning"",
                     dangerMode: true,
                 })
                       </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript1, false);
                return;
            }
            String Msj = "";
            Int32 Chekedd = 0;
            Int32 Cont = 0;
            foreach (GridViewRow row in GvModificar.Rows)
            {
                CheckBox chekCabec = ((CheckBox)(GvModificar.Rows[row.RowIndex].FindControl("chkModif")));
                if ((chekCabec.Checked == true))
                {
                    Cont++;
                }

            }
            if (Cont == 1) {
                //Nels :)
                //Se ha marcado check a un solo producto  NR :)           
            }
            else if (Cont > 1)
            {
                //  Se ha marcado check a mas de un producto NR
                //ningun proceso
                //   return;

            }
            else
            {
                // No se ha marcado check a ningun producto NR 
                string mensajeScript1 = @"<script type='text/javascript'>
                            swal({
                     title: ""Ningun Poducto Seleccionado"",
                     icon: ""warning"",
                     dangerMode: true,
                 })
                       </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", mensajeScript1, false);
                return;
            }


            try
            {
                foreach (GridViewRow row in GvModificar.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        bool isChecked = row.Cells[5].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                        if (isChecked)
                        {

                            String IdTxt = row.Cells[0].Text.ToString();
                            String Categoria = HdnModif.Value.ToString();
                            String PadreModif = Hd_ModifPadre.Value.ToString();
                            String NombrePorducto = row.Cells[1].Text.ToString();
                            Int32 IdFabricante = Convert.ToInt32(row.Cells[6].Text.ToString());
                            Int32 IdUsuario =  Convert.ToInt32(Request.Cookies["WebNestle"]["DLIdUsuario"]);
                            Msj = obj.ModificarProductoCategoria(Convert.ToString(IdTxt), Convert.ToInt32(Categoria), 
                                Convert.ToInt32(PadreModif),
                                IdFabricante, IdUsuario);
                        }
                    }
                }
                if (Msj == "Modificado")
                {
                    string mensajeScript1 = @"<script type='text/javascript'>
                       swal({
                title: ""MODIFICADO  CORRECTAMENTE"",
                icon: ""success"",
                dangerMode: false,
            })
                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "mensaje", mensajeScript1, false);

                    ListarProducto();
                    listarProductoModif();
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

                      "title: '" + builder.ToString() + "'," +
                       " icon: 'warning'," +
                      "  dangerMode: true," +
                 "   })  </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", menssajeScript, false);

                return;
            }
            //cargarTrev();
            ListarProducto();
            listarProductoModif();

        }

        protected void MenuTab_MenuItemClick(object sender, MenuEventArgs e)
        {
            MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value);
            int selectedTab = Int32.Parse(e.Item.Value);

            switch (selectedTab)
            {
                case 0:
                    //MenuTab.Items[0].ImageUrl = "~/images/TabOneOn.jpg";
                    //MenuTab.Items[1].ImageUrl = "~/images/TabTwoOff.jpg";                    
                    break;

                case 1:
                    //MenuTab.Items[0].ImageUrl = "~/images/TabOneOff.jpg";
                    //MenuTab.Items[1].ImageUrl = "~/images/TabTwoOn.jpg";
                    break;
            }
        }
        #endregion

        #region
        public void DropDownTree(DropDownList ddl)
        {
            ddl.Items.Clear();
            using (SqlConnection connection = new SqlConnection())
            {
                // Data Connection
                connection.ConnectionString = (ConfigurationManager.ConnectionStrings["AssetWhereConnectionString"].ConnectionString);
                connection.Open();
                string getLocations = @"
                With hierarchy (id, [location id], name, depth, [path])
                As (

                    Select ID, [LocationID], Name, 1 As depth,
                        Cast(Null as varChar(max)) As [path]
                    From dbo.Locations
                    Where ID = [LocationID]

                    Union All

                    Select child.id, child.[LocationID], child.name,
                        parent.depth + 1 As depth,
                        IsNull(
                            Cast(parent.id As varChar(max)),
                            Cast(parent.id As varChar(max))
                        ) As [path]
                    From dbo.Locations As child
                    Inner Join hierarchy As parent
                        On child.[LocationID] = parent.ID
                    Where child.ID != parent.[Location ID])

                Select *
                From hierarchy
                Order By [depth] Asc";

                using (SqlCommand cmd = new SqlCommand(getLocations, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader rs = cmd.ExecuteReader())
                    {
                        while (rs.Read())
                        {
                            string id = rs.GetGuid(0).ToString();
                            int depth = rs.GetInt32(3);
                            string text = rs.GetString(2);
                            string locationID = rs.GetGuid(1).ToString();
                            string padding = String.Concat(Enumerable.Repeat("- ", 2 * depth));


                            if (id == locationID)
                            {
                                ddl.Items.Add(new ListItem(padding + text, id));
                            }
                            else
                            {
                                int index = ddl.Items.IndexOf(ddl.Items.FindByValue(rs.GetString(4).ToString().ToLower()));

                                // Fix the location where the item is inserted. 
                                index = index + 1;

                                ddl.Items.Insert(index, new ListItem(padding + text, id));

                            }
                        }
                    }
                }
            }
        }
        #endregion

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            ListarProducto();
            //Response.Write("<script>alert('buscvano gaursar')</script>");
        }

        protected void BtnBuscarModif_Click(object sender, EventArgs e)
        {
            listarProductoModif();
            //Response.Write("<script>alert('buscvano Modificar')</script>");
        }
    }
}