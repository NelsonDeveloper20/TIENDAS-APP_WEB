<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_CargaProducto.aspx.cs" Inherits="Web_Nestle.F_CargaProducto" %>
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
  border-radius:3px;
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
            <h2 class="m-0">Cargar Producto  Tipo Cliente "VENDEDOR"</h2>     
            </div>
            <ul class="list-group list-group-flush">
            <li class="list-group-item p-3">
            <div class="row">
            <div class="col">
                   <div class="form-row">      
                       <asp:Panel ID="PanelSubirNuevo" runat="server">
                <div class="col-md-12">	
                <div class="form-row">
                <div class="form-group col-md-2" style="display:none;">
                <label>Fabricante</label>
                <asp:DropDownList ID="DDFabricante" runat="server"  class="form-control" Width="100%" Height="34px"  >
                </asp:DropDownList>
                </div>
                 <div class="form-group col-md-2" style="display:none">
                <label>Tipo Usuario</label>
                <asp:DropDownList ID="DDTipo" runat="server"  class="form-control" Width="100%" Height="34px"  >
                </asp:DropDownList>
                </div>
                    <div class="form-group col-md-4" style="margin-top: 6px;">
                    <br style="clear:both;"/>
                           <div class="custom-file">
                   <asp:FileUpload ID="FileUpload1" class="custom-file-input" runat="server" onchange="UploadFile(this);" />
  <label class="custom-file-label" for="inputGroupFile01">Seleccione Txt ...</label>
</div>
                </div>
                <div class="form-group col-md-2" style="    margin-top: 9px;">
                      <label></label><br style="clear:both"/>
                <asp:LinkButton ID="LinkButton1" ClientIDMode="Static" CssClass="btn btn-primary" Width="100%" runat="server" OnClick = "Unnamed1_Click" ><i class="fa fa-upload"></i> Subir</asp:LinkButton>
                </div>
                                  <div class="form-group col-md-2" style="    margin-top: 9px;">
                      <label></label><br style="clear:both"/>
                <asp:LinkButton ID="BtnCancelar" CssClass="btn btn-dark" Width="100%" runat="server" OnClick="BtnCancelar_Click" ><i class="fas fa-angle-double-left"></i> Cancelar</asp:LinkButton>
                </div>
                    <div class="form-group col-md-12">  <asp:Label ID="LblTotal" runat="server"></asp:Label>
                     <div class="table-responsive">
                    <asp:GridView ID="Gv_Producto" class="table table-bordered"  ShowHeaderWhenEmpty="true" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">           
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" HtmlEncode="False" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock" />
                            <asp:BoundField DataField="Fabricante" HeaderText="Fabricante" />
                            <asp:BoundField DataField="TipoUsuario" HeaderText="TipoCliente" /> 
                        </Columns>
                                <EmptyDataTemplate>
                                    <div><center><h3>Seleccione Txt</h3></center></div>
                                </EmptyDataTemplate>
                    <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                    </asp:GridView>
                     </div>
                    </div>
                </div>
                </div>
                       </asp:Panel>
                       <asp:Panel ID="PanelListar" runat="server" CssClass="col-lg-12">
                           <div class="col-12">                               
                    <div class="form-row">
                          <div class="form-group col-md-2">
                      <label><br /></label>
                <asp:LinkButton ID="Bntrefresh" Width="100%" CssClass="btn btn-primary" runat="server" OnClick="Bntrefresh_Click" ><i class="fas fa-sync"></i> Listar</asp:LinkButton>
                </div>
                         <div class="form-group col-md-2">
                      <label><br /></label>
                <asp:LinkButton ID="BtnNuevo" Width="100%" CssClass="btn btn-dark" runat="server" OnClick="BtnNuevo_Click" ><i class="fas fa-file-alt"></i> Nuevo</asp:LinkButton>
                </div>
                       <div class="form-group col-md-2"> <br style="clear:both"/><br style="clear:both"/> <h6>Total Productos:  <span class="badge badge-secondary">
                           <asp:Label ID="LblTotalproducto" runat="server" Text=""></asp:Label> </span></h6>
                           </div>
                           <div class="table-responsive">
                    <asp:GridView ID="GvListaProductos" class="table table-bordered" runat="server" 
                        CellPadding="4" ForeColor="#333333"
                         GridLines="None" AutoGenerateColumns="true" >       
                    <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"   /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                    </asp:GridView>
                               </div>
                    </div>
                           </div>
                       </asp:Panel>

                       </div>
            </div>
            </div>
            </li>
            </ul>
            </div>
            </div>         
            </div>  
    <asp:Button ID="btnUploadDoc" ClientIDMode="Static" Text="Upload" runat="server" OnClick="UploadDocument" Style="display: none;" />        
</form>
     <script type="text/javascript">
         function UploadFile(fileUpload) {
             $('.loader').fadeIn('fast').delay(9099988998).fadeOut('fast');
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUploadDoc.ClientID %>").click();
            }
         }
         $(document).ready(function () {

             $("#btnUploadDoc").click(function () {

                 $('.loader').fadeIn('fast').delay(9099988998).fadeOut('fast');
             });
             $("#LinkButton1").click(function () {

                 $('.loader').fadeIn('fast').delay(9099988998).fadeOut('fast');
             });

         });
    </script>
</asp:Content>
