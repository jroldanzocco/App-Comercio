﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuProveedores.aspx.cs" Inherits="J3AMS.UI.MenuProveedores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Proveedores</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <link href="Content/estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="MenuProveedores" runat="server">
        <main>
            <div class="centrar-menu">
                <asp:Button ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" CssClass="btn btn-primary" runat="server" Text="Menú principal" />
                <asp:Button ID="btnNuevoProveedor" OnClick="btnNuevoProveedor_Click"  CssClass="btn btn-primary" runat="server" Text="Nuevo" />
                <asp:Button ID="btnBuscarProveedor" CssClass="btn btn-primary" runat="server" Text="Buscar" />
                <asp:Button ID="btnEditarProveedor" CssClass="btn btn-primary" runat="server" Text="Editar" />
                <asp:Button ID="btnInformeProveedor" CssClass="btn btn-primary" runat="server" Text="Informes" />
                <asp:Button ID="btnEliminarProveedor" CssClass="btn btn-primary" runat="server" Text="Eliminar" />
            </div>
        </main>
    </form>
</body>
</html>