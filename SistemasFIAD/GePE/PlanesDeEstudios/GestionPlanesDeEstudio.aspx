<%@ Page Title="" Language="C#" MasterPageFile="../PaginasMaestras/MP_SistemasFIADLogueados.master" AutoEventWireup="true" CodeBehind="GestionPlanesDeEstudio.aspx.cs" Inherits="GePE.PlanesDeEstudios.GestionPlanesDeEstudio" %>

<%@ Register Src="../Controles/wfucAlfanumericoRequerido.ascx" TagPrefix="uc1" TagName="wfucAlfanumericoRequerido" %>
<%@ Register Src="../Controles/wfucNumeroEnteroPositivoRequerido.ascx" TagPrefix="uc1" TagName="wfucNumeroEnteroPositivoRequerido" %>
<%@ Register Src="../Controles/wfucTbAlfabeticoRequerido.ascx" TagPrefix="uc1" TagName="wfucTbAlfabeticoRequerido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h5 class="text-dark font-weight-bold pl-2">Módulo de planes de estudio</h5>

        <div class="row bg-light border pl-2">
            <div class="col-lg-8 col-md-6 col-sm-6">

                <asp:LinkButton ID="BtnMnuNuevo" runat="server" CssClass="btn btn-sm btn-secondary  pr-3" CausesValidation="false" OnClick="BtnMnuNuevo_Click"><i class="fas fa-plus-square"></i> Nuevo plan de estudio</asp:LinkButton>
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
                                    <asp:Label ID="lbClavePlanEstudio" class="text-dark font-weight-bold m-0" runat="server">Clave De Plan De Estudio</asp:Label>
                                    <uc1:wfucNumeroEnteroPositivoRequerido runat="server" ID="TbClavePlanEstudio" />
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbPlanEstudio" class="text-dark font-weight-bold m-0" runat="server">Plan Estudio</asp:Label>
                                    <uc1:wfucNumeroEnteroPositivoRequerido runat="server" ID="TbPlanEstudio" />
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbProgramaEducativo" class="text-dark font-weight-bold m-0" runat="server">Programa Educativo</asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlProgramaEducativo" ><asp:ListItem Value="">No seleccionado</asp:ListItem></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlProgramaEducativo" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlProgramaEducativo"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbFechaCreacion" class="text-dark font-weight-bold m-0" runat="server">Fecha De Creacion</asp:Label>
                                    <asp:TextBox runat="server" ID="TbFechaCreacion" type="date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTbFechaCreacion" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbFechaCreacion"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbTotalCreditos" class="text-dark font-weight-bold m-0" runat="server">Total Creditos</asp:Label>
                                    <asp:TextBox runat="server" ID="TbTotalCreditos"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTbTotalCreditos" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbTotalCreditos"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbEstadoPlanEstudios" class="text-dark font-weight-bold m-0" runat="server">Seleccione si el plan esta activo</asp:Label>
                                    <asp:CheckBox ID="cbEstadoPlanEstudios" runat="server" CssClass="font-weight-bold" />
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbComentarios" class="text-dark font-weight-bold m-0" runat="server">Comentarios</asp:Label>
                                    <asp:TextBox ID="TbComentarios" runat="server" TextMode="MultiLine" MaxLength="400"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTbComentarios" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbComentarios"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbPerfilDeIngreso" class="text-dark font-weight-bold m-0" runat="server">Perfil De Ingreso</asp:Label>
                                    <asp:TextBox ID="TbPerfilDeIngreso" runat="server" TextMode="MultiLine" MaxLength="400"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTbPerfilDeIngreso" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbPerfilDeIngreso"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbPerfilDeEgreso" class="text-dark font-weight-bold m-0" runat="server">Perfil De Egreso</asp:Label>
                                    <asp:TextBox ID="TbPerfilDeEgreso" runat="server" TextMode="MultiLine" MaxLength="400"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTbPerfilDeEgreso" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbPerfilDeEgreso"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbCampoOcupacional" class="text-dark font-weight-bold m-0" runat="server">Campo Ocupacional</asp:Label>
                                    <asp:TextBox ID="TbCampoOcupacional" runat="server" TextMode="MultiLine" MaxLength="400"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTbCampoOcupacional" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbCampoOcupacional"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbUnidadAcademica" class="text-dark font-weight-bold m-0" runat="server">Unidad Academica</asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlUnidadAcademica" ><asp:ListItem Value="">No seleccionado</asp:ListItem></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlUnidadAcademica" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlUnidadAcademica"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbEstatus" class="text-dark font-weight-bold m-0" runat="server">Estatus</asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlEstatus" ><asp:ListItem Value="">No seleccionado</asp:ListItem></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlEstatus" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlEstatus"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdNivelAcademico" class="text-dark font-weight-bold m-0" runat="server">Nivel Academico</asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlIdNivelAcademico" ><asp:ListItem Value="">No seleccionado</asp:ListItem></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlIdNivelAcademico" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdNivelAcademico"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer text-muted" align="center">
                            <asp:LinkButton ID="BtnGrabar" runat="server" CssClass="btn btn-md btn btn-success  pr-3" CausesValidation="true" OnClick="BtnGrabar_Click"><i class="fas fa-plus-square" ></i> Insertar</asp:LinkButton>
                            <asp:LinkButton ID="BtnBorrarModal" runat="server" CssClass="btn btn-md btn btn-danger pr-3" data-toggle="modal" CausesValidation="false" data-target="#BorrarModal"><i class="fas fa-trash-alt"></i>Borrar</asp:LinkButton>
                            <asp:LinkButton ID="BtnModificar" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="true" OnClick="BtnModificar_Click"><i class="fas fa-edit"></i> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuEditar" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="true" OnClick="BtnMnuEditar_Click"><i class="fas fa-edit" OnClick="BtnMnuEditar_Click"></i> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuBorrar" runat="server" CssClass="btn btn-md btn btn-danger pr-3" CausesValidation="false" OnClick="BtnMnuBorrar_Click"><i class="fas fa-trash-alt"></i> Borrar</asp:LinkButton><%--envia al panel borrar--%>
                            <asp:LinkButton ID="BtnCancelar" runat="server" CssClass="btn btn-md btn btn-dark pr-3" CausesValidation="false" OnClick="BtnCancelar_Click"><i class="fas fa-window-close"></i> Cancelar</asp:LinkButton>
                            <asp:LinkButton ID="BtnAceptar" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="false" OnClick="BtnCancelar_Click"><i class="fas fa-check"></i> Aceptar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PnlCapturaDatosPlanEstudioMateria" runat="server">
            <div class="container">
                <div class="card">
                    <div class="card-header text-center bg-success">
                        <h5 class="card-title">
                            <asp:Label ID="lblTituloAccionPlanEstudioMateria" runat="server" CssClass="text-white"></asp:Label></h5>
                    </div>
                    <div class="card-body">
                        <div class="row pl-2 pr-2">
                            <div class="col-lg-3 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdPlanEstudio" class="text-dark font-weight-bold m-0" runat="server">Plan de estudio</asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlIdPlanEstudio" ><asp:ListItem Value="">No seleccionado</asp:ListItem></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlIdPlanEstudio" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdPlanEstudio"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdMateria" class="text-dark font-weight-bold m-0" runat="server">Materia</asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlIdMateria" />
                                    <asp:RequiredFieldValidator ID="rfvddlIdMateria" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdMateria"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdTipoMateria" class="text-dark font-weight-bold m-0" runat="server">Tipo de materia</asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlIdTipoMateria" />
                                    <asp:RequiredFieldValidator ID="rfvddlIdTipoMateria" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdTipoMateria"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdEtapa" class="text-dark font-weight-bold m-0" runat="server">Etapa</asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlIdEtapa" />
                                    <asp:RequiredFieldValidator ID="rfvddlIdEtapa" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdEtapa"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdAreaConocimiento" class="text-dark font-weight-bold m-0" runat="server">Area de conocimiento</asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlIdAreaConocimiento" />
                                    <asp:RequiredFieldValidator ID="rfvddlIdAreaConocimiento" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdAreaConocimiento"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbSemestre" class="text-dark font-weight-bold m-0" runat="server">Semestre</asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlSemestre" />
                                    <asp:RequiredFieldValidator ID="rfvddlSemestre" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlSemestre"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                        <div class="card-footer text-muted" align="center">
                            <asp:LinkButton ID="BtnGrabarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-success  pr-3" CausesValidation="true" OnClick="BtnGrabarPlanEstudioMateria_Click"><i class="fas fa-plus-square" ></i> Insertar</asp:LinkButton>
                            <asp:LinkButton ID="BtnBorrarModalPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-danger pr-3" data-toggle="modal" CausesValidation="false" data-target="#BorrarModalPlanEstudioMateria"><i class="fas fa-trash-alt"></i>Borrar</asp:LinkButton>
                            <asp:LinkButton ID="BtnModificarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="true" OnClick="BtnModificarPlanEstudioMateria_Click"><i class="fas fa-edit"></i> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuEditarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="true" OnClick="BtnMnuEditarPlanEstudioMateria_Click"><i class="fas fa-edit" OnClick="BtnMnuEditar_Click"></i> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuBorrarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-danger pr-3" CausesValidation="false" OnClick="BtnMnuBorrarPlanEstudioMateria_Click"><i class="fas fa-trash-alt"></i> Borrar</asp:LinkButton><%--envia al panel borrar--%>
                            <asp:LinkButton ID="BtnCancelarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-dark pr-3" CausesValidation="false" OnClick="BtnCancelarPlanEstudioMateria_Click"><i class="fas fa-window-close"></i> Cancelar</asp:LinkButton>
                            <asp:LinkButton ID="BtnAceptarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="false" OnClick="BtnCancelarPlanEstudioMateria_Click"><i class="fas fa-check"></i> Aceptar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PnlGrvPlanEstudio" runat="server">
            <div class="container-fluid">
                <asp:GridView ID="GrvPlanEstudio" runat="server" AutoGenerateColumns="False"
                    CssClass="table thead-dark table-sm table-bordered table-responsive"
                    DataKeyNames="IdPlanEstudio"
                    OnRowDeleting="GrvPlanEstudio_RowDeleting"
                    OnRowEditing="GrvPlanEstudio_RowEditing"
                    OnRowCommand="GrvPlanEstudio_RowCommand"
                    OnSelectedIndexChanged="GrvPlanEstudio_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ClavePlanEstudio" HeaderText="CLAVE" />
                        <asp:BoundField DataField="PlanEstudio" HeaderText="NOMBRE DEl PLAN DE ESTUDIO" />
                        <asp:BoundField DataField="Estatus" HeaderText="ESTATUS" />

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnVerDetalles" runat="server" CssClass="btn btn-md btn-info"
                                    CausesValidation="false" CommandName="VerDetalles" CommandArgument="<%# Container.DataItemIndex %>"><i class="fas fa-info-circle"></i> Mas Detalles</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

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
                                <asp:LinkButton ID="GrvBtnAsignarMateria" runat="server" CssClass="btn btn-md btn-warning"
                                    CausesValidation="false" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>"><i class="fas fa-plus-square" ></i> Asignar materia</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnListarMaterias" runat="server" CssClass="btn btn-md btn-light"
                                    CausesValidation="false" CommandName="ListarMaterias" CommandArgument="<%# Container.DataItemIndex %>"><i class="fas fa-list"></i> Listar materia</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle CssClass="bg-dark text-white" />
                </asp:GridView>
            </div>
        </asp:Panel>

        <asp:Panel ID="PnlGrvPlanEstudioMateria" runat="server">
            <div class="container-fluid">
                <asp:GridView ID="GrvPlanEstudioMateria" runat="server" AutoGenerateColumns="False"
                    CssClass="table thead-dark table-sm table-bordered table-responsive"
                    DataKeyNames="IdPlanEstudioMateria"
                    OnRowDeleting="GrvPlanEstudioMateria_RowDeleting"
                    OnRowEditing="GrvPlanEstudioMateria_RowEditing"
                    OnSelectedIndexChanged="GrvPlanEstudioMateria_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="IdPlanEstudio" HeaderText="PLAN DE ESTUDIO" />
                        <asp:BoundField DataField="IdMateria" HeaderText="MATERIA" />
                        <asp:BoundField DataField="IdTipoMateria" HeaderText="TIPO DE MATERIA" />
                        <asp:BoundField DataField="IdEtapa" HeaderText="ETAPA" />
                        <asp:BoundField DataField="IdAreaConocimiento" HeaderText="AREA DE CONOCIMIENTO" />
                        <asp:BoundField DataField="Semestre" HeaderText="SEMESTRE" />

                        <%--                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
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
                        </asp:TemplateField>--%>
                    </Columns>
                    <HeaderStyle CssClass="bg-dark text-white" />
                </asp:GridView>
            </div>
        </asp:Panel>

        <%--Modal Borrar Plan Estudio--%>
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

        <%--Modal Borrar Plan Estudio - Materia--%>
        <div class="modal fade" id="BorrarModalPlanEstudioMateria" tabindex="-1" role="dialog" aria-labelledby="lbBorrarModalPlanEstudioMateria" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="lbBorrarModalPlanEstudioMateria">¿Esta seguro de borrar este registro?</h5>
                        <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                    <div class="modal-body">Si lo esta, presione "Borrar". </div>
                    <div class="modal-footer">
                        <button class="btn btn-md btn btn-dark pr-3" type="button" data-dismiss="modal"><i class="fas fa-window-close"></i>Cancelar</button>
                        <asp:LinkButton ID="BtnBorrarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-danger pr-3" CausesValidation="false" OnClick="BtnBorrarPlanEstudioMateria_Click"><i class="fas fa-trash-alt"></i> Borrar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfIdPlanEstudio" runat="server" />
</asp:Content>
