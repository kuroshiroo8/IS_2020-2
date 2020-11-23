<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MP_SistemasFIADLogueados.master" AutoEventWireup="true" CodeBehind="GestionMaterias.aspx.cs" Inherits="GePE.Materias.GestionMaterias" %>


<%@ Register Src="~/Controles/wfucAlfanumericoRequerido.ascx" TagPrefix="uc1" TagName="wfucAlfanumericoRequerido" %>
<%@ Register Src="~/Controles/wfucNumeroEnteroPositivoRequerido.ascx" TagPrefix="uc1" TagName="wfucNumeroEnteroPositivoRequerido" %>
<%@ Register Src="~/Controles/wfucTbAlfabeticoRequerido.ascx" TagPrefix="uc1" TagName="wfucTbAlfabeticoRequerido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h5 class="text-dark font-weight-bold pl-2">Módulo de materias</h5>

        <div class="row bg-light border pl-2">
            <div class="col-lg-8 col-md-6 col-sm-6">

                <asp:LinkButton ID="BtnMnuNuevo" runat="server" CssClass="btn btn-sm btn-secondary  pr-3" CausesValidation="false" OnClick="BtnMnuNuevo_Click"><i class="fas fa-plus-square"></i> Nueva carrera</asp:LinkButton>
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
                            <div class="col-lg-3 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbClaveMateria" class="text-dark font-weight-bold m-0" runat="server">Clave de la carrera</asp:Label>
                                    <uc1:wfucNumeroEnteroPositivoRequerido runat="server" ID="TbClaveMateria" />
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbNombreMateria" class="text-dark font-weight-bold m-0" runat="server">Nombre de la carrera</asp:Label>
                                    <uc1:wfucAlfanumericoRequerido runat="server" ID="TbNombreMateria" />
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
        <%-------------------------------fin de agegar ----------------------------%>
        <asp:Panel ID="PnlGrvMateria" runat="server">
            <div class="container-fluid">
                <asp:GridView ID="GrvMateria" runat="server" AutoGenerateColumns="False"
                    CssClass="table thead-dark table-sm table-bordered table-responsive"
                    DataKeyNames="IdMateria"
                    OnRowDeleting="GrvMaterias_RowDeleting"
                    OnRowEditing="GrvMaterias_RowEditing"
                    OnSelectedIndexChanged="GrvMaterias_SelectedIndexChanged">
                    <Columns>
                        <%-------------FALTA CORREGIR CAMPOR DE BD---%>
                        <asp:BoundField DataField="ClaveCarrera" HeaderText="CLAVE DE LA MATERIA" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="NOMBRE DE LA MATERIA" />
                        <asp:BoundField DataField="AliasCarrera" HeaderText="HORAS CLASE" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="HORAS TALLER" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="HORAS LAVORATORIO" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="HORAS EXTRA CURRICULARES" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="CREDITOS DE LA MATERIA" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="ETAPA DE FORMACION" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="CARACTERISTICAS DE FORMACION" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="SEMESTRE" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="AREA DE CONOCIMIENTO" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="URL PUA OFICIAL" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="URL PUA NO OFICIAL" />
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
    <asp:HiddenField ID="hfIdCarrera" runat="server" />
</asp:Content>
