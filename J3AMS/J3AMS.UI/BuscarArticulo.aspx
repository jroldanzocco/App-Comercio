<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarArticulo.aspx.cs" Inherits="J3AMS.UI.BuscarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table">
    <HeaderStyle CssClass="thead-dark" />
    <Columns>
        <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
        <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" />
        <asp:BoundField DataField="Stock" HeaderText="Stock" />
    </Columns>
</asp:GridView>


</asp:Content>
