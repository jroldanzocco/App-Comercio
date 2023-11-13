<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarProveedor.aspx.cs" Inherits="J3AMS.UI.BuscarProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <table class="table">
    <thead>
        <tr>
            <th scope="col">Razon Social</th>
            <th scope="col">Nombre de Fantasia</th>
            <th scope="col">CUIT</th>
            <th scope="col">Domicilio</th>
            <th scope="col">Telefono</th>
            <th scope="col">Celular</th>
            <th scope="col">Email</th>
            <th scope="col">Acciones</th>
        </tr>
    </thead>

    <asp:Repeater ID="repRepetidor" runat="server">
        <ItemTemplate>
            <tr runat="server" visible='<%# Convert.ToBoolean(Eval("Activo")) == true %>'>
                <td><%# Eval("RazonSocial") %></td>
                <td><%# Eval("NombreFantasia") %></td>
                <td><%# Eval("CUIT") %></td>
                <td><%# Eval("Domicilio") %></td>
                <td><%# Eval("Telefono") %></td>
                <td><%# Eval("Celular") %></td>
                <td><%# Eval("Email") %></td>
                <td>
                    <asp:Button ID="btnEditarProveedor" OnClick="btnEditarProveedor_Click" CssClass="btn btn-primary" runat="server" Text="Editar" />
                    <asp:Button ID="btnInformeProveedor" CssClass="btn btn-primary" runat="server" Text="Informes" />
                    <asp:Button ID="btnEliminarProveedor" CommandArgument='<%#Eval("Id") %>' CommandName="ProveedorId" OnClick="btnEliminarProveedor_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>

<asp:Button ID="btnNuevoProveedor" OnClick="btnNuevoProveedor_Click" CssClass="btn btn-primary" runat="server" Text="Nuevo" />

</asp:Content>
