<%@ Page Title="Artículos" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="BuscarArticulo.aspx.cs" Inherits="J3AMS.UI.BuscarArticulo" EnableViewState="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
        <div class="modal fade" id="modalArticulo" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">
                            <asp:Label ID="lblInformeArticulo" runat="server" /></h4>
                    </div>
                    <div class="modal-body text-center">
                        <label class="d-block font-weight-bold h6">Descripcion</label>
                        <asp:TextBox ID="txtDescripcion" CssClass="form-control mx-auto text-center" placeholder="Descripcion" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Tipo</label>
                        <asp:TextBox ID="txtTipo" CssClass="form-control mx-auto text-center" placeholder="Tipo" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Marca</label>
                        <asp:TextBox ID="txtMarca" CssClass="form-control mx-auto text-center" placeholder="Marca" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Proveedor</label>
                        <asp:TextBox ID="txtProveedor" CssClass="form-control mx-auto text-center" placeholder="Proveedor" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Precio Costo</label>
                        <asp:TextBox ID="txtPrecioCosto" CssClass="form-control mx-auto text-center" placeholder="Precio Costo" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Precio Venta</label>
                        <asp:TextBox ID="txtPrecioVenta" CssClass="form-control mx-auto text-center" placeholder="Precio Venta" runat="server" />

                        <label class="d-block mt-3 font-weight-bold h6">Stock</label>
                        <asp:TextBox ID="txtStock" CssClass="form-control mx-auto text-center" placeholder="Stock" runat="server" />

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
                    <asp:Button ID="btnNuevoArticulo" OnClick="btnNuevoArticulo_Click" CssClass="btn btn-success" runat="server" Text="Nuevo Articulo" />
                    <% } %>
                </div>
                <div class="d-flex flex-column">
                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">Descripción</th>
                                    <th scope="col">Marca</th>
                                    <th scope="col">Stock</th>
                                    <th scope="col" style="width: 200px";>Acciones</th>
                                </tr>
                            </thead>
                            <asp:Repeater ID="repRepetidor" runat="server">

                                <ItemTemplate>
                                    <tr runat="server" visible='<%# Convert.ToBoolean(Eval("Activo")) == true %>'>
                                        <td><%# Eval("Descripcion") %></td>
                                        <td><%# Eval("Marca") %></td>
                                        <td><%# Eval("Stock") %></td>
                                        <td class="d-flex gap-2">

                                            <asp:Button ID="btnInformeArticulo" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnInformeArticulo_Click" CssClass="btn btn-info w-auto " runat="server" Text="Informes" />

                                            <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).UserRole == J3AMS.Dominio.UserRole.ADMIN)
                                                { %>

                                            <asp:Button ID="btnEditarArticulo" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEditarArticulo_Click" CssClass="btn btn-primary w-auto" runat="server" Text="Editar" />
                                            <asp:Button ID="btnEliminarArticulo" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEliminarArticulo_Click" CssClass="btn btn-danger w-auto" runat="server" Text="Eliminar" />

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
    </div>

</asp:Content>


