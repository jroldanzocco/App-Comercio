<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="J3AMS.UI.AltaCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Alta CLiente</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <link href="Content/estilos.css" rel="stylesheet" />
</head>
<body>
        <form id="frmAltaCliente" runat="server">
            <div class="container-alta">
                <h2 class="text-center">Nuevo Cliente</h2>
                <div class="mb-3 form-alta">
                    <label for="txtNombreCLiente" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombreCLiente" CssClass="form-control" runat="server"></asp:TextBox>
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                    <label for="txtDni" class="form-label">CUIT/DNI</label>
                    <asp:TextBox ID="txtDni" CssClass="form-control" runat="server"></asp:TextBox>
                    <label for="txtIva" class="form-label">Categoria IVA</label>
                    <asp:TextBox ID="txtIva" CssClass="form-control" runat="server"></asp:TextBox>
                    <label for="txtFormaPago" class="form-label">Forma de pago</label>
                    <asp:TextBox ID="txtFormaPago" CssClass="form-control" runat="server"></asp:TextBox>
                    <label for="txtPlazo" class="form-label">Plazo de pago</label>
                    <asp:TextBox ID="txtPlazo" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3 btn-alta">
                    <asp:Button ID="btnAgregarCliente" CssClass="btn btn-primary" runat="server" Text="Agregar" />
                    <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-primary" runat="server" Text="Volver" />
                </div>
            </div>
        </form>
</body>
</html>
