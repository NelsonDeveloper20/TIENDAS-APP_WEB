<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_MantenimientoFormulario.aspx.cs" Inherits="Web_Nestle.F_MantenimientoFormulario" %>
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
                    <h6 class="m-0">Mantenimiento Formulario</h6>
                  </div>
                      <ul class="list-group list-group-flush">
                    <li class="list-group-item p-3">
                      <div class="row">
                        <div class="col">

              <asp:Panel ID="PanelAgregar" runat="server">				
			<div class="col-md-12">		
                 <div class="form-row">
				<div class="form-group col-lg-3">
					<label>Nombre</label>
					<input type="text" name="" runat="server" class="form-control" id="txtNombre" value="">
				</div>
				
				<div class="form-group col-lg-3">
					<label>Ruta</label>
					<input type="text" name="" class="form-control" runat="server" id="txtRuta" value="">
				</div>
				
				<div class="form-group col-lg-3">
					<label>Grupo</label>
					<input type="text" name="" class="form-control" runat="server" id="txtGrupo" value="">
				</div>
					<div class="form-group col-lg-3">
					 <label>Estado</label>
					      <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" class="form-control" Width="100%" Height="34px"  >
                              <asp:ListItem Text="Activo" Value="1" />
                              <asp:ListItem Text="Inactivo"  Value ="0"/>
                          </asp:DropDownList>
				</div>	 
				
                    <div class="form-group col-lg-3">
                        <asp:LinkButton ID="btnRegistro" runat="server" Class ="btn btn-success" OnClick="btnRegistro_Click">Registro</asp:LinkButton>
				    <asp:LinkButton  class="btn btn-success" runat="server" id="btnModificar_fr"  OnClick="btnMOdificar_Click" >Modificar</asp:LinkButton>
                    <asp:LinkButton  class="btn btn-primary" runat="server" id="btnNuevo_form"  OnClick="btnNuevo_Click">Cancelar</asp:LinkButton>
                    </div>
			</div></div>
		</asp:Panel>
            		<asp:Panel ID="PanelListar" runat="server">
			       <div class="col-lg-12">
                       <div class="form-row">
                           <br style="clear:both" /> <br style="clear:both" />
                     <div class="form-group col-md-6" > 
					    <input type="text" runat="server" id="txtBuscarUsuario" class="form-control" placeholder="Buscar Por Ruta"> 
                        </div>
                      <div class="form-group col-md-1" >
				        <button type="submit"  class="btn btn-success" title="Buscar">Buscar<i style="    margin: 4px 1px 1px 10px;" class="glyphicon glyphicon-search"></i></button>
                     </div>
                     <div class="form-group col-md-3">
                             <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-primary" OnClick="BtnNuevo_Click" >Nuevo</asp:LinkButton>
                   
                </div></div>
                    <asp:GridView ID="grFormulario" runat="server" 
                        AutoGenerateColumns="False"  ShowHeaderWhenEmpty="true" 
                        CssClass="table table-striped table-bordered table-hover" 
                        DataKeyNames="IdFormulario" OnRowCommand="grFormulario_RowCommand" >
 
                        <%--Paginador...--%>        
                         <HeaderStyle  Font-Bold="true" ForeColor="Black" font-size="15px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
 
                        <Columns>
                             <asp:BoundField DataField="IdFormulario" HeaderText="IdFormulario" InsertVisible="False" ReadOnly="True"  ControlStyle-Width="70px" >
<ControlStyle Width="70px"></ControlStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="True"  ControlStyle-Width="70px" >
<ControlStyle Width="70px"></ControlStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Ruta" HeaderText="Ruta" ReadOnly="True"  ControlStyle-Width="300px" >
<ControlStyle Width="300px"></ControlStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Grupo" HeaderText="Grupo" ReadOnly="True" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" ReadOnly="True" />
                             <asp:BoundField DataField="FecCrea" HeaderText="FecCrea" ReadOnly="True" />

                          
                             <%--botones de acción sobre los registros...--%>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <%--Botones de eliminar y editar cliente...--%>
                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" CommandArgument="<%# ((GridViewRow)Container).RowIndex  %>"
                                        CommandName="Eliminar" OnClientClick="return confirm('¿Eliminar cliente?');">Eliminar</asp:LinkButton>
                                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-info"  CommandName="Editar" CommandArgument="<%# ((GridViewRow)Container).RowIndex  %>" >Editar</asp:LinkButton> 
                           
                                </ItemTemplate>
                                <edititemtemplate>
                                    <%--Botones de grabar y cancelar la edición de registro...--%>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Grabar" CssClass="btn btn-success" CommandName="Update" OnClientClick="return confirm('¿Seguro que quiere modificar los datos del cliente?');" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-default" CommandName="Cancel" />
                                </edititemtemplate>

<HeaderStyle Width="200px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

        </Columns>       
               <EmptyDataTemplate>
        <div align="center">No Existe Formularios Registrados</div>
    </EmptyDataTemplate>
                         <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                            <RowStyle font-size="13px"   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
                              <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
 
    </asp:GridView>
   
				 <asp:HiddenField  ID="hdIdFormulario" runat="server"/>
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
