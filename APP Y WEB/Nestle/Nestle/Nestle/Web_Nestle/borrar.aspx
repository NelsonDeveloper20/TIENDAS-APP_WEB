<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="borrar.aspx.cs" Inherits="Web_Nestle.borrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:500px">
        
        <asp:GridView ID="grd" runat="server" Width="100%" 
            AutoGenerateColumns="false"
            AlternatingRowStyle-BackColor="#E9ECF1" 
            HeaderStyle-BackColor="white" 
            Font-Names="Arial" 
            RowStyle-HorizontalAlign="Center" 
            RowStyle-Height="22" 
            HeaderStyle-Height="25"
            FooterStyle-HorizontalAlign="Center" 
            FooterStyle-Font-Bold="true" 
            FooterStyle-ForeColor="#555555"
            ShowFooter="true" AllowPaging="true" PageSize="5" 
            OnPageIndexChanging="grd_PageIndexChanging" 
            OnRowDataBound="grd_RowDataBound">
                
            <Columns>
                <asp:TemplateField HeaderText="Book ID">
                    <ItemTemplate><%#Eval("BookID")%></ItemTemplate>
                </asp:TemplateField>
                    
                <asp:TemplateField HeaderText="Name of the Book">
                    <ItemTemplate><%#Eval("BookName")%></ItemTemplate>
                    <FooterTemplate>
                        <div style="padding:0 0 5px 0"><asp:Label Text="Page Total" runat="server" /></div>
                        <div><asp:Label Text="Grand Total" runat="server" /></div>
                    </FooterTemplate>
                </asp:TemplateField>
                    
                <asp:TemplateField HeaderText="Price ($)">
                    <ItemTemplate><asp:Label ID="lblTotalPrice" runat="server" Text='<%#Eval("Price")%>'>
                        </asp:Label></ItemTemplate>

                    <FooterTemplate>
                        <div style="padding:0 0 5px 0"><asp:Label ID="lblPageTotal" runat="server" /></div>
                        <div><asp:Label ID="lblGrandTotal" runat="server" /></div>
                    </FooterTemplate>

                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
