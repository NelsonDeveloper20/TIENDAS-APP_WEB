<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_ControlStock.aspx.cs" Inherits="Web_Nestle.F_ControlStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?&key=AIzaSyAbSQU24--3YuuUrdB07Af9yH-QmjW9118&libraries=places"></script> 
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
   <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
     <script src="jsFecha/bootstrap-datepicker.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/jquery2_2_4.js">    </script>
     
<style>
    .pinta_rojo{
        background:rgba(248, 10, 10, 0.60);
        font-weight:bold;
        color:#FFFFFF;
    }
     .hidden-field
 {
     display:none;
 }</style>
     <script type="text/javascript">
        function ShowPopup() {
            //$("#btnShowPopup").click();
            ////alert('click');
            //document.getElementById("btnShowPopup").click();
            //document.getElementById("btnShowPopup").click();
            //$("#myModal3").modal();
            //$('#myModal3').modal('show');            
        }
    </script>  
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager" runat="server" />         
            <div class="row">
            <div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 5px;margin-top: 10px;">
            <div class="card card-small mb-4">
            <div class="card-header border-bottom">
            <h6 class="m-0">Control Stock</h6>    
            </div>
            <ul class="list-group list-group-flush">
            <li class="list-group-item p-3">
            <div class="row">
            <div class="col">
                <div class="col-md-12">	
                     <div class="form-row">                         

                <asp:Panel ID="Panel2" DefaultButton="BtnBuscar" CssClass="form-group col-md-6" style="margin-left: 5px;   margin-bottom: 0px;" runat="server">
          <br style="clear:both"/>
  <%--<div class="form-group col-md-6" style="  margin-left: 5px;   margin-bottom: 0px;"><br style="clear:both"/>--%>
<div class="input-group mb-3">
<input type="text" class="form-control" placeholder="Ingrese Nombre de Producto" runat="server" id="TxtBuscarG" aria-describedby="basic-addon2">
<div class="input-group-append">
<asp:LinkButton ID="BtnBuscar" CssClass="btn btn-outline-secondary" BackColor="#5A6169" ForeColor="#FFFFFF" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-search"></i></asp:LinkButton>
</div>
</div>

<%--</div>--%>
      </asp:Panel>

                            
                <div class="form-group col-md-2">
                      <br style="clear:both"/>
                <asp:LinkButton ID="BtnExportar" CssClass="btn btn-primary" runat="server" OnClick="BtnExportar_Click1" Width="100%">Exportar&nbsp;&nbsp; <i class="fa fa-file-excel" aria-hidden="true"></i></asp:LinkButton>
                </div> 

                    <div class="form-group col-md-12">  <asp:Label ID="LblTotal" runat="server"></asp:Label>
                           <div class="table-responsive">
                               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                   <ContentTemplate>
                    <asp:GridView ID="GV_Pedido" class="table table-bordered" runat="server" 
                        CellPadding="4" ForeColor="#333333"   OnRowDataBound="GvPedido_OnRowDataBound"  
                         GridLines="None" AutoGenerateColumns="False" OnRowEditing="GV_Pedido_RowEditing" DataKeyNames="ID" OnRowCancelingEdit="GV_Pedido_RowCancelingEdit" OnRowUpdating="GV_Pedido_RowUpdating">
           
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <EditItemTemplate>
                                    <asp:Label ID="Label8" runat="server"  Text='<%# Bind("ID") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdAlmacen">
                                <EditItemTemplate>                                    
                                    <asp:Label ID="Labelaf1" runat="server"  Text='<%# Bind("IdAlmacen") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("IdAlmacen") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Producto">
                                <EditItemTemplate>
                                    <asp:Label ID="Label8nm" runat="server"  Text='<%# Bind("Producto") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Producto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stock">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TxtStock"  onKeyPress="return soloNumeros(event)" CssClass="form-control" runat="server" Text='<%# Bind("Stock") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LBlStock" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fabricante">
                                <EditItemTemplate>
                                    <asp:Label ID="hj" runat="server" Text='<%# Bind("Fabricante") %>'></asp:Label>
                                  
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Fabricante") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha Carga">
                                <EditItemTemplate>
                                    <asp:Label ID="Label6s" runat="server" Text='<%# Bind("FechaCarga") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("FechaCarga") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Usuario Carga">
                                <EditItemTemplate>
                                    <asp:Label ID="yg" runat="server" Text='<%# Bind("UsuarioCarga") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("UsuarioCarga") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             
                            
                            <asp:TemplateField HeaderText="Aciones">
                                <ItemTemplate>
                                 
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text=""   CommandName="Edit" ToolTip="Edit" 
                                        CommandArgument='' CssClass="btn btn-info">  <span aria-hidden="true" class="glyphicon glyphicon-pencil"></span> Editar</asp:LinkButton>
                           
                                         </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text=""  ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
                                        CommandArgument='' CssClass="btn btn-primary"> <span aria-hidden="true" class="glyphicon glyphicon-refresh"></span> Modificar</asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                        CommandArgument=''  CssClass="btn btn-dark" ForeColor="White"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span>   Cancelar</asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text=""  Width="100%"  ValidationGroup="newGrp" CommandName="InsertNew" ToolTip="Add"
                                        CommandArgument='' CssClass="btn btn-primary">   <span aria-hidden="true" class="glyphicon glyphicon-plus"></span>Insertar</asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Width="100%" Text="" CommandName="CancelNew" ToolTip="Cancel"
                                        CommandArgument='' CssClass="btn btn-dark" Visible="false" ForeColor="White">Cancelar</asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>  
                        </Columns>
           
                    <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                    </asp:GridView>
                                   </ContentTemplate>  <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GV_Pedido" />
            </Triggers>
                             </asp:UpdatePanel>
                           </div>
                          <div style="display:none">
                                   <asp:GridView ID="GridView1" runat="server"></asp:GridView>

                               </div>
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

       
   <asp:HiddenField  runat="server" ID="HndIdPedido" ClientIDMode="Static"/>
 <script>
     function soloNumeros(e) {
         var key = window.Event ? e.which : e.keyCode
         return (key >= 48 && key <= 57)
     }
 </script>
</form>
  
 
</asp:Content>
