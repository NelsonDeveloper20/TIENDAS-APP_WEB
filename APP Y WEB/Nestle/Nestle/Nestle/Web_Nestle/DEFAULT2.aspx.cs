using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_Nestle
{
    public partial class DEFAULT2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DefaultEmpRecord();
            }
        }
        private void DefaultEmpRecord()
        {
            //creating dataTable   
            DataTable dt = new DataTable();
            dt.TableName = "EmployeeDetails";
            dt.Columns.Add(new DataColumn("EmpId", typeof(string)));
            dt.Columns.Add(new DataColumn("EmpName", typeof(string)));
            dt.Columns.Add(new DataColumn("DeptName", typeof(string)));
            dt.Columns.Add(new DataColumn("EmpAddress", typeof(string)));
            dt.Columns.Add(new DataColumn("EmpSalary", typeof(string)));           

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridView1.DataSource = ds;
            GridView1.DataBind();
            int columncount = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            GridView1.Rows[0].Cells[0].Text = "No Records Found";
            GridView1.Rows[0].Cells[0].Style["display"] = "none";

            //saving databale into viewstate   
            ViewState["EmployeeDetails"] = dt;
            //bind Gridview   
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void AddNewRecordRowToGrid()
        {
            // check view state is not null   
            if (ViewState["EmployeeDetails"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["EmployeeDetails"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //add each row into data table   
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["EmpId"] = txtEmpId.Text;
                        drCurrentRow["EmpName"] = txtEmpName.Text;
                        drCurrentRow["DeptName"] = txtDeptName.Text;
                        drCurrentRow["EmpAddress"] = txtEmpAddress.Text;
                        drCurrentRow["EmpSalary"] = txtEmpSalary.Text;
                    }
                    //Remove initial blank row   
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();
                    }
                    //add created Rows into dataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Bind Gridview with latest Row   
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
        }
        protected void AddEmpDetails_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("EmpId", typeof(string)));
            dt.Columns.Add(new DataColumn("EmpName", typeof(string)));
            dt.Columns.Add(new DataColumn("DeptName", typeof(string)));
            dt.Columns.Add(new DataColumn("EmpAddress", typeof(string)));
            dt.Columns.Add(new DataColumn("EmpSalary", typeof(string)));
            string Id = string.Empty;
            string Name = string.Empty;
            string DeptName = string.Empty;
            string EmpAddress = string.Empty;
            string EmpSalary = string.Empty;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = (GridViewRow)GridView1.Rows[i];
                if (i != e.RowIndex)
                {
                    Id = row.Cells[1].Text;
                    Name = row.Cells[2].Text;
                    DeptName = row.Cells[3].Text;
                    EmpAddress = row.Cells[4].Text;
                    EmpSalary = row.Cells[5].Text;
                }
                else
                {
                    Id = ((TextBox)row.Cells[1].Controls[0]).Text;
                    Name = ((TextBox)row.Cells[2].Controls[0]).Text;
                    DeptName = ((TextBox)row.Cells[3].Controls[0]).Text;
                    EmpAddress = ((TextBox)row.Cells[4].Controls[0]).Text;
                    EmpSalary = ((TextBox)row.Cells[5].Controls[0]).Text;
                }
                DataRow dr = dt.NewRow();
                dr["EmpId"] = Id;
                dr["EmpName"] = Name;
                dr["DeptName"] = DeptName;
                dr["EmpAddress"] = EmpAddress;
                dr["EmpSalary"] = EmpSalary;
                dt.Rows.Add(dr);
            }
            GridView1.EditIndex = -1;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("EmpId", typeof(string)));
                dt.Columns.Add(new DataColumn("EmpName", typeof(string)));
                dt.Columns.Add(new DataColumn("DeptName", typeof(string)));
                dt.Columns.Add(new DataColumn("EmpAddress", typeof(string)));
                dt.Columns.Add(new DataColumn("EmpSalary", typeof(string)));
                string Id = string.Empty;
                string Name = string.Empty;
                string DeptName = string.Empty;
                string EmpAddress = string.Empty;
                string EmpSalary = string.Empty;
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridViewRow row = (GridViewRow)GridView1.Rows[i];
                    if (i != e.RowIndex)
                    {
                        Id = row.Cells[1].Text;
                        Name = row.Cells[2].Text;
                        DeptName = row.Cells[3].Text;
                        EmpAddress = row.Cells[4].Text;
                        EmpSalary = row.Cells[5].Text;
                        DataRow dr = dt.NewRow();
                        dr["EmpId"] = Id;
                        dr["EmpName"] = Name;
                        dr["DeptName"] = DeptName;
                        dr["EmpAddress"] = EmpAddress;
                        dr["EmpSalary"] = EmpSalary;
                        dt.Rows.Add(dr);
                    }
                }
                GridView1.EditIndex = -1;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindEmpDetails();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindEmpDetails();
        }
        private void BindEmpDetails()
        {
            if (ViewState["EmployeeDetails"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["EmployeeDetails"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //add each row into data table   
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["EmpId"] = txtEmpId.Text;
                        drCurrentRow["EmpName"] = txtDeptName.Text;
                        drCurrentRow["DeptName"] = txtDeptName.Text;
                        drCurrentRow["EmpAddress"] = txtEmpAddress.Text;
                        drCurrentRow["EmpSalary"] = txtEmpSalary.Text;
                    }
                    //Remove initial blank row   
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();
                    }
                    //Bind Gridview with latest Row   
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
        }
    }
}