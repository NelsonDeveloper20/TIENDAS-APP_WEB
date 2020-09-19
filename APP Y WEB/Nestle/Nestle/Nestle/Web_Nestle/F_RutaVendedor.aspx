<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_RutaVendedor.aspx.cs" Inherits="Web_Nestle.F_RutaVendedor" %>
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
     <style>   /*CHECKBOX*/
    
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
    .viewe:hover{
     
    color: #000000 !important;
     }
      .hidden-field
 {
     display:none;
 }
table th, table td {
  
  border: 1px solid #eee;
  /*padding: 12px 35px;*/
  border-collapse: collapse;
}
table th {
  background: #FF7C02;
  color: #fff;
  /*text-transform: uppercase;*/
  font-size: 11px;
  border-radius:6px;
}
 .checkbox{
pointer-events:none;
 }
</style>
    <script src="vendor/Multilist/jquery.sumoselect.min.js"></script>
    <link href="vendor/Multilist/sumoselect.css" rel="stylesheet" />
      <script>
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        });
    </script><div class="loader"></div>
    <form runat="server">

       <div class="row">
            <div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 5px;margin-top: 10px;">
            <div class="card card-small mb-4">
            <div class="card-header border-bottom">
            <h6 class="m-0">Rutas Vendedor</h6>    
            </div>
            <ul class="list-group list-group-flush">
            <li class="list-group-item p-3">
            <div class="row">
            <div class="col">
                   <div class="form-row">      
                       <asp:Panel ID="PanelListar" runat="server" CssClass="col-lg-12">
                           <div class="col-12">                               
                    <div class="form-row">
                        
                     <div class="form-group col-md-3" >
                    <label style="float: inherit;"> Vendedor</label><br style="clear:both"/>
                    <asp:DropDownList ID="DDUsuario"  runat="server"  class="form-control buscarDNels" style="width: 100% !important;"  >
                    </asp:DropDownList>                
                    </div>     
                         <div class="form-group col-md-2">
                <label>Dia</label>
                    <asp:DropDownList ID="DDDia"  runat="server"  class="form-control" style="width: 100% !important;"  >
                        <%--<asp:ListItem Value="0">Todos</asp:ListItem>--%>
                        <asp:ListItem Value="1">Lunes</asp:ListItem>
                        <asp:ListItem Value="2">Martes</asp:ListItem>
                        <asp:ListItem Value="3">Miercoles</asp:ListItem>
                        <asp:ListItem Value="4">Jueves</asp:ListItem>
                        <asp:ListItem Value="5">Viernes</asp:ListItem>
                        <asp:ListItem Value="6">Sabado</asp:ListItem>
                        <asp:ListItem Value="7">Domingo</asp:ListItem>
                    </asp:DropDownList>  
                </div>
                          <div class="form-group col-md-2">
                      <label><br /></label>
                <asp:LinkButton ID="Bntrefresh" Width="100%" CssClass="btn btn-primary" runat="server" OnClick="Bntrefresh_Click"   ><i class="fas fa-search"></i> Buscar</asp:LinkButton>
                </div>
                         
                           <div class="table-responsive">
                    <asp:GridView ID="GvRutas" class="table table-bordered" runat="server" 
                        CellPadding="4" ForeColor="#333333" ShowHeaderWhenEmpty="True"
                         GridLines="None" AutoGenerateColumns="False" OnRowDataBound="GvRutas_RowDataBound" >      
                        <Columns>
                            <asp:BoundField DataField="COD_VENDEDOR" HeaderText="Cod Vendedor" />
                            <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" />
                            <asp:BoundField DataField="Cod_Cliente" HeaderText="Cod Cliente" />
                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                             <asp:TemplateField HeaderText="L">
                                <ItemTemplate>
                                    <div class="checkbox">
                                    <label style="    font-size: 1.1em;">
                                    <asp:CheckBox runat="server" ID="CHK1" Checked='<%#Eval("L").ToString()=="1"?true:false %>'  />                      
                                    <span class="cr" style="border: 1px solid #ff7c02;"><i class="cr-icon fa fa-check"></i></span>
                                    </label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="M">
                                <ItemTemplate>
                                    <div class="checkbox">
                                    <label style="    font-size: 1.1em;">
                                    <asp:CheckBox runat="server" ID="CHK2" Checked='<%#Eval("M").ToString()=="1"?true:false %>'  />                      
                                    <span class="cr" style="border: 1px solid #ff7c02;"><i class="cr-icon fa fa-check"></i></span>
                                    </label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="MM">
                                <ItemTemplate>
                                    <div class="checkbox">
                                    <label style="    font-size: 1.1em;">
                                    <asp:CheckBox runat="server" ID="CHK3" Checked='<%#Eval("MM").ToString()=="1"?true:false %>' />                      
                                    <span class="cr" style="border: 1px solid #ff7c02;"><i class="cr-icon fa fa-check"></i></span>
                                    </label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="J">
                                <ItemTemplate>
                                    <div class="checkbox">
                                    <label style="    font-size: 1.1em;">
                                    <asp:CheckBox runat="server" ID="CHK4" Checked='<%#Eval("J").ToString()=="1"?true:false %>'  />                      
                                    <span class="cr" style="border: 1px solid #ff7c02;"><i class="cr-icon fa fa-check"></i></span>
                                    </label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="V">
                                <ItemTemplate>
                                    <div class="checkbox">
                                    <label style="    font-size: 1.1em;">
                                    <asp:CheckBox runat="server" ID="CHK5" Checked='<%#Eval("V").ToString()=="1"?true:false %>' />                      
                                    <span class="cr" style="border: 1px solid #ff7c02;"><i class="cr-icon fa fa-check"></i></span>
                                    </label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S">
                                <ItemTemplate>
                                    <div class="checkbox">
                                    <label style="    font-size: 1.1em;">
                                    <asp:CheckBox runat="server" ID="CHK6" Checked='<%#Eval("S").ToString()=="1"?true:false %>'  />                      
                                    <span class="cr" style="border: 1px solid #ff7c02;"><i class="cr-icon fa fa-check"></i></span>
                                    </label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="D">
                                <ItemTemplate>
                                    <div class="checkbox">
                                    <label style="    font-size: 1.1em;">
                                    <asp:CheckBox runat="server" ID="CHK7" Checked='<%#Eval("D").ToString()=="1"?true:false %>' />                      
                                    <span class="cr" style="border: 1px solid #ff7c02;"><i class="cr-icon fa fa-check"></i></span>
                                    </label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Fecha_Carga" HeaderText="Fecha_Carga" />                            
                        </Columns>
                        <EmptyDataTemplate> 
                            <div>
                                <h4>No hay registros</h4>
                            </div>

                        </EmptyDataTemplate>
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
        
    </form>
    <script>
         $.noConflict();
        jQuery(document).ready(function ($) {
            $('.buscarDNels').SumoSelect({ search: true, searchText: 'Buscar ....' });
        });
        $(function () {

            $('#TxtFechaInicio').datepicker({
                format: 'dd',
                autoclose: true,
                //startDate: "today",
                //minViewMode: 1,
                //todayBtn: 'linked'
                locale: 'es-es',
            });
        });
    </script>
</asp:Content>
