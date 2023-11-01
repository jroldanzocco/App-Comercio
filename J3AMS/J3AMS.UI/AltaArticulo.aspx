<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="J3AMS.UI.Alta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Articulos</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <link href="Content/estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="frmAltaArticulo" runat="server">
        <div class="container-alta">
            <h2 class="text-center">Nuevo Artículo</h2>
            <div class="mb-3 form-alta">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                <label for="txtTipo" class="form-label">Tipo</label>
                <asp:TextBox ID="txtTipo" CssClass="form-control" runat="server"></asp:TextBox>
                <label for="txtMarca" class="form-label">Marca</label>
                <asp:TextBox ID="txtMarca" CssClass="form-control" runat="server"></asp:TextBox>
                <label for="txtProveedor" class="form-label">Proveedor</label>
                <asp:TextBox ID="txtProveedor" CssClass="form-control" runat="server"></asp:TextBox>
                <label for="txtStock" class="form-label">Stock minimo</label>
                <asp:TextBox ID="txtStock" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3 btn-alta">
                <asp:Button ID="btnAgregarArticulo" CssClass="btn btn-primary" runat="server" Text="Agregar" />
                <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-primary" runat="server" Text="Volver" />
            </div>
        </div>
    </form>
</body>
</html>
