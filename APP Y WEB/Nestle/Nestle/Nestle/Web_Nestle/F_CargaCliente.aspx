<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_CargaCliente.aspx.cs" Inherits="Web_Nestle.F_CargaCliente" %>
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
 </style> 
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script>
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        });
        $(document).ready(function () {
            bsCustomFileInput.init()
        })
    </script>
<form id="form1" runat="server"><div class="loader"></div>
<asp:ScriptManager ID="ScriptManager" runat="server" />    
            <div class="row">
            <div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 5px;margin-top: 10px;">
            <div class="card card-small mb-4">
            <div class="card-header border-bottom">
            <h6 class="m-0">Cargar Cliente</h6>
            </div>
            <ul class="list-group list-group-flush">
            <li class="list-group-item p-3">
            <div class="row">
            <div class="col">
                <div class="col-md-12">	
                     <div class="form-row">
            

                          <div class="form-group col-md-4">
                     <br style="clear:both;"/>
                  <div class="custom-file">
                   <asp:FileUpload ID="FileUpload1" class="custom-file-input" runat="server" onchange="UploadFile(this);" />
  <label class="custom-file-label" for="inputGroupFile01">Seleccione Txt ...</label>
</div>
                </div>
                <div class="form-group col-md-2">
                     <br style="clear:both;"/>
                <asp:LinkButton ID="LinkButton1" ClientIDMode="Static" CssClass="btn btn-success" runat="server" OnClick = "Unnamed1_Click" ><i class="fa fa-upload"></i> Subir</asp:LinkButton>
                </div>
                    <div class="form-group col-md-12">  <asp:Label ID="LblTotal" runat="server"></asp:Label>
                        <div class="table-responsive">
                    <asp:GridView ID="Gv_Producto" class="table table-bordered" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" >           
                        <Columns>
                            <asp:BoundField DataField="Cod_Cliente" HeaderText="Cod_Cliente" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" HtmlEncode="False" />
                            <asp:BoundField DataField="Direccion" HeaderText="Direccion" HtmlEncode="False"  />
                            <asp:BoundField DataField="Cod_Canal" HeaderText="Cod_Canal" />
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                            <asp:BoundField DataField="Param1" HeaderText="Param1" />
                            <asp:BoundField DataField="Param2" HeaderText="Param2" />
                            <asp:BoundField DataField="Param3" HeaderText="Param3" />
                            <asp:BoundField DataField="Param4" HeaderText="Param4" />
                            <asp:BoundField DataField="Param5" HeaderText="Param5" />
                            <asp:BoundField DataField="Param6" HeaderText="Param6" />
                            <asp:BoundField DataField="Param7" HeaderText="Param7" />
                            <asp:BoundField DataField="Param8" HeaderText="Param8" />
                            <asp:BoundField DataField="Param9" HeaderText="Param9" />
                        </Columns>
                    <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                    </asp:GridView></div>
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
    <asp:Button ID="btnUploadDoc" ClientIDMode="Static" Text="Upload" runat="server" OnClick="UploadDocument" Style="display: none;" />        
</form>
    
   
     <script type="text/javascript">
         function UploadFile(fileUpload) {
             $('.loader').fadeIn('fast').delay(9099988998).fadeOut('fast');
             //$(".loader").fadeOut("slow");
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
