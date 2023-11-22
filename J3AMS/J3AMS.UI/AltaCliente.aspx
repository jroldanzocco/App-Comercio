<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="J3AMS.UI.AltaCliente" MasterPageFile="Site.Master" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <form id="frmAltaCliente" class="container mt-5">
        <h2 class="text-center mb-4">Nuevo Cliente</h2>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtNombreCliente" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombreCliente" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtDni" class="form-label">CUIT/DNI</label>
                <asp:TextBox ID="txtDni" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="ddlIva" class="form-label">Categoria IVA</label>
                <asp:DropDownList ID="ddlIva" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtFormaPago" class="form-label">Forma de pago</label>
                <asp:TextBox ID="txtFormaPago" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="txtPlazo" class="form-label">Plazo de pago</label>
                <asp:TextBox ID="txtPlazo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtDomicilio" class="form-label">Domicilio</label>
                <asp:TextBox ID="txtDomicilio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtTelefono" class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="txtCelular" class="form-label">Celular</label>
                <asp:TextBox ID="txtCelular" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnAgregarCliente" OnClick="btnAgregarCliente_Click" CssClass="btn btn-primary" runat="server" Text="Agregar" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary" runat="server" Text="Volver" />
            </div>
        </div>
    </form>
</asp:Content>

