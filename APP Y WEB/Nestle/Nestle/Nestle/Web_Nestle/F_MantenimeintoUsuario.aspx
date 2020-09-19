<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_MantenimientoUsuario.aspx.cs" Inherits="Web_Nestle.F_MantenimientoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager" 
runat="server" />
         
<div class="row">
<div class="col-lg-12" style="padding-left: 20px;padding-right: 20px;border-top-width: 10px;margin-top: 20px;">
<div class="card card-small mb-4">
<div class="card-header border-bottom">
<h6 class="m-0">Mantenimiento Usuarios</h6>
</div>
<ul class="list-group list-group-flush">
<li class="list-group-item p-3">
<div class="row">
<div class="col">

<asp:Panel ID="PanelAgregar" runat="server">
    <div class="col-lg-12">  <div class="form-row">
            <div class="form-group col-lg-3">
            <label>Nombre</label>
            <input type="text" name="" runat="server" class="form-control" id="txtNombre" value="" placeholder="Nombre" style="text-transform:uppercase">
            </div>
				
            <div class="form-group col-lg-3">
            <label>Apellido Paterno</label>
            <input type="text" name="" class="form-control" runat="server" id="txtApPaterno" value="" placeholder="Apellido Paterno" style="text-transform:uppercase">
            </div>
				
            <div class="form-group col-lg-3">
            <label>Apellido Materno</label>
            <input type="text" name="" class="form-control" runat="server" id="txtAPMaterno" value="" placeholder="Apellido Materno" style="text-transform:uppercase">
            </div>
          <div class="form-group col-lg-3">
            <label>Direccion</label>
            <input type="text" name="" class="form-control" runat="server" id="TxtDireccion" placeholder="Ingrese Direccion" value="" style="text-transform:uppercase">
            </div>
            <div class="form-group col-lg-3">
            <label>Usuario</label>
            <input type="text" name="" class="form-control" runat="server" id="txtUsuario" value="" placeholder="Usuario" style="text-transform:uppercase">
            </div>
            <div class="form-group col-lg-3">
            <label>Contraseña</label>
            <input type="password" name="" class="form-control" runat="server" id="txtContraseña" value="" placeholder="Clave" style="text-transform:uppercase">
            </div>
        
            <div class="form-group col-lg-3">
            <label>Empresa</label>
            <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="false" class="form-control" Width="100%" Height="34px"  >                      
            </asp:DropDownList>
            </div>	
            <div class="form-group col-lg-3" runat="server" id="tipoperfilweb">
            <label>Tipo Perfil Web</label>
            <asp:DropDownList ID="ddlSubPerfil" runat="server" AutoPostBack="false" class="form-control" Width="100%" Height="34px"  >                      
            </asp:DropDownList>
            </div>	
            <div class="form-group col-lg-3">
            <label>Estado</label>
            <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="false" class="form-control" Width="100%" Height="34px"  >
            <asp:ListItem Text="Activo" Value="1" />
            <asp:ListItem Text="Inactivo"  Value ="0"/>
            </asp:DropDownList>
            </div>	
            <div class="form-group col-lg-6"   style="padding-top: 23px;">
            <div class="form-group">
            <asp:LinkButton ID="btnRegistro_frm" class="btn btn-success" OnClick="btnRegistro_Click"  runat="server">Registro</asp:LinkButton>
            <asp:LinkButton ID="btnModificar_fr" class="btn btn-success" OnClick="btnMOdificar_Click"  runat="server">Modificar</asp:LinkButton>
            <asp:LinkButton ID="btnNuevo_f" class="btn btn-primary" runat="server" OnClick="btnNuevo_Click"  >Cancelar</asp:LinkButton>
                 
            </div>
            </div>
            </div>
   </div>
</asp:Panel>

<asp:Panel ID="PanelListar" runat="server"  DefaultButton="LinkButton2">
<div class="col-lg-12">
                
<div class="form-row">
    <asp:Panel ID="Panel1" class="form-group col-lg-6" DefaultButton="LinkButton2" runat="server">
<div class="input-group mb-3">
<input type="text" class="form-control" placeholder="Ingrese Nombre" runat="server" id="TxtBuscarG" aria-describedby="basic-addon2">
<div class="input-group-append">
<asp:LinkButton ID="LinkButton2" CssClass="btn btn-outline-secondary" BackColor="#5A6169" ForeColor="#FFFFFF" runat="server" OnClick="BtnBuscar_Click" ><i class="fa fa-search"></i></asp:LinkButton>
</div>
</div>
</asp:Panel>

<div class="form-group col-md-1">
<span class="input-group">
<asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-primary" OnClick="BtnNuevo_Click" >Nuevo</asp:LinkButton>
</span>
</div>
<div class="form-group col-md-2" style="padding-top: 10px; left: 0px; top: 0px;">
<asp:CheckBox data-bind="Name: Value" runat="server"  Text="Activos" Checked="true" ID="chksuc" AutoPostBack="True" OnCheckedChanged="chksuc_CheckedChanged" ></asp:CheckBox>
</div></div>
<div class="form-group col-lg-12" style="padding-left: 0px; padding-right: 0px;" >
    <div class="table-responsive">
<asp:GridView ID="grUsuario" runat="server" 
AutoGenerateColumns="False" 
CssClass="table table-striped table-bordered table-hover"
DataKeyNames="IdUsuario"     ShowHeaderWhenEmpty="true" 
allowpaging="true" OnRowCommand="grUsuario_RowCommand" > 
<HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
<EditRowStyle BackColor="#ffffcc" /> 
<Columns>
<asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" InsertVisible="False" ReadOnly="True"  ControlStyle-Width="70px" />
<asp:BoundField DataField="Nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="True"  ControlStyle-Width="70px" />
<asp:BoundField DataField="ApellidoMaterno" HeaderText="ApellidoMaterno" ReadOnly="True"  ControlStyle-Width="200px" />
<asp:BoundField DataField="ApellidoPaterno" HeaderText="ApellidoPaterno" ReadOnly="True" />
<asp:BoundField DataField="Usuario" HeaderText="Usuario" ReadOnly="True" />
<asp:BoundField DataField="Estado" HeaderText="Estado" ReadOnly="True" />
<asp:BoundField DataField="TipoUsuario" HeaderText="Tipo Usuario" ReadOnly="True" />
<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ShowHeader="False" HeaderText="Eliminar">
<ItemTemplate>
<asp:LinkButton ID="btnDelete" runat="server" Text="" CssClass="btn btn-danger"
CommandArgument="<%# ((GridViewRow)Container).RowIndex  %>"
CommandName="Eliminar" OnClientClick="return confirm('¿Eliminar cliente?');" >Eliminar</asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ShowHeader="False" HeaderText="Editar">
<ItemTemplate>
<asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-info" 
CommandName="Editar" CommandArgument="<%# ((GridViewRow)Container).RowIndex  %>" >Editar</asp:LinkButton>
</ItemTemplate>
                                    
<edititemtemplate>
<asp:Button ID="btnUpdate" runat="server" Text="Grabar" CssClass="btn btn-success" CommandName="Update" OnClientClick="return confirm('¿Seguro que quiere modificar los datos del cliente?');" />
<asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-default" CommandName="Cancel" />
</edititemtemplate>
</asp:TemplateField>
</Columns>
<EmptyDataTemplate>
<div align="center">No Existe Usuarios Registrados</div>
</EmptyDataTemplate>
<HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
<RowStyle font-size="13px"   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
<PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
</asp:GridView>
   

    </div>
</div>
<asp:HiddenField  ID="hdIdUsuario" runat="server"/>
</div>
</asp:Panel>

</div>
</div>
</li>
</ul>
</div>
</div>         
</div>          
</form>
</asp:Content>
