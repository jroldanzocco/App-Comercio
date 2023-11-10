<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaProveedor.aspx.cs" Inherits="J3AMS.UI.AltaProveedor" MasterPageFile="Site.Master" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <form id="frmAltaProveedores" class="container mt-5">
        <h2 class="text-center mb-4">Nuevo Proveedor</h2>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtRazonSocial" class="form-label">Razón Social</label>
                <asp:TextBox ID="txtRazonSocial" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtCuit" class="form-label">CUIT</label>
                <asp:TextBox ID="txtCuit" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label for="txtDomicilio" class="form-label">Domicilio</label>
                <asp:TextBox ID="txtDomicilio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtTelefono" class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnAgregarProveedor" OnClick="btnAgregarProveedor_Click" CssClass="btn btn-primary" runat="server" Text="Agregar" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary" runat="server" Text="Volver" />
            </div>
        </div>
    </form>
</asp:Content>
