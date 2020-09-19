<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_CargaConciliaciónCliente.aspx.cs" Inherits="Web_Nestle.F_CargaConciliaciónCliente" %>
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
  /*text-transform: uppercase;*/
  font-size: 11px;
  border-radius:2px;
}.loader {
    position: fixed;
    left: 0px;
    top: 0px;
    width: 100%;
    height: 100%;
    z-index: 9999;
    background: url('iconos/load2.gif') 50% 50% no-repeat rgb(249,249,249);
    opacity: .8;
        background-size: 20%;
        
}
 </style><script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script>
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        }); $(document).ready(function () {
            bsCustomFileInput.init()
        })
    </script><div class="loader">         
             </div>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager" runat="server" />         
            <div class="row">
            <div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 5px;margin-top: 10px;">
            <div class="card card-small mb-4">
            <div class="card-header border-bottom">
            <h6 class="m-0">carga Conciliacion Pedido</h6>
            </div>
            <ul class="list-group list-group-flush">
            <li class="list-group-item p-3">
            <div class="row">
            <div class="col">
             
                <asp:Panel ID="PanelSubir" CssClass="col-md-12" runat="server">
              
                     <div class="form-row">
                          <div class="form-group col-md-4">
                     <br style="clear:both;"/><br />  <div class="custom-file">
                   <asp:FileUpload ID="FileUpload1" class="custom-file-input" runat="server" onchange="UploadFile(this);" />
  <label class="custom-file-label" for="inputGroupFile01">Seleccione Txt ...</label>
</div>
                </div>
                <div class="form-group col-md-1">
                      <label><br /></label>
                <asp:LinkButton ID="LinkButton1" ClientIDMode="Static" CssClass="btn btn-primary" runat="server" OnClick = "Unnamed1_Click" ><i class="fa fa-upload"></i> Subir</asp:LinkButton>
                </div>

                    <div class="form-group col-md-12">  <asp:Label ID="LblTotal" runat="server"></asp:Label>
                           <div class="table-responsive">
                               <asp:GridView ID="GvSubir"  class="table table-bordered" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False">
                                   <Columns>
                                       <asp:BoundField DataField="IdPedidoMarket" HeaderText="IdPedido Market" />
                                       <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" />
                                       <asp:BoundField DataField="Cantidad" HeaderText="CantidadEntregadaCliente" />
                                       <asp:BoundField DataField="Precio" HeaderText="Precio" />
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
 
         function filter(__val__) {
             var preg = /^([0-9]+\.?[0-9]{0,2})$/;
             if (preg.test(__val__) === true) {
                 return true;
             } else {
                 return false;
             }

         }
    </script>
</asp:Content>
