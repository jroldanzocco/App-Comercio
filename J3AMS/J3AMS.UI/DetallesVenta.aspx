<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallesVenta.aspx.cs" Inherits="J3AMS.UI.DetallesVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Detalles de la Venta</h2>
        <asp:GridView ID="gridDetallesVenta" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Numero de Venta" />
                <asp:BoundField DataField="IdArticulo" HeaderText="ID del Articulo" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
