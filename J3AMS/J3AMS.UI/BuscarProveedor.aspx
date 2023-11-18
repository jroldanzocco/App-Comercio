<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarProveedor.aspx.cs" Inherits="J3AMS.UI.BuscarProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--Modal--%>
    <div class="container">
        <div class="modal fade" id="modalProveedor" role="dialog">
            <div class ="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Agregar proveedor</h4>
                        <asp:Label ID="lblMsg" Text="" runat="server" /> 
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <label>Razon Social</label>
                        <asp:TextBox ID="txtRazonSocial" CssClass="form-control" placeholder="Razon social" runat="server" />
                        
                        <label>Nombre Fantasia</label>
                        <asp:TextBox ID="txtNombreFantasia" CssClass="form-control" placeholder="Nombre Fantasia" runat="server"/>
                        
                        <label>CUIT</label>
                        <asp:TextBox ID="txtCuit" CssClass="form-control" placeholder="CUIT" runat="server"/>
                        
                        <label>Domicilio</label>
                        <asp:TextBox ID="txtDomicilio" CssClass="form-control" placeholder="Domicilio" runat="server"/>
                        
                        <label>Telefono</label>
                        <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Telefono" runat="server"/>
                        
                        <label>Celular</label>
                        <asp:TextBox ID="txtCelular" CssClass="form-control" placeholder="Celular" runat="server"/>
                        
                        <label>Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="correo@ejemplo.com" runat="server"/>

                        <label>Plazo de pago</label>
                        <asp:TextBox ID="txtPlazoPago" CssClass="form-control" placeholder="Dias" runat="server"/>
                        
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnGuardar" CssClass="btn btn-primary" Text="Agregar" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>

        <table class="table">
    <thead>
        <tr>
            <th scope="col">Razon Social</th>
            <th scope="col">CUIT</th>
            <th scope="col">Telefono</th>
            <th scope="col">Email</th>
            <th scope="col">Acciones</th>
        </tr>
    </thead>

    <asp:Repeater ID="repRepetidor" runat="server">
        <ItemTemplate>
            <tr runat="server" visible='<%# Convert.ToBoolean(Eval("Activo")) == true %>'>
                <td><%# Eval("RazonSocial") %></td>
                <td><%# Eval("CUIT") %></td>
                <td><%# Eval("Telefono") %></td>
                <td><%# Eval("Email") %></td>
                <td>
                    <asp:Button ID="btnEditarProveedor" CommandArgument='<%#Eval("Id") %>' CommandName="ProveedorId" OnClick="btnEditarProveedor_Click" CssClass="btn btn-primary" runat="server" Text="Editar" />
                    <asp:Button ID="btnInformeProveedor" CommandArgument='<%#Eval("Id") %>' CommandName="ProveedorId" CssClass="btn btn-primary" runat="server" Text="Informes" OnClick="btnInformeProveedor_Click" />
                    <asp:Button ID="btnEliminarProveedor" CommandArgument='<%#Eval("Id") %>' CommandName="ProveedorId" OnClick="btnEliminarProveedor_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>

<asp:Button ID="btnNuevoProveedor" OnClick="btnNuevoProveedor_Click" CssClass="btn btn-primary" runat="server" Text="Nuevo" />
<asp:Button ID="btnVolverAlMenu" OnClick="btnVolverAlMenu_Click" CssClass="btn btn-primary" runat="server" Text="Volver al Menu" />

</asp:Content>
