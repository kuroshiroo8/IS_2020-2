<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucTbAlfabeticoRequerido.ascx.cs" Inherits="Presentacion.Controles._Ganancia" %>

<link href="../CSS/bootstrap.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="TbAlfabeticoRequerido" runat="server" CssClass="form-control"></asp:TextBox>

<asp:RequiredFieldValidator ID="rfvTbAlfabeticoRequerido" runat="server" CssClass="text-danger" 
    ControlToValidate="TbAlfanumericoRequerido" ErrorMessage="*Este campo es requerido." 
    Display="Dynamic"></asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID="revTbAlfabeticoRequerido" runat="server" CssClass="text-danger"
    ControlToValidate="TbAlfanumericoRequerido"
    ErrorMessage="*Sólo letras."
    ValidationExpression="^[a-zA-Z ]+$"
    Display="Dynamic"></asp:RegularExpressionValidator>


