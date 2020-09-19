<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="Web_Nestle.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="https://vitalets.github.io/bootstrap-datepicker/jquery/jquery.js"></script>
    <script src="https://vitalets.github.io/bootstrap-datepicker/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
  
<%--        <script src="jsFecha/Moment.js"></script>
    <script src="jsFecha/Botstrap_Datetime.js"></script>--%>
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
           left: 0;
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
   </style>
    <form id="form1" runat="server">
        <script>
            jQuery(document).ready(function ($) {
                $('#GridView1 .pieChart').each(function (index, value) {
                    var percent = $(this).text();
                    var deg = 360 / 100 * percent;
                    $(this).html('<div class="percent">' + Math.round(percent) + '%' + '</div><div class="pieBack"></div><div ' + (percent > 50 ? ' class="slice gt50"' : 'class="slice"') + '><div class="pie"></div>' + (percent > 50 ? '<div class="pie fill"></div>' : '') + '</div>');
                    $(this).find('.slice .pie').css({
                        '-moz-transform': 'rotate(' + deg + 'deg)',
                        '-webkit-transform': 'rotate(' + deg + 'deg)',
                        '-o-transform': 'rotate(' + deg + 'deg)',
                        'transform': 'rotate(' + deg + 'deg)'
                    });
                });
            });
        </script>
<asp:ScriptManager ID="ScriptManager" runat="server" />         
            <div class="row">
            <div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 5px;margin-top: 10px;">
            <div class="card card-small mb-4">
                <div class="card-header border-bottom">
            <h6 class="m-0">Meta Bodega - Vendedor</h6>    
            </div>
            <ul class="list-group list-group-flush">
            <li class="list-group-item p-3">
            <div class="row">
            <div class="col">
           
        <div class="col-md-12" style="    margin-top: -6px;">   
            <div class="form-row">
                <div class="span9 columns">
          <div class="well">
            <input type="text" class="form-control" ClientIDMode="Static" runat="server" id="dp1">
          </div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                           <Columns>
                           
                            <asp:BoundField DataField="CodigoTxt" HeaderText="CodigoTxt" />                           
                            <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" /> 
                            <asp:BoundField DataField="Por_Visitar" HeaderText="Por Visitar" />
                            <asp:BoundField DataField="Visitados" HeaderText="Visitados" />
                            <asp:BoundField DataField="Cantidad_Pedidos" HeaderText="Cantidad Pedidos" />
                            <asp:BoundField DataField="Total" HeaderText="Total" />
                            <asp:BoundField HeaderText="Cantidad_Pedidos" ItemStyle-CssClass="pieChart" HeaderStyle-Width="100px"  />         
       
                        </Columns>
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
        <script>
            $(function () {
                var dateToday = new Date();
              
			window.prettyPrint && prettyPrint();
			$('#dp1').datepicker({
			    format: 'yyyy-mm-dd',
			    autoclose: true,
			    startDate: "today"
                //todayBtn: 'linked'
			});
           
            
		});
	</script>
</form>
</asp:Content>
