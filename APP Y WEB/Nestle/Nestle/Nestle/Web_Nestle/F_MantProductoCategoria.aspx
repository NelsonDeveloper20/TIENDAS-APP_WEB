<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_MantProductoCategoria.aspx.cs" Inherits="Web_Nestle.F_MantProductoCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
<script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>

   
    <style type="text/css"> 
    #MenuTab a.static.selected {
      border: 1px solid transparent;
    border-top-left-radius: .25rem;
    border-top-right-radius: .25rem;
            color: #ffffff;
    border-color: #dee2e6 #dee2e6 #fff;
            background-color: rgba(0, 123, 255, 1.00);
}
    .chk_sub label{
        font-size:14px !important;
    }
 #MenuTab a.static {
  
/*nelson :) */
            border: 1px solid transparent;
    border-top-left-radius: .25rem;
    border-top-right-radius: .25rem;display: block;
    padding: .5rem 1rem;    color: #007bff;
    text-decoration: none;
    background-color: #e9ececd1;
    -webkit-text-decoration-skip: objects;
    }
 .btn-group-sm .btn-fab{
  position: fixed !important;
  right: 68%;
}
.btn-group .btn-fab{
  position: fixed !important;
  right: 68%;
}
#main{
  bottom: 20px;
}
#mail{
  bottom: 80px
}
#sms{
  bottom: 125px
}
#autre{
  bottom: 170px
}       .btn {
    display: inline-block;
    font-weight: 400;
    text-align: center;
    white-space: nowrap;
    vertical-align: middle;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    border: 1px solid transparent;
    padding: .375rem .75rem;
    font-size: 0.9rem;
    line-height: 1.5;
    border-radius: .25rem;
    transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
}
/*end*/ .clase_div{
      /*border:1px solid green;
		padding:10px;
		margin:5px;*/
    } .treeNode
        {
            /* position: relative; */
            padding: 3px;
    margin-left: 8px;

    margin-bottom: -1px;
    background-color: #fff;
    border: 1px solid rgba(47, 123, 217, 0.23);
        }
     .rootNode
        {
            font-size:18px;
            width:100%;
            border-bottom:Solid 1px black;
            color:#337ab7;
        }
     .leafNode {
            /*border: Dotted 2px black;
            padding: 10px;
            background-color: #eeeeee;
            font-weight: bold;*/
        }
     .selectNode 
   {
        /*background-color:Black;
        border:Dotted 2px black;
        font-weight:bold;
        color:#fff;*/
    }img {
         margin-top:-7px;
         /*width:35px;*/
}

     td img {
         width:25px
}
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
    

          .tabs li
        {
           
    margin-right: 55px;   
        margin-left: -10px;
   font-weight: 500;
     color: #495057;
   /*background:#fff;*/
        }
        

    .tabs
        {
            position:relative;
            top:1px;
            left:10px;
        }
        .tab
        {
             border-color: #dee2e6 #dee2e6 #fff;
            /*background-color:#eeeeee;*/
               padding: 1px 11px;font-weight: 600;
        }
        .selectedTab
        {
                      color: #495057;
    background-color: #fff;
    border-color: #dee2e6 #dee2e6 #fff;

       border-radius: 5px 5px 0px 0px;
    text-decoration: none;
    border-style: none;
   color:#1d75d4;    
            background-color:white;
            border-top:1px solid #dee2e6;
border-right:1px solid #dee2e6;
border-bottom:1px solid #ffffff;
border-left:1px solid #dee2e6;
           
        }
        .tabContents
        {
            border:solid 1px #dee2e6;
            padding:10px;
            background-color:white;
              border-radius: 2px 2px 2px 2px;
        }
/*tab*/
        .headern{
            text-align:center;
        }
        .sel_nel{
            pointer-events:none;
        }
         .btn-default{
    height:33px;
       width: 152px;
          min-width: 100px;
}.btn{
       width: 100%;
 }
         .lunesaviernes{
             padding-left: 23px;
         }
        .hidden-field
 {
     display:none;
 }.wrapper {
   width: 50%;
}
           .icontext{
             background: url(Iconos/time.png) no-repeat right;
    padding-left: 17px;
    text-align: center;
    border: 1px solid #ccc;
    cursor: pointer;
        }
         .rounded_corners
    {
       
        -webkit-border-radius: 8px;
        -moz-border-radius: 8px;
        border-radius: 8px;
        overflow: hidden;
    }
    .rounded_corners td, .rounded_corners th
    {
       
        font-family: Arial;
        font-size: 10pt;
        text-align: center;
    }
    .rounded_corners table table td
    {
        border-style: none;
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
/*HOVER IMG*/
.imageBox {
  position: relative;
  float: left;
}

.imageBox .hoverImg {
  position: absolute;
  left: 0;
  top: 0;
  display: none;
}

.imageBox:hover .hoverImg {
  display: block;
}.imageBox:hover .hoverImg {
    display: block;
}


 .imageBox .imageInn {
  position: absolute;
  left: 0;
  top: 0;
  display: block;
}

.imageBox:hover .imageInn {
  display: none;
}.imageBox:hover .imageInn {
    display: none;
}
 
/*END HOVER*/
/*  bhoechie tab */
div.bhoechie-tab-container{
  z-index: 10;
  background-color: #ffffff;
  padding: 0 !important;
  border-radius: 4px;
  -moz-border-radius: 4px;
  border:1px solid #ddd;
  margin-top: 20px;
  margin-left: 50px;
  -webkit-box-shadow: 0 6px 12px rgba(0,0,0,.175);
  box-shadow: 0 6px 12px rgba(0,0,0,.175);
  -moz-box-shadow: 0 6px 12px rgba(0,0,0,.175);
  background-clip: padding-box;
  opacity: 0.97;
  filter: alpha(opacity=97);
}
div.bhoechie-tab-menu{
  padding-right: 0;
  padding-left: 0;
  padding-bottom: 0;
}
div.bhoechie-tab-menu div.list-group{
  margin-bottom: 0;
}
div.bhoechie-tab-menu div.list-group>a{
  margin-bottom: 0;
}
div.bhoechie-tab-menu div.list-group>a .glyphicon,
div.bhoechie-tab-menu div.list-group>a .fa {
  color: #5A55A3;
}
div.bhoechie-tab-menu div.list-group>a:first-child{
  border-top-right-radius: 0;
  -moz-border-top-right-radius: 0;
}
div.bhoechie-tab-menu div.list-group>a:last-child{
  border-bottom-right-radius: 0;
  -moz-border-bottom-right-radius: 0;
}
div.bhoechie-tab-menu div.list-group>a.active,
div.bhoechie-tab-menu div.list-group>a.active .glyphicon,
div.bhoechie-tab-menu div.list-group>a.active .fa{
  background-color: #5A55A3;
  background-image: #5A55A3;
  color: #ffffff;
}
div.bhoechie-tab-menu div.list-group>a.active:after{
  content: '';
  position: absolute;
  left: 100%;
  top: 50%;
  margin-top: -13px;
  border-left: 0;
  border-bottom: 13px solid transparent;
  border-top: 13px solid transparent;
  border-left: 10px solid #5A55A3;
}

div.bhoechie-tab-content{
  background-color: #ffffff;
  /* border: 1px solid #eeeeee; */
  padding-left: 20px;
  padding-top: 10px;
}

div.bhoechie-tab div.bhoechie-tab-content:not(.active){
  display: none;
}
/*dsfdf*/
         .hidden-field
 {
     display:none;
 }.wrapper {
   width: 50%;
}
           .icontext{
             background: url(Iconos/time.png) no-repeat right;
    padding-left: 17px;
    text-align: center;
    border: 1px solid #ccc;
    cursor: pointer;
        }
         .rounded_corners
    {
       
        -webkit-border-radius: 8px;
        -moz-border-radius: 8px;
        border-radius: 8px;
        overflow: hidden;
    }
    .rounded_corners td, .rounded_corners th
    {
       
        font-family: Arial;
        font-size: 10pt;
        text-align: center;
    }
    .rounded_corners table table td
    {
        border-style: none;
    }
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

.loader {
    position: fixed;
    left: 0px;
    top: 0px;
    width: 100%;
    height: 100%;
    z-index: 9999;
    background: url('http://superstorefinder.net/support/wp-content/uploads/2018/01/blue_loading.gif') 50% 50% no-repeat rgb(249,249,249);
    opacity: .8;
}
.MenuTab_1 a.static.selected {
      border: 1px solid transparent;
    border-top-left-radius: .25rem;
    border-top-right-radius: .25rem;
            color: #ffffff;
    border-color: #dee2e6 #dee2e6 #fff;
            background-color: rgba(0, 123, 255, 1.00);
                text-decoration:none !important;
                    border-radius: 3px !important;
}
a.active{
      border: 1px solid transparent;
    border-top-left-radius: .25rem;
    border-top-right-radius: .25rem;
            color: #ffffff;
    border-color: #dee2e6 #dee2e6 #fff;
            background-color: rgba(0, 123, 255, 1.00);
             text-decoration:none !important;
                 border-radius: 3px !important;
}
a.active:hover{
      border: 1px solid transparent;
    border-top-left-radius: .25rem;
    border-top-right-radius: .25rem;
            color: #ffffff;
    border-color: #dee2e6 #dee2e6 #fff;
            background-color: rgba(0, 123, 255, 1.00);
            text-decoration:none !important;

}.tab {
    border-color: #dee2e6 #dee2e6 #fff;
    background-color: #eeeeee;
    padding: 8px !important;
    font-weight: 500 !important;
}

a:active, a:hover {
      border: 1px solid transparent;
    border-top-left-radius: .25rem;
    border-top-right-radius: .25rem;
            color: #ffffff;
    border-color: #dee2e6 #dee2e6 #fff;
            background-color: rgba(0, 123, 255, 1.00);
            text-decoration:none !important;
}
</style>
<form id="form1" runat="server">
    
    <asp:HiddenField ID="HdnId_Up" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="HdnModif" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="Hd_IdPadre" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="Hd_ModifPadre" ClientIDMode="Static" runat="server" />
<asp:ScriptManager ID="ScriptManager" runat="server" />         
           
            <div class="col" style="margin-top: 24px;">    
           
               

        <div class="col-md-12" >   

            <asp:Menu ID="MenuTab"               
         Width="100%" ClientIDMode="Static"
            runat="server" 
           Orientation="Horizontal"
        StaticMenuItemStyle-CssClass="tab"
        StaticSelectedStyle-CssClass="active"
        CssClass="nav nav-tabs"
        
               OnMenuItemClick="MenuTab_MenuItemClick">
               <Items>
                   <asp:MenuItem  Value="0" Text="Asignar Categoria" Selected="True"/>
                   <asp:MenuItem  Value="1" Text="Modificar Productos Con Categoria"/>
               </Items>

<%--<StaticMenuItemStyle CssClass="tab"></StaticMenuItemStyle>--%>

<%--<StaticSelectedStyle BackColor="#FF0066"></StaticSelectedStyle>--%>
           </asp:Menu>
              <div class="tabContents">
           <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
               <asp:View ID="View1" runat="server">
               
        <div class="form-row">
                   
        <div class="col-lg-12"></div>
        <div class="card border-primary mb-3">
               <div class="card-header text-black"> <h5 class="page-title" style="    font-weight: 500;">Categoria</h5></div>
        
        <asp:TreeView ID="treeViewProductos" NodeStyle-CssClass="treeNode"  ClientIDMode="Static" ShowCheckBoxes="All" AutoPostBack="true" runat="server" 
        OnTreeNodeCheckChanged="treeViewProductos_TreeNodeCheckChanged" >                           
        </asp:TreeView>
        </div>

        <div class="form-group col-lg-9">
                           <div class="card border-primary mb-12">
  <div class="form-row">     
      <asp:Panel ID="Panel2" DefaultButton="BtnBuscar" CssClass="form-group col-md-6" style="margin-left: 5px;   margin-bottom: 0px;" runat="server">
          <br style="clear:both"/>
          <%--<div class="form-group col-md-6" style="  margin-left: 5px;   margin-bottom: 0px;"><br style="clear:both"/>--%>
<div class="input-group mb-3">
<input type="text" class="form-control" placeholder="Ingrese Nombre de Producto" runat="server" id="TxtBuscarG" aria-describedby="basic-addon2">
<div class="input-group-append">
<asp:LinkButton ID="BtnBuscar" CssClass="btn btn-outline-secondary" BackColor="#5A6169" ForeColor="#FFFFFF" runat="server" OnClick="BtnBuscar_Click"><i class="fa fa-search"></i></asp:LinkButton>
</div>
</div>

<%--</div>--%>
      </asp:Panel>

        <div class="form-group col-md-3">
               <br style="clear:both"/>
        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" OnClick="BtnGuardar_Click"><i class="fa fa-save"></i> Guardar</asp:LinkButton>
       
        </div></div>

        <div class="">
            <asp:UpdatePanel ID="panel1" class="table-responsive" runat="server">
<ContentTemplate>
        <asp:GridView ID="GVPRODUCTO"  runat="server" AutoGenerateColumns="False" 
        GridLines="None" DataKeyNames="IdProducto"
        CssClass="table table-bordered" Width="100%">
        <HeaderStyle  BackColor="#0078D7" ForeColor="White"  Font-Size="12px"  HorizontalAlign="Center" VerticalAlign="Middle"/>  
        <Columns>
            
        <asp:BoundField DataField="IdProductoTxt" HeaderText="IdProductoTxt" />
        <asp:BoundField DataField="NombrePro" HeaderText="Nombre Producto" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" />
            

        <asp:TemplateField HeaderStyle-CssClass="lunesaviernes">
        <HeaderStyle CssClass="lunesaviernes"></HeaderStyle>
        <ItemStyle HorizontalAlign="Center" Width="50px" Wrap="False" /> 
        <HeaderTemplate>
        <label>
        <asp:CheckBox ID = "chkAll" runat="server" AutoPostBack="true" title="Seleccionar todo" OnCheckedChanged="OnCheckedChanged"/>
        </label>
        </HeaderTemplate>
        <ItemTemplate>  
        <div class="form-group" >
        <div class="checkbox">
        <label style="font-size: 1.5em">    
        <asp:CheckBox runat="server" ID="chkselec" AutoPostBack="false" OnCheckedChanged="OnCheckedChanged" />                      
        <span class="cr" style="border: 2px solid #23A9E1;"><i class="cr-icon fa fa-check"></i></span>
        </label>
        </div></div>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="IdFabricante" HeaderText="" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
        <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
        </asp:BoundField>
        </Columns>
        <RowStyle font-size="12px"   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
        </asp:GridView>  

            </ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="GVPRODUCTO" />
</Triggers>
</asp:UpdatePanel>     
         
        </div>
                 </div>
        </div>

        </div>
            <%--    <div class="btn-group" style="    z-index: 99;">
        <div" class="btn-fab" id="main">
        
        </div>
      </div>--%>
               </asp:View>
               <asp:View ID="View2" runat="server">
                
               <div class="form-row">                          
                   <div class="col-lg-12">  </div>
                        <%--  <div class="col-lg-3">--%>
        <div class="card border-primary mb-3">
                     <div class="card-header text-black"> <h5 class="page-title" style="    font-weight: 500;">Categoria</h5></div>
                         <asp:TreeView ID="TrevModifi" NodeStyle-CssClass="treeNode"  ClientIDMode="Static" ShowCheckBoxes="All" AutoPostBack="true" runat="server" 
                        OnTreeNodeCheckChanged="treeViewProductos_TreeNodeCheckChanged" >                           
                        </asp:TreeView>
                      </div>

                       <div class="col-lg-9"> 
                           <div class="card border-primary mb-12">
                               <div class="form-row">
                                    <asp:Panel ID="Panel3" DefaultButton="BtnBuscarModif" CssClass="form-group col-md-6" style="margin-left: 5px;   margin-bottom: 0px;" runat="server">
          <br style="clear:both"/>
<%--<div class="form-group col-md-6" style="  margin-left: 5px;   margin-bottom: 0px;"><br style="clear:both"/>--%>
<div class="input-group mb-3">
<input type="text" class="form-control" runat="server" id="TxtBuscarModific" placeholder="Ingrese Nombre de Producto" aria-describedby="basic-addon2">
<div class="input-group-append">
<asp:LinkButton ID="BtnBuscarModif" CssClass="btn btn-outline-secondary" BackColor="#5A6169" ForeColor="#FFFFFF" runat="server" OnClick="BtnBuscarModif_Click"><i class="fa fa-search"></i></asp:LinkButton>
</div>
</div>

<%--</div>--%></asp:Panel>
                        <div class="form-group col-md-3"><br style="clear:both"/>
                <asp:LinkButton ID="btnModificar" CssClass="btn btn-success" runat="server" OnClick="btnModificar_Click" ><i class="fa fa-save"></i> Modificar</asp:LinkButton>
                </div></div>
                    
                              <div class="">
                                  <asp:UpdatePanel ID="UpdatePanel1" class="table-responsive" runat="server">
<ContentTemplate>
<asp:GridView ID="GvModificar"  runat="server" AutoGenerateColumns="False" 
 GridLines="None" DataKeyNames="IdProducto"
    CssClass="table table-bordered" Width="100%">
<HeaderStyle  BackColor="#0078D7" ForeColor="White"  Font-Size="12px"  HorizontalAlign="Center" VerticalAlign="Middle"/>  
<Columns>
            
    <asp:BoundField DataField="IdProductoTxt" HeaderText="IdProductoTxt" />
    <asp:BoundField DataField="NombrePro" HeaderText="Nombre Producto" />
    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
    <asp:BoundField DataField="Precio" HeaderText="Precio" />
    <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
            

<asp:TemplateField HeaderStyle-CssClass="lunesaviernes">
<HeaderStyle CssClass="lunesaviernes"></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Width="50px" Wrap="False" /> 
<HeaderTemplate>
<label>
<asp:CheckBox ID = "chkAll2" runat="server" AutoPostBack="true" title="Seleccionar todo" OnCheckedChanged="OnCheckedChanged2"/>
</label>
</HeaderTemplate>
<ItemTemplate>  
<div class="form-group" >
<div class="checkbox">
<label style="font-size: 1.5em">    
<asp:CheckBox runat="server" ID="chkModif" AutoPostBack="false" OnCheckedChanged="OnCheckedChanged" />                      
<span class="cr" style="border: 2px solid #23A9E1;"><i class="cr-icon fa fa-check"></i></span>
</label>
</div></div>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="IdFabricante" HeaderText="" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
<HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
</asp:BoundField>
</Columns>
<RowStyle font-size="12px"   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
</asp:GridView>      
     </ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="GvModificar" />
</Triggers>
</asp:UpdatePanel>  
                              </div></div>
                 
                       </div>
                 
                        

                           </div>
           
               </asp:View>
           </asp:MultiView>
        </div>


        </div>

            </div> 
    <script>
         function fireCheckChanged_modif() {

            var treeNode = event.srcElement || event.target;
            if (treeNode.tagName == "INPUT" && treeNode.type == "checkbox") {
                if (treeNode.checked) {
                    uncheckOthers_modif(treeNode.id);
                }              
            }
            var selected = "";
            var valuee = "";
            var id_padre = "";
            //Reference the TreeView.
            var tree = document.getElementById("<%=TrevModifi.ClientID %>");
            //Reference the CheckBoxes in TreeView.
            var checkboxes = tree.getElementsByTagName("INPUT");
            //Loop through the CheckBoxes.
            for (var i = 0; i < checkboxes.length; i++) {
                //If CheckBox is checked.
                if (checkboxes[i].checked) {
                    //Fetch the Text from the adjacent SPAN element.
                    var text = checkboxes[i].nextSibling.innerHTML;
                    //Fetch the Value from the Title(ToolTip) of CheckBox.
                    var value = checkboxes[i].title;
                    var idpadree = checkboxes[i].img;
                    id_padre += idpadree;
                    valuee += value;
                    selected += text;
                }
            }
            var names = valuee;
            var nameArr = names.split('_');
            var padre = "";
            var idcategoria = "";
            padre = nameArr[0].toString();
            idcategoria = nameArr[1];
            //alert('Padre: ' + nameArr[0].toString() + ' value: ' + nameArr[1].toString());           
             $("#HdnModif").val(idcategoria);
            $("#Hd_ModifPadre").val(padre);
         }
        
         function fireCheckChanged() {
     
            var treeNode = event.srcElement || event.target;
            if (treeNode.tagName == "INPUT" && treeNode.type == "checkbox") {
                if (treeNode.checked) {
                    uncheckOthers(treeNode.id);
                }              
            }
            var selected = "";
            var valuee = "";
            var id_padre = "";
            //Reference the TreeView.
            var tree = document.getElementById("<%=treeViewProductos.ClientID %>");
            //Reference the CheckBoxes in TreeView.
            var checkboxes = tree.getElementsByTagName("INPUT");
            //Loop through the CheckBoxes.
            for (var i = 0; i < checkboxes.length; i++) {
                //If CheckBox is checked.
                if (checkboxes[i].checked) {
                    //Fetch the Text from the adjacent SPAN element.
                    var text = checkboxes[i].nextSibling.innerHTML;
                    //Fetch the Value from the Title(ToolTip) of CheckBox.
                    var value = checkboxes[i].title;
                    valuee += value;
                    selected += text;
                }
            }
            var names = valuee;
            var nameArr = names.split('_');
            var padre = "";
            var idcategoria = ""; 
            padre = nameArr[0].toString();
            idcategoria = nameArr[1];
           // alert('Padre: '+nameArr[0].toString() + ' value: ' + nameArr[1].toString());
            $("#HdnId_Up").val(idcategoria);
            $("#Hd_IdPadre").val(padre);
         }
        function uncheckOthers(id) {
            var tree = document.getElementById("<%=treeViewProductos.ClientID %>");
            //Reference the CheckBoxes in TreeView.
            var checkboxes = tree.getElementsByTagName("INPUT");

            var elements = document.getElementsByTagName('input');
            // loop through all input elements in form
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes.item(i).type == "checkbox") {
                    if (checkboxes.item(i).id != id) {                      
                        checkboxes.item(i).checked = false;
                    }
                }
            }
        }
        function uncheckOthers_modif(id) {
             var tree = document.getElementById("<%=TrevModifi.ClientID %>");
            //Reference the CheckBoxes in TreeView.
            var checkboxes = tree.getElementsByTagName("INPUT");
            var elements = document.getElementsByTagName('input');
            // loop through all input elements in form
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes.item(i).type == "checkbox") {
                    if (checkboxes.item(i).id != id) {
                        checkboxes.item(i).checked = false;
                    }
                }
            }
        }
    </script>
 </form>
</asp:Content>
