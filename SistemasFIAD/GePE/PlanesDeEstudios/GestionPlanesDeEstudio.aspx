<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MP_SistemasFIADLogueados.master" AutoEventWireup="true" CodeBehind="GestionPlanesDeEstudio.aspx.cs" Inherits="GePE.PlanesDeEstudios.GestionPlanesDeEstudio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
    <h5 class="text-black pl-2">Módulo de planes de estudio</h5>

      <div class="row bg-light border pl-2">
      <div class="col-lg-8 col-md-6 col-sm-6">
        <asp:LinkButton ID="BtnMnuNuevo" runat="server" CssClass="btn btn-sm btn-secondary fa fa-plus-square pr-3" CausesValidation="false"> Nuevo plan de estudios</asp:LinkButton>
        <asp:LinkButton ID="BtnMnuListado" runat="server" CssClass="btn btn-sm btn-secondary fa fa-list-alt pr-3" CausesValidation="false"> Listado</asp:LinkButton>
        <asp:LinkButton ID="BtnMnuAsignaPLanDeEstudio" runat="server" CssClass="btn btn-sm btn-secondary fa fa-list-alt pr-3" CausesValidation="false"> Asignar materias</asp:LinkButton>
        <asp:LinkButton ID="BtnMnuPDF" runat="server" CssClass="btn btn-sm btn-secondary fa fa-file-pdf pr-3" CausesValidation="false"> PDF-Planes de estudio</asp:LinkButton>
      </div>
      <div class="col-lg-4 col-md-6 col-sm-6">
        <div class="row">
          <div class="col-lg-8 col-md-6 col-sm-6">
            <asp:TextBox ID="TbCriterioBusqueda" runat="server" CssClass="form-control" placeholder="Criterio de búsqueda"></asp:TextBox>
          </div>
          <div class="col-lg-4 col-md-6 col-sm-6">
            <asp:LinkButton ID="BtnBuscar" runat="server" CssClass="btn btn-sm btn btn-success fa fa-file-search" CausesValidation="false" > Buscar</asp:LinkButton>
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
