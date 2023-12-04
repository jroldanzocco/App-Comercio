<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarProveedor.aspx.cs" Inherits="J3AMS.UI.BuscarProveedor" %>

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
        <div class="modal fade" id="modalProveedor" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">
                            <asp:Label ID="lblInforme" runat="server" /></h4>
                    </div>
                    <div class="modal-body text-center">
                        <label class="d-block font-weight-bold h6">Razon Social</label>
                        <asp:TextBox ID="txtRazonSocial" CssClass="form-control mx-auto text-center" placeholder="Razon social" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">CUIT</label>
                        <asp:TextBox ID="txtCuit" CssClass="form-control mx-auto text-center" placeholder="CUIT" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Domicilio</label>
                        <asp:TextBox ID="txtDomicilio" CssClass="form-control mx-auto text-center" placeholder="Domicilio" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Telefono</label>
                        <asp:TextBox ID="txtTelefono" CssClass="form-control mx-auto text-center" placeholder="Telefono" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Celular</label>
                        <asp:TextBox ID="txtCelular" CssClass="form-control mx-auto text-center" placeholder="Celular" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control mx-auto text-center" placeholder="correo@ejemplo.com" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Plazo de pago(Dias)</label>
                        <asp:TextBox ID="txtPlazoPago" CssClass="form-control mx-auto text-center" placeholder="Dias" runat="server" />

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
            <asp:TextBox ID="txtBusqueda" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBusqueda_TextChanged" runat="server"></asp:TextBox>
        </div>
    </div>
        <div class="d-flex flex-column">
        <div class="table-responsive">
                    <div class="mb-2">
    <asp:Button ID="btnVolverAlMenu" OnClick="btnVolverAlMenu_Click" CssClass="btn btn-secondary" runat="server" Text="Volver al Menu" />
    <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
        { %>
<asp:Button ID="btnNuevoProveedor" OnClick="btnNuevoProveedor_Click" CssClass="btn btn-success" runat="server" Text="Nuevo Proveedor" />
<% } %>
            </div>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Razon Social</th>
                    <th scope="col">CUIT</th>
                    <th scope="col">Telefono</th>
                    <th scope="col">Email</th>
                    <th scope="col" style="width: 200px";>Acciones</th>
                </tr>
            </thead>

            <asp:Repeater ID="repRepetidor" runat="server">
                <ItemTemplate>
                    <tr runat="server" visible='<%# Convert.ToBoolean(Eval("Activo")) == true %>'>
                        <td><%# Eval("RazonSocial") %></td>
                        <td><%# Eval("CUIT") %></td>
                        <td><%# Eval("Telefono") %></td>
                        <td><%# Eval("Email") %></td>
                        <td class="d-flex gap-2">
                            <asp:Button ID="btnInformeProveedor" CommandArgument='<%#Eval("Id") %>' CommandName="ProveedorId" CssClass="btn btn-info w-auto " runat="server" Text="Informes" OnClick="btnInformeProveedor_Click" />
                            <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
                                { %>
                            <asp:Button ID="btnEditarProveedor" CommandArgument='<%#Eval("Id") %>' CommandName="ProveedorId" OnClick="btnEditarProveedor_Click" CssClass="btn btn-primary w-auto" runat="server" Text="Editar" />
                            <asp:Button ID="btnEliminarProveedor" CommandArgument='<%#Eval("Id") %>' CommandName="ProveedorId" OnClick="btnEliminarProveedor_Click" CssClass="btn btn-danger w-auto" runat="server" Text="Eliminar" />
                            <% } %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
            
        </div>
      </div>
    </div>
</asp:Content>
