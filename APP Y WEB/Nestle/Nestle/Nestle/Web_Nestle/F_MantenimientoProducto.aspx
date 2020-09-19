<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_MantenimientoProducto.aspx.cs" Inherits="Web_Nestle.F_MantenimientoProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
   <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
     <script src="jsFecha/bootstrap-datepicker.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/jquery2_2_4.js">    </script>

        <script src="vendor/Multilist/jquery.sumoselect.min.js"></script>
    <link href="vendor/Multilist/sumoselect.css" rel="stylesheet" />
      <script>
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        });
    </script><div class="loader"></div>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
        <div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 5px;margin-top: 10px;">
        <div class="card card-small mb-4">
        <div class="card-header border-bottom">
        <h6 class="m-0">Mantenimiento Producto</h6>    
        </div>
        <ul class="list-group list-group-flush">
        <li class="list-group-item p-3">
        <div class="row">
        <div class="col">
        <div class="form-row">  
             <asp:Panel ID="Panel1" class="form-group col-lg-6" DefaultButton="BtnBu" runat="server">
    <label></label>
<div class="input-group mb-3">
<input type="text" class="form-control" placeholder="Ingrese Codigo Ó Nombre del producto" runat="server" id="TxtNombre" aria-describedby="basic-addon2">
<div class="input-group-append">
<asp:LinkButton ID="BtnBu" CssClass="btn btn-outline-secondary" BackColor="#5A6169" ForeColor="#FFFFFF" runat="server" OnClick="BtnBu_Click"  ><i class="fa fa-search"></i></asp:LinkButton>
</div>
</div>

</asp:Panel>
            <div class="col-lg-12"> 
                   <div class="table-responsive">
               <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <asp:GridView ID="gridSample" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                CssClass="table table-bordered" OnRowCommand="gridSample_RowCommand"        DataKeyNames="IdProducto" CellPadding="4" 
                GridLines="None" OnRowCancelingEdit="gridSample_RowCancelingEdit"   OnRowEditing="gridSample_RowEditing"
                OnRowUpdating="gridSample_RowUpdating"    onrowdatabound="gridSample_RowDataBound"       onrowdeleting="gridSample_RowDeleting" AllowPaging="True" OnPageIndexChanging="gridSample_PageIndexChanging" PageSize="7" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="IdProductoTxt">
                        <EditItemTemplate>
                            <asp:Label ID="LblTxt" runat="server" Text='<%# Bind("IdProductoTxt") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("IdProductoTxt") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TxtCodigoProdInsert" placeholder="CODIGO TXT" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NombrePro">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" Text='<%# Bind("NombrePro") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("NombrePro") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TxtNombreInsert" CssClass="form-control" placeholder="NOMBRE PRODUCTO" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion">
                        <EditItemTemplate>
                            <asp:TextBox ID="Txtdescripcion" CssClass="form-control" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                        </ItemTemplate> 
                         <FooterTemplate>
                            <asp:TextBox ID="TxtDescripcionInsert" CssClass="form-control" placeholder="DESCRIPCION PRODUCTO" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtPrecio"   CssClass="form-control" runat="server" Text='<%# Bind("Precio") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                        </ItemTemplate>
                          <FooterTemplate>
                            <asp:TextBox ID="TxtPrecioInsert" CssClass="form-control" placeholder="PRECIO" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stock">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtStock" runat="server" CssClass="form-control" onKeyPress="return soloNumeros(event)"  Text='<%# Bind("Stock") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                        </ItemTemplate>
                          <FooterTemplate>
                            <asp:TextBox ID="TxtStockInsert" CssClass="form-control" onKeyPress="return soloNumeros(event)"  placeholder="STOCK" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Aciones">
                <ItemTemplate>
                                 
                <asp:LinkButton ID="lnkEdit" runat="server" Text=""   CommandName="Edit" ToolTip="Edit" 
                CommandArgument='' CssClass="btn btn-info">  <span aria-hidden="true" class="glyphicon glyphicon-pencil"></span> Editar</asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server"    Text="Delete" CommandName="Delete"
                ToolTip="Delete" OnClientClick='return confirm("Elimnar?");'
                CommandArgument='' CssClass="btn btn-dark">   <span aria-hidden="true" class="glyphicon glyphicon-trash"></span> Eliminar</asp:LinkButton>
                           
                </ItemTemplate>
                <EditItemTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text=""  ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
                CommandArgument='' CssClass="btn btn-primary"> <span aria-hidden="true" class="glyphicon glyphicon-refresh"></span> Modificar</asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                CommandArgument='' CssClass="btn btn-dark"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span>   Cancelar</asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text=""  Width="100%"  ValidationGroup="newGrp" CommandName="InsertNew" ToolTip="Add"
                CommandArgument='' CssClass="btn btn-primary">   <span aria-hidden="true" class="glyphicon glyphicon-plus"></span>Insertar</asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Width="100%" Text="" CommandName="CancelNew" ToolTip="Cancel"
                CommandArgument='' CssClass="btn btn-warning" Visible="false">Cancelar</asp:LinkButton>
                </FooterTemplate>
                </asp:TemplateField>                  
                </Columns>
        
                <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="12px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                <RowStyle font-size="13px"   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
                <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />

                <EditRowStyle  CssClass="edit_backg" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" BorderColor="#FF9900" BorderStyle="Groove" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
           <%--    </ContentTemplate> <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gridSample" />
            </Triggers>
                </asp:UpdatePanel>--%>
            </div>
                  </div>     
        </div>
        </div>
        </div>
        </li>
        </ul>
        </div>
        </div>         
        </div>  
        <script>


            function soloNumeros(e) {
                var key = window.Event ? e.which : e.keyCode
                return (key >= 48 && key <= 57)
            }
        </script>
    </form>
</asp:Content>
