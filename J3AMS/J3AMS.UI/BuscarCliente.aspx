<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCliente.aspx.cs" Inherits="J3AMS.UI.BuscarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
    <thead>
        <tr>
            <th scope="col">Apellido</th>
            <th scope="col">Nombre</th>
            <th scope="col">DNI</th>
            <th scope="col">Domicilio</th>
            <th scope="col">Telefono</th>
            <th scope="col">Celular</th>
            <th scope="col">Email</th>
            <th scope="col">Acciones</th>
        </tr>
    </thead>

    <asp:Repeater ID="repRepetidor" runat="server">
        <ItemTemplate>
            <tr>
                <td><%# Eval("Apellidos") %></td>
                <td><%# Eval("Nombres") %></td>
                <td><%# Eval("DNI") %></td>
                <td><%# Eval("Domicilio") %></td>
                <td><%# Eval("Telefono") %></td>
                <td><%# Eval("Celular") %></td>
                <td><%# Eval("Email") %></td>
                <td>
                    
                    <asp:Button ID="btnInformeCliente" CssClass="btn btn-primary" runat="server" Text="Informes" />
                    <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).NombreUsuario.ToString() == "Admin") { %>
                        <asp:Button ID="btnEditarCliente" OnClick="btnEditarCliente_Click" CssClass="btn btn-primary" runat="server" Text="Editar" />
                        <asp:Button ID="btnEliminarCliente" OnClick="btnEliminarCliente_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />
                    <% } %>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>

<% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).NombreUsuario.ToString() == "Admin") { %>
<asp:Button ID="btnNuevoCliente" OnClick="btnNuevoCliente_Click" CssClass="btn btn-primary" runat="server" Text="Nuevo" />
<% } %>
<asp:Button ID="btnVolverAlMenu" OnClick="btnVolverAlMenu_Click" CssClass="btn btn-primary" runat="server" Text="Volver al Menu" />

</asp:Content>
