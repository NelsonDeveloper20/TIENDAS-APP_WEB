<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_CargaPedidoSugeridoCliente.aspx.cs" Inherits="Web_Nestle.F_CargaPedidoSugeridoCliente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
        <script src="Js/bs-custom-file-input.js"></script>
 <style>
     
table th, table td {
  
  border: 1px solid #eee;
  /*padding: 12px 35px;*/
  border-collapse: collapse;
}
table th {
  background: #007BFF;
  color: #fff;
  text-transform: uppercase;
  font-size: 11px;
  border-radius:6px;
}.loader {
    position: fixed;
    left: 0px;
    top: 0px;
    width: 100%;
    height: 100%;
    z-index: 9999;
    background: url('https://visitqueanbeyanpalerang.com.au/wp-content/themes/queanbeyan-palerang/images/rolling-ajax-load.gif') 50% 50% no-repeat rgb(249,249,249);
    opacity: .8;
}
 </style><script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script>
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        }); $(document).ready(function () {
            bsCustomFileInput.init()
        })
    </script><div class="loader"></div>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager" runat="server" />         
            <div class="row">
            <div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 5px;margin-top: 10px;">
            <div class="card card-small mb-4">
            <div class="card-header border-bottom">
            <h6 class="m-0">carga Incremental Pedido Sugerido</h6>
            </div>
            <ul class="list-group list-group-flush">
            <li class="list-group-item p-3">
            <div class="row">
            <div class="col">
                <asp:Panel ID="PanelListar" CssClass="col-lg-12" runat="server">
                    <div class="row">
                      

                        

                       <div class="form-group col-md-3" >
                          <asp:LinkButton ID="BtnBuscar" Width="100%" CssClass="btn btn-success" Font-Size="13px" runat="server" OnClick="BtnBuscar_Click" ><i class="fas fa-search"></i> Buscar</asp:LinkButton>
				         </div>
                    <div class="form-group col-md-3">
                     <asp:LinkButton ID="BtnNuevo" runat="server" Font-Size="13px" Width="100%" class="btn btn-primary" OnClick="BtnNuevo_Click"><i class="fas fa-plus"></i> Nuevo</asp:LinkButton>
                   
                </div><br style="clear:both"/>
                  <div class="table-responsive">
                    <asp:GridView ID="GVCLIENTESUGERIDO" class="table table-bordered" runat="server" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" DataKeyNames="IdCliente" OnRowCancelingEdit="GVCLIENTESUGERIDO_RowCancelingEdit" OnRowEditing="GVCLIENTESUGERIDO_RowEditing" OnRowUpdating="GVCLIENTESUGERIDO_RowUpdating">
           
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <EditItemTemplate>  <asp:Label ID="Label3" runat="server" Text='<%# Bind("IdClienteIncrementoPedido") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("IdClienteIncrementoPedido") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="IdCliente">
                                <EditItemTemplate>
                                    <asp:Label ID="Label1C" runat="server" Text='<%# Bind("IdCliente") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1c3" runat="server" Text='<%# Bind("IdCliente") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cliente">
                                <EditItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cliente") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cliente") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Monto %">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TxtMonto" CssClass="form-control"    runat="server" Text='<%# Bind("Monto") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Monto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Aciones">
                <ItemTemplate>                                 
                <asp:LinkButton ID="lnkEdit" runat="server" Text=""   CommandName="Edit" ToolTip="Edit" 
                CommandArgument='' CssClass="btn btn-info">  <i class="fas fa-edit"></i> Editar</asp:LinkButton>
                </ItemTemplate>
            <EditItemTemplate>
            <asp:LinkButton ID="lnkInsert" runat="server" Text=""  ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
            CommandArgument='' CssClass="btn btn-primary"> <i class="fas fa-sync-alt"></i> Modificar</asp:LinkButton>
            <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
            CommandArgument='' CssClass="btn btn-dark"><i class="fas fa-exclamation-circle"></i>  Cancelar</asp:LinkButton>
            </EditItemTemplate>
                            </asp:TemplateField>  
                        </Columns>
             <EmptyDataTemplate>
                                    <div><center><h3>No hay Registros</h3></center></div>
                                </EmptyDataTemplate>
                    <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                    </asp:GridView>
                               </div>
                        </div>
                </asp:Panel>
                <asp:Panel ID="PanelSubir" CssClass="col-md-12" runat="server">
              
                     <div class="form-row">
                          <div class="form-group col-md-4">
                     <br style="clear:both;"/><br />     <div class="custom-file">
                   <asp:FileUpload ID="FileUpload1" class="custom-file-input" runat="server" onchange="UploadFile(this);" />
  <label class="custom-file-label" for="inputGroupFile01">Seleccione Txt ...</label>
</div>
                </div>
                <div class="form-group col-md-1">
                      <label><br /></label>
                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" OnClick = "Unnamed1_Click" ><i class="fa fa-upload"></i> Subir</asp:LinkButton>
                </div><div class="form-group col-md-1">
                      <label><br /></label>
                <asp:LinkButton ID="LinkButton2" CssClass="btn btn-dark" runat="server" OnClick="LinkButton2_Click"  ><i class="fas fa-angle-double-left"></i> Cancelar</asp:LinkButton>
                </div>
                    <div class="form-group col-md-12">  <asp:Label ID="LblTotal" runat="server"></asp:Label>
                           <div class="table-responsive">
                               <asp:GridView ID="GvSubir"  class="table table-bordered" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False">
                                   <Columns>
                                       <asp:BoundField DataField="IDCLIENTE" HeaderText="IDCLIENTE" />
                                       <asp:BoundField DataField="MONTO" HeaderText="MONTO %" />
                                   </Columns>
                                <EmptyDataTemplate>
                                    <div><center><h3>Seleccione Txt</h3></center></div>
                                </EmptyDataTemplate>
                               </asp:GridView>
                               </div>
                    </div>
                </div>
                   </asp:Panel>
            </div>
            </div>
            </li>
            </ul>
            </div>
            </div>         
            </div>  
    <asp:Button ID="btnUploadDoc" Text="Upload" runat="server" OnClick="UploadDocument" Style="display: none;" />        
</form>
     <script type="text/javascript">
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUploadDoc.ClientID %>").click();
            }
        }
         //function validaFloat(numero) {
         //    if (!/^([0-9])*[.]?[0-9]*$/.test(numero))
         //        alert("El valor " + numero + " no es un número");
         //}
   
         
    </script>
</asp:Content>
