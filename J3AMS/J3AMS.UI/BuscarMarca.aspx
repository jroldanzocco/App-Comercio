<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarMarca.aspx.cs" Inherits="J3AMS.UI.BuscarMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="d-flex justify-content-between mb-3">
            <div class="w-100">
            <label for="txtBusqueda" class="form-label">Búsqueda</label>
            <asp:TextBox ID="txtBusqueda" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBusqueda_TextChanged" runat="server"></asp:TextBox>
        </div>
            </div>
        <div class="d-flex flex-column">
        <div class="mb-2">
            <asp:Button ID="btnVolverAlMenu" OnClick="btnVolverAlMenu_Click" CssClass="btn btn-secondary" runat="server" Text="Volver al Menu" />
            <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
                { %>
            <asp:Button ID="btnNuevaMarca" OnClick="btnNuevaMarca_Click" CssClass="btn btn-success" runat="server" Text="Nuevo" />
            <% } %>
        </div>
        <div class="d-flex flex-column">
            <div class="table-responsive">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Nombre</th>
                    <th scope="col" style="width: 200px";>Acciones</th>
                </tr>
            </thead>

            <asp:Repeater ID="repMarcas" runat="server">
                
                <ItemTemplate>
                    <tr runat="server" visible='<%# Convert.ToBoolean(Eval("Activo")) == true %>'>
                        <td><%# Eval("Descripcion") %></td>
                        <td class="d-flex gap-2">
                            
                            <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
                                { %>
                            <asp:Button ID="btnEditarMarca" CommandArgument='<%#Eval("Id") %>' CommandName="MarcaId" OnClick="btnEditarMarca_Click" CssClass="btn btn-primary w-auto" runat="server" Text="Editar" />
                            <asp:Button ID="btnEliminarMarca" CommandArgument='<%#Eval("Id") %>' CommandName="MarcaId" OnClick="btnEliminarMarca_Click" CssClass="btn btn-danger w-auto" runat="server" Text="Eliminar" />
                            <% } %>
                        </td>
                    </tr>
                </ItemTemplate>
                
            </asp:Repeater>
        </table>
                </div>
            </div>
        </div>
        
    </div>
</asp:Content>
