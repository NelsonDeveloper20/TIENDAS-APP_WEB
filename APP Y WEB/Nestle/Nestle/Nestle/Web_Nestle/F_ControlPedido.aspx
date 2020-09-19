<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_ControlPedido.aspx.cs" Inherits="Web_Nestle.F_ControlPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
        <%--<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?&key=AIzaSyAbSQU24--3YuuUrdB07Af9yH-QmjW9118&libraries=places"></script>--%>
  
   
     <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?&key=AIzaSyDUzZdi2LgA2zI5o2bBSqJvuV-bEEkfZpU&libraries=places"></script>
  
       
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
   <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
     <script src="jsFecha/bootstrap-datepicker.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/jquery2_2_4.js">    </script>     
    <script src="vendor/Multilist/jquery.sumoselect.min.js"></script>
    <link href="vendor/Multilist/sumoselect.css" rel="stylesheet"/>
<style>  
     /*CHECKBOX*/
               #overlay{
    display:none;
 
}
        /*buscar combo*/
     .checkbox label:after, 
.radio label:after {
    content: '';
    display: table;
    clear: both;
}

.checkbox .cr,
.radio .cr {
    position: relative;
    display: inline-block;
    border: 1px solid #a9a9a9;
    border-radius: .25em;
    width: 1.3em;
    height: 1.3em;
    float: left;
    margin-right: .5em;
    border: 1px solid #02cf32;
}

.radio .cr {
    border-radius: 50%;
}

.checkbox .cr .cr-icon,
.radio .cr .cr-icon {
    position: absolute;
    font-size: .8em;
    line-height: 0;
    top: 50%;
    left: 20%;
}

.radio .cr .cr-icon {
    margin-left: 0.04em;
}

.checkbox label input[type="checkbox"],
.radio label input[type="radio"] {
    display: none;
}

.checkbox label input[type="checkbox"] + .cr > .cr-icon,
.radio label input[type="radio"] + .cr > .cr-icon {
    transform: scale(3) rotateZ(-20deg);
    opacity: 0;
    transition: all .3s ease-in;
}

.checkbox label input[type="checkbox"]:checked + .cr > .cr-icon,
.radio label input[type="radio"]:checked + .cr > .cr-icon {
    transform: scale(1) rotateZ(0deg);
    opacity: 1;
}

.checkbox label input[type="checkbox"]:disabled + .cr,
.radio label input[type="radio"]:disabled + .cr {
    opacity: .5;
}
        /*end*/
      /*CHECKBOX*/
/*Buscar dropdown list*/
.SumoSelect > .CaptionCont {
display: block;
width: 100%;
height: 34px;
padding: 6px 12px;
font-size: 14px;
line-height: 1.42857143;
color: #555;
background-color: #fff;
background-image: none;
border: 1px solid #ccc;
border-radius: 4px;
-webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
-webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
-o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
}
/*end*/
 .hidden-field
 {
     display:none;
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
  .loaderk {
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
<script type="text/javascript">   
    function ExportarCabecera() {
        var userDetails = ''; var retString = '';
        $('#GvExportTxt tbody tr').each(function () {
            var detail = '';
            $(this).find('td').each(function () {
                detail += $(this).html() + '|';
            }); detail = detail.substring(0, detail.length - 1);
            detail += ''; userDetails += detail + '\r\n';
        }); var a = document.createElement('a');
        var file = new Blob([userDetails], { type: 'text/plain' });
        a.href = URL.createObjectURL(file);
        a.download = 'Pedido.txt'; a.click();
    }
    </script> 
    <script>
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        });
    </script>
<form id="form1" runat="server"><div class="loader"></div>
     <div id ="overlay" class="loaderk"></div>
<asp:ScriptManager ID="ScriptManager" runat="server" />         
            <div class="row">
            <div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 5px;margin-top: 10px;">
            <div class="card card-small mb-4">
            <div class="card-header border-bottom">
            <h6 class="m-0">Pedido</h6>    
            </div>
            <ul class="list-group list-group-flush">
            <li class="list-group-item p-3">
            <div class="row">
            <div class="col">
               <%-- <div class="col-md-12">	--%>
                     <div class="form-row">  
                         <div class="col-lg-9 col-md-12">
                             <div class="card card-small mb-3">
                                 <div class="card-body">
                                     <div class="form-row" style="    margin-bottom: -22px;">  
                <div class="form-group col-md-3">
                <label>Fecha Inicio</label>
                <input type="text" class="form-control" runat="server" placeholder="aa/mm/yyyy" ClientIDMode="Static" id="TxtFechaInicio" autocomplete="off">
                    <div class="input-group-addon">
                    <span class="glyphicon glyphicon-th"></span>
                    </div>
                </div>

                 <div class="form-group col-md-3">
                <label>Fecha Fin</label>
               <input type="text" class="form-control" runat="server"  placeholder="aa/mm/yyyy" ClientIDMode="Static" id="TxtFecFin" autocomplete="off">
                    <div class="input-group-addon">
                    <span class="glyphicon glyphicon-th"></span>
                    </div>
                </div>    
                     <div class="form-group col-md-3" >
                    <label style="float: inherit;"> Vendedor</label><br style="clear:both"/>
                    <asp:DropDownList ID="DDUsuario"  runat="server"  class="form-control buscarDNels" style="width: 100% !important;"  >
                    </asp:DropDownList>                
                    </div>                           
                          <div class="form-group col-md-2" style="display:none">
                <label>Codigo</label>
               <input type="text" class="form-control" runat="server" readonly="readonly"    onKeyPress="return soloNumeros(event)"  placeholder="Codigo Externo" ClientIDMode="Static" id="TxtCorrelativo" autocomplete="off">
                </div>    
         <div class="form-group col-sm-2" style="display:none">
           <center>  <label>Pedidos Sin CodigoExterno</label>
       <div class="checkbox">
        <label style="font-size: 1.3em;margin-top:4px">
        <asp:CheckBox runat="server" ID="ChkCodigo" Checked="true"  />                      
        <span class="cr" style="border: 2px solid #23A9E1;"><i class="cr-icon fa fa-check"></i></span>
        </label>
        </div></center></div> 
                            

                          <div class="col-lg-12"></div>                
                <div class="form-group col-md-2" >
                      <%--<br style="clear:both"/>--%>
                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success" runat="server" OnClick="LinkButton1_Click" Width="100%"  ><i class="fa fa-search"></i>Buscar</asp:LinkButton>
                </div>           
                <div class="form-group col-md-3">
                      <%--<br style="clear:both"/>--%>
                <asp:LinkButton ID="BtnExportar" CssClass="btn btn-primary" runat="server" OnClick="BtnExportar_Click1" Width="100%">Exportar Excel&nbsp;&nbsp; <i class="fa fa-file-excel" aria-hidden="true"></i></asp:LinkButton>
                </div>  
                    <div class="form-group col-md-3" >
                      <%--<br style="clear:both"/>--%>
                     <h6>  <asp:Label ID="LblTotalped" runat="server" Text=""></asp:Label></h6>
                        </div>  
                                          <div class="form-group col-md-3" >
                      <%--<br style="clear:both"/>--%>
                     <h6>  <asp:Label ID="LblSoles" runat="server" Text=""></asp:Label></h6>
                        </div> 
                          </div></div>
                                 </div></div>
                         <div class="col-lg-3 col-md-12">
                             <div class="card card-small mb-3">
                                 <div class="card-header border-bottom">
                    <h6 class="m-0">Exportar Txt</h6>
                  </div>
                       
                         
                <div class="form-group col-md-12" style="    margin-bottom: 20px;">
                      <br style="clear:both"/>
                <asp:LinkButton ID="BtnExportTxt" CssClass="btn btn-primary" runat="server" OnClick="LinkButton2_Click" Width="100%">Exportar Pedido Txt Hoy&nbsp;&nbsp;<i class="fa fa-file" aria-hidden="true"></i></asp:LinkButton>
                </div>
                <div class="form-group col-md-3" style="display:none">
                      <br style="clear:both"/>
                <asp:LinkButton ID="BtnExportDetalle" Visible="false" CssClass="btn btn-primary" runat="server"  Width="100%" OnClick="LinkButton2_Click1" Font-Size="11px">Export Detalle Pedido Txt<i class="fa fa-file" aria-hidden="true"></i></asp:LinkButton>
                </div>
                             </div>   </div>
                    <div class="form-group col-md-12">  <asp:Label ID="LblTotal" runat="server"></asp:Label>
                           <div class="table-responsive">
                    <asp:GridView ID="GV_Pedido" class="table table-bordered" runat="server"  ShowFooter="true"
                        CellPadding="4" ForeColor="#333333"
                         GridLines="None" AutoGenerateColumns="False" OnRowDataBound="GV_Pedido_RowDataBound" >
           
                        <Columns>
                            <asp:BoundField DataField="IdPedido" HeaderText="IdPedido" />
                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="CodicionVenta" HeaderText="CodicionVenta" />
                            <asp:BoundField DataField="TipoUsuario" HeaderText="TipoUsuario" />
                            <asp:BoundField DataField="UsuarioVenta" HeaderText="UsuarioVenta" />
                            <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate><%#Eval("Cantidad")%></ItemTemplate>
                    <FooterTemplate>
                        <div><asp:Label Text="Total S/." runat="server" /></div>
                    </FooterTemplate>
                </asp:TemplateField>
                            <asp:TemplateField HeaderText="TotalPagar">
                    <ItemTemplate><asp:Label ID="lblTotalPrice" runat="server" Text='<%#Eval("TotalPagar")%>'>
                        </asp:Label></ItemTemplate>

                    <FooterTemplate>
                        <div style="padding:0 0 5px 0"><asp:Label ID="lblPageTotal" runat="server" /></div>
                        <div><asp:Label ID="lblGrandTotal" runat="server" /></div>
                    </FooterTemplate>

                </asp:TemplateField>
                          <%--  <asp:BoundField DataField="TotalPagar" HeaderText="TotalPagar" />--%>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                             <asp:TemplateField ShowHeader="False" HeaderText="Detalle" HeaderStyle-CssClass="stilo-header">
                        <ItemTemplate>
                        <a id="popdetalle" >
                        <img src="https://www.clickfactura.mx/images/iconos/icon-itickets.png" width="33px" />
                        </a>
                        </ItemTemplate>

                        <HeaderStyle CssClass="stilo-header"></HeaderStyle>
                        </asp:TemplateField>
                             <asp:TemplateField ShowHeader="False" HeaderText="Ver Mapa" HeaderStyle-CssClass="stilo-header">
                        <ItemTemplate>
                        <a id="popmapa" data-toggle="modal" data-target="#myModal2">
                        <img src="iconos/mapaver.png" width="33px" />
                        </a>
                        </ItemTemplate>

                        <HeaderStyle CssClass="stilo-header"></HeaderStyle>
                        </asp:TemplateField>
                             <asp:BoundField DataField="Latitud" HeaderText="" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
                    <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
                                 <FooterStyle CssClass="hidden-field"></FooterStyle>
                    </asp:BoundField>
                             <asp:BoundField DataField="Longitud" HeaderText="" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
                    <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
                                  <FooterStyle CssClass="hidden-field"></FooterStyle>
                    </asp:BoundField>
                            <asp:BoundField DataField="IdPedidoExterno" HeaderText="Codigo Externo" />
                        </Columns>
           
                    <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                    </asp:GridView>
                               <div style="display:none">
                                     <asp:Panel runat="server" ID="PanelExportarExcel">
       <center>  <table>
            <tr>
                <td>

                    <asp:Image ID="Image1" ImageUrl="http://3.19.108.54/nestle/iconos/logo_azulexport.png"
                        runat="server" />
              
                </td>
                <td>
                </td>
            </tr>
           <tr>
               <td></td><td>

               </td>
               <td>  <%-- NELSON :) --%>      
                            <b><h3>
<asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label><br />
<asp:Label ID="LblFecha" runat="server" Text="Label"></asp:Label></h3></b>
               </td>
           </tr>
        </table>
            </center>
                                  
        <br />
                                    <asp:GridView ID="GvExport" class="table table-bordered" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                                   <Columns>
                            <asp:BoundField DataField="IdPedido" HeaderText="IdPedido" />
                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="CodicionVenta" HeaderText="CodicionVenta" />
                            <asp:BoundField DataField="TipoUsuario" HeaderText="TipoUsuario" />
                            <asp:BoundField DataField="UsuarioVenta" HeaderText="UsuarioVenta" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="TotalPagar" HeaderText="TotalPagar" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        </Columns>
           
                    <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                    </asp:GridView>
  </asp:Panel>
                                   
                                   <asp:GridView ID="GvExportTxt" ClientIDMode="Static" runat="server" AutoGenerateColumns="false" DataKeyNames="Nro_Pedido_Interno,IdPedidoExterno" OnRowDataBound="GvExportTxt_RowDataBound">
                          <Columns>
                            <asp:BoundField DataField="Nro_Pedido_Interno" HeaderText="Nro_Pedido_Interno" />
                            <asp:BoundField DataField="COD_VENDEDOR" HeaderText="COD_VENDEDOR" />
                            <asp:BoundField DataField="COD_GRUPO" HeaderText="COD_GRUPO" />
                            <asp:BoundField DataField="COD_CLIENTE" HeaderText="COD_CLIENTE" />
                            <asp:BoundField DataField="COD_DISTRIBUIDOR" HeaderText="COD_DISTRIBUIDOR" />
                            <asp:BoundField DataField="COD_COND_VTA" HeaderText="COD_COND_VTA" />
                            <asp:BoundField DataField="PEDIDO_TOTAL_soles" HeaderText="PEDIDO_TOTAL_soles" />
                            <asp:BoundField DataField="Fec_Reg_Pedido" HeaderText="Fec_Reg_Pedido" />
                            <asp:BoundField DataField="em" HeaderText="em" />
                            <asp:BoundField DataField="Latitud" HeaderText="Latitud" />
                            <asp:BoundField DataField="Longitud" HeaderText="Longitud" />
                            <asp:BoundField DataField="Tipo_Pedido" HeaderText="Tipo_Pedido" />                              
                         </Columns>
                                   </asp:GridView>
                                   <asp:GridView ID="GvDetalleExport" runat="server"></asp:GridView>
                                   <asp:GridView ID="GV_IdPedidos" runat="server"></asp:GridView>
                               </div>
                           </div>
                    </div>
                </div>

                    
               <%-- </div>--%>
            </div>
            </div>
            </li>
            </ul>
            </div>
            </div>         
            </div>  

    <div class="modal fade bd-example-modal-lg" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Posicion Pedido</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>  
      <div class="modal-body" style="   padding-right: 0px;   padding-left: 0px;   padding-top: 0px;   padding-bottom: 0px;">
        
          <div style="  background: #ffffff00;" id="no_gps">
              <center>
<img src="iconos/no_map.jpg"  style="-webkit-box-shadow: 10px 21px 48px 57px rgba(230,230,230,1);
-moz-box-shadow: 10px 21px 48px 57px rgba(230,230,230,1);
    box-shadow: -25px 21px 49px 20px rgba(230,230,230,1);"/>
                  <h2 style="     
    border-radius: 10px;
    margin: 0px auto 10px;
    color: #333;
    text-align: center;
    font-size: 23px;
    text-transform: uppercase;
    font-weight: bold;   
   
    text-shadow: 5px 0px 8px #8e8e8ee">No se encontro ubicacion GPS</h2>
              </center>
     
               </div>
      <div id="map" style="height: 420px; margin: 0.6em; position: relative;text-align:center; overflow: hidden;">
                            </div>    

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
      </div>
    </div>
  </div>
</div>
     <div class="modal fade bd-example-modal-lg" id="myModal3" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel2">Detalle Pedido</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>  
      <div class="modal-body" style="   padding-right: 0px;   padding-left: 0px;   padding-top: 0px;   padding-bottom: 0px;">
            <asp:UpdatePanel ID="updatePanel2" runat="server" UpdateMode="Conditional" 
                ChildrenAsTriggers="true">
   <ContentTemplate>
         <asp:GridView ID="GvDetalle" ShowFooter="true" class="table table-bordered" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
      <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" />
          
                            <asp:BoundField DataField="NombrePro" HeaderText="Nombre" />
          
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="SubTotal" HeaderText="SubTotal"  />


                        </Columns>
               <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
       <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />

                    </asp:GridView>
       <div style="display:none">
    <asp:Button ID="btnBlock" class="Button" Text="BlockCalls" runat="server"       
                 onclick="Button1_Click" Enabled="True" Width="100px"  />  </div>
   </ContentTemplate>
   <Triggers>
     <asp:AsyncPostBackTrigger ControlID="btnBlock" EventName="Click"/> 
    </Triggers>
</asp:UpdatePanel>
     

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
      </div>
    </div>
  </div>
</div>         
   <asp:HiddenField  runat="server" ID="HndIdPedido" ClientIDMode="Static"/> 
</form>
  
 
     <script type="text/javascript">
         $.noConflict();
         jQuery(document).ready(function ($) {
             $('.buscarDNels').SumoSelect({ search: true, searchText: 'Buscar ....' });
         });
         function soloNumeros(e){
             var key = window.Event ? e.which : e.keyCode
             return (key >= 48 && key <= 57)
         }
         $(document).ready(function () {
           
             $("#<%=GV_Pedido.ClientID%> [id*='popmapa']").click(function () {

                 var tr = $(this).parent().parent();
                 var idOrden = $("td:eq(0)", tr).html();
                 var latitud = $("td:eq(10)", tr).html();
                 var longitud = $("td:eq(11)", tr).html();
                 var mylatop = new google.maps.LatLng(latitud, longitud);
                 var myLatlng = new google.maps.LatLng(latitud, longitud);
                
                 if (latitud == "&nbsp;" || mylatop == "") {
                     document.getElementById('no_gps').style.display = "block";
                     document.getElementById('map').style.display = "none";
                   
                 } else {
                   
                     document.getElementById('no_gps').style.display = "none";
                     document.getElementById('map').style.display = "block";
                     var map = new google.maps.Map(document.getElementById('map'), {
                         zoom: 13,
                         center: mylatop
                     });
                 var contentStringSuc = '<div>'
                 + '<b>Pedido :' + idOrden + '</b></div>';
                 var infowindowSuc = new google.maps.InfoWindow({
                     content: contentStringSuc,
                     maxWidth: 300
                 });
                 var image = 'http://201.234.124.219/webgesthorario/Iconos/ingreso.png';
                 var beachMarker = new google.maps.Marker({
                     position: myLatlng,
                     map: map,
                     icon: 'iconos/ingreso.png',
                     title: 'Pedido',
                     animation: google.maps.Animation.DROP
                 });
                 google.maps.event.addListener(beachMarker, 'click', function () {
                     infowindowSuc.open(map, beachMarker);

                     if (beachMarker.getAnimation() !== null) {
                         beachMarker.setAnimation(null);
                         map.setZoom(18);
                     } else {
                         beachMarker.setAnimation(google.maps.Animation.BOUNCE);
                         map.setZoom(18);
                         map.setCenter(myLatlng);
                     }
                 });
             }
             });

             $("#<%=GV_Pedido.ClientID%> [id*='popdetalle']").click(function () {
                 $('#overlay').fadeIn('fast').delay(800).fadeOut('fast');

                 var tr = $(this).parent().parent();
                 var idOrden = $("td:eq(0)", tr).html();
                 var lat = $("td:eq(8)", tr).html();
                 var lng = $("td:eq(9)", tr).html();                 
                 document.getElementById('<%=HndIdPedido.ClientID%>').value = idOrden;
                 document.getElementById("<%=btnBlock.ClientID %>").click();

          
             });
         });


         //$('.date').datepicker({
         //    uiLibrary: 'bootstrap4',
         //    locale: 'es-es',
         //});

   
       

         $(function () {
                       
             $('#TxtFechaInicio').datepicker({
                 format: 'dd/mm/yyyy',
                 autoclose: true,
                 //startDate: "today",
                 //minViewMode: 1,
                 //todayBtn: 'linked'
                 locale: 'es-es',
             });
             $('#TxtFecFin').datepicker({
                 format: 'dd/mm/yyyy',
                 autoclose: true,
                 //startDate: "today",
                 //minViewMode: 1,
                 //todayBtn: 'linked'
                 locale: 'es-ES',
             });


         });
     </script>
</asp:Content>
