<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaProveedor.aspx.cs" Inherits="J3AMS.UI.AltaProveedor" MasterPageFile="Site.Master" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div id="frmAltaProveedores" class="container mt-5">
        <h2 class="text-center mb-4">Nuevo Proveedor</h2>
        <div class="row justify-content-between text-left">
            <div class="form-group col-sm-6 flex-column d-flex">
                <label class="form-control-label px-3">Razon Social<span class="text-danger"> *</span></label>
                <asp:TextBox ID="txtRazonSocial" CssClass="form-control" placeholder="Debe coincidir con AFIP" runat="server" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtRazonSocial"
                    ErrorMessage="Razon social es requerida." Display="Dynamic" ValidationGroup="AgregarGroup" />
            </div>
            <div class="form-group col-sm-6 flex-column d-flex">
                <label class="form-control-label px-3 mb-1">Nombre de fantasia</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Ej: Industrias pepito" runat="server" />
            </div>
        </div>
        <div class="row justify-content-between text-left mt-4">
            <div class="form-group col-sm-6 flex-column d-flex">
                <label class="form-control-label px-3 mb-1">CUIT<span class="text-danger"> *</span></label>
                <asp:TextBox ID="txtCuit" CssClass="form-control" placeholder="Numero CUIT" runat="server" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtCuit"
                    ErrorMessage="CUIT es requerido." Display="Dynamic" ValidationGroup="AgregarGroup" />
            </div>
            <div class="form-group col-sm-6 flex-column d-flex">
                <label class="form-control-label px-3 mb-1">Domicilio</label>
                <asp:TextBox ID="txtDomicilio" CssClass="form-control" placeholder="Ej: Calle Falsa 123" runat="server" />
            </div>
        </div>
        <div class="row justify-content-between text-left mt-4">
            <div class="form-group col-sm-6 flex-column d-flex">
                <label class="form-control-label px-3 mb-1">Telefono<span class="text-danger"> *</span></label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Numero de telefono" runat="server" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtTelefono"
                    ErrorMessage="Telefono es requerido." Display="Dynamic" ValidationGroup="AgregarGroup" />
            </div>
            <div class="form-group col-sm-6 flex-column d-flex">
                <label class="form-control-label px-3 mb-1">Celular</label>
                <asp:TextBox ID="txtCelular" CssClass="form-control" placeholder="Numero de celular" runat="server" />
            </div>
        </div>
        <div class="row justify-content-between text-left mt-4">
            <div class="form-group col-sm-6 flex-column d-flex">
                <label class="form-control-label px-3 mb-1">Email<span class="text-danger"> *</span></label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="ej: Correo@example.com" runat="server" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtEmail"
                    ErrorMessage="Email es requerido." Display="Dynamic" ValidationGroup="AgregarGroup" />
            </div>
            <div class="form-group col-sm-6 flex-column d-flex">
                <label class="form-control-label px-3 mb-1">Categoria IVA<span class="text-danger"> *</span></label>
                <asp:DropDownList ID="ddlCategoriaIva" CssClass="form-select" runat="server">
                    <asp:ListItem Text="-- Seleccione Categoria --" Value="" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="row justify-content-between text-left mt-4">
            <div class="form-group col-12 flex-column d-flex">
                <label class="form-control-label px-3">Plazo de pago</label>
                <asp:TextBox ID="txtPlazo" CssClass="form-control" placeholder="Dias de Plazo" runat="server" />
                
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-md-6">
                <asp:Button ID="btnAgregarProveedor" OnClick="btnAgregarProveedor_Click" CssClass="btn btn-primary" ValidationGroup="AgregarGroup" runat="server" Text="Agregar" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary" runat="server" Text="Volver" />
            </div>
        </div>
    </div>
</asp:Content>
