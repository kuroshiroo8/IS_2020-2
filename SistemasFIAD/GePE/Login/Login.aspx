<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MP_SistemasFIADLogueados.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GePE.Login.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <!-- Outer Row -->
        <div class="row justify-content-center">
            <div class="col-xl-10 col-lg-12 col-md-9">
                <div class="card o-hidden border-0 shadow-lg my-4">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Bienvenido!</h1>
                                    </div>
                                    <form class="user">
                                        <div class="form-group">
                                            <asp:TextBox id="exampleInputEmail" runat="server" type="email" CssClass="form-control" aria-describedby="emailHelp" placeholder="Correo"/>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="exampleInputPassword" runat="server" type="password" CssClass="form-control" placeholder="Contraseña"/>
                                        </div>
                                        <div class="form-group">
                                                <asp:CheckBox ID="cbRecordar" runat="server" CssClass="form-control" text=" Recordar cotraseña"/>
                                        </div>
                                        <div align="center">
                                        <asp:LinkButton ID="btnSesion" runat="server" CssClass="btn btn-md btn btn-success pr-3" CausesValidation="true"><i class="fas fa-sign-in-alt"></i>  Iniciar Sesión</asp:LinkButton>
                                            </div>
                                    </form>
                                    <br />
                                    <div class="form-group">
                                                <asp:CheckBox ID="cbAlumno" runat="server" CssClass="form-control" text="Alumno" />
                                            </div>
                                    <div class="form-group">
                                                <asp:CheckBox ID="cbAdministrador" runat="server" CssClass="form-control" text="Administrador"/>
                                            </div>
                                    <div class="form-group">
                                                <asp:CheckBox ID="cbCapturista" runat="server" CssClass="form-control" TextAlign="right" Text="Capturista" /> <%--AutoPostBack="true" OnCheckedChanged="Check_selected"/>--%>
                                            </div>
                                    <hr>
                                    <div class="text-center">
                                        <!--a class="small" href="forgot-password.html">Forgot Password?</a-->
                                    </div>
                                    <div class="text-center">
                                        <!--a class="small" href="register.html">Create an Account!</a-->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
