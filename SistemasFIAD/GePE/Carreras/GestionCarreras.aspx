<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MP_SistemasFIADLogueados.master" AutoEventWireup="true" CodeBehind="GestionCarreras.aspx.cs" Inherits="GePE.Carreras.GestionCarreras" %>

<%@ Register Src="~/Controles/wefucNumeroEnteroPositivoReq.ascx" TagPrefix="uc1" TagName="wefucNumeroEnteroPositivoReq" %>
<%@ Register Src="~/Controles/wfucAlfabeticoRequerido.ascx" TagPrefix="uc1" TagName="wfucAlfabeticoRequerido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h5 class="text-dark font-weight-bold pl-2">Módulo de carreras</h5>

        <div class="row bg-light border pl-2">
            <div class="col-lg-8 col-md-6 col-sm-6">

                <asp:LinkButton ID="BtnMnuNuevo" runat="server" CssClass="btn btn-sm btn-secondary  pr-3" CausesValidation="false" OnClick="BtnMnuNuevo_Click"><i class="fas fa-plus-square"></i> Nueva carrera</asp:LinkButton>
                <asp:LinkButton ID="BtnMnuListado" runat="server" CssClass="btn btn-sm btn-secondary pr-3" CausesValidation="false" OnClick="BtnMnuListado_Click"><i class="fas fa-list"></i> Listado</asp:LinkButton>
            </div>
            <div class="col-lg-4 col-md-6 col-sm-6">
                <div class="row">
                    <div class="col-lg-8 col-md-6 col-sm-6">
                        <asp:TextBox ID="TbCriterioBusqueda" runat="server" CssClass="form-control" placeholder="Criterio de búsqueda"></asp:TextBox>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-6">
                        <asp:LinkButton ID="BtnBuscar" runat="server" CssClass="btn btn-sm btn btn-success " CausesValidation="false" OnClick="BtnBuscar_Click"><i class="fas fa-search"></i> Buscar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

        <div>
            <h4>
                <asp:Label ID="lblNombreAccion" runat="server" class="text-cebter text-primary"></asp:Label></h4>
        </div>

        <asp:Panel ID="PnlCapturaDatos" runat="server">
            <div class="container">
                <div class="card">
                    <div class="card-header text-center bg-success">
                        <h5 class="card-title">
                            <asp:Label ID="lblTituloAccion" runat="server" CssClass="text-white"></asp:Label></h5>
                    </div>

                    <div class="card-body">
                        <div class="row pl-2 pr-2">
                            <div class="col-lg-2 col-md-12 col-12">
                                <div class="form-group">
                                    <p class="text-dark font-weight-bold m-0">Clave de la carrera</p>
                                    <uc1:wfucAlfabeticoRequerido runat="server" ID="TbClaveCarrera" />
                                </div>
                            </div>
                            <div class="col-lg-10 col-md-12 col-12">
                                <div class="form-group">
                                    <p class="text-dark font-weight-bold m-0">Nombre de la carrera</p>
                                    <uc1:wfucAlfabeticoRequerido runat="server" ID="TbNombreCarrera" />
                                </div>
                            </div>
                        </div>

                        <div class="row pl-2 pr-2">
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <p class="text-dark font-weight-bold m-0">Alias</p>
                                    <uc1:wfucAlfabeticoRequerido runat="server" ID="TbAliasCarrera" />

                                </div>
                            </div>

                            <div class="row pl-2 pr-2">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <asp:CheckBox ID="cbActivaCarrera" runat="server" CssClass="font-weight-bold" Text="Carrera activa " TextAlign="Left" ToolTip="Seleccione si la carrera está activa" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer text-muted">
                            <asp:LinkButton ID="BtnGrabar" runat="server" CssClass="btn btn-md btn btn-success  pr-3" CausesValidation="true" OnClick="BtnGrabar_Click"><i class="fas fa-plus-square"></i> Grabar</asp:LinkButton>
                            <asp:LinkButton ID="BtnBorrar" runat="server" CssClass="btn btn-md btn btn-danger pr-3" CausesValidation="false" OnClick="BtnBorrar_Click"><i class="fas fa-minus-square"></i> Borrar</asp:LinkButton>
                            <asp:LinkButton ID="BtnModificar" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="true" OnClick="BtnModificar_Click"><i class="fas fa-edit"></i> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuEditar" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="true" OnClick="BtnMnuEditar_Click"><i class="fas fa-edit"></i> Editar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuBorrar" runat="server" CssClass="btn btn-md btn btn-danger pr-3" CausesValidation="false" OnClick="BtnMnuBorrar_Click"><i class="fas fa-minus-square"></i> Borrar</asp:LinkButton>
                            <asp:LinkButton ID="BtnCancelar" runat="server" CssClass="btn btn-md btn btn-dark pr-3" CausesValidation="false" OnClick="BtnCancelar_Click"><i class="fas fa-window-close"></i> Cancelar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PnlGrvCarreras" runat="server">
            <div class="container-fluid">
                <asp:GridView ID="GrvCarreras" runat="server" AutoGenerateColumns="False"
                    CssClass="table thead-dark table-sm table-bordered table-responsive"
                    DataKeyNames="IdCarrera"
                    OnRowDeleting="GrvCarreras_RowDeleting"
                    OnRowEditing="GrvCarreras_RowEditing"
                    OnSelectedIndexChanged="GrvCarreras_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ClaveCarrera" HeaderText="CLAVE" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="NOMBRE DE LA CARRERA" />
                        <asp:BoundField DataField="AliasCarrera" HeaderText="NOMBRE CORTO" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="NOMBRE DEL COORDINADOR" />
                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnEditar" runat="server" CssClass="btn btn-sm btn-primary "
                                    CausesValidation="false" CommandName="Edit"><i class="fas fa-edit"></i> Editar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="ACCIONES">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnBorrar" runat="server" CssClass="btn btn-sm btn-danger"
                                    CausesValidation="false" CommandName="Delete"><i class="fas fa-trash-alt"></i> Borrar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="bg-dark text-white" />
                </asp:GridView>
            </div>
        </asp:Panel>
    </div>
    <asp:HiddenField ID="hfIdCarrera" runat="server" />
</asp:Content>
