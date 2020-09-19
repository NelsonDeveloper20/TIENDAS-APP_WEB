using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FLHome : System.Web.UI.Page
{
    String idorden = "", idTipoResultado = "", FecpedidoI = "", FecPedidoF = "", Conductor = "", sucursal = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
            if (IsPostBack == false)
            {
       
            DateTime thisDay = DateTime.Today;
                datavalue.Value = thisDay.ToString("dd/MM/yyyy");
                datavalue2.Value = thisDay.ToString("dd/MM/yyyy");
                ListarOrdenes(idorden, idTipoResultado, FecpedidoI, FecPedidoF, Conductor, sucursal);
                CargarTipoResultado();
                ListarMotorizadoCombo();
                ListarSucursal();

             
            
        }
        //}
        //catch (Exception)
        //{

        //}
    }
 
    public void ListarSucursal()
    {
        Db.DASucursal OBJ = new Db.DASucursal();

        DataTable dt = new DataTable();

        dt = OBJ.ListarSucursalCombo();
        ddlSucursal.DataSource = dt;
        ddlSucursal.DataTextField = "Nombre";
        ddlSucursal.DataValueField = "idSucursal";
        ddlSucursal.DataBind();

        ddlSucursal.Items.Insert(0, new ListItem("..::TODOS::..", ""));
    }
    public void ListarMotorizadoCombo()
    {
        Db.DAMotorizado OBJ = new Db.DAMotorizado();

        DataTable dt = new DataTable();

        dt = OBJ.ListarMotorizadoCombo();
        ddlMotorizado.DataSource = dt;
        ddlMotorizado.DataTextField = "Nombre";
        ddlMotorizado.DataValueField = "idTrabajador";
        ddlMotorizado.DataBind();

        ddlMotorizado.Items.Insert(0, new ListItem("..::TODOS::..", ""));
    }
    public void ListarOrdenes(String idorden, String idTipoResultado, String FecpedidoI, String FecPedidoF, String Conductor, String sucursal)
    {
        DataTable dt = new DataTable();
        try
        {

            Db.DAOrdenes OBJ = new Db.DAOrdenes();
            dt = OBJ.ListarOrdenes(idorden, idTipoResultado, FecpedidoI, FecPedidoF, Conductor, sucursal);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            //GcExportar.DataSource = OBJ.Reporte(idorden, idTipoResultado, FecpedidoI, FecPedidoF, Conductor, sucursal);

            //GcExportar.DataBind();

        }
        catch (Exception ex)
        {
        }
    }
    public void CargarTipoResultado()
    {
        Db.DATipoResultadoOrden OBJ = new Db.DATipoResultadoOrden();

        DataTable dt = new DataTable();

        dt = OBJ.ListarTipoResultado();
        ddlTipoResultado.DataSource = dt;
        ddlTipoResultado.DataTextField = "Descripcion";
        ddlTipoResultado.DataValueField = "idTipoResultado";
        ddlTipoResultado.DataBind();

        ddlTipoResultado.Items.Insert(0, new ListItem("..::TODOS::..", ""));
    }
    protected void btnRegistro_Click(object sender, EventArgs e)
    {
        idTipoResultado = ddlTipoResultado.SelectedValue.ToString();
        idorden = txtOrden.Value.Trim();
        FecpedidoI = datavalue.Value;
        FecPedidoF = datavalue2.Value;
        Conductor = ddlMotorizado.SelectedValue.ToString();
        sucursal = ddlSucursal.SelectedValue.ToString();

        ListarOrdenes(idorden, idTipoResultado, FecpedidoI, FecPedidoF, Conductor, sucursal);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "tipoTrans")
        {
            Int32 Indice = int.Parse(e.CommandArgument.ToString());
            String IdOrden = (GridView1.Rows[Indice].Cells[0].Text).ToString();

            Db.DAOrdenes OBJ = new Db.DAOrdenes();
            GVDETALLE.DataSource = OBJ.ListarDetalle(IdOrden.ToString());
            GVDETALLE.DataBind();

            string script = @"<script type=text/javascript> showPopup()</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "myScript", script, false);
        }
    }
 

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        int RowSpan = 2;
        // actual row counter, spanned rows count as one
        int rowCount = 0;


        for (int i = GridView1.Rows.Count - 2; i >= 0; i--)
        {
            GridViewRow currRow = GridView1.Rows[i];
            GridViewRow prevRow = GridView1.Rows[i + 1];


            if (currRow.Cells[1].Text == prevRow.Cells[1].Text && !currRow.Cells[1].Text.Equals("&nbsp;"))
            {


                currRow.Cells[1].RowSpan = RowSpan;
                prevRow.Cells[1].Visible = false;

                //currRow.Cells[15].RowSpan = RowSpan;
                //prevRow.Cells[15].Visible = false;

                currRow.Cells[5].RowSpan = RowSpan;
                prevRow.Cells[5].Visible = false;

                currRow.Cells[6].RowSpan = RowSpan;
                prevRow.Cells[6].Visible = false;

                currRow.Cells[4].RowSpan = RowSpan;
                prevRow.Cells[4].Visible = false;

                currRow.Cells[11].RowSpan = RowSpan;
                prevRow.Cells[11].Visible = false;

                currRow.Cells[7].RowSpan = RowSpan;
                prevRow.Cells[7].Visible = false;
                /*
                currRow.Cells[19].RowSpan = RowSpan;
                prevRow.Cells[19].Visible = false;*/
                RowSpan += 1;

            }
            else
            {
                RowSpan = 2;
                rowCount++;
            }

            if (rowCount % 2 == 0)
            {
                currRow.BackColor = Color.FromName("#e6eafe");
            }

            for (Int32 x = 0; x < 22; x++)
            {
                GridView1.Rows[GridView1.Rows.Count - 1].Cells[x].BackColor = Color.FromName("#e6eafe");
            }
        }
    }
    protected void gvMyLista_PreRender(object sender, EventArgs e)
    {
        int RowSpan = 2;
        // actual row counter, spanned rows count as one
        int rowCount = 0;

        for (int i = GridView1.Rows.Count - 2; i >= 0; i--)
        {
            GridViewRow currRow = GridView1.Rows[i];
            GridViewRow prevRow = GridView1.Rows[i + 1];
            if (currRow.Cells[1].Text == prevRow.Cells[1].Text && !currRow.Cells[1].Text.Equals("&nbsp;"))
            {


                currRow.Cells[1].RowSpan = RowSpan;
                prevRow.Cells[1].Visible = false;

                //currRow.Cells[15].RowSpan = RowSpan;
                //prevRow.Cells[15].Visible = false;

                currRow.Cells[5].RowSpan = RowSpan;
                prevRow.Cells[5].Visible = false;

                currRow.Cells[6].RowSpan = RowSpan;
                prevRow.Cells[6].Visible = false;

                currRow.Cells[4].RowSpan = RowSpan;
                prevRow.Cells[4].Visible = false;

                currRow.Cells[11].RowSpan = RowSpan;
                prevRow.Cells[11].Visible = false;

                currRow.Cells[7].RowSpan = RowSpan;
                prevRow.Cells[7].Visible = false;
                /*
                currRow.Cells[19].RowSpan = RowSpan;
                prevRow.Cells[19].Visible = false;*/
                RowSpan += 1;

            }
            else
            {
                RowSpan = 2;
                rowCount++;
            }

            if (rowCount % 2 == 0)
            {
                currRow.BackColor = Color.FromName("#e6eafe");
            }

            for (Int32 x = 0; x < 22; x++)
            {
                GridView1.Rows[GridView1.Rows.Count - 1].Cells[x].BackColor = Color.FromName("#e6eafe");
            }
        }
    }




    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        idTipoResultado = ddlTipoResultado.SelectedValue.ToString();
        idorden = txtOrden.Value.Trim();
        FecpedidoI = datavalue.Value;
        FecPedidoF = datavalue2.Value;
        Conductor = ddlMotorizado.SelectedValue.ToString();
        sucursal = ddlSucursal.SelectedValue.ToString();
        ListarOrdenes(idorden, idTipoResultado, FecpedidoI, FecPedidoF, Conductor, sucursal);
    }
    protected void BtnExcel_Click(object sender, EventArgs e)
    {
       
        Db.DAOrdenes OBJ = new Db.DAOrdenes();
        //GcExportar.DataSource = OBJ.Reporte(txtOrden.Value.Trim(), ddlTipoResultado.SelectedValue.ToString(), 
        //datavalue.Value.ToString(), datavalue2.Value.ToString(), ddlMotorizado.SelectedValue.ToString(), ddlSucursal.SelectedValue.ToString());
        //GcExportar.DataBind();

        DataTable dt_report = new DataTable();
        dt_report= OBJ.Reporte(txtOrden.Value.Trim(), ddlTipoResultado.SelectedValue.ToString(),
        datavalue.Value.ToString(), datavalue2.Value.ToString(), ddlMotorizado.SelectedValue.ToString(), ddlSucursal.SelectedValue.ToString());
        
        ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
        wbook.Worksheets.Add(dt_report, "reporte");
        // Preparar la respuesta
        HttpResponse httpResponse = Response;
        httpResponse.Clear();
        httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        // Proporcione su nombre de archivo aquí
        httpResponse.AddHeader("content-disposition", "attachment;filename=\"Reporte_Pedido " + DateTime.Now + ".xlsx\"");
        //Vacíe el libro de trabajo al Response.OutputStream
        using (MemoryStream memoryStream = new MemoryStream())
        {
            wbook.SaveAs(memoryStream);
            memoryStream.WriteTo(httpResponse.OutputStream);
            memoryStream.Close();
        }

        httpResponse.End();
        
        
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    
}