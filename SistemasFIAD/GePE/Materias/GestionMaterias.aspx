<%@ Page Title="" Language="C#" MasterPageFile="../PaginasMaestras/MP_SistemasFIADLogueados.master" AutoEventWireup="true" CodeBehind="GestionMaterias.aspx.cs" Inherits="GePE.Materias.GestionMaterias" %>

<%@ Register Src="../Controles/wfucAlfanumericoRequerido.ascx" TagPrefix="uc1" TagName="wfucAlfanumericoRequerido" %>
<%@ Register Src="../Controles/wfucNumeroEnteroPositivoRequerido.ascx" TagPrefix="uc1" TagName="wfucNumeroEnteroPositivoRequerido" %>
<%@ Register Src="../Controles/wfucTbAlfabeticoRequerido.ascx" TagPrefix="uc1" TagName="wfucTbAlfabeticoRequerido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h5 class="text-dark font-weight-bold pl-2">Módulo de materias</h5>

        <div class="row bg-light border pl-2">
            <div class="col-lg-8 col-md-6 col-sm-6">

                <asp:LinkButton ID="BtnMnuNuevo" runat="server" CssClass="btn btn-sm btn-secondary  pr-3" CausesValidation="false" OnClick="BtnMnuNuevo_Click"><i class="fas fa-plus-square"></i> Nueva materia</asp:LinkButton>
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
                <asp:Label ID="lblNombreAccion" runat="server" class="text-ceter text-primary"></asp:Label>
            </h4>
        </div>
        <%-------------------------------seccion agregar--------------------------------------%>
        <asp:Panel ID="PnlCapturaDatos" runat="server">
            <div class="container">
                <div class="card">
                    <div class="card-header text-center bg-success">
                        <h5 class="card-title">
                            <asp:Label ID="lblTituloAccion" runat="server" CssClass="text-white"></asp:Label></h5>
                    </div>

                    <div class="card-body" align="center">
                        <div class="row pl-2 pr-2">
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbClaveMateria" class="text-dark font-weight-bold m-0" runat="server">Clave de la materia</asp:Label>
                                    <uc1:wfucNumeroEnteroPositivoRequerido runat="server" ID="TbClaveMateria" />
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbNombreMateria" class="text-dark font-weight-bold m-0" runat="server">Nombre de la materia</asp:Label>
                                    <uc1:wfucAlfanumericoRequerido runat="server" ID="TbNombreMateria" />
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbHC" class="text-dark font-weight-bold m-0" runat="server">Horas Clase</asp:Label>
                                    <uc1:wfucNumeroEnteroPositivoRequerido runat="server" ID="TbHC" />
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbHL" class="text-dark font-weight-bold m-0" runat="server">Horas Laboratorio</asp:Label>
                                    <uc1:wfucNumeroEnteroPositivoRequerido runat="server" ID="TbHL" />
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbHT" class="text-dark font-weight-bold m-0" runat="server">Horas Taller</asp:Label>
                                    <uc1:wfucNumeroEnteroPositivoRequerido runat="server" ID="TbHT" />
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbHE" class="text-dark font-weight-bold m-0" runat="server">Horas Extra Clase</asp:Label>
                                    <uc1:wfucNumeroEnteroPositivoRequerido runat="server" ID="TbHE" />
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbHPP" class="text-dark font-weight-bold m-0" runat="server">Horas Practicas Profesionales</asp:Label>
                                    <uc1:wfucNumeroEnteroPositivoRequerido runat="server" ID="TbHPP" />
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbCR" class="text-dark font-weight-bold m-0" runat="server">Creditos</asp:Label>
                                    <asp:TextBox ID="TbCR" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    <br />
                                    <asp:Label runat="server" ID="lbStatusCR" Text="Estado de la carga: " />
                                    <br />
                                </div>
                            </div>
                            <%--<div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbEstadoMateria" class="text-dark font-weight-bold m-0" runat="server">Seleccione si la materia está activa</asp:Label>
                                    <asp:CheckBox ID="cbEstadoMateria" runat="server" CssClass="font-weight-bold" Text="Materia activa " TextAlign="Left" ToolTip="Seleccione si la materia está activa" />
                                </div>
                            </div>--%>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbPathPUA" class="text-dark font-weight-bold m-0" runat="server">Pua oficial</asp:Label>
                                    <br />
                                    <asp:FileUpload ID="FuPathPUA" runat="server" />
                                    <br />
                                    <asp:Label runat="server" ID="lbStatusPathPUA" Text="Estado de la carga: " />
                                    <br />
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbPathPUAnoOficial" class="text-dark font-weight-bold m-0" runat="server">PUA no oficial</asp:Label>
                                    <br />
                                    <asp:FileUpload ID="FuPathPUAnoOficial" runat="server" />
                                    <br />
                                    <asp:Label runat="server" ID="lbStatusPathPUAnoOficial" Text="Estado de la carga: " />
                                    <br />
                                </div>
                            </div>
                        </div>
                        <div class="card-footer text-muted" align="center">
                            <asp:LinkButton ID="BtnGrabar" runat="server" CssClass="btn btn-md btn btn-success  pr-3" CausesValidation="true" OnClick="BtnGrabar_Click"><i class="fas fa-plus-square"></i> Insertar</asp:LinkButton>
                            <asp:LinkButton ID="BtnBorrarModal" runat="server" CssClass="btn btn-md btn btn-danger pr-3" data-toggle="modal" CausesValidation="false" data-target="#BorrarModal"><i class="fas fa-trash-alt"></i>Borrar</asp:LinkButton>
                            <asp:LinkButton ID="BtnModificar" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="true" OnClick="BtnModificar_Click"><i class="fas fa-edit"></i> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuEditar" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="false" OnClick="BtnMnuEditar_Click"><i class="fas fa-edit"></i> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuBorrar" runat="server" CssClass="btn btn-md btn btn-danger pr-3" CausesValidation="false" OnClick="BtnMnuBorrar_Click"><i class="fas fa-trash-alt"></i> Borrar</asp:LinkButton>
                            <asp:LinkButton ID="BtnCancelar" runat="server" CssClass="btn btn-md btn btn-dark pr-3" CausesValidation="false" OnClick="BtnCancelar_Click"><i class="fas fa-window-close"></i> Cancelar</asp:LinkButton>
                            <asp:LinkButton ID="BtnAceptar" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="false" OnClick="BtnCancelar_Click"><i class="fas fa-check"></i> Aceptar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PnlGrvMateria" runat="server">
            <div class="container-fluid">
                <asp:GridView ID="GrvMateria" runat="server" AutoGenerateColumns="False"
                    CssClass="table thead-dark table-sm table-bordered table-responsive"
                    DataKeyNames="IdMateria"
                    OnRowDeleting="GrvMaterias_RowDeleting"
                    OnRowEditing="GrvMaterias_RowEditing"
                    OnSelectedIndexChanged="GrvMaterias_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ClaveMateria" HeaderText="CLAVE" />
                        <asp:BoundField DataField="NombreMateria" HeaderText="MATERIA" />
                        <asp:BoundField DataField="HC" HeaderText="HC" />
                        <asp:BoundField DataField="HL" HeaderText="HL" />
                        <asp:BoundField DataField="HT" HeaderText="HT" />
                        <asp:BoundField DataField="HE" HeaderText="HE" />
                        <asp:BoundField DataField="HPP" HeaderText="HPP" />
                        <asp:BoundField DataField="CR" HeaderText="CR" />
                        <%--<asp:BoundField DataField="EstadoMateria" HeaderText="ESTADO" />--%>
                        <asp:HyperLinkField DataNavigateUrlFields="PathPUA" HeaderText="PathPUA"
                            DataNavigateUrlFormatString="" DataTextField="PathPUA" Target="_BLANK"
                            ControlStyle-CssClass="btn btn-md btn-info" DataTextFormatString="Ver"></asp:HyperLinkField>
                        <asp:HyperLinkField DataNavigateUrlFields="PathPUAnoOficial" HeaderText="PathPUAnoOficial"
                            DataNavigateUrlFormatString="" DataTextField="PathPUAnoOficial" Target="_BLANK"
                            ControlStyle-CssClass="btn btn-md btn-info" DataTextFormatString="Ver"></asp:HyperLinkField>
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
    <asp:HiddenField ID="hfIdMateria" runat="server" />
</asp:Content>
