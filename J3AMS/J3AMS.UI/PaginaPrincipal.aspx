<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="J3AMS.UI.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <main>
     <div class="centrar-menu">
         <asp:Button ID="btnClientes" OnClick="btnClientes_Click" CssClass="btn btn-primary" runat="server" Text="Clientes" />
         <asp:Button ID="btnProveedores" OnClick="btnProveedores_Click" CssClass="btn btn-primary" runat="server" Text="Proveedores" />
         <asp:Button ID="btnProductos" CssClass="btn btn-primary" OnClick="btnProductos_Click" runat="server" Text="Productos" />
         <asp:Button ID="btnMarcas" CssClass="btn btn-primary" OnClick="btnMarcas_Click" runat="server" Text="Marcas" />
         <asp:Button ID="btnTipos" CssClass="btn btn-primary" OnClick="btnTipos_Click" runat="server" Text="Tipos" />
         <asp:Button ID="btnVentas" CssClass="btn btn-primary" OnClick="btnNuevaVenta_Click" runat="server" Text="Ventas" />
         <asp:Button ID="btnCompras" CssClass="btn btn-primary" OnClick="btnNuevaCompra_Click" runat="server" Text="Compras" />
         <asp:Button ID="btnFacturas" CssClass="btn btn-primary" OnClick="btnFacturas_Click" runat="server" Text="Facturas" />
     </div>
 </main>
</asp:Content>
