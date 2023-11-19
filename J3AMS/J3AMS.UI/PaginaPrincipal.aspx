<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="J3AMS.UI.PaginaPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <link href="Content/estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="menuPrincipal" runat="server">
        <header>
            <div class="header">
                <div>
                    <h2 class="logo">J3</h2>
        </header>
        <main>
            <div class="centrar-menu">
                <% if (Session["usuario"] != null && ((J3AMS.Dominio.Usuario)Session["usuario"]).NombreUsuario.ToString() == "Admin") { %>

                <asp:Button ID="btnClientes" OnClick="btnClientes_Click" CssClass="btn btn-primary" runat="server" Text="Clientes" />
                <asp:Button ID="btnProveedores" OnClick="btnProveedores_Click" CssClass="btn btn-primary" runat="server" Text="Proveedores" />
                <asp:Button ID="btnProductos" CssClass="btn btn-primary" OnClick="btnProductos_Click" runat="server" Text="Productos" />
                <asp:Button ID="btnVentas" CssClass="btn btn-primary" OnClick="btnNuevaVenta_Click" runat="server" Text="Ventas" />
                <asp:Button ID="btnCompras" CssClass="btn btn-primary" OnClick="btnNuevaCompra_Click" runat="server" Text="Compras" />
                <asp:Button ID="btnFacturas" CssClass="btn btn-primary" OnClick="btnFacturas_Click" runat="server" Text="Facturas" />

                <% } %>
            </div>
        </main>
    </form>


</body>
</html>
