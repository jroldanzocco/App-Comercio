<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarFacturas.aspx.cs" Inherits="J3AMS.UI.BuscarFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Buscar Facturas por Número</h1>

    <div>
        <label>Número de Factura:</label>
        <asp:TextBox ID="txtNumeroFactura" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    </div>

    <asp:GridView ID="gvResultados" runat="server" AutoGenerateColumns="true"></asp:GridView>

    <asp:Button ID="btnVolverAlMenu" OnClick="btnVolverAlMenu_Click" CssClass="btn btn-primary" runat="server" Text="Volver al Menú" />
    <asp:Button ID="Imprimir" OnClick="btnImprimir_Click" CssClass="btn btn-primary" runat="server" Text="Imprimir" />
</asp:Content>
