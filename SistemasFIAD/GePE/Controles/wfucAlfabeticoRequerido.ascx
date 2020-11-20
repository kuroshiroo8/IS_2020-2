<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucAlfabeticoRequerido.ascx.cs" Inherits="GePE.Controles.wfucAlfabeticoRequerido" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="TbAlfabetico" runat="server" CssClass="form-control"></asp:TextBox>

<asp:RequiredFieldValidator ID="rfvTbAlfabetico" 
  CssClass="text-danger" runat="server" 
  ControlToValidate="TbAlfabetico" 
  ErrorMessage="Captura dato" 
  Font-Bold="False" 
  Display="Dynamic">
</asp:RequiredFieldValidator>

