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

                                    <div align="center">
                                        <h4>
                                            <asp:Label ID="lblNombreAccion" runat="server" class="text-ceter text-primary" CssClass="text-danger"></asp:Label></h4>
                                    </div>

                                    <form class="user">
                                        <div class="form-group">

                                            <asp:Label ID="lbEmail" class="text-dark font-weight-bold m-0" runat="server">Correo:</asp:Label>
                                            <br />
                                            <asp:TextBox ID="TbEmail" runat="server" type="email" CssClass="form-control" aria-describedby="emailHelp" placeholder="Correo" />

                                            <asp:RequiredFieldValidator ID="rfvTbEmail" runat="server" CssClass="text-danger"
                                                ControlToValidate="TbEmail"
                                                ErrorMessage="*Este campo es requerido."
                                                Display="Dynamic"></asp:RequiredFieldValidator>

                                            <asp:RegularExpressionValidator ID="revTbEmail" runat="server" CssClass="text-danger"
                                                ControlToValidate="TbEmail"
                                                ErrorMessage="*Este campo debe de tener una estructura parecida a ejemplo@uabc.edu.mx"
                                                ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                                                Display="Dynamic"></asp:RegularExpressionValidator>

                                        </div>
                                        <div class="form-group">

                                            <asp:Label ID="lbPass" class="text-dark font-weight-bold m-0" runat="server">Contraseña:</asp:Label>
                                            <br />
                                            <asp:TextBox ID="TbPass" runat="server" type="password" CssClass="form-control" placeholder="Contraseña" />

                                            <asp:RequiredFieldValidator ID="rfvTbPass" runat="server" CssClass="text-danger"
                                                ControlToValidate="TbPass"
                                                ErrorMessage="*Este campo es requerido."
                                                Display="Dynamic"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="form-group">

                                            <asp:Label ID="lbLogin" class="text-dark font-weight-bold m-0" runat="server">Tipo usuario:</asp:Label>
                                            <br />
                                            <asp:DropDownList runat="server" ID="ddlLogin" CssClass="form-control">
                                                <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="rfvddlLogin" runat="server" CssClass="text-danger"
                                                ControlToValidate="ddlLogin"
                                                ErrorMessage="*Este campo es requerido."
                                                InitialValue=""
                                                Display="Dynamic"></asp:RequiredFieldValidator>

                                        </div>
                                        <div align="center">
                                            <asp:LinkButton ID="BtnLogin" runat="server" CssClass="btn btn-md btn btn-success pr-3" CausesValidation="true" OnClick="BtnLogin_Click"><i class="fas fa-sign-in-alt"></i>  Iniciar Sesión</asp:LinkButton>
                                            <hr />
                                            <asp:LinkButton ID="BtnSinLogin" runat="server" CssClass="btn btn-md btn btn-warning pr-3" CausesValidation="false" OnClick="BtnSinLogin_Click"><i class="fas fa-sign-in-alt"></i>  Entrar sin iniciar sesión</asp:LinkButton>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
