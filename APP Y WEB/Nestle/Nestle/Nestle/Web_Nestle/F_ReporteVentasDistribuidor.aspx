<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_ReporteVentasDistribuidor.aspx.cs" Inherits="Web_Nestle.F_ReporteVentasDistribuidor" %>
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
.SumoSelect .select-all label{
    border-radius: 3px 3px 0 0;
    position: relative;
    border-bottom: 1px solid #ddd;
    background-color: #fff;
    padding: 8px 0 3px 35px;
    height: 20px;
    cursor: pointer;
    
    margin-top: -17px;
}.hidden-field
 {
     display:none;
 }</style>
   
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager" runat="server" />         
            <div class="row">
            <div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 5px;margin-top: 10px;">
            <div class="card card-small mb-4">
            <div class="card-header border-bottom">
            <h6 class="m-0"> Reporte de ventas Distribuidor</h6>    
            </div>
            <ul class="list-group list-group-flush">
            <li class="list-group-item p-3">
            <div class="row">
            <div class="col">
                <div class="col-md-12">	
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
                     
                          <div class="form-group col-md-3">
                <label>Vendedor</label><br style="clear:both"/>
                              <asp:DropDownList ID="DDVendedor" CssClass="form-control lismultinelso" runat="server" ></asp:DropDownList>
                                 <%--<asp:ListBox ID="DDVendedor" runat="server" SelectionMode="Single"  class="form-control lismultinelso"></asp:ListBox>--%>
                </div>     
                          </div>
                 
                    </div>
                <div class="col-md-12">  
                        <asp:UpdatePanel ID="UpdatePanel1" class="form-row" runat="server">
                            <ContentTemplate>
                <div class="form-group col-md-2" style="  ">
                      <br style="clear:both"/>
                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success" runat="server" OnClick="LinkButton1_Click" Width="100%"  ><i class="fa fa-search"></i>Buscar</asp:LinkButton>
                </div>
                <div class="form-group col-md-2" style=" top: 0px; left: 0px;">
                      <br style="clear:both"/>
                <asp:LinkButton ID="BtnExportar" CssClass="btn btn-primary" runat="server" OnClick="BtnExportar_Click1" Width="100%">Exportar&nbsp;&nbsp; <i class="fa fa-file-excel" aria-hidden="true"></i></asp:LinkButton>
                </div> 
                         
                    <div class="form-group col-md-12">  <asp:Label ID="LblTotal" runat="server"></asp:Label>
                           <div class="table-responsive">
                               <asp:GridView ID="GvReporte" class="table table-bordered" runat="server" 
                        CellPadding="4" ForeColor="#333333">
                                     <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                               </asp:GridView>

                           </div>
                        </div>  
                        </ContentTemplate>
                          <Triggers>  
     <asp:PostBackTrigger ControlID="BtnExportar" />
</Triggers> 
                        </asp:UpdatePanel>
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
             $('.lismultinelso').SumoSelect({ search: true, searchText: 'Buscar Conductores.', selectAll: true });
         });
         //// Code that uses other library's $ can follow here.
         //$(document).ready(function () {
         //    //$(".lismultinelso").SumoSelect();
             
         //});


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
