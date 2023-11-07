<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="J3AMS.UI.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table table-bordered table-striped">
    <Columns>
        <asp:BoundField DataField="Marca.Nombre" HeaderText="Marca" />
        <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
        <asp:BoundField DataField="Proveedor.Nombre" HeaderText="Proveedor" />
    </Columns>
</asp:GridView>


</asp:Content>