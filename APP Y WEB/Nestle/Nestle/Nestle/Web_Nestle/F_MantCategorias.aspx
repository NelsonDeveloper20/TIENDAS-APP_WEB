<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="F_MantCategorias.aspx.cs" Inherits="Web_Nestle.F_MantCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
<style> 

      /*booostrap*/ .hidden-field
 {
     display:none;
 }
      .btn {
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
  </style>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager" runat="server" />  
    <asp:HiddenField ID="HdnId_Up" ClientIDMode="Static" runat="server" />
  <div class="row" style="margin-top: 10px;">              
              <div class="col-lg-5">
                <!-- Post Overview -->
                 <%-- <div class="card border-primary mb-3">--%>
                          <div class="card border-primary mb-3">
                        <div class="card-header text-black"> Categoria</div>
                        <div class="">                            
                             <input id="box" style="display:none"> 
                        <div class="input-group col-lg-12" style="   padding-right: 3px;   padding-left: 3px;">
                              <asp:FileUpload ID="FlImg_Nuevo" CssClass="form-control" runat="server" />
                        <input type="text" class="form-control" runat="server" id="txtNuevoCate" placeholder="Nueva Categoria" aria-label="Add new category" aria-describedby="basic-addon2">
                        <div class="input-group-append">
                            <asp:LinkButton ID="BtnNuevo_Cate" CssClass="btn btn-white px-2" runat="server" OnClick="BtnNuevo_Cate_Click">     <i class="material-icons">add</i></asp:LinkButton>                      
                        </div>
                        </div>
                            </div>
                        <asp:TreeView ID="treeViewProductos" NodeStyle-CssClass="treeNode"  ClientIDMode="Static" ShowCheckBoxes="All" AutoPostBack="true" runat="server" 
                        OnTreeNodeCheckChanged="treeViewProductos_TreeNodeCheckChanged" >
                         <%--  ExpandImageUrl="iconos/mas2.png"
             CollapseImageUrl="~/Images/Collapse.jpg"
             LeafNodeStyle-ImageUrl="~/Images/Leaf.jpg"--%>
                           
                        </asp:TreeView>
                        </div>
                <!-- / Post Overview -->
              </div>
      <div class="col-md-7">
                <!-- Add New Post Form -->            
             <div class='card border-primary mb-4'>                     
                        <div class="card-header text-black">Edit Categoria</div>
            
                    <div  style="display:block" id="d_modif">                        
                   
                    <div class="form-group col-md-12">
                    <label>Categoria</label>                                 
                    <input type="text" id="txtcategoria"  ClientIDMode="Static" runat="server"   class="form-control"/>      
                    </div>                     
                         
                    <div class="col-md-12">
                    <div class="form-group">       
                    <div class="input-group">
                        
                    <asp:FileUpload ID="imgInp" ClientIDMode="Static" class="form-control" onchange="preview_image(event)" runat="server" /> 
                    
                    </div>
                    <img id='img-upload' width="100%" src="" onerror="this.src = 'http://www.ciccolombia.travel/images/Parameters/publicar-anuncio-gratis.png'" height="250px"/>
                    </div>
                    </div>
                    <div class="col-md-12"> 
                    <div class="row">      
                    <div class="form-group col-lg-4">
                  <button type="button" style="width: 100%;"  class="btn btn-success" runat="server" OnClick="validateModif()">Modificar <i class="fas fa-sync-alt"></i></button>
                  
                    <%--<asp:LinkButton ID="BntModificarCate"  CssClass="btn btn-info" runat="server" OnClick="BntModificarCate_Click">Modificar</asp:LinkButton>--%>
                    </div>
                    <div class="form-group col-lg-4">
                     <button type="button" class="btn btn-primary" style="width: 100%;"  onclick="func_Nuevo()"> nuevo</button>
                    </div>
                    <div class="form-group col-lg-4">
                   <button type="button" class="btn btn-danger" style="width: 100%;"  onclick="func_eliminar()"> Eliminar</button>
                    </div> </div></div>                    
                    </div>
              
                   <div  style="display:none" id="d_nuevo">    
                    <div class="form-group col-md-12">
                    <label> Categoria</label>                                 
                    <input type="text" id="txtcategoriaNuevo"  readonly class="form-control"/>      
                    </div>
                    <div class="form-group col-lg-12">
                    <label>Nombre</label>
                    <input type="text" name="" class="form-control" runat="server" ClientIDMode="Static" id="txtnomCategoria">
                    </div>                          
                         
                    <div class="col-md-12">
                    <div class="form-group">       
                    <div class="input-group">
                    <asp:FileUpload ID="FileUpload2" ClientIDMode="Static" CssClass="form-control" runat="server" onchange="preview_image_nuevo(event)"/>                   
                    </div>
                    <img id='img-upload2' src="" onerror="this.src = 'http://www.ciccolombia.travel/images/Parameters/publicar-anuncio-gratis.png'" width="100%" height="250px"/>
                    </div>
                    </div>
                      
                    <div class="col-md-12"> 
                    <div class="row">      
                    <div class="form-group col-lg-4">
                    <button type="button" style="width: 100%;"  class="btn btn-info" runat="server" OnClick="valida_insert()">Guardar <i class="fas fa-save"></i></button>
                    </div>
                    <div class="form-group col-lg-4">
                    <button type="button" onclick="func_Modifc()"  class="btn btn-warning" style=" width: 100%;color: #FFFFFF;">Cancelar</button>
                    </div> </div></div>
                    </div>
                   
                         
             </div>
              </div>
            </div>
    
    <div style="display:none">
        <asp:Button ID="BtnInsertar" runat="server" OnClick="Submit" Text="Button" />
        <asp:Button ID="BtnModif" runat="server" OnClick="BntModificarCate_Click" Text="Button" />
        <asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click" Text="Button" />
        <asp:HiddenField ID="HdnFoto" ClientIDMode="Static" runat="server" />
    </div>
    <script>

        $(document).ready(function () {
            $("#box").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $('#treeViewProductos').contents().find('table tbody tr td').filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });

        });
        function func_eliminar() {
            var valor = '';
              var tree = document.getElementById("<%=treeViewProductos.ClientID %>");
            var checkboxes = tree.getElementsByTagName("INPUT");
            for (var i = 0; i < checkboxes.length; i++) {
                //If CheckBox is checked.
                if (checkboxes[i].checked) {
                    var value = checkboxes[i].title;
                    valor += value;
                }
            }
            if (valor == '') {
                swal({
                    title: "Seleccione Categoria",
                    icon: "warning",
                    dangerMode: true,
                });
                return;
            }
          //  alert(valor);
            $("#HdnId_Up").val(valor);
            document.getElementById('<%= BtnEliminar.ClientID %>').click();

        }
        function validateModif() {
            var valor = '';
             var tree = document.getElementById("<%=treeViewProductos.ClientID %>");
            var checkboxes = tree.getElementsByTagName("INPUT");
            for (var i = 0; i < checkboxes.length; i++) {
                //If CheckBox is checked.
                if (checkboxes[i].checked) {
                    var value = checkboxes[i].title;
                    valor += value;
                }
            }
            if (valor == '') {
                swal({
                    title: "Seleccione Categoria",
                    icon: "warning",
                    dangerMode: true,
                });
                return;
            }
            if ($('#txtcategoria').val() == "") {
                // alert('Ingrese rut');    

                swal({
                    title: "Ingrese Nombre De Categoria",
                    icon: "warning",
                    dangerMode: true,
                });
                document.getElementById("txtnomCategoria").focus();
                return;
            }
  /*          if (document.getElementById("imgInp").files.length == 0) {
                swal({
                    title: "Seleccione Imagen",
                    icon: "warning",
                    dangerMode: true,
                });
                document.getElementById("imgInp").focus();
                return;
            }
*/
              document.getElementById('<%= BtnModif.ClientID %>').click();

        }
        function valida_insert() {
            var valor = '';
            var tree = document.getElementById("<%=treeViewProductos.ClientID %>");
            var checkboxes = tree.getElementsByTagName("INPUT");
            for (var i = 0; i < checkboxes.length; i++) {
                //If CheckBox is checked.
                if (checkboxes[i].checked) {
                    var value = checkboxes[i].title;
                    valor += value;
                }
            }
            if (valor == '') {
                swal({
                    title: "Seleccione Categoria",
                    icon: "warning",
                    dangerMode: true,
                });
                return;
            }
            if ($('#txtnomCategoria').val() == "") {
                // alert('Ingrese rut');    
              
                swal({
                    title: "Ingrese Nombre  De Sub Categoria",
                    icon: "warning",
                    dangerMode: true,
                });
                document.getElementById("txtnomCategoria").focus();
                return;                
            }
            if (document.getElementById("FileUpload2").files.length == 0) {
                swal({
                    title: "Seleccione Imagen",
                    icon: "warning",
                    dangerMode: true,
                });
                document.getElementById("FileUpload2").focus();
                return;
            }

        document.getElementById('<%= BtnInsertar.ClientID %>').click();
        }
      function func_Nuevo(){    
          document.getElementById("d_modif").style.display = "none";
          document.getElementById("d_nuevo").style.display = "block";
      }
      function func_Modifc() {
          document.getElementById("d_modif").style.display = "block";
          document.getElementById("d_nuevo").style.display = "none";
      }
        function fireCheckChanged() {

             
             $("#imgInp").val('');
             $("#FileUpload2").val('');
            var treeNode = event.srcElement || event.target;
            if (treeNode.tagName == "INPUT" && treeNode.type == "checkbox") {
                if (treeNode.checked) {
                    uncheckOthers(treeNode.id);
                }              
            }

            var selected = "";
            var valuee = "";
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
            $('#img-upload').attr('src', '');
              var data = {
                        idup: valuee
                    }
                   
                    $.ajax({
                        type: "POST",                                              // tipo de request que estamos generando
                        url: 'F_MantCategorias.aspx/obtenerCateg',                    // URL al que vamos a hacer el pedido
                        data: JSON.stringify(data),                                  // data es un arreglo JSON que contiene los parámetros que 
                        // van a ser recibidos por la función del servidor
                        contentType: "application/json; charset=utf-8",            // tipo de contenido
                        dataType: "json",                                          // formato de transmición de datos
                        async: true,                                               // si es asincrónico o no
                        success: function (response) {
                            // función que va a ejecutar si el pedido fue exitoso
                            var categoriaData = (typeof response.d) == 'string' ?
                                   eval('(' + response.d + ')') :
                                   response.d;
                            var RutaImagen='';
                            $("#HdnFoto").val(RutaImagen);
                            for (var i = 0; i < categoriaData.length; i++) {
                                RutaImagen = categoriaData[i].Imagen;
                            }
                            var cadena_url = RutaImagen,
                            patron = "Z-",
                            nuevoValor = "",
                            src_img = cadena_url.replace(patron, nuevoValor);
                            var urlimg = 'http://3.19.108.54/nestle/CategoriaImagen/' + src_img;
                           // alert(urlimg);
                            //document.getElementById("img-upload").src = urlimg;
                            $('#img-upload').attr('src', urlimg);
                            $("#HdnFoto").val(RutaImagen);
                            
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                            var error = eval("(" + XMLHttpRequest.responseText + ")");
                            //alert(error.Message);
                        }
                    });
                    $("#txtcategoria").val(selected);
                    $("#txtcategoriaNuevo").val(selected);
                    $("#HdnId_Up").val(valuee);
        }
      
        function uncheckOthers(id) {
            var elements = document.getElementsByTagName('input');
            // loop through all input elements in form
            for (var i = 0; i < elements.length; i++) {
                if (elements.item(i).type == "checkbox") {
                    if (elements.item(i).id != id) {
                        elements.item(i).checked = false;
                    }
                }
            }
        }
      

        function preview_image(event) {
            var reader = new FileReader();
            reader.onload = function () {
                var output = document.getElementById('img-upload');
                output.src = reader.result;
            }
            reader.readAsDataURL(event.target.files[0]);
        }
        function preview_image_nuevo(event) {
            var reader = new FileReader();
            reader.onload = function () {
                var output = document.getElementById('img-upload2');
                output.src = reader.result;
            }
            reader.readAsDataURL(event.target.files[0]);
        }
          
    </script>
    </form>
</asp:Content>
