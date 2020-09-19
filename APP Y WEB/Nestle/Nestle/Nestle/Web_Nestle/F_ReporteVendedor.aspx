<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_ReporteVendedor.aspx.cs" Inherits="Web_Nestle.F_ReporteVendedor" %>
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
     
    <script src="vendor/Multilist/jquery.sumoselect.min.js"></script>
    <link href="vendor/Multilist/sumoselect.css" rel="stylesheet" />
<style> 
   /*pie chart nelson*/
   .pieChart
       {
           position: relative;
           font-size: 80px;
           width: 1em;
           height: 1em;
           display: block;
       }        
       .percent
       {
           position: absolute;
           top: 1.05em;
           left: 5px;
           width: 3.33em;
           font-size: 0.3em;
           text-align: center;
       }
        
       .slice
       {
           position: absolute;
           width: 1em;
           height: 1em;
           clip: rect(0px,1em,1em,0.5em);
       }
       .slice.gt50
       {
           clip: rect(auto, auto, auto, auto);
       }
       .slice > .pie
       {
           border: 0.1em solid #66EE66;
           position: absolute;
           width: 0.8em; /* 1 - (2 * border width) */
           height: 0.8em; /* 1 - (2 * border width) */
           clip: rect(0em,0.5em,1em,0em);
           -moz-border-radius: 0.5em;
           -webkit-border-radius: 0.5em;
           border-radius: 0.5em;
       }
       .pieBack
       {
           border: 0.1em solid #EEEEEE;
           position: absolute;
           width: 0.8em; 
           height: 0.8em; 
           -moz-border-radius: 0.5em;
           -webkit-border-radius: 0.5em;
           border-radius: 0.5em;
       }
       .slice > .pie.fill
       {
           -moz-transform: rotate(180deg) !important;
           -webkit-transform: rotate(180deg) !important;
           -o-transform: rotate(180deg) !important;
           transform: rotate(180deg) !important;
       }      
/*end*/
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
/*end*/ .hidden-field
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
}</style>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>--%>
    <script>
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        });
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#GvReporte .pieChart').each(function (index, value) {
                var percent = $(this).text();
                var deg = 360 / 100 * percent;
                $(this).html('<div class="percent">' + Math.round(percent) + '%' + '</div><div class="pieBack"></div><div ' + (percent > 50 ? ' class="slice gt50"' : 'class="slice"') + '><div class="pie"></div>' + (percent > 50 ? '<div class="pie fill"></div>' : '') + '</div>');
                $(this).find('.slice .pie').css({
                    '-moz-transform': 'rotate(' + deg + 'deg)',
                    '-webkit-transform': 'rotate(' + deg + 'deg)',
                    '-o-transform': 'rotate(' + deg + 'deg)',
                    'transform': 'rotate(' + deg + 'deg)'
                });
                //Nelson :)
            });
        });
    </script>
<form id="form1" runat="server"><div class="loader"></div>
<asp:ScriptManager ID="ScriptManager" runat="server" />         
            <div class="row">
            <div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 5px;margin-top: 10px;">
            <div class="card card-small mb-4">
            <div class="card-header border-bottom">
            <h6 class="m-0">Reporte Venta</h6>    
            </div>
            <ul class="list-group list-group-flush">
            <li class="list-group-item p-3">
            <div class="row">
            <div class="col">
                <div class="col-md-12">	
                     <div class="form-row">  

                <div class="form-group col-md-2">
                <label>Fecha</label>
                <input type="text" class="form-control" runat="server" placeholder="aa/mm/yyyy" ClientIDMode="Static" id="TxtFechaInicio" autocomplete="off">
                    <div class="input-group-addon">
                    <span class="glyphicon glyphicon-th"></span>
                    </div>
                </div>
                     <div class="form-group col-md-3" >
                    <label style="float: inherit;"> Usuario</label><br style="clear:both"/>
                    <asp:DropDownList ID="DDUsuario"  runat="server"  class="form-control buscarDNels" style="width: 100% !important;"  >
                    </asp:DropDownList>                
                    </div>           
                <div class="form-group col-md-2" >
                      <br style="clear:both"/>
                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success" runat="server" OnClick="LinkButton1_Click" Width="100%"  ><i class="fa fa-search"></i>Buscar</asp:LinkButton>
                </div>
                <div class="form-group col-md-2">
                      <br style="clear:both"/>
                <asp:LinkButton ID="BtnExportar" CssClass="btn btn-primary" runat="server" OnClick="BtnExportar_Click1" Width="100%">Exportar&nbsp;&nbsp; <i class="fa fa-file-excel" aria-hidden="true"></i></asp:LinkButton>
                </div>                          
  
                    <div class="form-group col-md-12">  <asp:Label ID="LblTotal" runat="server"></asp:Label>
                           <div class="table-responsive">
                    <asp:GridView ID="GvReporte" class="table table-bordered" runat="server" ClientIDMode="Static"
                        CellPadding="4" ForeColor="#333333"
                         GridLines="None" AutoGenerateColumns="False" OnRowDataBound="GvReporte_RowDataBound" >           
                        <Columns>
                           
                            <asp:BoundField DataField="CodigoTxt" HeaderText="CodigoTxt" />
                           
                            <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" /> 
                            <asp:BoundField DataField="Por_Visitar" HeaderText="Por Visitar" />
                            <asp:BoundField DataField="Visitados" HeaderText="Visitados" />
                            <asp:BoundField DataField="Cantidad_Pedidos" HeaderText="Cantidad Pedidos" />
                            <asp:BoundField DataField="Total" HeaderText="Total" />
                            <asp:BoundField HeaderText="Avance Visita" ItemStyle-CssClass="pieChart" HeaderStyle-Width="100px"  />         
       
                        </Columns>
                    <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"   /> 
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
            </td><td></td>
            <td>
            <b><h3>
            <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="LblFecha" runat="server" Text="Label"></asp:Label></h3></b>
            </td>
            </tr>
            </table>
            </center>
                     <%-- NELSON :) --%>             
            <br />
    <asp:GridView ID="GvExport" class="table table-bordered" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
         <Columns>
                           
                            <asp:BoundField DataField="CodigoTxt" HeaderText="CodigoTxt" /> 
                            <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" /> 
                            <asp:BoundField DataField="Por_Visitar" HeaderText="Por Visitar" />
                            <asp:BoundField DataField="Visitados" HeaderText="Visitados" />
                            <asp:BoundField DataField="Cantidad_Pedidos" HeaderText="Cantidad Pedidos" />
                            <asp:BoundField DataField="Total" HeaderText="Total" />
                        </Columns>
     <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
    </asp:GridView></asp:Panel>
                                 
                               </div>

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
</form>
  
 
     <script type="text/javascript">
         $.noConflict();
         jQuery(document).ready(function ($) {
             $('.buscarDNels').SumoSelect({ search: true, searchText: 'Buscar ....' });
         });
         function soloNumeros(e) {
             var key = window.Event ? e.which : e.keyCode
             return (key >= 48 && key <= 57)
         }      



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
