<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="J3AMS.UI.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container">
        <div class="row mt-4">
            <div class="col-md-6">
                <div class="text-center">
                    <asp:Button ID="btnClientes" OnClick="btnClientes_Click" CssClass="btn btn-primary btn-block mb-2" runat="server" Text="Clientes" /><br />
                    <asp:Button ID="btnProveedores" OnClick="btnProveedores_Click" CssClass="btn btn-primary btn-block mb-2" runat="server" Text="Proveedores" /><br />
                    <asp:Button ID="btnProductos" CssClass="btn btn-primary btn-block mb-2" OnClick="btnProductos_Click" runat="server" Text="Productos" /><br />
                    <asp:Button ID="btnMarcas" CssClass="btn btn-primary btn-block mb-2" OnClick="btnMarcas_Click" runat="server" Text="Marcas" /><br />
                    <asp:Button ID="btnTipos" CssClass="btn btn-primary btn-block mb-2" OnClick="btnTipos_Click" runat="server" Text="Tipos" /><br />
                </div>
            </div>
            <div class="col-md-6">
                <div class="text-center">
                    <asp:Button ID="btnCompras" CssClass="btn btn-primary btn-block mb-2" OnClick="btnNuevaCompra_Click" runat="server" Text="Comprar" /><br />
                    <asp:Button ID="btnVentas" CssClass="btn btn-primary btn-block mb-2" OnClick="btnNuevaVenta_Click" runat="server" Text="Vender" /><br />
                    <asp:Button ID="btnListarCompras" CssClass="btn btn-primary btn-block mb-2" OnClick="btnListarCompras_Click" runat="server" Text="Listar Compras" /><br />
                    <asp:Button ID="btnListarVentas" CssClass="btn btn-primary btn-block mb-2" OnClick="btnListarVentas_Click" runat="server" Text="Listar Ventas" /><br />
                    </div>
            </div>
        </div>
    </main>

</asp:Content>
