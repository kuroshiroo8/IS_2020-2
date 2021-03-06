﻿<%@ Page Title="" Language="C#" MasterPageFile="../PaginasMaestras/MP_SistemasFIADLogueados.master" AutoEventWireup="true" CodeBehind="GestionPlanesDeEstudio.aspx.cs" Inherits="GePE.PlanesDeEstudios.GestionPlanesDeEstudio" %>

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
                <asp:LinkButton ID="BtnMnuListadoEstatus" runat="server" CssClass="btn btn-sm btn-secondary pr-3" CausesValidation="false" OnClick="BtnMnuListadoEstatus_Click"><i class="fas fa-list"></i> Listado</asp:LinkButton>
            </div>
            <div class="col-lg-4 col-md-6 col-sm-6">
                <div class="row">
                    <div class="col-lg-8 col-md-6 col-sm-6">
                        <asp:TextBox ID="TbCriterioBusqueda" runat="server" CssClass="form-control" placeholder="Criterio de búsqueda" tyle="text-align:center"></asp:TextBox>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-6">
                        <asp:LinkButton ID="BtnBuscar" runat="server" CssClass="btn btn-sm btn btn-success " CausesValidation="false" OnClick="BtnBuscar_Click"><i class="fas fa-search"></i> Buscar</asp:LinkButton>
                        <asp:LinkButton ID="BtnBuscarEstatus" runat="server" CssClass="btn btn-sm btn btn-success " CausesValidation="false" OnClick="BtnBuscarEstatus_Click"><i class="fas fa-search"></i> Buscar</asp:LinkButton>
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
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbClavePlanEstudio" class="text-dark font-weight-bold m-0" runat="server">Clave De Plan De Estudio</asp:Label>
                                    <br />
                                    <asp:TextBox runat="server" ID="TbClavePlanEstudio" CssClass="form-control" TextMode="Number"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbClavePlanEstudio" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbClavePlanEstudio"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="revTbClavePlanEstudio" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbClavePlanEstudio"
                                        ErrorMessage="*Este campo debe de tener la estructura XXX con numeros de 0 a 9."
                                        ValidationExpression="^[0-9]{3}$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbPlanEstudio" class="text-dark font-weight-bold m-0" runat="server">Plan Estudio</asp:Label>
                                    <br />
                                    <asp:TextBox runat="server" ID="TbPlanEstudio" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbPlanEstudio" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbPlanEstudio"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="revTbPlanEstudio" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbPlanEstudio"
                                        ErrorMessage="*Este campo debe de tener la estructura 2XXX-X con digito 1 o 2 despues del guion."
                                        ValidationExpression="^[2-9]{1}[0-9]{3}-[1-2]{1}$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbProgramaEducativo" class="text-dark font-weight-bold m-0" runat="server">Programa Educativo</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlProgramaEducativo" CssClass="form-control">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="rfvddlProgramaEducativo" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlProgramaEducativo"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbFechaCreacion" class="text-dark font-weight-bold m-0" runat="server">Fecha De Creacion</asp:Label>
                                    <br />
                                    <asp:TextBox runat="server" ID="TbFechaCreacion" type="date" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTbFechaCreacion" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbFechaCreacion"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbTotalCreditos" class="text-dark font-weight-bold m-0" runat="server">Total Creditos</asp:Label>
                                    <br />
                                    <asp:TextBox runat="server" ID="TbTotalCreditos" CssClass="form-control" TextMode="Number"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbTotalCreditos" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbTotalCreditos"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="revTbTotalCreditos" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbTotalCreditos"
                                        ErrorMessage="*Este campo debe de tener la estructura XXX con numeros de 0 a 9."
                                        ValidationExpression="^[0-9]{3}$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbEstadoPlanEstudios" class="text-dark font-weight-bold m-0" runat="server">Seleccione si el plan esta activo</asp:Label>
                                    <br />
                                    <asp:CheckBox ID="cbEstadoPlanEstudios" runat="server" CssClass="font-weight-bold form-control" />

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbComentarios" class="text-dark font-weight-bold m-0" runat="server">Comentarios</asp:Label>
                                    <br />
                                    <asp:TextBox ID="TbComentarios" runat="server" TextMode="MultiLine" MaxLength="400" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbComentarios" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbComentarios"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbPerfilDeIngreso" class="text-dark font-weight-bold m-0" runat="server">Perfil De Ingreso</asp:Label>
                                    <br />
                                    <asp:TextBox ID="TbPerfilDeIngreso" runat="server" TextMode="MultiLine" MaxLength="400" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbPerfilDeIngreso" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbPerfilDeIngreso"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbPerfilDeEgreso" class="text-dark font-weight-bold m-0" runat="server">Perfil De Egreso</asp:Label>
                                    <br />
                                    <asp:TextBox ID="TbPerfilDeEgreso" runat="server" TextMode="MultiLine" MaxLength="400" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbPerfilDeEgreso" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbPerfilDeEgreso"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbCampoOcupacional" class="text-dark font-weight-bold m-0" runat="server">Campo Ocupacional</asp:Label>
                                    <br />
                                    <asp:TextBox ID="TbCampoOcupacional" runat="server" TextMode="MultiLine" MaxLength="400" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbCampoOcupacional" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbCampoOcupacional"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbUnidadAcademica" class="text-dark font-weight-bold m-0" runat="server">Unidad Academica</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlUnidadAcademica" CssClass="form-control">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="rfvddlUnidadAcademica" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlUnidadAcademica"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>

                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdNivelAcademico" class="text-dark font-weight-bold m-0" runat="server">Nivel Academico</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlIdNivelAcademico" CssClass="form-control">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="rfvddlIdNivelAcademico" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdNivelAcademico"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbEstatus" class="text-dark font-weight-bold m-0" runat="server">Estatus</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlEstatus" CssClass="form-control">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>
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
        <%--asignar materia a plan de estudio--%>
        <asp:Panel ID="PnlCapturaDatosPlanEstudioMateria" runat="server">
            <div class="container">
                <div class="card">
                    <div class="card-header text-center bg-success">
                        <h5 class="card-title">
                            <asp:Label ID="lblTituloAccionPlanEstudioMateria" runat="server" CssClass="text-white"></asp:Label></h5>
                    </div>
                    <div class="card-body">
                        <div class="row pl-2 pr-2">
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdPlanEstudio" class="text-dark font-weight-bold m-0" runat="server">Plan de estudio</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlIdPlanEstudio" CssClass="form-control">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlIdPlanEstudio" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdPlanEstudio"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdMateria" class="text-dark font-weight-bold m-0" runat="server">Materia</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlIdMateria" CssClass="form-control" AutoPostBack="True" ViewStateMode="Enabled"
                                        EnableViewState="true" OnSelectedIndexChanged="ItemSelected">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlIdMateria" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdMateria"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdTipoMateria" class="text-dark font-weight-bold m-0" runat="server">Tipo de materia</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlIdTipoMateria" CssClass="form-control" AutoPostBack="True" ViewStateMode="Enabled"
                                        EnableViewState="true" OnSelectedIndexChanged="TipoChange">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlIdTipoMateria" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdTipoMateria"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdEtapa" class="text-dark font-weight-bold m-0" runat="server">Etapa</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlIdEtapa" CssClass="form-control" AutoPostBack="True" ViewStateMode="Enabled"
                                        EnableViewState="true" OnSelectedIndexChanged="Index_Changed">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlIdEtapa" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdEtapa"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbIdAreaConocimiento" class="text-dark font-weight-bold m-0" runat="server">Area de conocimiento</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlIdAreaConocimiento" CssClass="form-control">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlIdAreaConocimiento" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlIdAreaConocimiento"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbSemestre" class="text-dark font-weight-bold m-0" runat="server">Semestre</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlSemestre" CssClass="form-control" AutoPostBack="True" ViewStateMode="Enabled"
                                        EnableViewState="true" OnSelectedIndexChanged="ItemSelected">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlSemestre" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlSemestre"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbSeriada" class="text-dark font-weight-bold m-0" runat="server">Seleccione si la materia esta seriada</asp:Label>
                                    <br />
                                    <asp:CheckBox ID="cbSeriada" runat="server" CssClass="font-weight-bold form-control" AutoPostBack="true" OnCheckedChanged="On_Check" />
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbMateriaSeriada" class="text-dark font-weight-bold m-0" runat="server">Materia seriada</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlMateriaSeriada" CssClass="form-control">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="card-footer text-muted" align="center">
                            <asp:LinkButton ID="BtnGrabarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-success  pr-3" CausesValidation="true" OnClick="BtnGrabarPlanEstudioMateria_Click"><i class="fas fa-plus-square" ></i> Insertar</asp:LinkButton>
                            <asp:LinkButton ID="BtnBorrarModalPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-danger pr-3" data-toggle="modal" CausesValidation="false" data-target="#BorrarModalPlanEstudioMateria"><i class="fas fa-trash-alt"></i>Borrar</asp:LinkButton>
                            <asp:LinkButton ID="BtnModificarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="true" OnClick="BtnModificarPlanEstudioMateria_Click"><i class="fas fa-edit"></i> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuEditarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="true" OnClick="BtnMnuEditarPlanEstudioMateria_Click"><i class="fas fa-edit"></i> Modificar</asp:LinkButton>
                            <asp:LinkButton ID="BtnMnuBorrarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-danger pr-3" CausesValidation="false" OnClick="BtnMnuBorrarPlanEstudioMateria_Click"><i class="fas fa-trash-alt"></i> Borrar</asp:LinkButton><%--envia al panel borrar--%>
                            <asp:LinkButton ID="BtnCancelarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-dark pr-3" CausesValidation="false" OnClick="BtnCancelarPlanEstudioMateria_Click"><i class="fas fa-window-close"></i> Cancelar</asp:LinkButton>
                            <asp:LinkButton ID="BtnAceptarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="false" OnClick="BtnCancelarPlanEstudioMateria_Click"><i class="fas fa-check"></i> Aceptar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PnlCapturaDatosCorreo" runat="server">
            <div class="container">
                <div class="card">
                    <div class="card-header text-center bg-success">
                        <h5 class="card-title">
                            <asp:Label ID="lblTituloAccionCorreo" runat="server" CssClass="text-white"></asp:Label></h5>
                    </div>
                    <div class="card-body">
                        <div class="row pl-2 pr-2">
                            <div class="col-lg-12 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbDestinatario" class="text-dark font-weight-bold m-0" runat="server">Destinatario</asp:Label>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlDestinatario" CssClass="form-control">
                                        <asp:ListItem Value="">No seleccionado</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlDestinatario" runat="server" CssClass="text-danger"
                                        ControlToValidate="ddlDestinatario"
                                        ErrorMessage="*Este campo es requerido."
                                        InitialValue=""
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-12 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbRemitente" class="text-dark font-weight-bold m-0" runat="server">Remitente</asp:Label>
                                    <br />
                                    <asp:TextBox runat="server" ID="TbRemitente" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-12 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbAsunto" class="text-dark font-weight-bold m-0" runat="server">Asunto</asp:Label>
                                    <br />
                                    <asp:TextBox runat="server" ID="TbAsunto" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbAsunto" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbAsunto"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-12 col-md-12 col-12">
                                <div class="form-group">
                                    <asp:Label ID="lbObservaciones" class="text-dark font-weight-bold m-0" runat="server">Observaciones</asp:Label>
                                    <br />
                                    <asp:TextBox ID="TbObservaciones" runat="server" TextMode="MultiLine" MaxLength="400" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvTbObservaciones" runat="server" CssClass="text-danger"
                                        ControlToValidate="TbObservaciones"
                                        ErrorMessage="*Este campo es requerido."
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                        <div class="card-footer text-muted" align="center">
                            <asp:LinkButton ID="BtnEnviarPnlCapturaDatosCorreo" runat="server" CssClass="btn btn-md btn btn-success  pr-3" CausesValidation="true" OnClick="BtnEnviarPnlCapturaDatosCorreo_Click"><i class="fas fa-plus-square" ></i> Enviar</asp:LinkButton>
                            <asp:LinkButton ID="BtnCancelarPnlCapturaDatosCorreo" runat="server" CssClass="btn btn-md btn btn-dark pr-3" CausesValidation="false" OnClick="BtnCancelarPnlCapturaDatosCorreo_Click"><i class="fas fa-window-close"></i> Cancelar</asp:LinkButton>
                            <asp:LinkButton ID="BtnAceptarPnlCapturaDatosCorreo" runat="server" CssClass="btn btn-md btn btn-primary pr-3" CausesValidation="false" OnClick="BtnAceptarPnlCapturaDatosCorreo_Click"><i class="fas fa-check"></i> Aceptar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <%--*******************************--%>
        <asp:Panel ID="PnlGrvPlanEstudio" runat="server" align="center">
            <div class="container-fluid">

                <asp:GridView ID="GrvPlanEstudio" runat="server" AutoGenerateColumns="False"
                    CssClass="table thead-dark table-sm table-bordered table-responsive "
                    DataKeyNames="IdPlanEstudio"
                    OnRowDeleting="GrvPlanEstudio_RowDeleting"
                    OnRowEditing="GrvPlanEstudio_RowEditing"
                    OnRowCommand="GrvPlanEstudio_RowCommand"
                    OnSelectedIndexChanged="GrvPlanEstudio_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ClavePlanEstudio" HeaderText="CLAVE" />
                        <asp:BoundField DataField="PlanEstudio" HeaderText="NOMBRE DEl PLAN DE ESTUDIO" />
                        <asp:BoundField DataField="NombreCarrera" HeaderText="CARRERA DEl PLAN DE ESTUDIO" />
                        <asp:BoundField DataField="Estatus" HeaderText="ESTATUS" />

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnMapaCurricular" runat="server" CssClass="btn btn-md btn-outline-primary"
                                    CausesValidation="false" CommandName="MapaCurricular" CommandArgument="<%# Container.DataItemIndex %>"><i class="far fa-calendar-alt"></i>Generar Mapa Curricular</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

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
                                <asp:LinkButton ID="GrvBtnListarMaterias" runat="server" CssClass="btn btn-md btn-outline-warning"
                                    CausesValidation="false" CommandName="ListarMaterias" CommandArgument="<%# Container.DataItemIndex %>"><i class="fas fa-list"></i> Listar materias</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--administrador********************************************************************************************************--%>

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnAprobar" runat="server" CssClass="btn btn-md btn-outline-secondary"
                                    CausesValidation="false" CommandName="Aprobar" CommandArgument="<%# Container.DataItemIndex %>"><i class="fas fa-thumbs-up"></i> Aprobar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnRecaptura" runat="server" CssClass="btn btn-md btn-outline-dark"
                                    CausesValidation="false" CommandName="Recaptura" CommandArgument="<%# Container.DataItemIndex %>"><i class="far fa-thumbs-down"></i> Recaptura</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--administrador********************************************************************************************************--%>

                        <%--capturista********************************************************************************************************--%>

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnRevisión" runat="server" CssClass="btn btn-md btn-outline-secondary"
                                    CausesValidation="false" CommandName="Revisión" CommandArgument="<%# Container.DataItemIndex %>"><i class="far fa-check-square"></i> Revisión</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnPublicar" runat="server" CssClass="btn btn-md btn-outline-dark"
                                    CausesValidation="false" CommandName="Publicar" CommandArgument="<%# Container.DataItemIndex %>"><i class="fas fa-upload"></i> Publicar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--capturista********************************************************************************************************--%>
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
                        <asp:BoundField DataField="NombrePlanEstudio" HeaderText="PLAN DE ESTUDIO" />
                        <asp:BoundField DataField="NombreMateria" HeaderText="MATERIA" />
                        <asp:BoundField DataField="NombreTipoMateria" HeaderText="TIPO DE MATERIA" />
                        <asp:BoundField DataField="NombreEtapa" HeaderText="ETAPA" />
                        <asp:BoundField DataField="NombreArea" HeaderText="AREA DE CONOCIMIENTO" />
                        <asp:BoundField DataField="Semestre" HeaderText="SEMESTRE" />

                        <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="GrvBtnEditar" runat="server" CssClass="btn btn-md btn-primary "
                                    CausesValidation="false" CommandName="Edit" OnClick="BtnMnuEditarPlanEstudioMateria_Click"><i class="fas fa-edit"></i> Modificar</asp:LinkButton>
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

        <asp:Panel ID="PnlGrvMapaCurricular" runat="server">
            <div class="container-fluid">

                <h5>
                    <%--Estos son los encabezado de ver mapa curricular--%>
                    <asp:Label ID="lbPnlGrvMapaCurricularNombreCarrera" class="text-dark font-weight-bold m-0" runat="server">Nombre De La Carrera</asp:Label>
                    <asp:Label ID="lbPnlGrvMapaCurricularPlanEstudio" class="text-dark font-weight-bold m-0" runat="server">Plan De Estudio</asp:Label>
                </h5>

                <asp:GridView ID="GrvMapaCurricular" runat="server" AutoGenerateColumns="False"
                    CssClass="table thead-dark table-sm table-bordered table-responsive">
                    <Columns>
                        <asp:BoundField DataField="I" HeaderText="I" />
                        <asp:BoundField DataField="II" HeaderText="II" />
                        <asp:BoundField DataField="III" HeaderText="III" />
                        <asp:BoundField DataField="IV" HeaderText="IV" />
                        <asp:BoundField DataField="V" HeaderText="V" />
                        <asp:BoundField DataField="VI" HeaderText="VI" />
                        <asp:BoundField DataField="VII" HeaderText="VII" />
                        <asp:BoundField DataField="VIII" HeaderText="VIII" />
                    </Columns>
                    <HeaderStyle CssClass="bg-dark text-white" />
                </asp:GridView>

                <table class="table thead-dark table-sm table-bordered table-responsive">
                    <tr>
                        <td style="border-style: none; width: 10%"></td>
                        <td style="border-style: none;"><b>Áreas del Conocimiento</b></td>
                    </tr>
                    <tr>
                        <td style="background-color: #D98880;"></td>
                        <td style="border-style: none;">CIENCIAS BÁSICAS</td>
                    </tr>
                    <tr>
                        <td style="background-color: #C39BD3;"></td>
                        <td style="border-style: none;">CIENCIAS SOCIALES Y HUMANIDADES</td>
                    </tr>
                    <tr>
                        <td style="background-color: #7FB3D5"></td>
                        <td style="border-style: none;">CIENCIAS DE LA INGENIERÍA</td>
                    </tr>
                    <tr>
                        <td style="background-color: #7DCEA0"></td>
                        <td style="border-style: none;">INGENIERÍA APLICADA</td>
                    </tr>
                    <tr>
                        <td style="background-color: #F7DC6F"></td>
                        <td style="border-style: none;">CIENCIAS ECONÓMICAS - ADMINISTRATIVAS</td>
                    </tr>
                    <tr>
                        <td style="background-color: #F0B27A"></td>
                        <td style="border-style: none;">DISEÑO EN INGENIERÍA</td>
                    </tr>
                    <tr>
                        <td style="background-color: #B2BABB"></td>
                        <td style="border-style: none;">CURSOS COMPLEMENTARIOS</td>
                    </tr>

                </table>

                <table class="table thead-dark table-sm table-bordered table-responsive">
                    <tr>
                        <td style="border-style: none;"></td>
                        <td style="border-style: none;"><b>Créditos por Etapas de Formación</b></td>
                        <td><b>OB</b></td>
                        <td><b>OP</b></td>
                        <td><b>TOT</b></td>
                    </tr>
                    <tr>
                        <td><b>EB</b></td>
                        <td><b>Etapa Básica</b></td>
                        <td>
                            <asp:Label ID="lbEBOB" runat="server">0</asp:Label></td>
                        <td>
                            <asp:Label ID="lbEBOP" runat="server">0</asp:Label></td>
                        <td>
                            <asp:Label ID="lbEBTOT" runat="server">0</asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>ED</b></td>
                        <td><b>Etapa Disciplinaria</b></td>
                        <td>
                            <asp:Label ID="lbEDOB" runat="server">0</asp:Label></td>
                        <td>
                            <asp:Label ID="lbEDOP" runat="server">0</asp:Label></td>
                        <td>
                            <asp:Label ID="lbEDTOT" runat="server">0</asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>ET</b></td>
                        <td><b>Etapa Terminal</b></td>
                        <td>
                            <asp:Label ID="lbETOB" runat="server">0</asp:Label></td>
                        <td>
                            <asp:Label ID="lbETOP" runat="server">0</asp:Label></td>
                        <td>
                            <asp:Label ID="lbETTOT" runat="server">0</asp:Label></td>
                    </tr>
                    <tr>
                        <td style="border-style: none;"></td>
                        <td style="border-style: none;"></td>
                        <td style="border-style: none;"><b><i><u>
                            <asp:Label ID="lbOBTOT" runat="server">0</asp:Label></u></i></b></td>
                        <td style="border-style: none;"><b><i><u>
                            <asp:Label ID="lbOPTOT" runat="server">0</asp:Label></u></i></b></td>
                        <td style="border-style: none;"><b><i><u>
                            <asp:Label ID="lbTOT" runat="server">0</asp:Label></u></i></b></td>
                    </tr>
                    <tr>
                        <td style="border-style: none;"></td>
                        <td><b>Practicas Profesionales</b></td>
                        <td>10</td>
                        <td>0</td>
                        <td>10</td>
                    </tr>
                    <tr>
                        <td style="border-style: none;"></td>
                        <td style="border-style: none;"><b>Créditos Totales Programa</b></td>
                        <td style="border-style: none;"><b><i><u>
                            <asp:Label ID="lbTotalOB" runat="server">0</asp:Label></u></i></b></td>
                        <td style="border-style: none;"><b><i><u>
                            <asp:Label ID="lbTotalOP" runat="server">0</asp:Label></u></i></b></td>
                        <td style="border-style: none;"><b><i><u>
                            <asp:Label ID="lbTotalTOT" runat="server">0</asp:Label></u></i></b></td>
                    </tr>

                </table>

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
                        <asp:LinkButton ID="BtnBorrarPlanEstudioMateria" runat="server" CssClass="btn btn-md btn btn-danger pr-3"
                            CausesValidation="false" OnClick="BtnBorrarPlanEstudioMateria_Click"><i class="fas fa-trash-alt"></i> Borrar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfIdPlanEstudio" runat="server" />
</asp:Content>
