<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaVenta.aspx.cs" Inherits="J3AMS.UI.NuevaVenta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Nueva Venta</h1>
    
    <div class="form-group">
        <label for="ddlClientes">Cliente:</label>
        <asp:DropDownList ID="ddlClientes" runat="server"></asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="ddlProductos">Productos:</label>
        <asp:DropDownList ID="ddlProductos" runat="server"></asp:DropDownList>
        <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
        <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" CssClass="btn btn-primary" />
    </div>

    <h2>Productos Seleccionados</h2>
    <ul>
        <asp:Repeater ID="repProductosSeleccionados" runat="server">
            <ItemTemplate>
                <li>
                    <%# Eval("Descripcion") %> - Cantidad: <%# Eval("Cantidad") %>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    <asp:Button ID="btnGenerarFactura" runat="server" Text="Generar Factura" OnClick="btnGenerarFactura_Click" CssClass="btn btn-success" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-success" />
</asp:Content>
