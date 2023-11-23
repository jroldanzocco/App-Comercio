﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarTipo.aspx.cs" Inherits="J3AMS.UI.BuscarTipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Nombre</th>
                </tr>
            </thead>

            <asp:Repeater ID="repTipos" runat="server">

                <ItemTemplate>
                    <tr runat="server" visible='<%# Convert.ToBoolean(Eval("Activo")) == true %>'>
                        <td><%# Eval("Descripcion") %></td>
                        <td>

                            <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
                                { %>
                            <asp:Button ID="btnEditarTipo" CommandArgument='<%#Eval("Id") %>' CommandName="TipoId" OnClick="btnEditarTipo_Click" CssClass="btn btn-primary" runat="server" Text="Editar" />
                            <asp:Button ID="btnEliminarTipo" CommandArgument='<%#Eval("Id") %>' CommandName="TipoId" OnClick="btnEliminarTipo_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />
                            <% } %>
                        </td>
                    </tr>
                </ItemTemplate>

            </asp:Repeater>
        </table>

        <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
            { %>
        <asp:Button ID="btnNuevoTipo" OnClick="btnNuevoTipo_Click" CssClass="btn btn-primary" runat="server" Text="Nuevo" />
        <% } %>
        <asp:Button ID="btnVolverAlMenu" OnClick="btnVolverAlMenu_Click" CssClass="btn btn-primary" runat="server" Text="Volver al Menu" />
    </div>
</asp:Content>
