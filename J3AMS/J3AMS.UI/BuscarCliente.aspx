﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCliente.aspx.cs" Inherits="J3AMS.UI.BuscarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--Modal--%>
    <style>
        .modal-header {
            justify-content: center !important;
        }

        .truncate-text {
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }
    </style>
    <div class="container">
        <div class="modal fade" id="modalCliente" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">
                            <asp:Label ID="lblInformeCliente" runat="server" /></h4>
                    </div>
                    <div class="modal-body text-center">
                        <label class="d-block font-weight-bold h6">Nombre</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control mx-auto text-center" placeholder="Nombre" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Apellido</label>
                        <asp:TextBox ID="txtApellido" CssClass="form-control mx-auto text-center" placeholder="Apellido" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">DNI</label>
                        <asp:TextBox ID="txtDni" CssClass="form-control mx-auto text-center" placeholder="DNI" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Teléfono</label>
                        <asp:TextBox ID="txtTelefonoCliente" CssClass="form-control mx-auto text-center" placeholder="Teléfono" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Celular</label>
                        <asp:TextBox ID="txtCelularCliente" CssClass="form-control mx-auto text-center" placeholder="Celular" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Email</label>
                        <asp:TextBox ID="txtEmailCliente" CssClass="form-control mx-auto text-center" placeholder="correo@ejemplo.com" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Categoria IVA</label>
                        <asp:TextBox ID="txtCategoria" CssClass="form-control mx-auto text-center" placeholder="Categoria" runat="server" />

                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnVolver" CssClass="btn btn-secondary w-100 mx-auto" Text="Volver" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="d-flex justify-content-between mb-3">
    <div class="w-100">
            <label for="txtBusqueda" class="form-label">Búsqueda</label>
            <asp:TextBox ID="txtBusqueda" AutoPostBack="true" OnTextChanged="txtBusqueda_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
            </div>

        <div class="d-flex flex-column">
        <div class="mb-2">
            <asp:Button ID="btnVolverAlMenu" OnClick="btnVolverAlMenu_Click" CssClass="btn btn-secondary" runat="server" Text="Volver al Menu" />
            <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
                { %>
            <asp:Button ID="btnNuevoCliente" OnClick="btnNuevoCliente_Click" CssClass="btn btn-success" runat="server" Text="Nuevo" />
            <% } %>
        </div>
        <div class="d-flex flex-column">
            <div class="table-responsive">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Apellido</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">DNI</th>
                    <th scope="col">Telefono</th>
                    
                    <th scope="col" style="width: 200px";>Acciones</th>
                </tr>
            </thead>

            <asp:Repeater ID="repRepetidor" runat="server">
                <ItemTemplate>
                    <tr runat="server" visible='<%# Convert.ToBoolean(Eval("Activo")) == true %>'>
                        <td><%# Eval("Apellidos") %></td>
                        <td><%# Eval("Nombres") %></td>
                        <td><%# Eval("DNI") %></td>
                        <td><%# Eval("Telefono") %></td>
                        
                        <td class="d-flex gap-2">
                            <asp:Button ID="btnInformeCliente" OnClick="btnInformeCliente_Click" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" CssClass="btn btn-info w-auto" runat="server" Text="Informes" />
                            <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
                                { %>
                            <asp:Button ID="btnEditarCliente" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEditarCliente_Click" CssClass="btn btn-primary w-auto" runat="server" Text="Editar" />
                            <asp:Button ID="btnEliminarCliente" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEliminarCliente_Click" CssClass="btn btn-danger w-auto" runat="server" Text="Eliminar" />
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
