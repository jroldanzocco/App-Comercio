<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaVenta.aspx.cs" Inherits="J3AMS.UI.NuevaVenta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de Artículos Disponibles</h1>
    <asp:Repeater ID="repArticulosDisponibles" runat="server">
        <ItemTemplate>
            <div>
                <span><%# Eval("Descripcion") %></span>
                <span><%# Eval("PrecioVenta") %></span>
                <span><%# Eval("Stock") %></span>
                <asp:Button ID="btnAgregarArticulo" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnAgregarArticulo_Click" CssClass="btn btn-primary" runat="server" Text="Agregar" />
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <h1>Lista de Productos Vendidos</h1>
    <asp:Repeater ID="repProductosVendidos" runat="server">
        <ItemTemplate>
            <div>
                <span><%# Eval("Descripcion") %></span>
                <span><%# Eval("Cantidad") %></span>
                <asp:Button ID="btnEliminarArticulo" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEliminarArticulo_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:Button ID="btnVolverAlMenu" OnClick="btnVolverAlMenu_Click" CssClass="btn btn-primary" runat="server" Text="Cancelar y Volver al Menú" />
</asp:Content>


