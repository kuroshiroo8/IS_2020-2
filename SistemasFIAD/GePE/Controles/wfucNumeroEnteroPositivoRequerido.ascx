<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucNumeroEnteroPositivoRequerido.ascx.cs" Inherits="Presentacion.Controles.efucNumeroEnteroPositivoReq" %>

<link href="../CSS/bootstrap.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="TbNumeroEnteroPositivoRequerido" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>

<asp:RequiredFieldValidator ID="rfvTbNumeroEnteroPositivoRequerido" runat="server" CssClass="text-danger"
    ControlToValidate="TbNumeroEnteroPositivoRequerido"
    ErrorMessage="*Este campo es requerido."
    Display="Dynamic"></asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID="revTbNumeroEnteroPositivoRequerido" runat="server" CssClass="text-danger"
    ControlToValidate="TbNumeroEnteroPositivoRequerido"
    ErrorMessage="Sólo números positivos."
    ValidationExpression="^\d+$"
    Display="Dynamic"></asp:RegularExpressionValidator>

