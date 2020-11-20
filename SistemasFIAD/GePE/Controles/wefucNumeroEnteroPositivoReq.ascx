<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wefucNumeroEnteroPositivoReq.ascx.cs" Inherits="Presentacion.Controles.efucNumeroEnteroPositivoReq" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="TbNumeroEnteroPositivoReq" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
 
<asp:RequiredFieldValidator ID="rfvNumEntPosReq" runat="server"  CssClass="text-danger"
  ControlToValidate="TbNumeroEnteroPositivoReq" 
  ErrorMessage="Captura número." Display="Dynamic"></asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID="revNumEntPos" runat="server"  CssClass="text-danger"
  ControlToValidate="TbNumeroEnteroPositivoReq" 
  ErrorMessage="Sólo números positivos." 
  ValidationExpression="^\d+$" Display="Dynamic"></asp:RegularExpressionValidator>

