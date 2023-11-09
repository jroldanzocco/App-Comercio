<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaProveedores.aspx.cs" Inherits="J3AMS.UI.AltaProveedores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Alta Proveedores</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <link href="Content/estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="frmAltaProveedores" runat="server">
        <div class="container-alta">
            <h2 class="text-center">Nuevo Proveedor</h2>
            <div class="mb-3 form-alta">
                <label for="txtRazonSocial" class="form-label">Razón Social</label>
                <asp:TextBox ID="txtRazonSocial" CssClass="form-control" runat="server"></asp:TextBox>
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                <label for="txtCuit" class="form-label">CUIT</label>
                <asp:TextBox ID="txtCuit" CssClass="form-control" runat="server"></asp:TextBox>
                <label for="txtDomicilio" class="form-label">Domicilio</label>
                <asp:TextBox ID="txtDomicilio" CssClass="form-control" runat="server"></asp:TextBox>
                <label for="txtTelefono" class="form-label">Telefono</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3 btn-alta">
                <asp:Button ID="btnAgregarCliente" OnClick="btnAgregarCliente_Click" CssClass="btn btn-primary" runat="server" Text="Agregar" />
                <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-primary" runat="server" Text="Volver" />
            </div>
        </div>
    </form>
</body>
</html>
