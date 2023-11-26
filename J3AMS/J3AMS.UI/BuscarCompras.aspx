<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCompras.aspx.cs" Inherits="J3AMS.UI.BuscarCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">NumeroFactura</th>
                    <th scope="col">Facturada</th>
                </tr>
            </thead>

            <asp:Repeater ID="repRepetidorCompras" runat="server">
                <ItemTemplate>
                    <tr runat="server" visible='<%# Convert.ToBoolean(Eval("Activo")) == true %>'>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("NumeroFactura") %></td>
                        <td>
                            <asp:Button ID="btnDetallesCompra" OnClick="btnDetallesCompra_Click" CommandArgument='<%#Eval("Id") %>' CommandName="CompraId" CssClass="btn btn-info w-100" runat="server" Text="Detalles" />

                            <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
                                { %>
<%--                            <asp:Button ID="btnEditarCompra" CommandArgument='<%#Eval("Id") %>' CommandName="CompraId" OnClick="btnEditarCompra_Click" CssClass="btn btn-primary" runat="server" Text="Editar" />
                            <asp:Button ID="btnEliminarCompra" CommandArgument='<%#Eval("Id") %>' CommandName="CompraId" OnClick="btnEliminarCompra_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />--%>
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
