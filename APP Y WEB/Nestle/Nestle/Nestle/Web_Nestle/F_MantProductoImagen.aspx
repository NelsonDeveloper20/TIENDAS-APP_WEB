<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_MantProductoImagen.aspx.cs" Inherits="Web_Nestle.F_MantProductoImagen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>



    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <form id="form1" runat="server">
        <style>
            .viewe:hover {
                color: #1c77f5 !important;
            }

            .card-post__image {
                position: relative;
                min-height: 4.3125rem;
                border-top-left-radius: .625rem;
                border-top-right-radius: .625rem;
                background-size: cover;
                background-position: center;
                background-repeat: no-repeat;
            }

            .btn-file {
                position: relative;
                overflow: hidden;
            }

                .btn-file input[type=file] {
                    position: absolute;
                    top: 0;
                    right: 0;
                    min-width: 100%;
                    min-height: 100%;
                    font-size: 100px;
                    text-align: right;
                    filter: alpha(opacity=0);
                    opacity: 0;
                    outline: none;
                    background: white;
                    cursor: inherit;
                    display: block;
                }
            /*.nels{
margin-left: 7px;
}*/

            #img-upload {
                width: 100%;
            }
        </style>
        <asp:ScriptManager ID="ScriptManager" runat="server" />

        <div class="row">
            <div class="col-lg-12" style="padding-left: 20px; padding-right: 20px; border-top-width: 5px; margin-top: 10px;">
                <div>
                    <%--<div class="card card-small mb-4">--%>
                    <div>
                        <%-- <div class="card-header border-bottom"> --%>

                        <h6 class="m-0 card-small">Mantenimiento Imagen Producto</h6>
                    </div>
                    <%--<ul class="list-group list-group-flush">
<li class="list-group-item p-3">--%>
                    <%--  <ul>
    <li>--%>
                    <div class="row">
                        <center>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                    <ContentTemplate>
  <%-- <div class="form-group col-lg-12">--%>
<asp:Panel ID="Panel1" class="form-group col-lg-12" DefaultButton="BtnBuscar" runat="server">
<div class="input-group mb-3">
<input type="text" class="form-control" placeholder="Ingrese Nombre de Producto" runat="server" id="TxtBuscarG" aria-describedby="basic-addon2">
<div class="input-group-append">
<asp:LinkButton ID="BtnBuscar" CssClass="btn btn-outline-secondary" BackColor="#5A6169" ForeColor="#FFFFFF" runat="server" OnClick="BtnBuscar_Click" ><i class="fa fa-search"></i></asp:LinkButton>
</div>
</div>
</asp:Panel>

   <%--</div>--%>
                      <center>
    <asp:DataList ID="DataList1" runat="server" DataKeyField="IdProductoTxt" 
        oncancelcommand="DataList1_CancelCommand" 
        ondeletecommand="DataList1_DeleteCommand" oneditcommand="DataList1_EditCommand" 
        onupdatecommand="DataList1_UpdateCommand" RepeatColumns="7" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row nels">    
                      <EditItemTemplate>
                            <asp:UpdatePanel ID="FileUpPanel" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                            <div class="col-sm-12 mb-4">
                            <div class="card card-small card-post card-post--1" style="    width: 15rem;
    box-shadow: 0 12px 31px 0 rgba(17, 17, 19, 0.41);
    border-radius: 10px;">
                            <div class="card-post__image" >  
                            <%--<asp:Image ID="img1" runat="server" ImageAlign="AbsBottom" ImageUrl=' <%# Eval("Imagen") %>' Height="100px" Width="100px" />--%> 
                            <div style="    margin-top: 25%;">    
                            <asp:FileUpload ID="FileUpload2" ClientIDMode="Static" CssClass="form-control"   runat="server" />
                            </div>
                            </div>
                            <div class="card-body" style="    padding-top: 20px;padding-right: 2px;    padding-bottom: 5px;    padding-left: 2px;">
                            <h7 class="card-title"><asp:Label ID="Label1" runat="server" Text='<%#  Bind("NombrePro") %>'></asp:Label></h7>
                            </div>
                            <ul class="list-group list-group-flush">
                            <li class="list-group-item" style="   padding-left: 0px;   padding-right: 0px;    padding-bottom: 0px;    padding-top: 0px;">Precio: <asp:Label ID="Label3" runat="server" Text='<%#  Bind("Precio") %>'></asp:Label></li>
                            <li class="list-group-item" style="   padding-left: 0px;   padding-right: 0px;    padding-bottom: 0px;    padding-top: 0px;">Id: <asp:Label ID="Label2" runat="server" Text='<%#  Bind("IdProductoTxt") %>'></asp:Label></li>
                            </ul>
                            <div class="card-body" style="   padding-top: 10px;">                       
                            <asp:LinkButton ID="LinkButton1" Class ="btn btn-success" runat="server" CommandName="Update" >Modificar</asp:LinkButton>
                            &nbsp; &nbsp;
                            <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-info" CommandName="Cancel">Cancelar</asp:LinkButton>
                            </div>
                            </div>
                            </div>
                            </ContentTemplate>
                            <Triggers>
                            <asp:PostBackTrigger ControlID="LinkButton1" />
                            </Triggers>
                            </asp:UpdatePanel>
                    </EditItemTemplate>
                    <ItemTemplate>                     
                            <div class="col-sm-12 mb-4">
                            <div class="card card-small card-post card-post--1" style="
    box-shadow: 0 12px 31px 0 rgba(17, 17, 19, 0.41);
    border-radius: 10px;width: 12rem;">
                            <div class="card-post__image" > 
                                <a id="popdetalle" onclick="mostrarImg_nels(' <%# "http://3.19.108.54/nestle/ProductoImagen/"+Eval("Imagen") %>');" title="Click Para Ver Imagen">                                 
                            <asp:Image ID="img2" runat="server" ImageAlign="AbsBottom" ImageUrl=' <%# "~/ProductoImagen/"+Eval("Imagen") %>' onerror="this.src = 'images/noimagen.jpg'" style="width:100%;      -webkit-border-radius: 12px 11px 0px 0px;" /> 
                           </a> </div>
                            <div class="card-body" style="    padding-top: 0px;
                            padding-right: 2px;    padding-bottom: 5px;    padding-left: 2px;">
                            <h7 class="card-title"><asp:Label ID="Label1" runat="server" Text='<%#  Bind("NombrePro") %>'></asp:Label></h7>
                            </div>
                            <ul class="list-group list-group-flush">
                            <li class="list-group-item" style="   padding-left: 0px;   padding-right: 0px;    padding-bottom: 0px;    padding-top: 0px;">Precio: <asp:Label ID="Label3" runat="server" Text='<%#  Bind("Precio") %>'></asp:Label></li>
                            <li class="list-group-item" style="   padding-left: 0px;   padding-right: 0px;    padding-bottom: 0px;    padding-top: 0px;">Id: <asp:Label ID="Label2" runat="server" Text='<%#  Bind("IdProductoTxt") %>'></asp:Label></li>
                            </ul>                     
                            <div class="card-body" style="   padding-top: 10px;">
                            <asp:LinkButton ID="LinkButton3" class="btn btn-primary"  CommandName="Edit" runat="server" CausesValidation="False">Editar</asp:LinkButton>
                            <div style="display:none">
                            <asp:LinkButton ID="LinkButton4" class="btn btn-danger" Enabled="false" CommandName="Delete" runat="server">Eliminar</asp:LinkButton>
                            </div>
                            </div>
                            </div>
                            </div>
                    </ItemTemplate>

</asp:DataList>      </center>
</ContentTemplate>
</asp:UpdatePanel>

          
<div style="display:none;">
            <asp:LinkButton ID="BtnGuardar" runat="server" OnClick="BtnGuardar_Click">Gaurdar</asp:LinkButton>

                 <asp:GridView ID="GV_prodImage"  
                        runat="server" AutoGenerateColumns="False" 
                     class="table table-bordered" 
                        OnRowDataBound="GvModif_RowDataBound" 
                        GridLines="None" 
                         Font-Size="9px" Height="10px" style="   margin-right: -8px;" CellSpacing="5"                          >
                           <HeaderStyle  BackColor="#0078D7" ForeColor="White" font-size="12px"   HorizontalAlign="Center" VerticalAlign="Middle"/>  
            <Columns>
        <asp:TemplateField HeaderText="ID">  
        <ItemTemplate>  
        <asp:Label ID="lbleid" runat="server" Text='<%# Eval("IdProductoTxt") %>'>  
        </asp:Label>  
        </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Empresa">
        <ItemTemplate>  
        <asp:Image ID="img1" runat="server" ImageUrl=' <%# Eval("Imagen") %>' Height="100px" Width="100px" /> 
            
        </ItemTemplate>   
        </asp:TemplateField>  

        <asp:TemplateField HeaderText="Subir Foto"> 
        <ItemTemplate>  
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </ItemTemplate>   
        </asp:TemplateField>  
            </Columns>
            <HeaderStyle Height="30px" />
                            <RowStyle font-size="9px"   HorizontalAlign="Center"   VerticalAlign="Middle"     /> 
        </asp:GridView>       </div> 
                 
            </center>
                    </div>
                </div>
                <%--</li>
</ul>--%>
            </div>
        </div>
        </div>  
        <div class="col-md-6" style="display: none">
            <div class="form-group">
                <label>Upload Image</label>
                <div class="input-group">
                    <span class="input-group-btn">
                        <span class="btn btn-default btn-file">Browse…
                            <input type="file" id="imgInp">
                        </span>
                    </span>
                    <input type="text" class="form-control" readonly>
                </div>
                <img id='img-upload' />
            </div>
        </div>
        <div id="myModal" class="modal">
            <center>
                  <a onclick="miFuncion()"  style="font-size: 24px;    cursor: pointer;" class="viewe"><i class="fas fa-times"></i></a><br style="clear:both"/>
  <img  id="mi_imagen"  onerror="this.src = 'images/noimagen.jpg'" style=" box-shadow: 0px -2px 15px 10px rgba(154, 154, 154, 0.77);
    border-radius: 10px;
    height: 50%;
    width: 50%;
    border: 2px solid #7b7272;"
    />
            </center>
        </div>

        <script>
            function miFuncion() {
                $('#myModal').modal('hide');  //For hide
            }

            function mostrarImg_nels(direcc) {
                //var src_img= direcc;
                $("#mi_imagen").attr("src", '');
                var cadena_url = direcc,
                               patron = "Z-",
                               nuevoValor = "",
                               src_img = cadena_url.replace(patron, nuevoValor);


                $("#mi_imagen").attr("src", src_img);

                $('#myModal').modal('show');
            }
            $(document).ready(function () {


                for (i = 0; i < number; i++) {
                    container.appendChild(document.createTextNode("Member " + (i + 1)));
                    var input = document.createElement("input");
                    input.type = "text";
                    container.appendChild(input);
                    container.appendChild(document.createElement("br"));
                }

                $(document).on('change', '.btn-file :file', function () {
                    var input = $(this),
                        label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
                    input.trigger('fileselect', [label]);
                });

                $('.btn-file :file').on('fileselect', function (event, label) {

                    var input = $(this).parents('.input-group').find(':text'),
                        log = label;

                    if (input.length) {
                        input.val(log);
                    } else {
                        if (log) alert(log);
                    }
                });
                function readURL(input) {
                    if (input.files && input.files[0]) {
                        var reader = new FileReader();

                        reader.onload = function (e) {
                            $('#img-upload').attr('src', e.target.result);
                        }

                        reader.readAsDataURL(input.files[0]);
                    }
                }

                $("#imgInp").change(function () {
                    readURL(this);
                });
            });
        </script>
    </form>
</asp:Content>
