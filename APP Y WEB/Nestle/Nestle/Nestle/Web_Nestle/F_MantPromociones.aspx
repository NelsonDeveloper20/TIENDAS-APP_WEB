<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_MantPromociones.aspx.cs" Inherits="Web_Nestle.F_MantPromociones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           
<script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="jsFecha/bootstrap-datepicker.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
    <script src="jsFecha/jquery2_2_4.js"></script>
<%--    <script src="Js/jquery.sumoselect.min.js"></script>
    <link href="Js/sumoselect.css" rel="stylesheet" />--%>
 
  <style> 
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
  </style> <script type="text/javascript">
	    function shrinkandgrow(input) {
	        var displayIcon = "img" + input;
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
    </script>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager" runat="server" />         
<div class="row">
<div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 5px;margin-top: 10px;">
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
                 
        <fieldset class="col-md-12">    	
        <legend>Promocion</legend>	
        <div class="form-row">  
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
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
                <div class="form-group col-md-2" style="    margin-top: 8px;">
                    <br style="clear:both"/>
                    <span class="input-group">
                        <asp:LinkButton ID="BtnBuscar" Width="100%" runat="server" OnClick="BtnBuscar_Click" class="btn btn-success" style="float: left"> <i class="glyphicon glyphicon-search"></i>Buscar</asp:LinkButton>
                       </span>
                </div>
                      <div class="form-group col-md-2"  style="    margin-top: 8px;">
                    <br style="clear:both"/>
                    <span class="input-group">
                    <asp:LinkButton ID="LinkButton1" Width="100%"  runat="server" class="btn btn-primary" OnClick="BtnNuevo_Click" >Nuevo</asp:LinkButton>
                    </span>
                </div></div>
                    <div class="col_lg-12">
                        <div class="table-responsive">
<asp:GridView ID="GvPromociones" runat="server" ForeColor="#333333" class="table table-bordered" AutoGenerateColumns="false" DataKeyNames="IdPromocion"
OnRowDataBound="GvPromociones_OnRowDataBound"     
    OnRowCommand="GvPromociones_RowCommand"  >
		<Columns>
		<asp:TemplateField ItemStyle-Width="20px">
		<ItemTemplate>
			<a href="JavaScript:shrinkandgrow('div<%# Eval("IdPromocion") %>');">
                <button type="button" class="btn btn-outline-primary btn-circle"><i class="fa fa-plus" aria-hidden="true"></i> </button>
				<img alt="Details" id="imgdiv<%# Eval("IdPromocion") %>" src="http://201.234.124.219/webgesthorario/imagenes/detail.gif" style="display:none"/>
			</a>
			<div id="div<%# Eval("IdPromocion") %>" style="display: none;">
				<asp:GridView ID="GridView2" runat="server" class="table table-bordered" Width="100%" AutoGenerateColumns="false" DataKeyNames="IdPromocion"
                HeaderStyle-ForeColor="White">
				<Columns>
                    <%--ItemStyle-Width="150px"--%>
					<asp:BoundField  DataField="Cantidad" HeaderText="Cantidad" />
					<asp:BoundField  DataField="NombrePro" HeaderText="Producto-Categoria" />
					<asp:BoundField  DataField="Descripcion" HeaderText="Descripcion" />
					<asp:BoundField  DataField="cant_Boni" HeaderText="Cantidad Bonificacion" />
					<asp:BoundField  DataField="Stock" HeaderText="Stock" />
				</Columns> <HeaderStyle  BackColor="#f5f5f5" ForeColor="#252020" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"  Font-Size="12px"   /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
				</asp:GridView>
			</div>
		</ItemTemplate>
		</asp:TemplateField>
			<asp:BoundField ItemStyle-Width="150px" DataField="IdPromocion" HeaderText="ID" />
			<asp:BoundField ItemStyle-Width="100px" DataField="Fecha_Inicio" HeaderText="Fecha_Inicio" />
			<asp:BoundField ItemStyle-Width="100px" DataField="Fec_Fin" HeaderText="Fec_Fin" />
			<asp:BoundField ItemStyle-Width="100px" DataField="Condicion" HeaderText="Condicion" />
			<asp:BoundField ItemStyle-Width="100px" DataField="TipoCondicion" HeaderText="TipoCondicion" />
			<asp:BoundField ItemStyle-Width="100px" DataField="TipoPromocion" HeaderText="TipoPromocion" />
			<asp:BoundField ItemStyle-Width="100px" DataField="TipoBonificacion" HeaderText="TipoBonificacion" />
			<asp:BoundField ItemStyle-Width="100px" DataField="Producto" HeaderText="Producto" />
			<asp:BoundField ItemStyle-Width="100px" DataField="Categoria" HeaderText="Categoria" />
			<asp:BoundField ItemStyle-Width="100px" DataField="MontoBonificacion" HeaderText="MontoBonificacion" />
            

              <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ShowHeader="False" HeaderText="Noficacion">
            <ItemTemplate> 

            <asp:LinkButton ID="BtnSpush"  runat="server" Text="" CssClass="btn btn-outline-primary"
            CommandArgument="<%# ((GridViewRow)Container).RowIndex  %>"
            CommandName="EnviarPush">               
                 <%# Eval("FlagNotificacion").ToString() == "0" ? "<img src='http://201.234.124.219/webgesthorario/Iconos/accept.png' width='23px' height='20px'/>" : "Enviar<i class='fa fa-paper-plane' aria-hidden='true'></i>" %>  
            </asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ShowHeader="False" HeaderText="Eliminar">
            <ItemTemplate>
            <asp:LinkButton ID="btnDelete" runat="server" Text="" CssClass="btn btn-outline-danger"
            CommandArgument="<%# ((GridViewRow)Container).RowIndex  %>"
            CommandName="Eliminar" OnClientClick="return confirm('¿Eliminar?');" >Eliminar</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="FlagNotificacion" HeaderText="FlagNotificacion" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
            <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
            </asp:BoundField>  <%-- 13 --%>
		</Columns> 
     <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"  Font-Size="11px"   /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
</asp:GridView></div></div>

         </asp:Panel>
            <asp:Panel ID="Panel_Agregar" class="col-lg-12" runat="server">

                <div class="col-lg-12">

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
         </div>    </div>
            <div class="col-lg-12">
            <asp:UpdatePanel ID="panel1" class="form-row" runat="server">
            <ContentTemplate>
                    <div class="form-group col-md-2">
                    <label style="float: inherit;">Tipo Usuario</label>
                    <asp:DropDownList ID="DDTipoUsuario"  runat="server"  class="form-control" style="width: 100% !important;"  >
                    </asp:DropDownList>                
                    </div>  
                    <div class="form-group col-md-2">
                    <label style="float: inherit;">Condicion</label>
                    <asp:DropDownList ID="DDCondicion"  runat="server"  class="form-control" style="width: 100% !important;"  >
                    </asp:DropDownList>                
                    </div>   
                    <div class="form-group col-md-2">
                    <label style="float: inherit;">Tipo Condicion</label>
                    <asp:DropDownList ID="DDTipoCondicion"  runat="server"  class="form-control" style="width: 100% !important;"  >
                    </asp:DropDownList>                
                    </div> 
                    <div class="form-group col-md-2">
                    <label style="float: inherit;">Tipo Promocion</label>
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
                        <asp:TextBox ID="TxtMontoBonifica" runat="server" placeholder="Monto Bonificacion "  class="form-control" ClientIDMode="Static"></asp:TextBox>
                         </div>    
                    <div class="form-group col-sm-3" id="producto" runat="server">
                    <label style="float: inherit;">Producto</label>
                    <asp:DropDownList ID="DDTipoProducto"  runat="server"  class="form-control" style="width: 100% !important;"  AutoPostBack="true" OnSelectedIndexChanged="DDTipoProducto_SelectedIndexChanged" >
                    </asp:DropDownList>                
                    </div>    
                    <div class="form-group col-sm-3" runat="server" id="categoria">
                    <label style="float: inherit;">Categoria</label>
                    <asp:DropDownList ID="DDtipoCategoria"  runat="server"  class="form-control" style="width: 100% !important;" AutoPostBack="true" OnSelectedIndexChanged="DDtipoCategoria_SelectedIndexChanged"  >
                    </asp:DropDownList>                
                    </div>                  
                    <div class="form-group col-md-3" style="display:none">
                    <label>Cantidad</label>                                 
                    <input type="text" id="Text1" placeholder="Cantidad "  ClientIDMode="Static" runat="server"   class="form-control"/>      
                    </div>  
        
                    <%--  </div>--%>
                    <%--     </ContentTemplate>  </asp:UpdatePanel>--%>
                    <div class="table-responsive" >              

                    <asp:GridView runat="server" ID="gvDetails" ForeColor="#333333"  Width="100%" class="table table-bordered"
                    GridLines="None"  ShowFooter="True" AllowPaging="True" AutoGenerateColumns="False" 
                    DataKeyNames="idPromBoni,idusuario" OnPageIndexChanging="gvDetails_PageIndexChanging"
                    OnRowCancelingEdit="gvDetails_RowCancelingEdit"  OnRowCreated="grvMergeHeader_RowCreated"
                    OnRowEditing="gvDetails_RowEditing" OnRowUpdating="gvDetails_RowUpdating" 
                    OnRowDeleting="gvDetails_RowDeleting" OnRowCommand ="gvDetails_RowCommand" OnRowDataBound="gvDetails_RowDataBound" >
                    <Columns>

    
                    <asp:BoundField DataField="idPromBoni" Visible="false" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
                    <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
                    </asp:BoundField>

                    <%--   <asp:BoundField DataField="idPromBoni">
                    </asp:BoundField>--%>

                    <asp:TemplateField HeaderText="Producto_Categoria">
                    <ItemTemplate>
                    <asp:Label ID="LblProducPromo" runat="server" Text='<%# Eval("idprodProm")%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="TxtProductPromo" Enabled="false"  CssClass="form-control"  runat="server" Text='<%# Eval("idprodProm")%>'/>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="TxtInsProdProm" Enabled="false" placeholder="" CssClass="form-control" runat="server" />
                    </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad Promocion">
                    <ItemTemplate>
                    <asp:Label ID="lblCantProm" runat="server" Text='<%# Eval("cantidadProm")%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="TxtCantProm"  CssClass="form-control" runat="server" Text='<%# Eval("cantidadProm")%>'/>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="TxtCanProm"  placeholder="Cantidad" CssClass="form-control"  runat="server" />
                    </FooterTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Descripcion">
                    <ItemTemplate>
                    <asp:Label ID="LblDescripcion" runat="server" Text='<%# Eval("Descripcion")%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="TxtDescripcion" TextMode="MultiLine"  CssClass="form-control" runat="server" Text='<%# Eval("Descripcion")%>'/>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="TxtInsDescripcion" TextMode="MultiLine" placeholder="Descripcion"  CssClass="form-control"  runat="server" />
                    </FooterTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Producto Bonificacion">
                    <ItemTemplate>
                    <asp:Label ID="idprox" runat="server" Text='<%# Eval("IdProdcuto_Categoria")%>' style="display:none"/>
                    <asp:Label ID="LblProdBoni" runat="server" Text='<%# Eval("idprodBoni")%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <%--<asp:TextBox ID="TxtProdBoni" CssClass="form-control"  runat="server" Text='<%# Eval("idprodBoni")%>'/>
                    --%>
                    <asp:DropDownList ID="DDprod_EditBoni"  runat="server"  class="form-control" style="width: 100% !important;"  >
                    </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>    
                    <asp:DropDownList ID="DDProdBoniProd"  runat="server"  class="form-control" style="width: 100% !important;"  >
                    </asp:DropDownList>  
                    <%--<asp:TextBox ID="TxtInsProdBoni" CssClass="form-control"  runat="server" />--%>
                    </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad Bonificacion">
                    <ItemTemplate>
                    <asp:Label ID="LblCantBoni" runat="server" Text='<%# Eval("cantidadBoni")%>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="TxtCantBoni" CssClass="form-control"  runat="server" Text='<%# Eval("cantidadBoni")%>'/>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="TxtIsnCantBoni" placeholder="Cantidad Bonificacion"  CssClass="form-control"  runat="server" />
                    </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText = "Stock" ItemStyle-Width="60px">
                    <ItemTemplate>
                    <asp:Label ID="LblStock" runat="server" Text='<%# Eval("stockBoni")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="TxtStock" CssClass="form-control"  runat="server" Text='<%# Eval("stockBoni")%>'/>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <div class="input-group">
                    <asp:TextBox ID="TxtInsStock"  placeholder="Stock"  CssClass="form-control"  runat="server" />
                    &nbsp;&nbsp;&nbsp;   <asp:LinkButton ID="btnAdd" CommandName="AddNew" CssClass="btn btn-outline-primary" runat="server"><i class="fa fa-plus" aria-hidden="true"></i>&nbsp;&nbsp;Add</asp:LinkButton>
                    </div>
                    </FooterTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="false" ShowDeleteButton="true" />
                    </Columns>
    
                    <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                    </asp:GridView>
                        </div>
                    <div style="display:none">
                    <asp:GridView ID="GvInsert" runat="server" AutoGenerateColumns="False">
                    <Columns>
                    <asp:BoundField DataField="cantidadProm" HeaderText="cantidadProm" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="IdProdcuto_Categoria" HeaderText="IdProdcuto_Categoria" />
                    <asp:BoundField DataField="cantidadBoni" HeaderText="cantidadBoni" />
                    <asp:BoundField DataField="stockBoni" HeaderText="stockBoni" />
                    </Columns>
                    </asp:GridView>
                    </div>
                        <div class="form-group col-lg-12"   style="padding-top: 10px;">
                    <div class="form-group">
                    <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" runat="server" OnClick="BtnGuardar_Click" >
                    Guardar Promocion&nbsp;&nbsp;<i class="fa fa-save"></i> </asp:LinkButton>
                    <%--<asp:LinkButton ID="btnModificar_fr" class="btn btn-success" OnClick="btnMOdificar_Click"  runat="server">Modificar</asp:LinkButton>--%>
                    <asp:LinkButton ID="btnNuevo_f" class="btn btn-primary" runat="server" OnClick="btnNuevo_Click"  >Cancelar</asp:LinkButton>
                    <%--<button class="btn btn-outline-secondary" onclick="EnviarMensaje()" type="button">Enviar Notificacion &nbsp;&nbsp;<i class="fa fa-paper-plane" aria-hidden="true"></i></button>--%>
                    </div>
                    </div>
                        
            <asp:HiddenField ID="Hdn_IdPromocion" ClientIDMode="Static" runat="server" />
            <asp:Label ID="lblresult" runat="server"></asp:Label>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvDetails" />
            </Triggers>
            </asp:UpdatePanel>
            </div>

            </asp:Panel>
       </div>     
        </div>

        </fieldset>
        <fieldset class="col-md-12" style="    margin-top: 10px; display:none">    	
        <legend>Bonificaciones</legend>	<div class="form-row"> 
                      
             
                    <div class="form-group col-sm-3">
                    <label style="float: inherit;">Producto</label>
                    <asp:DropDownList ID="DDProdBoni"  runat="server"  class="form-control" style="width: 100% !important;"  >
                    </asp:DropDownList>                
                    </div>         
                    <div class="form-group col-md-3">
                    <label>Cantidad</label>                                 
                    <input type="text" id="Text2" placeholder="Cantidad "  ClientIDMode="Static" runat="server"   class="form-control"/>      
                    </div>	        
                    <div class="form-group col-md-2">
                    <label>Stock Bonificaciones</label>                                 
                    <input type="text" id="Text3" placeholder="Cantidad "  ClientIDMode="Static" runat="server"   class="form-control"/>      
                    </div> 

        </div>			
        </fieldset>		
        <div class="clearfix"></div>
                    

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
            
        function EnviarMensaje() {
           var Id_Promocion = $('#<%=Hdn_IdPromocion.ClientID%>').val();
            Id_Promocion='25'
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
    </script>
 </form>
</asp:Content>
