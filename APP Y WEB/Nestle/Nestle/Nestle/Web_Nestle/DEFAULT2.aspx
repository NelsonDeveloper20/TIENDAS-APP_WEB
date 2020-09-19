<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DEFAULT2.aspx.cs" Inherits="Web_Nestle.DEFAULT2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
 
   <form id="form1" runat="server">  
            <div align="center">  
                <h1 style="color:green">Welcome To CURD Operation Without Database</h1>  
                <div style="width: 55%; background-image: url(Images/mks1.jpg); border: 5px solid yellow; border-radius: 25px; box-shadow: maroon 10px 10px 10px; color: aliceblue">  
                    <table>  
                        <tr>  
                            <td></td>  
                            <th style="color:black">Emp ID:  
                            </th>  
                            <th style="color:black">Emp Name:  
                            </th>  
                            <th style="color:black">Dept Name :  
                            </th>  
                            <th style="color:black">Emp Address :  
                            </th>  
                            <th style="color:black">Emp Salary:  
                            </th>  
                        </tr>  
                        <tr>  
                            <td></td>  
                            <td>  
                                <asp:TextBox ID="txtEmpId" runat="server" Width="120px"></asp:TextBox>  
  
                            </td>  
                            <td>  
                                <asp:TextBox ID="txtEmpName" runat="server" Width="120px"></asp:TextBox>  
                            </td>  
                            <td>  
                                <asp:TextBox ID="txtDeptName" runat="server" Width="120px"></asp:TextBox>  
                            </td>  
                            <td>  
                                <asp:TextBox ID="txtEmpAddress" runat="server" Width="120px"></asp:TextBox>  
                            </td>  
                            <td>  
                                <asp:TextBox ID="txtEmpSalary" runat="server" Width="120px"></asp:TextBox>  
                            </td>  
                        </tr>  
                        <tr>  
  
                            <td colspan="6" align="right">  
                                <asp:Button ID="AddEmpDetails" runat="server" Style="color: White" Text="Add Employee" OnClick="AddEmpDetails_Click" BackColor="#00248E" />  
                            </td>  
                        </tr>  
                    </table>  
  
                    <div style="margin-left: 10px; margin-top: 10px">  
                        <asp:GridView ID="GridView1" Width="700" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" AutoGenerateColumns="False" runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">  
                            <Columns>  
                                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" HeaderText="Operation" ItemStyle-Width="120px" />  
  
                                <asp:BoundField HeaderStyle-Width="120px" HeaderText="Emp Id" DataField="EmpId">  
                                    <HeaderStyle Width="120px"></HeaderStyle>  
                                </asp:BoundField>  
                                <asp:BoundField HeaderStyle-Width="120px" HeaderText="Emp Name" DataField="EmpName">  
                                    <HeaderStyle Width="120px"></HeaderStyle>  
                                </asp:BoundField>  
                                <asp:BoundField HeaderStyle-Width="120px" HeaderText="Dept Name" DataField="DeptName">  
                                    <HeaderStyle Width="120px"></HeaderStyle>  
                                </asp:BoundField>  
                                <asp:BoundField HeaderStyle-Width="120px" HeaderText="Emp Address" DataField="EmpAddress">  
                                    <HeaderStyle Width="120px"></HeaderStyle>  
                                </asp:BoundField>  
                                <asp:BoundField HeaderStyle-Width="120px" HeaderText="Emp Salary" DataField="EmpSalary">  
                                    <HeaderStyle Width="120px"></HeaderStyle>  
                                </asp:BoundField>  
                            </Columns>  
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399"  />  
                            <RowStyle BackColor="White" ForeColor="#003399" />  
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />  
                            <SortedDescendingHeaderStyle BackColor="#002876" />  
                        </asp:GridView>  
                    </div>  
                    <br />  
                </div>  
            </div>  
        </form>  
</body>
</html>
