<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarMarca.aspx.cs" Inherits="J3AMS.UI.BuscarMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Nombre</th>
                </tr>
            </thead>

            <asp:Repeater ID="repMarcas" runat="server">
                
                <ItemTemplate>
                    <tr runat="server" visible='<%# Convert.ToBoolean(Eval("Activo")) == true %>'>
                        <td><%# Eval("Descripcion") %></td>
                        <td>
                            
                            <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
                                { %>
                            <asp:Button ID="btnEditarMarca" CommandArgument='<%#Eval("Id") %>' CommandName="MarcaId" OnClick="btnEditarMarca_Click" CssClass="btn btn-primary" runat="server" Text="Editar" />
                            <asp:Button ID="btnEliminarMarca" CommandArgument='<%#Eval("Id") %>' CommandName="MarcaId" OnClick="btnEliminarMarca_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />
                            <% } %>
                        </td>
                    </tr>
                </ItemTemplate>
                
            </asp:Repeater>
        </table>

        <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
            { %>
        <asp:Button ID="btnNuevaMarca" OnClick="btnNuevaMarca_Click" CssClass="btn btn-primary" runat="server" Text="Nuevo" />
        <% } %>
        <asp:Button ID="btnVolverAlMenu" OnClick="btnVolverAlMenu_Click" CssClass="btn btn-primary" runat="server" Text="Volver al Menu" />
    </div>
</asp:Content>
