<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FLControldePedido.aspx.cs" Inherits="FLHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" Visible=" false">
    <head>
        <style type="text/css">
 
            body {
                background-color: white;
            }

            .GridPager a,
            .GridPager span {
                display: inline-block;
                padding: 0px 9px;
                margin-right: 4px;
                border-radius: 3px;
                border: solid 1px #c0c0c0;
                background: #e9e9e9;
                box-shadow: inset 0px 1px 0px rgba(255,255,255, .8), 0px 1px 3px rgba(0,0,0, .1);
                font-size: .875em;
                font-weight: bold;
                text-decoration: none;
                color: #717171;
                text-shadow: 0px 1px 0px rgba(255,255,255, 1);
            }

            .GridPager a {
                background-color: #f5f5f5;
                color: #969696;
                border: 1px solid #969696;
            }

            .GridPager span {
                background: #616161;
                box-shadow: inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8);
                color: #f0f0f0;
                text-shadow: 0px 0px 3px rgba(0,0,0, .5);
                border: 1px solid #3AC0F2;
            }

            .hidden-field {
                display: none;
            }

            .stilo-header {
                padding-left: 2px;
                padding-right: 2px;
                text-align: center;
                font-size: 9px;
            }

            .stilo-item {
                padding-left: 2px;
                padding-right: 2px;
                padding-top: 2px;
                padding-bottom: 2px;
                font-size: 9px;
            }

            .stilo-tipServicio {
                padding-left: 0px;
                padding-right: 0px;
                padding-top: 0px;
                padding-bottom: 0px;
                font-size: 8px;
            }

            .btnIngresar {
                float: right;
            }

            #loginbox {
                margin-top: 30px;
            }

                #loginbox > div:first-child {
                    padding-bottom: 10px;
                }

            .iconmelon {
                display: block;
                margin: auto;
            }

            #form > div {
                margin-bottom: 25px;
            }

                #form > div:last-child {
                    margin-top: 10px;
                    margin-bottom: 10px;
                }

            .panel {
                background-color: transparent;
            }

            .panel-body {
                padding-top: 30px;
                background-color: rgba(2555,255,255,.3);
            }

            #particles {
                width: 100%;
                height: 100%;
                overflow: hidden;
                top: 0;
                bottom: 0;
                left: 0;
                right: 0;
                position: absolute;
                z-index: -2;
            }

            .iconmelon,
            .im {
                position: relative;
                width: 230px;
                height: 150px;
                display: block;
                fill: #525151;
            }

                .iconmelon:after,
                .im:after {
                    content: '';
                    position: absolute;
                    top: 0;
                    left: 0;
                    width: 100%;
                    height: 100%;
                }

            .loader {
                position: fixed;
                left: 0px;
                top: 0px;
                width: 100%;
                height: 100%;
                z-index: 9999;
                background: url('http://superstorefinder.net/support/wp-content/uploads/2018/01/blue_loading.gif') 50% 50% no-repeat rgb(249,249,249);
                opacity: .8;
        </style>
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?&key=AIzaSyAbSQU24--3YuuUrdB07Af9yH-QmjW9118&libraries=places"></script> 
        
        <%--<script src="images/jquery.tablePagination.0.1.js"></script>--%>


        <script type="text/javascript">
            $(document).ready(function () {
                $('.TituloContenedor').text('CONTROL DE PEDIDOS');
              
            })
            window.alert = function () { };
            var defaultCSS = document.getElementById('bootstrap-css');
            function changeCSS(css) {
                if (css) $('head > link').filter(':first').replaceWith('<link rel="stylesheet" href="' + css + '" type="text/css" />');
                else $('head > link').filter(':first').replaceWith(defaultCSS);
            }
//            $(document).ready(
//function () {
//    $('table').tablePagination({});
//});
        //MOSTRAR POPUP
        function showPopup() {
            $('#ModalHistorial').modal('show');
        }
        $(function () {
            $(".show").click(function () {
                showPopup();
            });
        });

     
        
        </script>
    </head>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <form id="form1" runat="server">

<div class="col-sm-12" style="   
padding-left: 1px;
padding-right: 1px;
">

            <div class="form-group col-sm-2" style="   
    padding-left: 1px;
    padding-right: 1px;

">
                <label>Estado</label>
                <asp:DropDownList ID="ddlTipoResultado" style="font-size: 12px" class="form-control" runat="server" AutoPostBack="false" Width="100%" Height="34px">
                </asp:DropDownList>
            </div>

            <div class="form-group col-sm-2" style="   
    padding-left: 1px;
    padding-right:1px;

">
                <label>Fec. Inicial</label>
                <div class="input-group date form_date" id="datetime" runat="server" data-date-format="dd/mm/yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                    <input type="text" class="form-control" id="datavalue" runat="server" readonly  style="font-size:12px"/>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>


            </div>

            <div class="form-group col-sm-2" style="   
    padding-left: 1px;
    padding-right: 1px;

">
                <label>Fec. Final</label>
                <div class="input-group date form_date " data-date="" data-date-format="dd/mm/yyyy"  data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                    <input type="text" class="form-control" id="datavalue2" runat="server" style="font-size:12px" readonly />
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>

            </div>

            <div class="form-group col-sm-2" style="   
    padding-left: 1px;
    padding-right: 1px;

">
                <label>Conductor</label>
                <asp:DropDownList ID="ddlMotorizado" class="form-control" style="font-size:12px" runat="server" AutoPostBack="false" Width="100%" Height="34px">
                </asp:DropDownList>
            </div>
            <div class="form-group col-sm-2" style="   
    padding-left: 1px;
    padding-right: 1px;

">
                <label>Sucursal</label>
                <asp:DropDownList ID="ddlSucursal" class="form-control" style="font-size:12px"  runat="server" AutoPostBack="false" Width="100%" Height="34px">
                </asp:DropDownList>
            </div>
            <div class="form-group col-sm-2" style="   
    padding-left: 1px;
    padding-right: 1px;

">
                <label>N° Orden</label>
                <input type="text" name="" autocomplete="off" style="font-size:12px" class="form-control" runat="server" id="txtOrden" value="">
            </div>
            <div class="form-group col-sm-6" style="   

    padding-left: 1px;
    padding-right: 1px;
    padding-bottom: 0px;
    border-top-width: 10px;
    margin-top: 10px;
    margin-bottom: 0px;



">
                <asp:Button runat="server" ID="btnRegistro" OnClick="btnRegistro_Click" CssClass="btn btn-primary" Width="100%" Text="Mostrar Reporte / Actualizar Reporte"></asp:Button>
               
            </div>     <div class="form-group col-sm-6" style="   
  
    padding-left: 1px;
    padding-right: 1px;
    padding-bottom: 0px;
    border-top-width: 10px;
    margin-top: 10px;
    margin-bottom: 0px;


">
             <asp:Button runat="server" ID="BtnExcel" CssClass="btn btn-success" Width="100%" Text="Exportar Excel" OnClick="BtnExcel_Click"></asp:Button>
                </div>   

   
        </div>

        <div class="col-sm-12" style="padding-left: 0px; padding-right: 0px;">

            <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" onprerender="gvMyLista_PreRender" OnDataBound="GridView1_DataBound" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table-bordered bs-table" runat="server" AutoGenerateColumns="false" CellPadding="1" PageSize="50" AllowPaging="True">
                <AlternatingRowStyle Wrap="True" />
                <Columns>
                    <asp:BoundField DataField="idOrden" HeaderText="Orden" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
<HeaderStyle CssClass="hidden-field"></HeaderStyle>

<ItemStyle CssClass="hidden-field"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="idRuta" HeaderText="Ruta" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >

<HeaderStyle CssClass="hidden-field"></HeaderStyle>

<ItemStyle CssClass="hidden-field"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="idOrden" HeaderText="Orden" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >                   
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Resultado" HeaderText="Resultado" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Motorizado" HeaderText="Motorizado" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="celular" HeaderText="celular" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="cantidadOrden" HeaderText="cant" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="FecPedido" HeaderText="Creacion" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField DataField="FecRecepcion" HeaderText="Recepcion" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="FecPreparacion" HeaderText="Preparacion" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="FecInicio" HeaderText="Inicio Ruta" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="FecEntrega" HeaderText="Entrega" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="TipoServicio" HeaderText="Tipo Serv." ItemStyle-CssClass="stilo-tipServicio" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-tipServicio"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>

            <%--        <asp:BoundField DataField="tipoTransporte" HeaderText="Tipo de Transporte" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>
<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>--%>


                    <asp:TemplateField ShowHeader="False" HeaderText="Tipo de Transporte"  ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
                                <ItemTemplate> 
                                        <asp:LinkButton ID="BtTip" runat="server"  CommandArgument="<%# ((GridViewRow)Container).RowIndex  %>"
                                        CommandName="tipoTrans" ><%# Eval("tipoTransporte") %>
                                        </asp:LinkButton>
                                </ItemTemplate>

<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                            </asp:TemplateField> 


                       <asp:TemplateField ShowHeader="False" HeaderText="Foto" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header">
                        <ItemTemplate>
                            <a id="popfoto" data-toggle="modal" data-target="#myModal">
                                <img src="imagenes/cam.png" />
                            </a>
                        </ItemTemplate>

<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="EntrePedidos" HeaderText="Tiempo entre Servicio" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="tiempoEntrega" HeaderText="Tiempo Entrega" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="MontoTotal" HeaderText="MontoTotal" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Motivo" HeaderText="Motivo" ItemStyle-CssClass="stilo-item" HeaderStyle-CssClass="stilo-header" >
<HeaderStyle CssClass="stilo-header"></HeaderStyle>

<ItemStyle CssClass="stilo-item"></ItemStyle>
                    </asp:BoundField>
                     <asp:TemplateField ShowHeader="False" HeaderText="Ver Mapa" HeaderStyle-CssClass="stilo-header">
                        <ItemTemplate>
                            <a id="popmapa" data-toggle="modal" data-target="#myModal2">
                                <img src="imagenes/map.png" />
                            </a>
                        </ItemTemplate>

<HeaderStyle CssClass="stilo-header"></HeaderStyle>
                    </asp:TemplateField>

                   
                   
                </Columns>
                <HeaderStyle BackColor="#0066cc" Font-Bold="true" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                <RowStyle ForeColor="Black" Font-Size="9px" HorizontalAlign="Center" VerticalAlign="Middle" />

            </asp:GridView>
            <div style="display:none">
            <asp:gridview id="GcExportar" runat="server"> <HeaderStyle BackColor="#0066cc" Font-Bold="true" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                <RowStyle ForeColor="Black" Font-Size="9px" HorizontalAlign="Center" VerticalAlign="Middle" />
</asp:gridview></div>
            <!-------------------------------------------------------------------->

            <div class="col-sm-2">
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog" style="width: 400px;">
                        <div class="modal-content" style="width: 400px;">

                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h3 class="modal-title" id="myModalLabel">Fotos</h3>

                            </div>
                            <div class="modal-body" style="padding-left: 0px; padding-bottom: 0px; padding-right: 0px; padding-top: 0px;">
                                <section class="panel">
                                    <div id="c-slide" class="carousel slide auto panel-body">
                                        <ol id="bolas" class="carousel-indicators out">
                                        </ol>
                                        <div id="cuerpo" class="carousel-inner">
                                        </div>
                                        <div id="p">
                                            <a data-slide="prev" href="#c-slide" class="left carousel-control">
                                                <i class="arrow_carrot-left_alt2"></i>
                                            </a>
                                            <a data-slide="next" href="#c-slide" class="right carousel-control">
                                                <i class="arrow_carrot-right_alt2"></i>
                                            </a>
                                        </div>
                                    </div>
                                </section>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <!---------------------------------------------------------------->
            <!-------------------------------------------------------------------->
            <div class="col-sm-2">
                <div class="modal fade" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog" style="width: 700px;">
                        <div class="modal-content" style="width: 700px;">

                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h3 class="modal-title" id="myModalLabel">Posicion de Entrega del Servicio</h3>

                            </div>
                            <div class="modal-body" style="padding-left: 0px; padding-bottom: 0px; padding-right: 0px; padding-top: 0px; width: 428px; height: 420px;">
                                <div id="map" style="height: 420px; width: 680px; margin: 0.6em; position: relative;text-align:center; overflow: hidden;">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>


              <div class="col-sm-2">    
                            <div class="modal fade"  id="ModalHistorial" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
                                <div class="modal-dialog" style="width: 700px;">
                                    <div class="modal-content" style=" width: 700px;">
                                         
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h3 class="modal-title" id="myModalLabel">Movimientos Tipo Transporte</h3>
                                        </div>
                                        <div class="modal-body"style="padding-left: 0px;padding-bottom: 0px;padding-right: 0px;padding-top: 0px;height: 100%;"> 
                                      <center>

                                          <asp:GridView ID="GVDETALLE"  
                                              CssClass="table table-bordered table-hover"
                                               runat="server">
                                              
                <HeaderStyle BackColor="#0066cc" Font-Size="11px" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                <RowStyle ForeColor="Black" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" />

                                          </asp:GridView>
                               </center>               
                                        </div> 
                                        <div class="modal-footer">
                                          
                                        </div>
                                    </div> 
                                </div> 
                            </div>
                        </div>          
            <!---------------------------------------------------------------->
               <div class="col-sm-2">    
                            <div class="modal fade"  id="ModalDetalle" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
                                <div class="modal-dialog" style="width: 700px;">
                                    <div class="modal-content" style=" width: 700px;">
                                         
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h3 class="modal-title" id="myModalLabel2"> <asp:Label ID="LblTileDetalle" runat="server" Text="Label"></asp:Label> </h3>
                                        </div>
                                        <div class="modal-body"style="padding-left: 0px;padding-bottom: 0px;padding-right: 0px;padding-top: 0px;height: 100%;"> 
                                      <center>

                                          <asp:GridView ID="GridviewDetalle"  
                                              CssClass="table table-bordered table-hover"
                                               runat="server">
                                              
                <HeaderStyle BackColor="#0066cc" Font-Size="11px" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                <RowStyle ForeColor="Black" Font-Size="11px" HorizontalAlign="Center" VerticalAlign="Middle" />

                                          </asp:GridView>
                               </center>               
                                        </div> 
                                        <div class="modal-footer">
                                          
                                        </div>
                                    </div> 
                                </div> 
                            </div>
                        </div>  

        </div>


                              <%--<asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>--%>
  
 
    </form>




    <script type="text/javascript">

        $(document).ready(function () {

            





            $("#<%=GridView1.ClientID%> [id*='popmapa']").click(function () {

                 var protocol = location.protocol;
                 var slashes = protocol.concat("//");
                 var host = slashes.concat(window.location.hostname);

                 var tr = $(this).parent().parent();
                 var idOrden = $("td:eq(0)", tr).html();
                 var lat = '';
                 var lng = '';
                 $.ajax({
                     type: 'GET',
                     url: host + '/ApiDelcorpInkafarma/api/OrdenMoto?idOrden=' + idOrden,
                     crossDomain: true,
                     dataType: 'xml',
                     error: function (jqXHR, textStatus, errorThrown) {

                         if (jqXHR.status == 0) {
                             alert('Not connect: Verify Network.');

                         } else if (jqXHR.status == 404) {

                             alert('Requested page not found [404]');

                         } else if (jqXHR.status == 500) {

                             alert('Internal Server Error [500].');

                         } else if (textStatus === 'parsererror') {

                             alert('Requested JSON parse failed.');

                         } else if (textStatus === 'timeout') {

                             alert('Time out error.');

                         } else if (textStatus === 'abort') {

                             alert('Ajax request aborted.');

                         } else {
                             alert('Uncaught Error: ' + jqXHR.responseText);
                         }
                     },
                     success: function (data) {

                         $('#map').html('');
                         if ($(data).find('Latitud').text() != '' || $(data).find('Longitud').text() != '') {

                             $(data).find('Coordenada').each(function () {
                                 //  parseFloat()
                                 lat = $(this).find('Latitud').text();
                                 lng = $(this).find('Longitud').text();
                             });

                             var myLatlng = new google.maps.LatLng(lat, lng);
                             var mapOptions = {
                                 zoom: 17,
                                 center: myLatlng,
                                 mapTypeId: google.maps.MapTypeId.ROADMAP
                             }
                             var map = new google.maps.Map(document.getElementById("map"), mapOptions);
                             var marker = new google.maps.Marker({
                                 position: myLatlng,
                                 icon: host + '/farmacias/imagenes/posEntrega.png'
                             });
                             marker.setMap(map);
                         } else {
                             $('#map').append('<img   src="imagenes/nomapa.jpg"   style="height: 100%;align-content:  center;position: unset;">');

                         }
                     }
                 });


             });


             var imagen1 = new Image();
             var imagen2 = new Image();
             var imagen3 = new Image();

             $("#<%=GridView1.ClientID%> [id*='popfoto']").click(function () {

                        var protocol = location.protocol;
                        var slashes = protocol.concat("//");
                        var host = slashes.concat(window.location.hostname);

                        var tr = $(this).parent().parent();
                        var idpedido = $("td:eq(0)", tr).html();

                        var im1 = host + "/ApiDelcorpInkafarma/imagenes/FotosApp/" + idpedido + "_1.jpeg";
                        var im2 = host + "/ApiDelcorpInkafarma/imagenes/FotosApp/" + idpedido + "_2.jpeg";
                        var im3 = host + "/ApiDelcorpInkafarma/imagenes/FotosApp/" + idpedido + "_3.jpeg";

                        imagen1.src = im1;
                        imagen2.src = im2;
                        imagen3.src = im3;

                        var htmlIndice = '';
                        var htmlImagenes = '';
                        $('#bolas').html(htmlIndice);
                        $('#cuerpo').html(htmlImagenes);
                        $('#p').html('');
                        $('#p').append('<a data-slide="prev" href="#c-slide" class="left carousel-control"><i class="arrow_carrot-left_alt2"></i>  </a> <a   data-slide="next" href="#c-slide" class="right carousel-control">  <i class="arrow_carrot-right_alt2"></i> </a>');

                        imagen1.onload = function () {
                            //$("#img1").attr("src", im1);
                            htmlIndice = '<li class="active" data-slide-to="0" data-target="#c-slide"></li>';
                            htmlImagenes = '<div  class="item text-center active"><img src="' + im1 + '"  height ="10px"></div>';
                            $('#bolas').append(htmlIndice);
                            $('#cuerpo').append(htmlImagenes);
                        };
                        imagen1.onerror = function () {
                            //$("#img1").attr("src", "Fotos/nosetomofoto.png");
                            htmlIndice = '<li class="active" data-slide-to="0" data-target="#c-slide"></li>';
                            htmlImagenes = '<div  class="item text-center active"><img   src="imagenes/nosetomofoto.png"   height ="10px"></div>';

                            $('#p').html('');
                            $('#bolas').append(htmlIndice);
                            $('#cuerpo').append(htmlImagenes);
                        };

                        imagen2.onload = function () {
                            htmlIndice = '<li class="" data-slide-to="1" data-target="#c-slide"></li>';
                            htmlImagenes = '<div class="item text-center"><img   src="' + im2 + '"   height ="10px""></div>';
                            $('#bolas').append(htmlIndice);
                            $('#cuerpo').append(htmlImagenes);

                        };

                        imagen3.onload = function () {
                            htmlIndice = '<li class="" data-slide-to="2" data-target="#c-slide"></li>';
                            htmlImagenes = '<div class="item text-center"><img   src="' + im3 + '"   height ="10px"></div>';
                            $('#bolas').append(htmlIndice);
                            $('#cuerpo').append(htmlImagenes);

                        };


                    });

                    $('.TituloContenedor').text('Control de Pedidos');

                    function convertDate(inputFormat) {
                        function pad(s) { return (s < 10) ? '0' + s : s; }
                        var d = new Date(inputFormat);
                        return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/');
                    }


                    $('#btnFoto').click(function () {
                        alert("The paragraph was clicked.");
                    });
                    $("#datetime").find("input").val();
         });

                $('.form_datetime').datetimepicker({
                    //language:  'es',

                    weekStart: 1,
                    todayBtn: 1,
                    autoclose: 1,
                    todayHighlight: 1,
                    startView: 2,
                    forceParse: 0,
                    showMeridian: 1
                });
                $('.form_date').datetimepicker({

                    language: 'es',
                    weekStart: 1,
                    todayBtn: 1,
                    autoclose: 1,
                    todayHighlight: 1,
                    startView: 2,
                    minView: 2,
                    forceParse: 0
                });
                $('.form_time').datetimepicker({

                    language: 'es',
                    weekStart: 1,
                    todayBtn: 1,
                    autoclose: 1,
                    initialDate: '',
                    todayHighlight: 1,
                    startView: 1,
                    minView: 0,
                    maxView: 1,
                    forceParse: 0
                });

    </script>

        
</asp:Content>

