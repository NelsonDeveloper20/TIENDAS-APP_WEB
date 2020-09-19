<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_RptPedidoVenta.aspx.cs" Inherits="Web_Nestle.F_RptPedidoVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <script src="jsFecha/bootstrap-datepicker.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/jquery2_2_4.js">    </script>
    
    <script src="vendor/Multilist/jquery.sumoselect.min.js"></script>
    <link href="vendor/Multilist/sumoselect.css" rel="stylesheet"/>
    <script src="https://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/modules/series-label.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>

    <style>
        .loader {
    position: fixed;
    left: 0px;
    top: 0px;
    width: 100%;
    height: 100%;
    z-index: 9999;
    background: url('https://visitqueanbeyanpalerang.com.au/wp-content/themes/queanbeyan-palerang/images/rolling-ajax-load.gif') 50% 50% no-repeat rgb(249,249,249);
    opacity: .8;
}/*Buscar dropdown list*/
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
    </style>
    <script>

     
        function porcentaje(monto_n,Promedio_tres, TotalSugerido, MontoVenta) {

            
            var monto_Porcent = parseFloat(monto_n);
            var Promedio_tres1 = parseFloat(Promedio_tres);
            var TotalSugerido1 = parseFloat(TotalSugerido);
            var MontoVenta1 = parseFloat(MontoVenta);

            var Promedio_tres2 = (new Intl.NumberFormat("en", { style: "decimal" }).format(Promedio_tres1));
            var TotalSugerido2 = (new Intl.NumberFormat("en", { style: "decimal" }).format(TotalSugerido1));
            var MontoVenta2 = (new Intl.NumberFormat("en", { style: "decimal" }).format(MontoVenta1));
            var monto_Porcent1 = (new Intl.NumberFormat("en", { style: "decimal" }).format(monto_Porcent));
          

            Highcharts.getOptions().colors = Highcharts.map(
                Highcharts.getOptions().colors, function (color) {
                    return {
                        radialGradient: { cx: 0.5, cy: 0.3, r: 0.7 },
                        stops: [
                           [0, color],
                           [1, Highcharts.Color(color).brighten(-0.2).get('rgb')] // darken
                        ]
                    };
                }
             );
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });

           Highcharts.chart('container', {
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Avance Venta de Pedido:  ' + monto_Porcent+' %'
                },
                subtitle: {
                    text: 'Reporte'
                },
                xAxis: {
                    type: 'category',
                    labels: {
                        style: {
                            fontSize: '1.2em'
                        }
                    }
                },
                yAxis: {
                    title: {
                        text: 'Total Porcent Pedido Venta'
                    }
                    //,max: 200

                },
                legend: {
                    enabled: false
                },
                plotOptions: {
                    series: {
                        borderWidth: 0,
                        dataLabels: {
                            enabled: true,
                            format: 'S/. {point.y:,.0f}' //%',
                            
                        },
                        stacking: 'normal'
                    }
           
                },
                tooltip: {
                    headerFormat: '<span style="font-size:13px">{series.name}</span><br>',                    
                    //style: {
                    //    fontSize: '2em'
                    //}        pointFormat: '<span style="font-size:16px;color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b>  total<br/>'
                    pointFormat: '<span style="font-size:16px;color:{point.color}">{point.name}</span>: <b>S/. {point.y:,.0f}</b>  <br/>'
                },
                series: [
                    {
                        name: "Venta",
                        colorByPoint: true,
                        data: [
                            //{
                            //name: "Monto",
                            //y: monto_n1,
                            //},
                            {
                                name: "Promedio Ultimo Pedido",
                                y: Promedio_tres1
                            },
                            {
                                name: "Total Pedido Sugerido",
                                y: TotalSugerido1
                               
                            },
                            {
                                name: "Total Venta" +"",
                                y: MontoVenta1
                            }
                        ], dataLabels: {
                            align: "center",
                            enabled: true,
                            borderColor: "",
                            style: {
                                fontSize: "17px",
                                //fontWeight: 'normal',
                                //fontFamily: "Arial",
                                textShadow: false,
                                fontWeight:600
                            }
                        }
                    }
                    //, {
                    //    name: 'Porcentaje',
                    //    data: [null, null, monto_Porcent]
                    //}
                ],
               
                
            });
           
        }
    </script>
     <script>
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        });
    </script>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="loader"></div>
    <div class="col-lg-12"></div><br style="clear:both"/>
            <div class="row">
              <div class="col-lg-12 mb-6">
                <div class="card card-small mb-12">
                  <div class="card-header border-bottom">
                    <h6 class="m-0">Avance Venta Pedido </h6>
                  </div>
                  <ul class="list-group list-group-flush">
                    <li class="list-group-item p-0 px-3 pt-3">
                      <div class="row">
                        <div class="col-sm-12">
                          <!-- Checkboxes -->
                             <div class="form-row">  
                          <div class="form-group col-md-2">
                <label>Fecha Inicio</label>
                <input type="text" class="form-control" runat="server" placeholder="aa/mm/yyyy" ClientIDMode="Static" id="TxtFechaInicio" autocomplete="off">
                    <div class="input-group-addon">
                    <span class="glyphicon glyphicon-th"></span>
                    </div>
                </div>

                 <div class="form-group col-md-2">
                <label>Fecha Fin</label>
               <input type="text" class="form-control" runat="server"  placeholder="aa/mm/yyyy" ClientIDMode="Static" id="TxtFecFin" autocomplete="off">
                    <div class="input-group-addon">
                    <span class="glyphicon glyphicon-th"></span>
                    </div>
                </div>  
             <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                                  <ContentTemplate>

                        <div class="form-row">  
                
                    <asp:Panel ID="PnlDia" class="form-group col-md-6" runat="server">
                <label>Dia</label>
                    <asp:DropDownList ID="DDDia"  runat="server"  class="form-control" style="width: 100% !important;" AutoPostBack="True" OnSelectedIndexChanged="DDDia_SelectedIndexChanged"  >
                        <asp:ListItem Value="0">Todos</asp:ListItem>
                        <asp:ListItem Value="2">Lunes</asp:ListItem>
                        <asp:ListItem Value="3">Martes</asp:ListItem>
                        <asp:ListItem Value="4">Miercoles</asp:ListItem>
                        <asp:ListItem Value="5">Jueves</asp:ListItem>
                        <asp:ListItem Value="6">Viernes</asp:ListItem>
                        <asp:ListItem Value="7">Sabado</asp:ListItem>
                        <asp:ListItem Value="1">Domingo</asp:ListItem>
                    </asp:DropDownList>  
                   </asp:Panel>
                            <asp:Panel ID="pnlFiltro" CssClass="form-group col-md-6" runat="server">
                                
                <label>Tipo Filtro Dia</label>
                    <asp:DropDownList ID="DDTipoFiltro"  runat="server"  class="form-control" style="width: 100% !important;"  >
                     </asp:DropDownList>  
                            </asp:Panel> </div>


                 </ContentTemplate>
             </asp:UpdatePanel>
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                                     <ContentTemplate>
    <div class="form-row">  
                     <div class="form-group col-md-6" >
                    <label style="float: inherit;"> Vendedor</label><br style="clear:both"/>
                    <asp:DropDownList ID="DDUsuario"  runat="server"  class="form-control buscarDNels" style="width: 100% !important;" AutoPostBack="True" OnSelectedIndexChanged="DDUsuario_SelectedIndexChanged"  >
                    </asp:DropDownList>                
                    </div>   
                    <div class="form-group col-md-6" >
                    <label style="float: inherit;"> Bodega</label><br style="clear:both"/>
                    <asp:DropDownList ID="DDBodega"   runat="server"  class="form-control buscarDNels" style="width: 100% !important;"  >
                    </asp:DropDownList>                
                    </div>   </div>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>     

                              </div> 

                                      
                <div class="form-group col-md-2" >
                      <%--<br style="clear:both"/>--%>
                <asp:LinkButton ID="BntBuscar" CssClass="btn btn-success" runat="server" Width="100%" OnClick="BntBuscar_Click"  ><i class="fa fa-search"></i>Buscar</asp:LinkButton>
                </div> 
                         
                            <div class="col-lg-12"></div><br style="clear:both"/>
<div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
                        </div>

                      </div>
                    </li>

                  </ul>
                </div>
              </div>
         
            </div>
        
    <div class="col-lg-12"></div><br style="clear:both"/>
    <div class="col-lg-12"></div><br style="clear:both"/>
        
    </form>
    <script>
        //jQuery(document).ready(function ($) {
            
        //});
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('.buscarDNels').SumoSelect({ search: true, searchText: 'Buscar ....' });
            
            //$(<%=DDUsuario.ClientID%>).SumoSelect({ search: true, searchText: 'Buscar ....' });
        });
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
