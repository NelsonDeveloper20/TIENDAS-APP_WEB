<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="FrmMiCuenta.aspx.cs" Inherits="Web_Nestle.FrmMiCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <form runat="server">
        <div class="alert alert-success alert-dismissible fade show mb-0" role="alert" style="display: none">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">×</span>
            </button>
            <i class="fa fa-check mx-2"></i>
            <strong>Success!</strong> Your profile has been updated!
        </div>
        <div class="main-content-container container-fluid px-4">
            <!-- Page Header -->
            <div class="page-header row no-gutters py-4">
                <div class="col-12 col-sm-4 text-center text-sm-left mb-0">
                    <span class="text-uppercase page-subtitle">Delcorp</span>
                    <h3 class="page-title">Mi Cuenta</h3>
                </div>
            </div>
            <!-- End Page Header -->
            <!-- Default Light Table -->
            <div class="row">
                <div class="col-lg-4">
                    <div class="card card-small mb-4 pt-3">
                        <div class="card-header border-bottom text-center">
                            <div class="mb-3 mx-auto">
                                <img class="rounded-circle" src="http://swedworks.se/wp-content/uploads/2018/05/person-logo.png" alt="User Avatar" width="110">
                            </div>
                            <h4 class="mb-0">
                                <asp:Label ID="LblNombre" runat="server" Text="Label"></asp:Label>
                            </h4>
                            <span class="text-muted d-block mb-2">User</span>
                            <button type="button" class="mb-2 btn btn-sm btn-pill btn-outline-primary mr-2">
                                <i class="material-icons mr-1">person_add</i>Foto</button>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item px-4">
                                <div class="progress-wrapper">
                                    <strong class="text-muted d-block mb-2"></strong>
                                    <div class="progress progress-sm">
                                        <div class="progress-bar bg-primary" role="progressbar" aria-valuenow="74" aria-valuemin="0" aria-valuemax="100" style="width: 74%;">
                                            <%--  <span class="progress-value">74%</span>--%>
                                        </div>
                                    </div>
                                </div>
                            </li>
                            <li class="list-group-item p-4">
                                <strong class="text-muted d-block mb-2"></strong>
                                <span></span>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-8">
                    <div class="card card-small mb-4">
                        <div class="card-header border-bottom">
                            <h6 class="m-0">Mis Datos</h6>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item p-3">
                                <div class="row">
                                    <div class="col">
                                        <form>
                                            <div class="form-row">
                                                <div class="form-group col-md-4">
                                                    <label for="feFirstName">Nombre</label>
                                                    <input type="text" runat="server" class="form-control" id="TxtNombre" placeholder="Nombre" style="text-transform: uppercase">
                                                </div>
                                                <div class="form-group col-md-4">
                                                    <label for="feLastName">Apellido Paterno</label>
                                                    <input type="text" runat="server" class="form-control" id="TxtPaterno" placeholder="Apellido Paterno" style="text-transform: uppercase">
                                                </div>
                                                <div class="form-group col-md-4">
                                                    <label for="feLastName">Apellido Materno</label>
                                                    <input type="text" runat="server" class="form-control" id="TxtMaterno" placeholder="Apellido Materno" style="text-transform: uppercase">
                                                </div>
                                            </div>
                                            <div class="form-row">
                                                <div class="form-group col-md-6">
                                                    <label for="feEmailAddress">Usuario</label>
                                                    <input type="email" class="form-control" runat="server" id="TxtUsuario" placeholder="Usuario" style="text-transform: uppercase">
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label for="fePassword">Password</label>
                                                    <input type="password" class="form-control" runat="server" id="TxtPassword" placeholder="Password">
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="feInputAddress">Direccion</label>
                                                <input type="text" class="form-control" id="feInputAddress" placeholder="Direccion" style="text-transform: uppercase">
                                            </div>
                                            <div class="form-row" style="display: none">
                                                <div class="form-group col-md-6">
                                                    <label for="feInputCity">City</label>
                                                    <input type="text" class="form-control" id="feInputCity">
                                                </div>
                                                <div class="form-group col-md-4">
                                                    <label for="feInputState">State</label>
                                                    <select id="feInputState" class="form-control">
                                                        <option selected>Choose...</option>
                                                        <option>...</option>
                                                    </select>
                                                </div>
                                                <div class="form-group col-md-2">
                                                    <label for="inputZip">Zip</label>
                                                    <input type="text" class="form-control" id="inputZip">
                                                </div>
                                            </div>
                                            <div class="form-row" style="display: none">
                                                <div class="form-group col-md-12">
                                                    <label for="feDescription">Description</label>
                                                    <textarea class="form-control" name="feDescription" rows="5">Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio eaque, quidem, commodi soluta qui quae minima obcaecati quod dolorum sint alias, possimus illum assumenda eligendi cumque?</textarea>
                                                </div>
                                            </div>
                                            <asp:LinkButton ID="BtnActualizar" CssClass="btn btn-accent" runat="server" OnClick="BtnActualizar_Click">Actualizar Cuenta</asp:LinkButton>

                                        </form>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- End Default Light Table -->
        </div>
    </form>
</asp:Content>
