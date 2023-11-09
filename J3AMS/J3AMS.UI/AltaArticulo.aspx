<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="J3AMS.UI.Alta" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Nuevo Artículo</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <link href="Content/estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="frmAltaArticulo" runat="server" class="container mt-5">
        <h2 class="text-center mb-4">Nuevo Artículo</h2>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="ddlTipo" class="form-label">Tipo</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="ddlProveedor" class="form-label">Proveedor</label>
                <asp:DropDownList ID="ddlProveedor" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <label for="txtPrecioCosto" class="form-label">Precio Costo</label>
                <asp:TextBox ID="txtPrecioCosto" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtPrecioVenta" class="form-label">Precio Venta</label>
                <asp:TextBox ID="txtPrecioVenta" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="txtStockMinimo" class="form-label">Stock Mínimo</label>
                <asp:TextBox ID="txtStockMinimo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnAgregarArticulo" OnClick="btnAgregarArticulo_Click" CssClass="btn btn-primary" runat="server" Text="Agregar" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary" runat="server" Text="Volver" />
            </div>
        </div>
    </form>
</body>
</html>
