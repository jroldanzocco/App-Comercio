<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaCompra.aspx.cs" Inherits="J3AMS.UI.NuevaCompra" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de Artículos Disponibles</h1>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">Descripcion</th>
                <th scope="col">PrecioVenta</th>
                <th scope="col">Stock</th>
                <th scope="col">Acciones</th>
            </tr>
        </thead>
        <asp:Repeater ID="repArticulosDisponibles" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Descripcion") %></td>
                    <td><%# Eval("PrecioVenta") %></td>
                    <td><%# Eval("Stock") %></td>
                    <td>
                        <asp:Button ID="btnAgregarArticulo" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnAgregarArticulo_Click" CssClass="btn btn-primary" runat="server" Text="Agregar" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <h1>Lista de Productos Comprados</h1>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">Descripcion</th>
                <th scope="col">Cantidad</th>
                <th scope="col">Acciones</th>
            </tr>
        </thead>
        <asp:Repeater ID="repProductosComprados" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Descripcion") %></td>
                    <td><%# Eval("Cantidad") %></td>
                    <td>
                        <asp:Button ID="btnEliminarArticulo" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEliminarArticulo_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <asp:Button ID="btnVolverAlMenu" OnClick="btnVolverAlMenu_Click" CssClass="btn btn-primary" runat="server" Text="Cancelar y Volver al Menú" />

    <asp:Button ID="btnConfirmarGuardarCompra" OnClick="btnConfirmarGuardarCompra_Click" CssClass="btn btn-success" runat="server" Text="Confirmar y Guardar Compra" />

</asp:Content>