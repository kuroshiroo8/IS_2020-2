<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_Ganancia.ascx.cs" Inherits="Presentacion.Controles._Ganancia" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="TbAlfaNumerico" runat="server" CssClass="form-control"></asp:TextBox>
 
<asp:RequiredFieldValidator ID="rfvTbAlfaNUmerico" CssClass="text-danger" runat="server" 
  ControlToValidate="TbAlfaNumerico" 
  ErrorMessage="Captura dato" 
  Font-Bold="False" Display="Dynamic"></asp:RequiredFieldValidator>

