<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="J3AMS.UI.Alta" MasterPageFile="Site.Master" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div id="frmAltaArticulo" class="container mt-5">
        <h2 class="text-center mb-4">Nuevo Artículo</h2>
        <div class="row mb-3">

            <div class="col-md-6">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator runat="server" ID="txtDescripcionReq" ControlToValidate="txtDescripcion" ForeColor="Red"
                    ErrorMessage="La descripcion es requerida." Display="Dynamic" ValidationGroup="AgregarGroup" />
                <asp:RegularExpressionValidator runat="server" ID="txtDescripcionRegex" ControlToValidate="txtDescripcion" ForeColor="Red"
                    ValidationExpression="^[a-zA-Z0-9\s]+$" ErrorMessage="Ingrese solo letras y números." ValidationGroup="AgregarGroup" />
            </div>
            <div class="col-md-6">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                <asp:Label runat="server" ID="lblErrorMarca" ForeColor="Red"/>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="ddlTipo" class="form-label">Tipo</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
                <asp:Label runat="server" ID="lblErrorTipo" ForeColor="Red"/>
            </div>
            <div class="col-md-6">
                <label for="ddlProveedor" class="form-label">Proveedor</label>
                <asp:DropDownList ID="ddlProveedor" CssClass="form-select" runat="server"></asp:DropDownList>
                <asp:Label runat="server" ID="lblErrorProveedor" ForeColor="Red"/>
            </div>
        </div>
        <div class="row mb-3">

            <div class="col-md-6">
                <label for="txtPrecioCosto" class="form-label">Precio Costo</label>
                <asp:TextBox ID="txtPrecioCosto" CssClass="form-control" runat="server" />
                <asp:RegularExpressionValidator runat="server" ID="revPrecioCosto" ControlToValidate="txtPrecioCosto" ForeColor="Red"
                    ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingrese un número válido." ValidationGroup="AgregarGroup" />
            </div>
            <div class="col-md-6">
    <label for="txtPrecioVenta" class="form-label">Precio Venta</label>
    <div class="d-flex align-items-start">
        <asp:TextBox ID="txtPrecioVenta" CssClass="form-control" runat="server" />
        <asp:RegularExpressionValidator runat="server" ID="revPrecioVenta" ControlToValidate="txtPrecioVenta" ForeColor="Red"
            ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingrese un número válido." ValidationGroup="AgregarGroup" />
    </div>
    <asp:Label runat="server" ID="lblErrorVenta" ForeColor="Red"/>
</div>
        </div>
        <div class="row mb-3">

            <div class="col-md-6">
                <label for="txtStock" class="form-label">Stock</label>
                <asp:TextBox ID="txtStock" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ID="revStock" ControlToValidate="txtStock" ForeColor="Red"
                    ValidationExpression="^\d+$" ErrorMessage="Ingrese un número válido." ValidationGroup="AgregarGroup" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnAgregarArticulo" OnClick="btnAgregarArticulo_Click" CssClass="btn btn-primary" ValidationGroup="AgregarGroup" runat="server" Text="Agregar" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary" runat="server" Text="Volver" />
            </div>
        </div>
    </div>
</asp:Content>




