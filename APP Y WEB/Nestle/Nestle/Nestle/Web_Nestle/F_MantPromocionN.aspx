<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_MantPromocionN.aspx.cs" Inherits="Web_Nestle.F_MantPromocionN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="jsFecha/bootstrap-datepicker.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/jquery2_2_4.js"></script>
    
    <script src="vendor/Multilist/jquery.sumoselect.min.js"></script>
    <link href="vendor/Multilist/sumoselect.css" rel="stylesheet" />

  <style>      

      .SumoSelect {
    width: 176px !important;
}
      .optWrapper{
              width: 297px !important;
      }
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
       input[type=checkbox] {
         position: relative;
	       cursor: pointer;           
  
    }
    input[type=checkbox]:before {
         content: "";
         display: block; 
         position: absolute;
         width: 16px;
         height: 16px;
         top: 0;
         left: 0;
         border: 1px solid rgb(11, 157, 226);
         border-radius: 3px;
         background-color: white;
}
     
    input[type=checkbox]:checked:after {
         content: "";
         display: block;
         width: 5px;
         height: 10px;
         border: solid #366df1;
         border-width: 0 2px 2px 0;
         -webkit-transform: rotate(45deg);
         -ms-transform: rotate(45deg);
         transform: rotate(45deg);
         position: absolute;
         top: 2px;
         left: 6px;
}
   .header_p{
       width:15%;
       padding:8px !important;
   }
   .foote{
       padding:3px;
   }
.hidden-field
 {
     display:none;
 } .btn-circle {
  width: 30px;
  height: 30px;
  text-align: center;
  padding: 6px 0;
  font-size: 12px;
  line-height: 1.428571429;
  border-radius: 15px;
}
.btn-circle.btn-lg {
  width: 50px;
  height: 50px;
  padding: 10px 16px;
  font-size: 18px;
  line-height: 1.33;
  border-radius: 25px;
}
.btn-circle.btn-xl {
  width: 70px;
  height: 70px;
  padding: 10px 16px;
  font-size: 24px;
  line-height: 1.33;
  border-radius: 35px;
} .hidden-field
 {
       visibility:hidden;
     /*display:ho;*/
 }
.datepicker{
       z-index: 99999 !important;
}
/*legggend*/

    fieldset 
	{
		border: 1px solid #ddd !important;
		margin: 0;
		xmin-width: 0;
		padding: 10px;       
		position: relative;
		border-radius:4px;
		background-color: #f5f6f8;  /* #f5f5f5; */
		padding-left:10px!important;    }	
	
		legend
		{
		    font-size: 14px;
    /*font-weight: bold;*/
    margin-bottom: 0px;
    width: 50%;
    border: 1px solid #ddd;
    border-radius: 4px;
    padding: 1px 2px 1px 5px;
    background-color: #ffffff;
		}
/*end*/
      .datepicker {
              z-index: 9999;

      }
      /*CHECKBOX*/
      
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
    	/* The customcheck */
.customcheck {
    display: block;
    position: relative;
    padding-left: 35px;
    margin-bottom: 12px;
    cursor: pointer;
    font-size: 22px;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
}

/* Hide the browser's default checkbox */
.customcheck input {
    position: absolute;
    opacity: 0;
    cursor: pointer;
}

/* Create a custom checkbox */
.checkmark {
    position: absolute;
    top: 0;
    left: 0;
    height: 25px;
    width: 25px;
    background-color: #eee;
    border-radius: 5px;
}

/* On mouse-over, add a grey background color */
.customcheck:hover input ~ .checkmark {
    background-color: #ccc;
}

/* When the checkbox is checked, add a blue background */
.customcheck input:checked ~ .checkmark {
    background-color: #02cf32;
    border-radius: 5px;

}

/* Create the checkmark/indicator (hidden when not checked) */
.checkmark:after {
    content: "";
    position: absolute;
    display: none;
}

/* Show the checkmark when checked */
.customcheck input:checked ~ .checkmark:after {
    display: block;
}

/* Style the checkmark/indicator */
.customcheck .checkmark:after {
    left: 9px;
    top: 5px;
    width: 5px;
    height: 10px;
    border: solid white;
    border-width: 0 3px 3px 0;
    -webkit-transform: rotate(45deg);
    -ms-transform: rotate(45deg);
    transform: rotate(45deg);
}
/*END CHECKBOX*/

/*chec 2*/
/* Hide the browser's default checkbox */
.customcheck2 input {
    position: absolute;
    opacity: 0;
    cursor: pointer;
}

/* Create a custom checkbox */
.checkmark2 {
    position: absolute;
    top: 0;
    left: 0;
    height: 25px;
    width: 25px;
    background-color: #eee;
    border-radius: 5px;
}

/* On mouse-over, add a grey background color */
.customcheck2:hover input ~ .checkmark2 {
    background-color: #ccc;
}

/* When the checkbox is checked, add a blue background */
.customcheck2 input:checked ~ .checkmark2 {
    background-color: #02cf32;
    border-radius: 5px;
}

/* Create the checkmark/indicator (hidden when not checked) */
.checkmark2:after {
    content: "";
    position: absolute;
    display: none;
}

/* Show the checkmark when checked */
.customcheck2 input:checked ~ .checkmark2:after {
    display: block;
}

/* Style the checkmark/indicator */
.customcheck2 .checkmark2:after {
    left: 9px;
    top: 5px;
    width: 5px;
    height: 10px;
    border: solid white;
    border-width: 0 3px 3px 0;
    -webkit-transform: rotate(45deg);
    -ms-transform: rotate(45deg);
    transform: rotate(45deg);
}      
/*END CHECKBOX*/
.loader {
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
	    function shrinkandgrow(input) {
	        var displayIcon = "img" + input;
	        var displayIcon2 = "imgdiv_" + input.replace("div", "");
	        var uno = document.getElementById(displayIcon2);
	        if (uno.innerHTML == '<i class="fa fa-plus" aria-hidden="true"></i>') {
	            uno.innerHTML = '<i class="fas fa-minus"></i>';
	        } else {
	            uno.innerHTML = '<i class="fa fa-plus" aria-hidden="true"></i>'
	        }	       
	      
	        //alert();
	      
            if ($("#" + displayIcon).attr("src") == "http://201.234.124.219/webgesthorario/imagenes/detail.gif")
            {
                $("#" + displayIcon).closest("tr")
			    .after("</td><td colspan = '100%'>" + $("#" + input)
			    .html() + "");
                $("#" + displayIcon).attr("src", "http://201.234.124.219/webgesthorario/imagenes/close.gif");
            } else
            {
                $("#" + displayIcon).closest("tr").next().remove();
                $("#" + displayIcon).attr("src", "http://201.234.124.219/webgesthorario/imagenes/detail.gif");
		    }
	    }
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        });
    </script>

<form id="form1" runat="server"><div class="loader"></div>
<asp:ScriptManager ID="ScriptManager" runat="server" />   
    <asp:HiddenField ID="HdnIp" runat="server" />
<div class="row">
<div class="col-lg-12" style="padding-left: 5px;
    padding-right: 5px;margin-top: 10px;">
<div class="card card-small mb-4">
<div class="card-header border-bottom">
<h6 class="m-0">Promociones</h6>    
</div>
<ul class="list-group list-group-flush">
<li class="list-group-item p-3">
<div class="row">
<div class="col">           
<div class="" style="    margin-top: -6px;">   
<div class="form-row">  

    


         <asp:Panel ID="Panel_Listar" class="col-lg-12" runat="server">
                     <div class="form-row">
                      <div class="form-group col-md-2">
                    <label>Fecha Inicio</label>
                    <input type="text" class="form-control" runat="server" placeholder="dd/mm/yyyy" ClientIDMode="Static" id="TXtBuscFecInicio" autocomplete="off">
                    <div class="input-group-addon">
                    <span class="glyphicon glyphicon-th"></span>
                    </div>
                    </div>  
            
                    <div class="form-group col-md-2">
                    <label>Fecha Fin</label>
                    <input type="text" class="form-control" runat="server"  placeholder="dd/mm/yyyy" ClientIDMode="Static" id="TxtBuscFechFin" autocomplete="off">
                    <div class="input-group-addon">
                    <span class="glyphicon glyphicon-th"></span>
                    </div>
                    </div>   
                         <div class="form-group col-md-1">
                               <br style="clear:both"/> <br style="clear:both"/>
                    <label>Activo</label>
                             <asp:CheckBox ID="ChkEstado" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="ChkEstado_CheckedChanged" />
                    </div>   

                      
                <div class="form-group col-md-2" >
                    <br style="clear:both"/> <br style="clear:both"/>
                    <span class="input-group">
                        <asp:LinkButton ID="BtnBuscar" Width="100%" runat="server" OnClick="BtnBuscar_Click" class="btn btn-success" style="float: left"> <i class="glyphicon glyphicon-search"></i>Buscar</asp:LinkButton>
                       </span>
                </div>
                      <div class="form-group col-md-2" >
                    <br style="clear:both"/> <br style="clear:both"/>
                    <span class="input-group">
                    <asp:LinkButton ID="LinkButton1" Width="100%"  runat="server" class="btn btn-primary" OnClick="BtnNuevo_Click" >Nuevo</asp:LinkButton>
                    </span>
                </div></div>
                    <div class="col_lg-12">
                        <div class="table-responsive">                          
        <asp:GridView ID="GvPromociones" runat="server"   ForeColor="#333333" class="table table-bordered" 
        AutoGenerateColumns="false" DataKeyNames="IdPromocion" OnRowDataBound="GvPromociones_OnRowDataBound"     
        OnRowCommand="GvPromociones_RowCommand"  >
		<Columns>
		<asp:TemplateField ItemStyle-Width="20px">
		<ItemTemplate>
			<a href="JavaScript:shrinkandgrow('div<%# Eval("IdPromocion") %>');">
                <button type="button" id="imgdiv_<%# Eval("IdPromocion") %>" class="btn btn-outline-primary btn-circle w3r"><i class="fa fa-plus" aria-hidden="true"></i></button>
				<img alt="Details" id="imgdiv<%# Eval("IdPromocion") %>" src="http://201.234.124.219/webgesthorario/imagenes/detail.gif" style="display:none"/>
			</a>
			<div id="div<%# Eval("IdPromocion") %>" style="display: none;">
                
   <div class="row">
         <div class="col-lg-6" >
          <div class="card border-primary mb-6">
              <div class="card-header border-bottom">
<h6 class="m-0">Condicion</h6>    
</div> 
				<asp:GridView ID="GridView2" runat="server" class="table table-bordered" Width="100%" AutoGenerateColumns="false" DataKeyNames="IdPromocion"
                HeaderStyle-ForeColor="White">
				<Columns>
                    <%--ItemStyle-Width="150px"--%>
                    <asp:BoundField  DataField="ID" HeaderText="ID" />
					<asp:BoundField  DataField="Producto" HeaderText="Producto" />
					<asp:BoundField  DataField="Categoria" HeaderText="Categoria" />
					<asp:BoundField  DataField="Descripcion" HeaderText="Descripcion" />
					<asp:BoundField  DataField="Grupo" HeaderText="Grupo" />
					<asp:BoundField  DataField="Cantidad" HeaderText="Cantidad" />
				</Columns> <HeaderStyle  BackColor="#f5f5f5" ForeColor="#252020" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"  Font-Size="12px"   /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
				</asp:GridView>
              </div></div>
        <div class="col-lg-6" > 
          <div class="card border-primary mb-6">
              <div class="card-header border-bottom">
<h6 class="m-0">Bonificacion</h6>    
</div> 
                <asp:GridView ID="GvBonfi" runat="server" class="table table-bordered" Width="100%" AutoGenerateColumns="false" DataKeyNames="IdPromocion"
                HeaderStyle-ForeColor="White">
				<Columns>
                    <%--ItemStyle-Width="150px"--%>
                    <asp:BoundField  DataField="ID" HeaderText="ID" />
					<asp:BoundField  DataField="producto" HeaderText="producto" />
					<asp:BoundField  DataField="Cantidad" HeaderText="Cantidad" />
					<asp:BoundField  DataField="Stock" HeaderText="Stock" />
					<asp:BoundField  DataField="Grupo" HeaderText="Grupo" />
				</Columns> <HeaderStyle  BackColor="#f5f5f5" ForeColor="#252020" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"  Font-Size="12px"   /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
				</asp:GridView>
              </div></div>

       </div>
			</div>
		</ItemTemplate>
		</asp:TemplateField>
			<asp:BoundField ItemStyle-Width="150px" DataField="IdPromocion" HeaderText="ID" />			
					<asp:BoundField  DataField="Fecha_Inicio" HeaderText="Fecha_Inicio" />
					<asp:BoundField  DataField="Fec_Fin" HeaderText="Fec_Fin" />
					<asp:BoundField  DataField="TipoPromocion" HeaderText="TipoPromocion" />
					<asp:BoundField  DataField="TipoUsuario" HeaderText="TipoUsuario" />
					<asp:BoundField  DataField="TipoCondicion" HeaderText="TipoCondicion" />
					<asp:BoundField  DataField="Condicion" HeaderText="Condicion" />
					<asp:BoundField  DataField="TipoBonificacion" HeaderText="TipoBonificacion" />
					<asp:BoundField  DataField="MontoBonificacion" HeaderText="MontoBonificacion" />   
					<asp:BoundField  DataField="Historico" HeaderText="Historico" /> 
					<asp:BoundField  DataField="PrimeraCompra" HeaderText="PrimeraCompra" />        

              <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ShowHeader="False" HeaderText="Noficacion">
            <ItemTemplate> 

            <asp:LinkButton ID="BtnSpush"  runat="server" Text="" CssClass="btn btn-outline-primary"
            CommandArgument="<%# ((GridViewRow)Container).RowIndex  %>"
            CommandName="EnviarPush">               
                 <%# Eval("FlagNotificacion").ToString() == "0" ? "<img src='http://201.234.124.219/webgesthorario/Iconos/accept.png' width='23px' height='20px'/>" : "Enviar<i class='fa fa-paper-plane' aria-hidden='true'></i>" %>  
            </asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField><%-- 12 --%>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ShowHeader="False" HeaderText="Editar">
            <ItemTemplate>
            <asp:LinkButton ID="BtnEditar" runat="server" Text="" CssClass="btn btn-outline-success"
            CommandArgument="<%# ((GridViewRow)Container).RowIndex  %>"
            CommandName="Editar" >Editar</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>    <%-- 13 --%>     
           
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ShowHeader="False" HeaderText="Activar/DesActivar">
            <ItemTemplate>
            <asp:LinkButton ID="btnDelete" runat="server" Text="" CssClass="btn btn-outline-dark"
            CommandArgument="<%# ((GridViewRow)Container).RowIndex  %>"
            CommandName="Eliminar" OnClientClick="return confirm('¿Continuar?');" >  <%# Eval("estado").ToString() == "Activo" ? "DesActivar" : "Activar" %>    </asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>      <%-- 14 --%>
            
            <asp:BoundField DataField="FlagNotificacion" HeaderText="FlagNotificacion" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
            <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
            </asp:BoundField>  <%-- 15 --%>
            
            <asp:BoundField DataField="estado" HeaderText="estado" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
            <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
            </asp:BoundField>  <%-- 16 --%>
		</Columns> 
     <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"  Font-Size="11px"   /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
</asp:GridView>
                        </div></div>

         </asp:Panel>
    
            <asp:HiddenField ID="Hdn_IdPromocion" ClientIDMode="Static" runat="server" />
            <asp:Panel ID="Panel_Agregar" class="col-lg-12" runat="server">
           <div class="row">     
                 <div class="col-lg-8" style="   padding-right: 2px;">

     <div class="form-row"> 
        <%--    <asp:UpdatePanel ID="UpdatePanel1" class="col-lg-12"  runat="server">
                <ContentTemplate>--%>
               <%--      <div class="form-row"> --%>
            
                    <div class="form-group col-md-2">
                    <label>Fecha Inicio</label>
                    <input type="text" class="form-control" runat="server" placeholder="dd/mm/yyyy" ClientIDMode="Static" id="TxtFechaIni" autocomplete="off">
                    <div class="input-group-addon">
                    <span class="glyphicon glyphicon-th"></span>
                    </div>
                    </div>  
            
                    <div class="form-group col-md-2">
                    <label>Fecha Fin</label>
                    <input type="text" class="form-control" runat="server"  placeholder="dd/mm/yyyy" ClientIDMode="Static" id="TxtFechaFin" autocomplete="off">
                    <div class="input-group-addon">
                    <span class="glyphicon glyphicon-th"></span>
                    </div>
                    </div>  
  

                    <div class="form-group col-md-2" style="display:none">
                    <label style="float: inherit;">Tipo Usuario</label>
                    <asp:DropDownList ID="DDTipoUsuario"  runat="server"  class="form-control" style="width: 100% !important;"  >
                    </asp:DropDownList>                
                    </div>  
                    <div class="form-group col-md-3">
                    <label style="float: inherit;">Condicion</label>
                    <asp:DropDownList ID="DDCondicion"  runat="server"  class="form-control" style="width: 100% !important;"  >
                    </asp:DropDownList>                
                    </div>  
                    <div class="form-group col-md-3">
                    <label style="float: inherit;">Tipo Promocion</label>
                    <asp:DropDownList ID="DDTipoCondicion"  runat="server"  class="form-control" style="width: 100% !important;"  >
                    </asp:DropDownList>                
                    </div> 
                    <div class="form-group col-md-2">
                    <label style="float: inherit;">Tipo Condicion</label>
                    <asp:DropDownList ID="DDtipoPromocion"  runat="server"  ClientIDMode="Static" class="form-control" AutoPostBack="true" style="width: 100% !important;" OnSelectedIndexChanged="DDtipoPromocion_SelectedIndexChanged" >
                    </asp:DropDownList>                
                    </div> 

              <div class="form-group col-sm-3">
                    <label style="float: inherit;">Tipo Bonificacion</label>
                    <asp:DropDownList ID="DDTipoBonificacion"  runat="server"  class="form-control" style="width: 100% !important;" AutoPostBack="true" OnSelectedIndexChanged="DDTipoBonificacion_SelectedIndexChanged"  >
                    </asp:DropDownList>                
                    </div>     
                    <div class="form-group col-md-3">
                    <label>Monto Bonificacion</label> 
                        <asp:TextBox ID="TxtMontoBonifica" runat="server" AutoComplete="off" placeholder="Monto Bonificacion "  onkeypress="return validateFloatKeyPress(this, event, 9, 2);" class="form-control" ClientIDMode="Static"></asp:TextBox>
                         </div>      
        <div class="form-group col-sm-2" >
           <center>   <label>  Primera Compra</label>
          
        <div class="checkbox">
        <label style="font-size: 1.5em">
        <asp:CheckBox runat="server" ID="ChkPrimeroCompra" AutoPostBack="false"  />                      
        <span class="cr" style="border: 2px solid #23A9E1;"><i class="cr-icon fa fa-check"></i></span>
        </label>
        </div></center></div>
         <div class="form-group col-sm-2" >
           <center>  <label>Historico</label>
       <div class="checkbox">
        <label style="font-size: 1.5em">
        <asp:CheckBox runat="server" ID="ChkHistorico" AutoPostBack="false"  />                      
        <span class="cr" style="border: 2px solid #23A9E1;"><i class="cr-icon fa fa-check"></i></span>
        </label>
        </div></center></div> 
    


     </div>  
    </div>
                <div class="col-lg-4" style=" padding-left: 0px;  padding-right: 1px;">
<asp:GridView ID="GridView1" runat="server" class="table table-bordered" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="Id">
            <ItemTemplate>
                <asp:Label ID="lblId" runat="server" class="form-control-plaintext" Text='<%# Eval("Id") %>' />
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tipo Usuario">
            <ItemTemplate>
                <asp:Label ID="lblCountry" runat="server" class="form-control-plaintext" Text='<%# Eval("TipoUsuer") %>' />
            </ItemTemplate>
            <FooterTemplate>
                <asp:DropDownList ID="dd_tipo" runat="server" class="form-control buscarDNels"></asp:DropDownList>
                <%--<asp:TextBox ID="txtCountry" runat="server" Text="Test Country" />--%>
            </FooterTemplate>
        </asp:TemplateField>

       <%-- <asp:BoundField DataField="IdTipoUser" HeaderText="IdTipoUser" />--%>
       

        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                     <asp:LinkButton ID="bt_elim" CommandArgument='<%# Eval("Id") %>' OnClick="Delete" CssClass="btn btn-outline-dark" runat="server"><i class="far fa-trash-alt"></i></asp:LinkButton>
              
                <%--<asp:Button Text="Delete" runat="server" OnClick="Delete" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("Id") %>'
                    Width="75px" />--%>
            </ItemTemplate>
            <FooterTemplate>
                   <asp:LinkButton ID="btnAdd" CommandName="Footer" OnClick="Add" CssClass="btn btn-outline-primary" runat="server"><i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
                <%--<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Add" Width="75px" CommandName="Footer" />--%>
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        <table>
            <tr>
                <th scope="col">
                    Id
                </th>
                <th scope="col">
                    Tipo Usuario
                </th>

                <th scope="col">
                    Action
                </th>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    
                <asp:DropDownList ID="dd_tipo" runat="server" class="form-control buscarDNels"></asp:DropDownList>
                 <%--   <asp:TextBox ID="txtCountry" runat="server" Text="Test Country" />--%>
                </td>


                <td>
                  <asp:LinkButton ID="btnAdd" CommandName="EmptyDataTemplate" OnClick="Add" CssClass="btn btn-outline-primary" runat="server"><i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
                    <%--<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Add" Width="75px" CommandName="EmptyDataTemplate" />--%>
                </td>
            </tr>
        </table>
    </EmptyDataTemplate>
    
   <%--  <HeaderStyle   font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"  Font-Size="11px"   /> --%>
</asp:GridView>
                    </div></div>
   <div class="row">
       
     <div class="col-lg-7" style="  padding-right: 2px;    padding-left: 7px;">  
        <div class="card border-primary mb-7">
              <div class="card-header border-bottom">
<h6 class="m-0">Condicion</h6>    
</div> 
        <asp:GridView runat="server" ID="gvDetails"  class="table table-bordered" ShowFooter="True" AllowPaging="True" AutoGenerateColumns="False" 
            DataKeyNames="IdPromCondicion,IdPromocion,IdProducto,Grupo" 
            OnRowCancelingEdit="gvDetails_RowCancelingEdit"
           OnRowEditing="gvDetails_RowEditing" 
            OnRowUpdating="gvDetails_RowUpdating" 
            OnRowDeleting="gvDetails_RowDeleting"           
            OnRowDataBound="gvDetails_RowDataBound"  >  
        <Columns>

                <asp:BoundField DataField="IdPromCondicion" Visible="false" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
                <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Producto / Categoria" >                 
                <ItemTemplate>
                <asp:Label ID="lbl_it" runat="server" Text='<%# Eval("IdProducto")%>' Visible="false"></asp:Label>
                <asp:Label ID="lblprod_cat" runat="server" Text='<%# Eval("Producto")%>' class="form-control-plaintext"/>
                </ItemTemplate>
                <EditItemTemplate>
                    
                <asp:TextBox ID="txtprod_cat" runat="server" AutoCompleteType="Office"  class="form-control " Text='<%# Eval("IdProducto")%>' Visible="false"/>                    
                <asp:DropDownList ID="DD_Prod_Catedit"  runat="server"  class="form-control buscarDNels" style="width: 100% !important;">
                </asp:DropDownList>  
                <asp:DropDownList ID="DDCategoriaedit"  runat="server"  class="form-control buscarDNels" style="width: 100% !important;"  >
                </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                <asp:DropDownList ID="DD_Prod_CatIns"  runat="server"  class="form-control buscarDNels" style="width: 100% !important;"  >
                </asp:DropDownList>  
                <asp:DropDownList ID="DDCategoriaIns"  runat="server"  class="form-control buscarDNels" style="width: 100% !important;"  >
                </asp:DropDownList>
               </FooterTemplate>                         
                <ItemStyle Width="30%" />
                <HeaderStyle  Width="30%" />
                <FooterStyle Width="30%" />  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                <asp:Label ID="lblCantidad" class="form-control-plaintext" runat="server" Text='<%# Eval("Cantidad")%>'/>
                </ItemTemplate>
                <EditItemTemplate>
                <asp:TextBox ID="txtCantidad" onKeyPress="return soloNumeros(event)"  class="form-control " runat="server" Text='<%# Eval("Cantidad")%>'/>
                </EditItemTemplate>
                <FooterTemplate>
                <asp:TextBox ID="txtCantidad_ins" onKeyPress="return soloNumeros(event)" class="form-control " runat="server" />
                </FooterTemplate>                    
                <ItemStyle  CssClass="header_p"  />
                <HeaderStyle CssClass="header_p"  />
                <FooterStyle Width="15%" CssClass="foote" />  
                </asp:TemplateField>
                <asp:TemplateField HeaderText = "Descripcion">
                <ItemTemplate>
                <asp:Label ID="lblDescripcion" class="form-control-plaintext" runat="server" Text='<%# Eval("Descripcion")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                <asp:TextBox ID="txtDescripcion"  TextMode="MultiLine" Rows="1" class="form-control " runat="server" Text='<%# Eval("Descripcion")%>'/>
                </EditItemTemplate>
                <FooterTemplate>
                <asp:TextBox ID="txtDescripcion_ins" TextMode="MultiLine" Rows="1" class="form-control " runat="server" />
                </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText = "Grupo">
                <ItemTemplate>
                <asp:Label ID="lblGrupo" runat="server" class="form-control-plaintext"  Text='<%# Eval("Grupo")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                <asp:TextBox ID="txtGrupo" Enabled="false" runat="server" onKeyPress="return soloNumeros(event)" class="form-control " Text='<%# Eval("Grupo")%>' Width="50px"/>
                </EditItemTemplate>
                <FooterTemplate>
                <div class="">
                <asp:TextBox ID="txtGrupo_ins" onKeyPress="return soloNumeros(event)" runat="server"  class="form-control " Width="50px"/>
              <%-- CommandName="AddNew"--%>
                     </div> 
                </FooterTemplate>   
                </asp:TemplateField>
              <%--  <asp:CommandField ShowEditButton="false" ShowDeleteButton="false" />--%>
              <asp:TemplateField HeaderText="Aciones">
                                <ItemTemplate>
                                 
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text=""   CommandName="Edit" ToolTip="Edit" 
                                        CommandArgument='' CssClass="btn btn-info"> <i class="fas fa-pencil-alt"></i></asp:LinkButton>
                                  <asp:LinkButton ID="lnkDelete" runat="server"    Text="Delete" CommandName="Delete"
                                        ToolTip="Delete" OnClientClick='return confirm("Elimnar?");'
                                        CommandArgument='' CssClass="btn btn-dark">  <i class="fas fa-trash-alt"></i></asp:LinkButton>
                           
                                  </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text=""  ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
                                        CommandArgument='' CssClass="btn btn-primary"> <i class="fas fa-sync-alt"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                        CommandArgument='' CssClass="btn btn-dark"><i class="fas fa-angle-double-left"></i></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text=""  Width="100%"  ValidationGroup="newGrp" CommandName="Footer" OnClick="agregarCondicion"  ToolTip="Add"
                                        CommandArgument='' CssClass="btn btn-primary">  <i class="fa fa-plus" aria-hidden="true"></i> </asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Width="100%" Text="" CommandName="CancelNew" ToolTip="Cancel"
                                        CommandArgument='' CssClass="btn btn-warning" Visible="false">Cancelar</asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>   
        </Columns>
        </asp:GridView><br style="clear:both;margin-bottom:10px;"/>
                      </div>            
         </div>
       
     <div class="col-lg-5" style="      padding-right: 7px;    padding-left: 2px;">  
          <div class="card border-primary mb-5">     
            <div class="card-header border-bottom">
            <h6 class="m-0">Bonificacion</h6>    
            </div> 
      <asp:GridView runat="server" ID="GvDemo2" ShowFooter="True" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="IdPromocionBonificacion,IdPromocion"
          class="table table-bordered"
          OnRowDataBound="GvDemo2_RowDataBound" 
          OnRowDeleting="GvDemo2_RowDeleting" OnRowEditing="GvDemo2_RowEditing" OnRowCancelingEdit="GvDemo2_RowCancelingEdit" OnRowUpdating="GvDemo2_RowUpdating" >
        <HeaderStyle CssClass="headerstyle" />
        <Columns>

                <asp:BoundField DataField="IdPromocionBonificacion" Visible="false" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
                <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
                </asp:BoundField>

                 <asp:TemplateField HeaderText="Producto">
                <ItemTemplate>
                <asp:Label ID="lblprod_product" runat="server" class="form-control-plaintext" Text='<%# Eval("Producto")%>'/>
                </ItemTemplate>  
                                        
                <EditItemTemplate>                    
                <asp:TextBox ID="txtprod_cat2" runat="server" AutoCompleteType="Office"  class="form-control " Text='<%# Eval("IdProducto")%>' Visible="false"/>                    
                <asp:DropDownList ID="DDProductoEditar"  runat="server"  class="form-control buscarDNels" style="width: 100% !important;" AutoPostBack="false" OnSelectedIndexChanged="DDProductoEditar_SelectedIndexChanged">
                </asp:DropDownList>  
                </EditItemTemplate>

                <FooterTemplate>
                <asp:DropDownList ID="DDProductoi"  runat="server"  class="form-control buscarDNels" style="width: 100% !important;" AutoPostBack="false" OnSelectedIndexChanged="DDProductoi_SelectedIndexChanged"  >
                </asp:DropDownList>  
                </FooterTemplate>
                <FooterStyle  CssClass="foote" />  
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                <asp:Label ID="lblCantidad2" runat="server" class="form-control-plaintext" Text='<%# Eval("Cantidad")%>'/>
                </ItemTemplate>
                                      
                <EditItemTemplate>                    
                <asp:TextBox ID="TxtCantidadEditIns" runat="server" onKeyPress="return soloNumeros(event)" Text='<%# Eval("Cantidad")%>' style="width: 100% !important;" class="form-control "/>                    
               
                </EditItemTemplate>

                <FooterTemplate>
                <asp:TextBox ID="txtCantidad_ins2"  onKeyPress="return soloNumeros(event)" class="form-control " runat="server"  style="width: 100% !important;"  />
                </FooterTemplate>                      
                <ItemStyle  CssClass="header_p"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText = "Stock">
                <ItemTemplate>
                <asp:Label ID="LblStock" runat="server" class="form-control-plaintext" Text='<%# Eval("Stock")%>'></asp:Label>
                </ItemTemplate>
                       
                <EditItemTemplate>                    
                <asp:TextBox ID="TxtStock_ins" runat="server" onKeyPress="return soloNumeros(event)" Text='<%# Eval("Stock")%>' class="form-control "/>                    
               
                </EditItemTemplate>

                <FooterTemplate>
                <asp:TextBox ID="TxtStock" onKeyPress="return soloNumeros(event)" class="form-control " runat="server" />
                </FooterTemplate>                    
                <HeaderStyle CssClass="header_p"  />
 <FooterStyle  CssClass="foote" />   
                </asp:TemplateField>
                <asp:TemplateField HeaderText = "Grupo" >
                <ItemTemplate>
                <asp:Label ID="lblGrupo2" runat="server"   class="form-control-plaintext"  Text='<%# Eval("Grupo")%>'></asp:Label>                   
                </ItemTemplate>
                    
                <EditItemTemplate>                    
                <asp:TextBox ID="TxtGrupo_in" runat="server" Text='<%# Eval("Grupo")%>' onKeyPress="return soloNumeros(event)"  class="form-control "/>                    
               
                </EditItemTemplate>
                <FooterTemplate>
                    <div class="">
                <asp:TextBox ID="txtGrupo_ins2" runat="server" onKeyPress="return soloNumeros(event)" class="form-control" />
                  <%--<asp:LinkButton ID="btnAdd2" CommandName="AddNew_Boni" CssClass="btn btn-outline-primary" runat="server"><i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>--%>
               </div> </FooterTemplate>
                </asp:TemplateField>
                <%--<asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />--%>
             <asp:TemplateField HeaderText="Aciones">
                                <ItemTemplate>
                                 
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text=""   CommandName="Edit" ToolTip="Edit" 
                                        CommandArgument='' CssClass="btn btn-info"> <i class="fas fa-pencil-alt"></i></asp:LinkButton>
                                  <asp:LinkButton ID="lnkDelete" runat="server"    Text="Delete" CommandName="Delete"
                                        ToolTip="Delete" OnClientClick='return confirm("Elimnar?");'
                                        CommandArgument='' CssClass="btn btn-dark">  <i class="fas fa-trash-alt"></i></asp:LinkButton>
                           
                                  </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text=""  ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
                                        CommandArgument='' CssClass="btn btn-primary"> <i class="fas fa-sync-alt"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                        CommandArgument='' CssClass="btn btn-dark"><i class="fas fa-angle-double-left"></i></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text=""  Width="100%"  ValidationGroup="newGrp" CommandName="Footer" OnClick="agregarBonificacion"  ToolTip="Add"
                                        CommandArgument='' CssClass="btn btn-primary">  <i class="fa fa-plus" aria-hidden="true"></i> </asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Width="100%" Text="" CommandName="CancelNew" ToolTip="Cancel"
                                        CommandArgument='' CssClass="btn btn-warning" Visible="false">Cancelar</asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>   
        </Columns>

        </asp:GridView><br style="clear:both;margin-bottom:10px;"/></div>
  </div>
       </div>
             
                 <div class="form-group col-lg-12"   style="padding-top: 10px;">
                    <div class="form-group">
                    <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" runat="server" OnClick="BtnGuardar_Click" >
                    Guardar Promocion&nbsp;&nbsp;<i class="fa fa-save"></i> </asp:LinkButton>
                        <asp:LinkButton ID="BtnModificar" CssClass="btn btn-primary"  runat="server" OnClick="BtnModificar_Click">Modificar</asp:LinkButton>
                    <%--<asp:LinkButton ID="btnModificar_fr" class="btn btn-success" OnClick="btnMOdificar_Click"  runat="server">Modificar</asp:LinkButton>--%>
                    <asp:LinkButton ID="btnNuevo_f" class="btn btn-dark" runat="server" OnClick="btnNuevo_Click"  >Cancelar</asp:LinkButton>
                    <%--<button class="btn btn-outline-secondary" onclick="EnviarMensaje()" type="button">Enviar Notificacion &nbsp;&nbsp;<i class="fa fa-paper-plane" aria-hidden="true"></i></button>--%>
                    </div>
                    </div>
                </asp:Panel>
    <asp:HiddenField ID="hdnIdPromocion" runat="server" />


       






    <div style="display:none">

        <asp:GridView ID="Gv_Condicion" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HtmlEncode="False" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="IdCategoria" HeaderText="IdCategoria" />
                <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" />
                <asp:BoundField DataField="Grupo" HeaderText="Grupo" />
                <asp:BoundField DataField="IdCondicionM" HeaderText="IdCondicionM" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="Gv_Bonficiacion" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                <asp:BoundField DataField="grupo" HeaderText="grupo" />
                <asp:BoundField DataField="IdBoniM" HeaderText="IdBoniM" />
            </Columns>
       </asp:GridView>
        
    <asp:GridView ID="gv_insert" runat="server"></asp:GridView>
        
                       <asp:Button ID="BtnPos" runat="server"  Text="Post" OnClick="BtnPos_Click" />
              
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
     <script type="text/javascript">
         $.noConflict();
         jQuery(document).ready(function ($) {
             $('.buscarDNels').SumoSelect({ search: true, searchText: 'Buscar ....' });
         });


         function soloNumeros(e) {
             var key = window.Event ? e.which : e.keyCode
             return (key >= 48 && key <= 57)
         }
        function EnviarMensaje() {
           var Id_Promocion = $('#<%=Hdn_IdPromocion.ClientID%>').val();
          
            //if (Id_Promocion == '') {
            //    swal("Primero Cree Una Promocion!", "Advertencia", "error");
            //    return;
            //}
            var msj = '';//$('#<=HdnMensaje.ClientID%>').val();
           // alert(Id_Promocion + ' | ' + msj);
            var protocol = location.protocol;
            var slashes = protocol.concat("//");
            var host = slashes.concat(window.location.hostname);
            $.ajax({
                type: "POST",
                url: host + '/ApiDelcorpTienda/api/NotificaNuevaPromocion?id=' + Id_Promocion + '&msj=' + msj,
                // data: "{ idEmpresaMaster: '" + idempresMast + "', idEmpresa: " + ddempresa + "',  idSucursal: " + ddseucursal + "', idTrabajador: " + IdTrabajador + "', idTipoTrabajador: " + tipotrabajad + "', idHorario: " + idhorario + "', FlatLibre: " + flag + "', fechaCambio: " + fecha + "', horaInicio: " + horarinicio + "', horaSalida: " + horafin + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (resultado) {
                    swal("Noticiacion Enviada Correctamente!", "Delcorp", "success");                 
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                    var error = eval("(" + XMLHttpRequest.responseText + errorThrown+ ")");
                   
                    swal("Ocurrio un error!", "" + error + "", "error");
                },
                failure: function (r) {
                    alert(r.d.MsgValidacion);

                }
            });
         

        }
            function run() {
                var valu = document.getElementById("DDtipoPromocion").value;
                alert(valu);
            }
        $(function () {
            //$("#TxtMontoCondicion").blur(function () {
            //    var valorn = $('#TxtMontoCondicion').val();
            //    if (valorn == "") {

            //    } else {
            //        hacer_posback();
            //    }
            //});

            $('#TxtFechaIni').datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                startDate: "today",
                //minViewMode: 1,
                //todayBtn: 'linked'
                  locale: 'es-es',
            });
            $('#TxtFechaFin').datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                startDate: "today",
                //minViewMode: 1,
                //todayBtn: 'linked'
                locale: 'es-es',
            });
            $('#TXtBuscFecInicio').datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                //startDate: "today",
                //minViewMode: 1,
                //todayBtn: 'linked'
                locale: 'es-es',
            });
            $('#TxtBuscFechFin').datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                //startDate: "today",
                //minViewMode: 1,
                //todayBtn: 'linked'
                locale: 'es-ES',
            });               
            
        });
        function hacer_posback() {
             document.getElementById('<%= BtnPos.ClientID %>').click();
        }
        function enviarnotificacion(idusuario, titulo, descripcion) {
            //alert(idusuario + titulo + ' '+descripcion );
            //return;
            $.ajax({
                type: "GET", url: 'http:///ApiDelcorpTienda/api/NotificacionPromocionTexto?IdUsuario=' + idusuario + '&id=1&titulo=&msj=' + descripcion + '&rutafoto=',

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (resultado) {
                    swal("Notificación Enviada Correctamente!", "Delcorp", "success");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                    var error = eval("(" + XMLHttpRequest.responseText + errorThrown + ")");

                    swal("Ocurrio un error!", "" + error + "", "error");
                },
                failure: function (r) {
                    alert(r.d.MsgValidacion);

                }
            });


        }

    
         // <!--
        function validateFloatKeyPress(el, evt, ints, decimals) {
            el.value = el.value.replace(",", ".");
            // El punto lo cambiamos por la coma
            //if (evt.keyCode == 46) {
            //    evt.keyCode = 44;

            //}

            // Valores numéricos
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57)) {
                return false;
            }

            // Sólo una coma
            if (charCode == 46) {
                if (el.value.indexOf(".") !== -1) {
                    return false;
                }

                return true;
            }

            // Determinamos si hay decimales o no
            if (el.value.indexOf(".") == -1) {
                // Si no hay decimales, directamente comprobamos que el número que hay ya supero el número de enteros permitidos
                if (el.value.length >= ints) {
                    return false;
                }
            }
            else {

                // Damos el foco al elemento
                el.focus();

                // Para obtener la posición del cursor, obtenemos el rango de la selección vacía
                var oSel = document.selection.createRange();

                // Movemos el inicio de la selección a la posición 0
                oSel.moveStart('character', -el.value.length);

                // La posición de caret es la longitud de la selección
                iCaretPos = oSel.text.length;

                // Distancia que hay hasta la coma
                var dec = el.value.indexOf(".");

                // Si la posición es anterior a los decimales, el cursor está en la parte entera
                if (iCaretPos <= dec) {
                    // Obtenemos la longitud que hay desde la posición 0 hasta la coma, y comparamos
                    if (dec >= ints) {
                        return false;
                    }
                }
                else { // El cursor está en la parte decimal
                    // Obtenemos la longitud de decimales (longitud total menos distancia hasta la coma menos el carácter coma)
                    var numDecimals = el.value.length - dec - 1;

                    if (numDecimals >= decimals) {
                        return false;
                    }
                }
            }

            return true;
        }
       // -->
    </script>
    </form>
</asp:Content>
