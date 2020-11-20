<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MP_SistemasFIADLogueados.master" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="GePE.prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCarrera" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="IdCarrera" HeaderText="IdCarrera" InsertVisible="False" ReadOnly="True" SortExpression="IdCarrera" />
            <asp:BoundField DataField="ClaveCarrera" HeaderText="ClaveCarrera" SortExpression="ClaveCarrera" />
            <asp:BoundField DataField="NombreCarrera" HeaderText="NombreCarrera" SortExpression="NombreCarrera" />
            <asp:BoundField DataField="AliasCarrera" HeaderText="AliasCarrera" SortExpression="AliasCarrera" />
            <asp:CheckBoxField DataField="EstadoCarrera" HeaderText="EstadoCarrera" SortExpression="EstadoCarrera" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionBD %>" SelectCommand="SELECT [IdCarrera], [ClaveCarrera], [NombreCarrera], [AliasCarrera], [EstadoCarrera] FROM [Carreras]"></asp:SqlDataSource>
</asp:Content>
