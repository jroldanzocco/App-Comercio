<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarVentas.aspx.cs" Inherits="J3AMS.UI.BuscarVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">NumeroFactura</th>
                </tr>
            </thead>

            <asp:Repeater ID="repRepetidorVentas" runat="server">
                <ItemTemplate>
                    <tr runat="server">
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("NumeroFactura") %></td>
                        <td>
                            <asp:Button ID="btnDetallesVenta" OnClick="btnDetallesVenta_Click" CommandArgument='<%#Eval("Id") %>' CommandName="VentaId" CssClass="btn btn-info w-100" runat="server" Text="Detalles" />

                            <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
                                { %>
<%--                            <asp:Button ID="btnEditarVenta" CommandArgument='<%#Eval("Id") %>' CommandName="CompraId" OnClick="btnEditarVenta_Click" CssClass="btn btn-primary" runat="server" Text="Editar" />
                            <asp:Button ID="btnEliminarVenta" CommandArgument='<%#Eval("Id") %>' CommandName="CompraId" OnClick="btnEliminarVenta_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />--%>
                            <% } %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

        <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
            { %>
        <% } %>
        <asp:Button ID="btnVolverAlMenu" OnClick="btnVolverAlMenu_Click" CssClass="btn btn-primary" runat="server" Text="Volver al Menú" />
    </div>
</asp:Content>