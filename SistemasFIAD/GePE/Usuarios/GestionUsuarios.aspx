﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MP_SistemasFIADLogueados.master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="GePE.usuarios.GestionUsuarios" %>

<%@ Register Src="../Controles/wfucAlfanumericoRequerido.ascx" TagPrefix="uc1" TagName="wfucAlfanumericoRequerido" %>
<%@ Register Src="../Controles/wfucNumeroEnteroPositivoRequerido.ascx" TagPrefix="uc1" TagName="wfucNumeroEnteroPositivoRequerido" %>
<%@ Register Src="../Controles/wfucTbAlfabeticoRequerido.ascx" TagPrefix="uc1" TagName="wfucTbAlfabeticoRequerido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h5 class="text-dark font-weight-bold pl-2">Módulo de usuarios</h5>

        <div class="row bg-light border pl-2">
            <div class="col-lg-8 col-md-6 col-sm-6">

                <asp:LinkButton ID="BtnMnuNuevo" runat="server" CssClass="btn btn-sm btn-secondary  pr-3" CausesValidation="false" OnClick="BtnMnuNuevo_Click"><i class="fas fa-plus-square"></i> Nuevo usuario</asp:LinkButton>
                <asp:LinkButton ID="BtnMnuListado" runat="server" CssClass="btn btn-sm btn-secondary pr-3" CausesValidation="false" OnClick="BtnMnuListado_Click"><i class="fas fa-list"></i> Listado</asp:LinkButton>
            </div>
            <div class="col-lg-4 col-md-6 col-sm-6">
                <div class="row">
                    <div class="col-lg-8 col-md-6 col-sm-6">
                        <asp:TextBox ID="TbCriterioBusqueda" runat="server" CssClass="form-control" placeholder="Criterio de búsqueda" tyle="text-align:center"></asp:TextBox>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-6">
                        <asp:LinkButton ID="BtnBuscar" runat="server" CssClass="btn btn-sm btn btn-success " CausesValidation="false" OnClick="BtnBuscar_Click"><i class="fas fa-search"></i> Buscar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

        <div align="center">
            <h4>
                <asp:Label ID="lblNombreAccion" runat="server" class="text-ceter text-primary"></asp:Label></h4>
        </div>
        <%-------------------------------seccion agregar--------------------------------------%>
        <asp:Panel ID="PnlCapturaDatos" runat="server">
            <div class="container">
                <div class="card">
                    <div class="card-header text-center bg-success">
                        <h5 class="card-title">
                            <asp:Label ID="lblTituloAccion" runat="server" CssClass="text-white"></asp:Label></h5>
                    </div>

                    <div class="card-body">
                        <div class="row pl-2 pr-2">
                            <div class="col-lg-4 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbCalveUsuario" runat="server" class="text-dark font-weight-bold m-0">Clave del usuario</asp:Label>
                                    <asp:TextBox runat="server" ID="TbnumClaveUsuario1" CssClass="form-control" TextMode="Number"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbnumClaveUsuario1" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbnumClaveUsuario1"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="revTbnumClaveUsuario1" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbnumClaveUsuario1"
                                        ErrorMessage="*Este campo debe de tener la estructura XXX con numeros de 0 a 9."
                                        ValidationExpression="^[0-9]{3}$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                            </div>
                            <div class="col-lg-4 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbNombreUsuario" class="text-dark font-weight-bold m-0" runat="server">Nombre del usuario</asp:Label>

                                    <asp:TextBox runat="server" ID="TbNombreUsuario" CssClass="form-control" placeholder="Nombre(s)" tyle="text-align:center"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbNombreUsuario" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbNombreUsuario"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="revTbNombreUsuario" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbNombreUsuario"
                                        ErrorMessage="*Sólo letras."
                                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]+$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbApellidoPaterno" class="text-dark font-weight-bold m-0" runat="server">Apellido paterno</asp:Label>
                                    <asp:TextBox runat="server" ID="TbApellidoPaterno" CssClass="form-control" placeholder="Apellido Paterno" tyle="text-align:center"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbApellidoPaterno" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbApellidoPaterno"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="revTbApellidoPaterno" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbApellidoPaterno"
                                        ErrorMessage="*Sólo letras."
                                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]+$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="col-lg-4 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbApellidoMaterno" class="text-dark font-weight-bold m-0" runat="server">Apellido materno</asp:Label>
                                    <asp:TextBox runat="server" ID="TbApellidoMaterno" CssClass="form-control" placeholder="Apellido Materno" tyle="text-align:center"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbApellidoMaterno" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbApellidoMaterno"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="revTbApellidoMaterno" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbApellidoMaterno"
                                        ErrorMessage="*Sólo letras."
                                        ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]+$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbCorreoUsuario" class="text-dark font-weight-bold m-0" runat="server">Correo del usuario</asp:Label>
                                    <asp:TextBox ID="TbCorreoUsuario" runat="server" type="email" CssClass="form-control" aria-describedby="emailHelp" placeholder="Correo@uabc.edu.mx" />

                                    <asp:RequiredFieldValidator ID="rfvTbCorreoUSuario" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbCorreoUsuario"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="revTbCorreoUsuario" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbCorreoUsuario"
                                        ErrorMessage="*Este campo debe de tener una estructura parecida a ejemplo@uabc.edu.mx"
                                        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <div class="col-lg-4 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbContraseña" Class="text-dark font-weight-bold m-0" runat="server">Contraseña</asp:Label>
                                    <br />
                                    <asp:TextBox ID="TbContraseñaUsuario1" runat="server" type="password" CssClass="form-control" placeholder="Contraseña" />

                                    <asp:RequiredFieldValidator ID="rfvTbContraseñaUsuario1" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbContraseñaUsuario1"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="revTbContraseñaUsuario1" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbContraseñaUsuario1"
                                        ErrorMessage="*Sólo alfanumericos."
                                        ValidationExpression="^[a-zA-Z0-Z9ñÑáéíóúÁÉÍÓÚ -.,]+$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="col-lg-3 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbTipoUsuario" class="text-dark font-weight-bold m-0" runat="server">Tipo usuario</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlTipoUsuario" CssClass="form-control">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlProgramaEducativo" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlTipoUsuario"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer text-muted" align="center">
                            <asp:LinkButton ID="BtnGrabar" runat="server" CssClass="btn btn-md btn btn-success  pr-3" CausesValidation="true" OnClick="BtnGrabar_Click"><i class="fas fa-plus-square"></i> Insertar</asp:LinkButton>
                            <asp:LinkButton ID="BtnBorrarModal" runat="server" CssClass="btn btn-md btn btn-danger pr-3" data-toggle="modal" CausesValidation="false" data-target="#BorrarModal"><i class="fas fa-trash-alt"></i>Borrar</asp:LinkButton>
                            <asp:LinkButton ID="BtnModificar" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="true" OnClick="BtnModificar_Click"><i class="fas fa-edit"></i> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuEditar" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="true" OnClick="BtnMnuEditar_Click"><i class="fas fa-edit"></i> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuBorrar" runat="server" CssClass="btn btn-md btn btn-danger pr-3" CausesValidation="false" OnClick="BtnMnuBorrar_Click"><i class="fas fa-trash-alt"></i> Borrar</asp:LinkButton>
                            <asp:LinkButton ID="BtnCancelar" runat="server" CssClass="btn btn-md btn btn-dark pr-3" CausesValidation="false" OnClick="BtnCancelar_Click"><i class="fas fa-window-close"></i> Cancelar</asp:LinkButton>
                            <asp:LinkButton ID="BtnAceptar" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="false" OnClick="BtnCancelar_Click"><i class="fas fa-check"></i> Aceptar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PnlGrvUsuarios" runat="server">
            <div class="container-fluid">
                <asp:GridView ID="GrvUsuarios" runat="server" AutoGenerateColumns="False"
                    CssClass="table thead-dark table-sm table-bordered table-responsive"
                    DataKeyNames="IdUsuario"
                    OnRowDeleting="GrvUsuarios_RowDeleting"
                    OnRowEditing="GrvUsuarios_RowEditing"
                    OnSelectedIndexChanged="GrvUsuarios_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ClaveUsuario" HeaderText="CLAVE" />
                        <asp:BoundField DataField="NombreUsuario" HeaderText="NOMBRE DEL USUARIO" />
                        <asp:BoundField DataField="CorreoUSuario" HeaderText="CORREO DEL USUARIO" />
                        <asp:BoundField DataField="TipoUsuario" HeaderText="TIPO USUARIO" />

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnEditar" runat="server" CssClass="btn btn-md btn-primary "
                                    CausesValidation="false" CommandName="Edit"><i class="fas fa-edit"></i> Modificar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="ACCIONES">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnBorrar" runat="server" CssClass="btn btn-md btn-danger"
                                    CausesValidation="false" CommandName="Delete"><i class="fas fa-trash-alt"></i> Borrar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnNotificar" runat="server" CssClass="btn btn-md btn-warning"
                                    CausesValidation="false" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>"><i class="fas fa-envelope-open-text"></i> Notificar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle CssClass="bg-dark text-white" />
                </asp:GridView>
            </div>
        </asp:Panel>
        <%------------modal-borrar---------------------%>
        <div class="modal fade" id="BorrarModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">¿Esta seguro de borrar este registro?</h5>
                        <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                    <div class="modal-body">Si lo esta, presione "Borrar". </div>
                    <div class="modal-footer">
                        <button class="btn btn-md btn btn-dark pr-3" type="button" data-dismiss="modal"><i class="fas fa-window-close"></i>Cancelar</button>
                        <asp:LinkButton ID="BtnBorrar" runat="server" CssClass="btn btn-md btn btn-danger pr-3" CausesValidation="false" OnClick="BtnBorrar_Click"><i class="fas fa-trash-alt"></i> Borrar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <asp:HiddenField ID="hfIdUsuario" runat="server" />
</asp:Content>
