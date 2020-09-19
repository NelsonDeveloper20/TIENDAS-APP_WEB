<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_MetaBodegaVendedor.aspx.cs" Inherits="Web_Nestle.F_MetaBodegaVendedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
<script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.min.js"></script>
   --%>
<%--    <script src="Js/jQuery.js"></script>--%>
<%--    <script src="jsFecha/Moment.js"></script>
    <script src="jsFecha/Botstrap_Datetime.js"></script>--%>
    <script src="jsFecha/bootstrap-datepicker.js"></script>
         <%--<script src="https://vitalets.github.io/bootstrap-datepicker/jquery/jquery.js"></script>--%>
    <%--<script src="https://vitalets.github.io/bootstrap-datepicker/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>--%>
    <script src="jsFecha/bootstrap-datepicker2.js"></script>
 <%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>--%>
    <script src="jsFecha/jquery2_2_4.js"></script>
  <style>     

      .datepicker {
              z-index: 9999;

      }
       .GridPager a, 
.GridPager span { 
    display: inline-block; 
    padding: 0px 9px; 
    margin-right: 4px; 
    border-radius: 3px; 
    border: solid 1px #31b3eb; 
    background: #e9e9e9; 
    box-shadow: inset 0px 1px 0px rgba(255,255,255, .8), 0px 1px 3px rgba(0,0,0, .1); 
    font-size: .875em; 
    font-weight: bold; 
    text-decoration: none; 
    color: #717171; 
    text-shadow: 0px 1px 0px rgba(255,255,255, 1); 
} 

.GridPager a { 
    background-color: #f5f5f5; 
    color: #969696; 
    border: 1px solid #969696; 
} 
.GridPager a:hover { 
    background: #1068f3; 
    /*box-shadow: inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8);*/ 
    color: #f0f0f0; 
    text-shadow: 0px 0px 3px rgba(0,0,0, .5); 
    border: 1px solid #007afe; 
} 
.GridPager span { 

    background: #1068f3; 
    /*box-shadow: inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8);*/ 
    color: #f0f0f0; 
    text-shadow: 0px 0px 3px rgba(0,0,0, .5); 
    border: 1px solid #007afe; 
}       
  </style>


<form id="form1" runat="server">
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
           
        <div class="" style="    margin-top: -6px;">   
            <div class="form-row">               
            
                  <asp:Panel ID="PanelAgregar" runat="server">	
                      <div class="col-lg-12">
                       <div class="form-row">	
                    <div class="form-group col-lg-3">
                    <label style="float: inherit;">Tipo Usuario</label>
                    <asp:DropDownList ID="DDTipoUusario"  runat="server"  class="form-control"  style="width:100% !important"  >
                    </asp:DropDownList>                
                    </div>
                    <div class="form-group col-md-3">
                    <label>Mes</label>
                    <input type="text" class="form-control" runat="server" ClientIDMode="Static" id="TxtFecha" autocomplete="off">
                    <div class="input-group-addon">
                    <span class="glyphicon glyphicon-th"></span>
                    </div>
                    </div>                 
                <div class="form-group col-md-3" style="display:none">
                    <label>Código Premio</label>                                 
                    <input type="text" id="TxtCodigoPremio" placeholder="Código "  ClientIDMode="Static" runat="server"   class="form-control"/>      
                    </div> 
                           <div class="col-12"></div>
                <div class="form-group col-md-4">

                <asp:FileUpload ID="FileUpload1"  runat="server" CssClass="form-control" onchange="UploadFile(this);" />
                </div>  
                <div class="form-group col-md-2">
                 <asp:LinkButton ID="BtnGuardar" Width="100%" class="btn btn-primary"   runat="server" OnClick="BtnGuardar_Click" ><i class="fa fa-upload"></i> Subir</asp:LinkButton>
                </div>
                           <div class="form-group col-md-2">
                 <asp:LinkButton ID="BtnCancelar" Width="100%" class="btn btn-dark"   runat="server" ForeColor="White" OnClick="BtnCancelar_Click"  ><i class="fas fa-angle-double-left"></i> Cancelar</asp:LinkButton>
                </div>
                            <div class="form-group col-md-12">  <asp:Label ID="LblTotal" runat="server"></asp:Label>
                           <div class="table-responsive">
                               <asp:GridView ID="GvSubir"  class="table table-bordered" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False">
                                   <Columns>
                                       <asp:BoundField DataField="IDUSUARIO" HeaderText="Id Usuario" />
                                       <asp:BoundField DataField="MONTO" HeaderText="Monto" />
                                       <asp:BoundField DataField="FECHA" HeaderText="Fecha" />
                                       <asp:BoundField DataField="TIPOUSUARIO" HeaderText="TipoUsuario" />
                                   </Columns>
                                <EmptyDataTemplate>
                                    <div><center><h3>Seleccione Txt</h3></center></div>
                                </EmptyDataTemplate>
                                   <HeaderStyle  BackColor="#007bff" ForeColor="#FFFFFFF" Font-Bold="false"/>
                               </asp:GridView>
                               </div>
                    </div>
                       </div></div>
</asp:Panel>

                <asp:Panel ID="Panel_Listar" CssClass="col-lg-12" runat="server">
                    <div class="col-lg-12">
                       <div class="form-row">	
                       <div class="form-group col-lg-3">
                    <label style="float: inherit;">Tipo Usuario</label>
                    <asp:DropDownList ID="DDBuscar"  runat="server"  class="form-control"  style="width:100% !important"  >
                    </asp:DropDownList>                
                    </div>
                    <div class="form-group col-md-4">
                    <label>Mes</label>
                    <input type="text" class="form-control" runat="server" ClientIDMode="Static" id="TxtMesBuscar" autocomplete="off">
                    <div class="input-group-addon">
                    <span class="glyphicon glyphicon-th"></span>
                    </div>
                    </div> 
                       <%--<div class="col-lg-12"></div>--%>  
                      <div class="form-group col-md-2" ><br style="clear:both"/>
                          <asp:LinkButton ID="BtnBuscar" Width="100%" CssClass="btn btn-success" runat="server" OnClick="BtnBuscar_Click"><i class="fas fa-search"></i> Buscar</asp:LinkButton>
				         </div>
                     <div class="form-group col-md-2"><br style="clear:both"/>
                     <asp:LinkButton ID="BtnNuevo" runat="server" Width="100%" class="btn btn-primary" OnClick="BtnNuevo_Click"><i class="fas fa-plus"></i> Nuevo</asp:LinkButton>
                   
                </div>
                <div class="col-lg-12">
                       <div class="table-responsive">
                    <asp:GridView ID="GV_MetaMensual"  runat="server" AutoGenerateColumns="False" 
 GridLines="None" DataKeyNames="ID"
    CssClass="table table-bordered" Width="100%" AllowPaging="True" OnPageIndexChanging="GV_MetaMensual_PageIndexChanging" OnRowCancelingEdit="GV_MetaMensual_RowCancelingEdit" OnRowEditing="GV_MetaMensual_RowEditing" OnRowUpdating="GV_MetaMensual_RowUpdating">
<HeaderStyle  BackColor="#0078D7" ForeColor="White"  Font-Size="12px"  HorizontalAlign="Center" VerticalAlign="Middle"/>  
<Columns>
            
    <asp:TemplateField HeaderText="ID">
        <EditItemTemplate>
           <asp:Label ID="Label2" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="ID Usuario">
        <EditItemTemplate>
           <asp:Label ID="Label2n" runat="server" Text='<%# Bind("idUsuario") %>'></asp:Label>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Labelmn2" runat="server" Text='<%# Bind("idUsuario") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Usuario">
        <EditItemTemplate>
            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="TipoUsuario">
        <EditItemTemplate>
            <asp:Label ID="Label4" runat="server" Text='<%# Bind("TipoUsuario") %>'></asp:Label>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Label4" runat="server" Text='<%# Bind("TipoUsuario") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Meta Fecha">
        <EditItemTemplate>
            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Monto">
        <EditItemTemplate>
            <asp:TextBox ID="tXTmONTO" CssClass="form-control" runat="server" Text='<%# Bind("Monto") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Monto") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
               <asp:TemplateField HeaderText="Aciones">
                <ItemTemplate>                                 
                <asp:LinkButton ID="lnkEdit" runat="server" Text=""   CommandName="Edit" ToolTip="Edit" 
                CommandArgument='' CssClass="btn btn-info"> <i class="fas fa-edit"></i> Editar</asp:LinkButton>
                </ItemTemplate>
            <EditItemTemplate>
            <asp:LinkButton ID="lnkInsert" runat="server" Text=""  ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
            CommandArgument='' CssClass="btn btn-primary"><i class="fas fa-sync-alt"></i> Modificar</asp:LinkButton>
            <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
            CommandArgument='' CssClass="btn btn-dark"><i class="fas fa-exclamation-circle"></i>   Cancelar</asp:LinkButton>
            </EditItemTemplate>
                            </asp:TemplateField>    
</Columns>
<RowStyle font-size="12px"   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
                          <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
</asp:GridView>   
                           </div>
               </div> </div></div>
                    </asp:Panel>
            </div>
    
        </div>
            </div>
            </div>
            </li>
            </ul>
            </div>
            </div>         
            </div>  
    
    <asp:Button ID="btnUploadDoc" Text="Upload" runat="server" OnClick="UploadDocument" Style="display: none;" />   
    <script>
          function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUploadDoc.ClientID %>").click();
            }
        }
        $(function () {
         
            //window.prettyPrint && prettyPrint();
            $('#TxtFecha').datepicker({
                format: 'mm/yyyy',
                autoclose: true,
                startDate: "today",
                minViewMode: 1,
                //todayBtn: 'linked'
                  locale: 'es-es',
            });
            $('#TxtMesBuscar').datepicker({
                format: 'mm/yyyy',
                autoclose: true,
                //startDate: "today",
                minViewMode: 1,
                //todayBtn: 'linked'
                locale: 'es-es',
            });
            
        });

        //$('#datetimepicker1').datetimepicker({
        //    //minDate: moment().add(-0, 'd').toDate(),
        //    maxDate: moment().add(+0, 'd').toDate(),

        //    locale: 'es-es',
        //    format: 'DD.MM.YYYY'
        //});
       
        //$('.datepicker').datepicker({
        //        //minDate: moment().add(-0, 'd').toDate(),
        //       // maxDate: moment().add(+0, 'd').toDate(),
        //        locale: 'es-es',
        //        format: 'YYYY.MM.DD'
        //    });
       
        //$('.datepicker').datepicker({
        //    format: 'yyyy-mm-dd',
        //    autoclose: true,
        //    endDate: "today",
        //    maxDate: today
        //});

        //var currentTime = new Date();
        //// First Date Of the month 
        //var startDateFrom = new Date(currentTime.getFullYear(), currentTime.getMonth(), 1);
        //// Last Date Of the Month 
        //var startDateTo = new Date(currentTime.getFullYear(), currentTime.getMonth() + 1, 0);

        ////$("#datepicker").datepicker({
        ////    dateFormat: 'dd.mm.yy',
        ////    minDate: startDateFrom,
        ////    maxDate: startDateTo
        ////});

        //$('.from').datepicker({
        //    minDate: startDateFrom,
        //    maxDate: startDateTo,
        //    autoclose: true,
        //    minViewMode: 1,
        //    format: 'mm/yyyy'
        //});

    

    </script>
 </form>
</asp:Content>
