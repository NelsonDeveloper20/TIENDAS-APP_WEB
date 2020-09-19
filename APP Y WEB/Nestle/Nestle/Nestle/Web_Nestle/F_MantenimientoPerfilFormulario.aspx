<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_MantenimientoPerfilFormulario.aspx.cs" Inherits="Web_Nestle.F_MantenimientoPerfilFormulario" %>
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
                    <h6 class="m-0">Mantenimiento Perfil Formulario</h6>
                  </div>
                      <ul class="list-group list-group-flush">
                    <li class="list-group-item p-3">
                      <div class="row">
                        <div class="col">
        
              
<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate>
<fieldset >	
		 <div class="col-lg-12">      
                 <div class="form-row">                        
                 <span style="float:left;"><asp:Label ID="lblInfo" runat="server" /></span>
                <div class="form-group col-lg-6">
                <label>Perfil</label>
                <asp:DropDownList ID="ddlPerfiles" runat="server" AutoPostBack="true"  class="form-control" Width="100%" Height="34px" OnSelectedIndexChanged="ddlPerfiles_SelectedIndexChanged"  >
                  </asp:DropDownList>
                </div>                 
                <span style="float:right; padding: 10px;"><small>Total Formularios:</small> <asp:Label ID="lblTotalUsuario" runat="server" CssClass="label label-warning" /></span>
             <br style="clear:both"/>
           <br style="clear:both"/>
           <br style="clear:both"/>
                         <asp:HiddenField  ID="hdIdFormulario" runat="server"/>
                         <asp:HiddenField  ID="hdIdPerfil" runat="server"/>  
                <div class="form-group col-lg-5">       <div class="form-row">                           
                    <asp:ListBox ID="ddlFormulariosNoAgregados" runat="server"  CssClass="form-control" SelectionMode="Multiple" style="min-height: 150px; Width:100% !important">
                </asp:ListBox>  </div>
              </div> 
             <div class="form-group col-lg-2" style="    margin-top: 20px;">
                 <asp:LinkButton ID="btnagregar_f" CssClass="btn btn-primary" runat="server" OnClick="btnagregar_Click">agregar</asp:LinkButton>
                 <asp:LinkButton ID="btnEliminar_f" CssClass="btn btn-danger" runat="server" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
            
             </div>                      
                <div class="form-group col-lg-5" style="  margin-top: 10px;">
                <asp:ListBox ID="ddlFormulariosAsignado" CssClass="form-control" runat="server" SelectionMode="Multiple" style="width:100% !important;min-height: 150px;">                                  
                </asp:ListBox>                                
                </div> 
           <br style="clear:both"/>
           <br style="clear:both"/>
           <br style="clear:both"/>
                <div class="form-group col-lg-12">
                      <center>
<asp:LinkButton runat="server" ID="btnRegistro_f" CssClass ="btn btn-success" style="width:100%" OnClick="btnRegistro_Click1">Registro</asp:LinkButton>
				
                           
                 </center>      
                </div>                                   
    </div>
</fieldset>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnRegistro_f" EventName="click" />
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

          
    </form>
</asp:Content>
