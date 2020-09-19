<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_SendPromociones.aspx.cs" Inherits="Web_Nestle.F_SendPromociones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script src="jsFecha/jquery2_2_4.js"></script>
<script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
 <style>
.viewe:hover{     
    color: #000000 !important;
     }.hidden-field
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
  text-transform: uppercase;
  font-size: 11px;
  border-radius:6px;
}
/*.view_n:hover{
  width:205px !important;
    height:360px !important;
transform: scale(2);
z-index:9999999;

}*/
 </style>
    <form id="form1" runat="server">
    
<asp:ScriptManager ID="ScriptManager" runat="server" />     

          <asp:Panel ID="panelListar" CssClass="row" runat="server" style="margin-top: 10px;">
              
      <div class="col-lg-12">  
        <div class="card border-primary mb-12">
            
                <div class="card-header text-black">Notificaciones </div>
              <div class="form-row">   
                <asp:Panel ID="Panel2" DefaultButton="BtnBuscar" CssClass="form-group col-md-6" style="margin-left: 5px;   margin-bottom: 0px;" runat="server">
                <div class="input-group col-md-12">
                <input type="text" class="form-control" placeholder="Ingrese Titulo de Notificacion" runat="server" id="TxtBuscarG" aria-describedby="basic-addon2">
                <div class="input-group-append">
                <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-outline-secondary" BackColor="#5A6169" ForeColor="#FFFFFF" runat="server" OnClick="BtnBuscar_Click"><i class="fa fa-search"></i></asp:LinkButton>
                </div>
                </div>
                </asp:Panel>
                <div class="form-group col-md-4">
                <span class="input-group">
                <asp:LinkButton ID="LinkButton1" Width="100%"  runat="server" class="btn btn-primary" OnClick="BtnNuevo_Click" OnDataBinding="LinkButton1_DataBinding" >Nuevo</asp:LinkButton>
                </span>
                </div>
                <br style="clear:both"/>
                  </div>
              <div class="table-responsive">
            <asp:GridView ID="GvNofiticacion" runat="server" ForeColor="#333333" class="table table-bordered" 
            AutoGenerateColumns="False" DataKeyNames="idNotificacion"
            OnRowDataBound="GvPromociones_OnRowDataBound"    ShowHeaderWhenEmpty="true"   
            OnRowCommand="GvPromociones_RowCommand"  >
		<Columns>
			<asp:BoundField ItemStyle-Width="150px" DataField="idNotificacion" HeaderText="ID" >
			<ItemStyle Width="150px" />
            </asp:BoundField>
			<asp:BoundField ItemStyle-Width="100px" DataField="Titulo" HeaderText="Titulo" >
			<ItemStyle Width="100px" />
            </asp:BoundField>
			<asp:BoundField ItemStyle-Width="100px" DataField="Descripcion" HeaderText="Descripcion" >
			<ItemStyle Width="100px" />
            </asp:BoundField>
            
            <asp:BoundField DataField="TipoUsuario" HeaderText="Tipo Usuario" ItemStyle-Width="100px">
            <ItemStyle Width="100px" />
            </asp:BoundField>

              <asp:TemplateField HeaderText="Imagen">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Imagen") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                       <a id="popdetalle" >
                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("Imagen") %>' Visible="false"></asp:Label>
                      <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Imagen")%>' Width="52px" Height="70px" Style=" border-radius: 8px;" CssClass="view_n"/>
                  </a>
                           </ItemTemplate>
                  <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:BoundField DataField="FlagEnviado" HeaderText="Cant Veces Enviado" ItemStyle-Width="100px">
            <ItemStyle Width="100px" />
            </asp:BoundField>
            
            
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText=" Enviar Notificacion" ItemStyle-HorizontalAlign="Center" ShowHeader="False">
            <ItemTemplate>
            <asp:LinkButton ID="BtnSpush" runat="server" CommandArgument="<%# ((GridViewRow)Container).RowIndex  %>" CommandName="EnviarPush" CssClass="btn btn-outline-primary" Text="">               
            Enviar<i class='fa fa-paper-plane' aria-hidden='true'></i> 
            </asp:LinkButton>
            </ItemTemplate>
            <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>        
            
                      <asp:BoundField DataField="Imagen" HeaderText="" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" >
                    <HeaderStyle CssClass="hidden-field"></HeaderStyle><ItemStyle CssClass="hidden-field"></ItemStyle>
                    </asp:BoundField>
		</Columns> 
                    <EmptyDataTemplate>
        <div align="center">No hay Registros</div>
    </EmptyDataTemplate>
     <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="11px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
                    <RowStyle   HorizontalAlign="Center"   VerticalAlign="Middle"  Font-Size="11px"   /> 
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
</asp:GridView>
                  </div>
            </div></div>
      </asp:Panel> 
          <asp:Panel ID="PanelAgregar" CssClass="row" runat="server" style="margin-top: 10px;">


    

      <div class="col-lg-7">  
        <div class="card border-primary mb-7">
                <div class="card-header text-black">Descipcion </div>
                <div class="form-group col-md-12">
                <label>Titulo</label>                                 
                <input type="text" id="TxtTitulo" placeholder="Ingrese Descipcion  "  ClientIDMode="Static" runat="server"   class="form-control"/>      
                </div> 
              <div class="col-lg-12" style="
    padding-left: 0px;  padding-right: 1px;
        ">
        <asp:GridView ID="GridView1" runat="server" class="table table-bordered" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
        <asp:TemplateField HeaderText="Id" >
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
        </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action">
        <ItemTemplate>
        <asp:LinkButton ID="bt_elim" CommandArgument='<%# Eval("Id") %>' OnClick="Delete" CssClass="btn btn-outline-dark" runat="server"><i class="far fa-trash-alt"></i></asp:LinkButton>
              
        </ItemTemplate>
        <FooterTemplate>
        <asp:LinkButton ID="btnAdd" CommandName="Footer" OnClick="Add" CssClass="btn btn-outline-primary" runat="server"><i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
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
        </td>


        <td>
        <asp:LinkButton ID="btnAdd" CommandName="EmptyDataTemplate" OnClick="Add" CssClass="btn btn-outline-primary" runat="server"><i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
        </td>
        </tr>
        </table>
        </EmptyDataTemplate>
        </asp:GridView>
                  <div style="display:none">
                      
    <asp:GridView ID="gv_insert" runat="server"></asp:GridView>
                  </div>
                    </div>  
                <div class="form-group col-md-12">
                <label>Descripcion</label> 
                <asp:TextBox ID="TxtDescripcion" runat="server" placeholder="Ingrese Descipcion  " class="form-control" TextMode="MultiLine" cols="20" rows="8" style="    width: 100% !important;"></asp:TextBox>   
                </div>   <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Corbel" 
                ForeColor="#CC0000"></asp:Label>    
              <div class="form-group col-md-12">
                <div class="row">
            <div class="form-group col-md-4">
            <asp:LinkButton ID="BtnGuardar" runat="server" Width="100%" CssClass="btn btn-success" OnClick="BtnGuardar_Click" >Guardar</asp:LinkButton>     
           </div>
            <div class="form-group col-md-4">                      
            <asp:LinkButton ID="btnNuevo_f" class="btn btn-primary"  Width="100%" runat="server" OnClick="btnNuevo_Click"  >Cancelar</asp:LinkButton> 
            </div></div>
                </div>     

     </div>
    </div>   
     <div class="col-lg-5">  
            <div class="card border-primary mb-5">
                <div class="card-header text-black">Imagen </div>   
                       
        <div class="form-group col-md-12">                   
        <asp:Label ID="Label3" runat="server" Font-Bold="False" 
        Text="Seleccione Imagen..."></asp:Label>                    
        <asp:FileUpload ID="UploasIMg" ClientIDMode="Static" class="form-control" onchange="preview_image(event)" runat="server" /> 
        </div>   

        <div class="form-group col-md-12"> 
                <div class="form-row">   
                    <div class="col-lg-5">
                        <center>
                            <div class='card card-small mb-3' style="    margin-left: 10px;">
                  <div class="card-header border-bottom">
                    <h6 class="m-0">Tamaño Imagen Aceptable</h6>
                  </div>
                  <div class='card-body p-0'>
                    <ul class="list-group list-group-flush">
                      <li class="list-group-item p-3">
                        <span class="d-flex mb-2">
                          <i class="material-icons mr-1">visibility</i>
                          <strong class="mr-1">Ancho:</strong>
                             <strong class="text-success"> 350 PX</strong>
                        </span>
                        <span class="d-flex mb-2">
                          <i class="material-icons mr-1">visibility</i>
                          <strong class="mr-1">Alto:</strong>
                          <strong class="text-success">625 PX</strong>
                        </span>
                      </li>
                    </ul>
                  </div>
                </div>

                        </center>
                    </div>
                    <div class="col-lg-7">
            <center> 
        <img id='img-upload' width="205px" src="" onerror="this.src = 'images/basepromo.jpg'" height="360px" style="    box-shadow: 0 12px 31px 0 rgb(102, 109, 117);
    border-radius: 10px;
    border: 2px solid #1010101f;"/> </div>                  
       </center> 
            </div>
          </div>
      </div> 

        </asp:Panel> 
        <div id="myModal" class="modal">
              
            <center>
                  <a onclick="miFuncion()"  style="font-size: 24px;    cursor: pointer;" class="viewe"><i class="fas fa-times"></i></a><br style="clear:both"/>
  <img  id="mi_imagen" width="301px"  height="545px" onerror="this.src = 'images/basepromo.jpg'" style="     box-shadow: 0 12px 31px 0 rgb(17, 17, 19);
    border-radius: 10px;
    border: 2px solid #1010101f;"/>
            </center>
</div>
       <script>


           function miFuncion() {
               $('#myModal').modal('hide');  //For hide
           }

           $(document).ready(function () {
             $("#<%=GvNofiticacion.ClientID%> [id*='popdetalle']").click(function () {

                 var tr = $(this).parent().parent();
                 var src_img = $("td:eq(7)", tr).html();               
                 $("#mi_imagen").attr("src", src_img);

                 $('#myModal').modal('show');
          
             });
           });

           function preview_image(event) {
               var reader = new FileReader();
               reader.onload = function () {
                   var output = document.getElementById('img-upload');
                   output.src = reader.result;
               }
               reader.readAsDataURL(event.target.files[0]);
           }

           function enviarnotificacion(idusuario, titulo, descripcion, imagen, IdNotificacion) {
                //alert(idusuario +' TITLUO: '+ titulo + ' DESCRIPC: ' + descripcion + '  IMA: ' + imagen+ ' ID_NOT' + IdNotificacion);
               return;
            $.ajax({
                type: "GET", url: 'http://192.168.0.159/ApiDelcorpTienda/api/NotificaNuevaPromocion?IdUsuario=' + idusuario + '&id=1&titulo=' + titulo + '&msj=' + descripcion + '&rutafoto=' + imagen + '&idNotificacion=' + IdNotificacion,
              
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (resultado) {
                    swal("Notificación Enviada Correctamente!", "Delcorp", "success");                 
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
       </script>
        

    </form>
</asp:Content>
