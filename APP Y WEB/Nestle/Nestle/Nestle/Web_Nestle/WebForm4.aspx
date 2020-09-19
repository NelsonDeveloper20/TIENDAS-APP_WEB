<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="WebForm4.aspx.cs" Inherits="Web_Nestle.WebForm4" %>

<!DOCTYPE html>
<html class="no-js h-100" lang="en">
<head runat="server">
    <title>Nestle</title>
     <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <meta name="description" content="A high-quality &amp; free Bootstrap admin dashboard template pack that comes with lots of templates and components.">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

      <%-- end --%>   
         <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css" rel="stylesheet" />  
<%--<link href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css" rel="stylesheet" /> --%> 
<link href="https://cdn.datatables.net/responsive/2.2.3/css/responsive.bootstrap4.min.css" rel="stylesheet" /> 
     <script src="https://code.jquery.com/jquery-3.3.1.js"></script>  
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js|https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/js/bootstrap.min.js"></script>--%>  
 <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>  
 <script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js"></script>  
 <script src="https://cdn.datatables.net/responsive/2.2.3/js/dataTables.responsive.min.js"></script>  
 <script src="https://cdn.datatables.net/responsive/2.2.3/js/responsive.bootstrap4.min.js"></script>  

    <%-- pop --%>
    <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?&key=AIzaSyAbSQU24--3YuuUrdB07Af9yH-QmjW9118&libraries=places"></script> 
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <%-- ingre --%>
     <link href="https://use.fontawesome.com/releases/v5.0.6/css/all.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <%--    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" >--%>    
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet"  data-version="1.1.0" href="styles/shards-dashboards.1.1.0.min.css">
    <link rel="stylesheet" href="styles/extras.1.1.0.min.css">
    <script async defer src="https://buttons.github.io/buttons.js"></script>
  
       <style> .hidden-field
 {
     display:none;
 }
/*abajo nels*/
table.dataTable thead .sorting_asc:before, table.dataTable thead .sorting_desc:after {
    opacity: 1;
}thead .sorting:before, table.dataTable thead .sorting_asc:before, table.dataTable thead .sorting_desc:before, table.dataTable thead .sorting_asc_disabled:before, table.dataTable thead .sorting_desc_disabled:before {
    right: 1em;
    content: "\2191";
}
/*arriba*/
table.dataTable thead .sorting:after, table.dataTable thead .sorting_asc:after, table.dataTable thead .sorting_desc:after, table.dataTable thead .sorting_asc_disabled:after, table.dataTable thead .sorting_desc_disabled:after {
    right: 0.5em;
    content: "\2193";
}


       </style>

    <script type="text/javascript">  
        function handleClick(event) {
            alert('click');
        }

        function showPopupFalta() {
            //alert('holin');

            //jQuery.noConflict();
            var capa = document.getElementById("prueba2");
            //capa.onclick = muestraMensaje;
            capa.click();
        }
        //$(document).ready(function () {
        //    $('#example').DataTable();
        //});
        var nuevoalias = jQuery.noConflict();
        nuevoalias(document).ready(function () {
            $("#GV_Pedido").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                responsive: true
            });

            document.getElementById("GV_Pedido_length").style.display = "none";
            document.getElementById("GV_Pedido_filter").style.display = "none";
        });
        //$(document).ready(function () {  
          
        //});  
      
        jQuery.noConflict();
        (function ($) {
            $(function () {
                // More code using $ as alias to jQuery
                //$('button').click(function () {
                //    $('#modalID').modal('show');
                //});
                //$("#myModal3").modal();
            });
        })(jQuery);
       
      
    </script>  
    <style>  
        .btnMargin {  
            margin-bottom: 10px !important;  
        }  
    </style>  
</head>
<body  class="h-100">
   <form id="form1" runat="server">
        
    
        <asp:HiddenField  runat="server" ID="HndIdPedido" ClientIDMode="Static"/>
<asp:ScriptManager ID="ScriptManager" runat="server" />  
         <div class="container-fluid">
        <div class="row">
               <!-- Main Sidebar -->
        <aside class="main-sidebar col-12 col-md-3 col-lg-2 px-0">
          <div class="main-navbar">
            <nav class="navbar align-items-stretch navbar-light bg-white flex-md-nowrap border-bottom p-0">
              <a class="navbar-brand w-100 mr-0" href="#" style="line-height: 25px;">
                <div class="d-table m-auto">
                  <img id="main-logo" class="d-inline-block align-top mr-1" style="max-width: 33%;" src="iconos/carrito_nst.jpg" alt="Tiendas Delcorp">
                  <span class="d-none d-md-inline ml-1">Nestle</span>
                </div>
              </a>
              <a class="toggle-sidebar d-sm-inline d-md-none d-lg-none">
                <i class="material-icons">&#xE5C4;</i>
              </a>
            </nav>
          </div>
          <form action="#" class="main-sidebar__search w-100 border-right d-sm-flex d-md-none d-lg-none">
             </form>
          <div class="nav-wrapper">
              

            <ul class="nav flex-column">
                
           
                    <% string strGrupo = "";%>                    <% string strGrupoSig = "";%>                    <%bool entra = true;%>                    <% int x = 0; %>                    <% for (x = 0; x <= dt.Rows.Count - 1; x++)  { %>                    <%strGrupo = dt.Rows[x]["Grupo"].ToString();%>                    <% if (entra == true){%>
                    <li class="nav-item dropdown">
                    <a href="#" class="nav-link dropdown-toggle text-nowrap px-3" data-toggle="dropdown" role="button"   aria-haspopup="true" aria-expanded="false">
                           <i class="material-icons">vertical_split</i>
                       <span class="d-none d-md-inline-block" style="display: contents !important;"><% Response.Write(dt.Rows[x]["Grupo"].ToString());  %></span>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-small">
                        <%  entra = false;  } %>
                       <a class="dropdown-item" href=" <% Response.Write(dt.Rows[x]["Ruta"].ToString()); %>">
                       <i class="material-icons">vertical_split</i> <% Response.Write(dt.Rows[x]["Nombre"].ToString());  %>
                       </a>
                       

                    <% if (x + 1 <= dt.Rows.Count - 1) {%>                    <%strGrupoSig = dt.Rows[x + 1]["Grupo"].ToString();%>                    <%  if (strGrupo != strGrupoSig)     {%>
                    </ul>
                    </li>
                        <% entra = true;} %>                    <% }else {strGrupoSig = "";     }}  
                        %> 
             
               
            </ul>
               <ul class="nav flex-column">
                
               <li class="nav-item">
                <a class="nav-link " href="FrmMiCuenta.aspx">
                  <i class="material-icons">person</i>
                  <span>Mi cuenta </span>
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link " href="Login.aspx">
                  <i class="material-icons">error</i>
                  <span>Cerrar Sesión </span>
                </a>
              </li>
                   </ul>
          </div>
        </aside>
        <!-- End Main Sidebar -->
               <main class="main-content col-lg-10 col-md-9 col-sm-12 p-0 offset-lg-2 offset-md-3">
              <div class="main-navbar sticky-top bg-white">
                 <!-- Main Navbar   MENU CABECERA-->
            <nav class="navbar align-items-stretch navbar-light flex-md-nowrap p-0">
              <form action="#" class="main-navbar__search w-100 d-none d-md-flex d-lg-flex">
                  <%-- <div class="input-group input-group-seamless ml-3">
                  <div class="input-group-prepend">
                    <div class="input-group-text">
                      <i class="fas fa-search"></i>
                    </div>
                  </div>
                  <input class="navbar-search form-control" type="text" placeholder="Search for something..." aria-label="Search"> </div>--%>
              </form>
              <ul class="navbar-nav border-left flex-row ">
                <li class="nav-item border-right dropdown notifications">
                  <a class="nav-link nav-link-icon text-center" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <div class="nav-link-icon__wrapper">
                      <i class="material-icons">&#xE7F4;</i>
                      <span class="badge badge-pill badge-danger">2</span>
                    </div>
                  </a>
                  <div class="dropdown-menu dropdown-menu-small" aria-labelledby="dropdownMenuLink">
                    <a class="dropdown-item" href="#">
                      <div class="notification__icon-wrapper">
                        <div class="notification__icon">
                          <i class="material-icons">&#xE6E1;</i>
                        </div>
                      </div>
                      <div class="notification__content">
                        <span class="notification__category">Analytics</span>
                        <p>Your website’s active users count increased by
                          <span class="text-success text-semibold">28%</span> in the last week. Great job!</p>
                      </div>
                    </a>
                    <a class="dropdown-item" href="#">
                      <div class="notification__icon-wrapper">
                        <div class="notification__icon">
                          <i class="material-icons">&#xE8D1;</i>
                        </div>
                      </div>
                      <div class="notification__content">
                        <span class="notification__category">Sales</span>
                        <p>Last week your store’s sales count decreased by
                          <span class="text-danger text-semibold">5.52%</span>. It could have been worse!</p>
                      </div>
                    </a>
                    <a class="dropdown-item notification__all text-center" href="#"> View all Notifications </a>
                  </div>
                </li>
                <li class="nav-item dropdown">
                  <a class="nav-link dropdown-toggle text-nowrap px-3" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                    <img class="user-avatar rounded-circle mr-2" src="https://login.delcorpxpress.com/delcorp-xpress/assets/logoMobile.png" alt="User Avatar">
                    <span class="d-none d-md-inline-block">
                        <asp:Label ID="LblNombre" runat="server" ></asp:Label>
                    </span>
                  </a>
                <div class="dropdown-menu dropdown-menu-small">
                    <a class="dropdown-item" href="FrmMiCuenta.aspx">
                      <i class="material-icons">&#xE7FD;</i> Mi Cuenta</a>
                    <a class="dropdown-item" href="">
                      <i class="material-icons">vertical_split</i> Blog Posts</a>
                    <a class="dropdown-item" href="">
                      <i class="material-icons">note_add</i> Add New Post</a>
                    <div class="dropdown-divider"></div>
                    <a class="dropdown-item text-danger" href="Login.aspx">
                      <i class="material-icons text-danger">&#xE879;</i> Cerrar sesión </a>
                  </div>
                </li>
              </ul>
              <nav class="nav">
                <a href="#" class="nav-link nav-link-icon toggle-sidebar d-md-inline d-lg-none text-center border-left" data-toggle="collapse" data-target=".header-navbar" aria-expanded="false" aria-controls="header-navbar">
                  <i class="material-icons">&#xE5D2;</i>
                </a>
              </nav>
            </nav>
                  </div>
               <div class="main-content-container container-fluid px-4">

    
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
                <div class="col-md-12">	
                     <div class="form-row">  

                    <div class="form-group col-md-2">
                <label>Fecha Inicio</label>
                <div class="input-group date" data-provide="datepicker">
                <input type="text" class="form-control" runat="server" id="TxtFechaInicio" autocomplete="off">
                <div class="input-group-addon">
                <span class="glyphicon glyphicon-th"></span>
                </div>
                </div>
                </div>
                 <div class="form-group col-md-2">
                <label>Fecha Fin</label>
              <div class="input-group date" data-provide="datepicker">
                <input type="text" class="form-control" runat="server" id="TxtFecFin" autocomplete="off">
                <div class="input-group-addon">
                <span class="glyphicon glyphicon-th"></span>
                </div>
                </div>
                </div>                       
                <div class="form-group col-md-2" style="    margin-top: 7px;">
                      <br style="clear:both"/>
                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success" runat="server" OnClick="LinkButton1_Click"  ><i class="fa fa-search"></i>Buscar</asp:LinkButton>
                </div>
                <div class="form-group col-md-2" style="    margin-top: 7px;">
                      <br style="clear:both"/>
                <asp:LinkButton ID="BtnExportar" CssClass="btn btn-primary" runat="server" OnClick="BtnExportar_Click1"><i class="fa fa-file-excel-o" aria-hidden="true"></i>Exportar</asp:LinkButton>
                </div>
                     <%--<asp:Button ID="btnExportToWord" CssClass="btnMargin btn btn-outline-primary rounded-0" runat="server" Text="ExportToWord" OnClick="btnExportToWord_Click" />--%>                  <%--  <asp:Button ID="btnExportToExcel" CssClass="btnMargin btn btn-outline-primary rounded-0" runat="server" Text="ExportToExcel" OnClick="btnExportToExcel_Click" />  
                    <asp:Button ID="btnExportToPDF" CssClass="btnMargin btn btn-outline-primary rounded-0" runat="server" Text="ExportToPDF" OnClick="btnExportToPDF_Click" />  --%>
                  <div class="col-md-12">
                           <asp:GridView ID="GV_Pedido" CssClass="table table-bordered" Width="100%"
                        AutoGenerateColumns="false" runat="server"   ForeColor="#333333" OnRowCommand="GV_Pedido_RowCommand">
                         <Columns>
                              <asp:BoundField DataField="IdPedido" HeaderText="IdPedido" />
                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="CodicionVenta" HeaderText="CodicionVenta" />
                            <asp:BoundField DataField="TipoUsuario" HeaderText="TipoUsuario" />
                            <asp:BoundField DataField="UsuarioVenta" HeaderText="UsuarioVenta" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="TotalPagar" HeaderText="TotalPagar" />
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
                        <img src="http://quieromipaginaweb.co/wp-content/uploads/2019/02/mapa.png" width="33px" />
                        </a>
                        </ItemTemplate>

                        <HeaderStyle CssClass="stilo-header"></HeaderStyle>
                        </asp:TemplateField>
                    <asp:BoundField DataField="Latitud" HeaderText="" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
                    <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
                    </asp:BoundField>
                      <asp:BoundField DataField="Longitud" HeaderText="" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
                    <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
                    </asp:BoundField>
                             </Columns>
                          <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px" />                   
                    </asp:GridView> </div>
                          
                     <div style="display:none">
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

               </div>
            </div>
               </div>
         </main>
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
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="SubTotal" HeaderText="SubTotal"  ItemStyle-Width="60" DataFormatString="{0:N2}"
        ItemStyle-HorizontalAlign="Right" />

                        </Columns>
               <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
       <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />

                    </asp:GridView>
       <div style="display:none">
            <asp:LinkButton ID="pinchame" runat="server" OnClick="Btn_hABER_Click">LinkButton</asp:LinkButton>
 </div>
   </ContentTemplate>
   <Triggers>
     <asp:AsyncPostBackTrigger ControlID="pinchame" EventName="Click"/> 
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
       
  <div style="display:none">

        <asp:Button ID="Btn_hABER" runat="server" Text="Button" ClientIDMode="Static" OnClick="Btn_hABER_Click" />
      <input id="prueba2" type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal3" value="pinchame2" >
      </div>
           <script type="text/javascript">
               function muestraMensaje() {
                   alert('REGLAS DE LA PEÑA');
               }
               $(document).ready(function () {

             $("#<%=GV_Pedido.ClientID%> [id*='popmapa']").click(function () {

                 var tr = $(this).parent().parent();
                 var idOrden = $("td:eq(0)", tr).html();
                 var latitud = $("td:eq(10)", tr).html();
                 var longitud = $("td:eq(11)", tr).html();
                 var mylatop = new google.maps.LatLng(latitud, longitud);
                 var myLatlng = new google.maps.LatLng(latitud, longitud);
                
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
                     icon: image,
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
                
             });

             $("#<%=GV_Pedido.ClientID%> [id*='popdetalle']").click(function () {
               
                 var tr = $(this).parent().parent();
                 var idOrden = $("td:eq(0)", tr).html();
                 var lat = $("td:eq(8)", tr).html();
                 var lng = $("td:eq(9)", tr).html();                 
                 document.getElementById('<%=HndIdPedido.ClientID%>').value = idOrden;
                 //document.getElementById("HndIdPedido").value = idOrden;
                 var valorr = document.getElementById("HndIdPedido").value;
                 //alert(valorr);
               
                 var hiddenControl = '<%= HndIdPedido.ClientID %>';
                 document.getElementById(hiddenControl).value = idOrden;

                 var capa = document.getElementById("pinchame");
                 //capa.onclick = muestraMensaje;
                 capa.click();             
                
                 
             });
         });


         //$('.date').datepicker({
         //    uiLibrary: 'bootstrap4',
         //    locale: 'es-es',
         //});

        

    </script>
    </form>
    
  
       <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.1/Chart.min.js"></script>
    <script src="https://unpkg.com/shards-ui@latest/dist/js/shards.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Sharrre/2.0.1/jquery.sharrre.min.js"></script>
    <script src="scripts/extras.1.1.0.min.js"></script>
    <script src="scripts/shards-dashboards.1.1.0.min.js"></script>
    <script src="scripts/app/app-blog-overview.1.1.0.js"></script>
</body>
</html>
