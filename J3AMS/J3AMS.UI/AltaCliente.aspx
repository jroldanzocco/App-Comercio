<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="J3AMS.UI.AltaCliente" MasterPageFile="Site.Master" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <form id="frmAltaCliente" class="container mt-5">
        <h2 class="text-center mb-4">Nuevo Cliente</h2>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtNombreCliente" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombreCliente" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtNombreCliente"
                ErrorMessage="Nombre cliente es requerido." Display="Dynamic" ValidationGroup="AgregarGroup" />
                <asp:RegularExpressionValidator runat="server" ID="txtDescripcionRegex" ControlToValidate="txtNombreCliente" ForeColor="Red"
    ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚ\s]+$" ErrorMessage="Ingrese solo letras." ValidationGroup="AgregarGroup" />
                <asp:RegularExpressionValidator runat="server" ID="txtMaxCharactersRegex" ControlToValidate="txtNombreCliente" ForeColor="Red"
    ValidationExpression="^.{1,255}$" ErrorMessage="Ingrese hasta 255 caracteres como máximo."
    ValidationGroup="AgregarGroup" />
            </div>
            <div class="col-md-6">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtApellido"
                ErrorMessage="Apellido cliente es requerido." Display="Dynamic" ValidationGroup="AgregarGroup" />
                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtApellido" ForeColor="Red"
    ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚ\s]+$" ErrorMessage="Ingrese solo letras." ValidationGroup="AgregarGroup" />
                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ControlToValidate="txtApellido" ForeColor="Red"
    ValidationExpression="^.{1,255}$" ErrorMessage="Ingrese hasta 255 caracteres como máximo."
    ValidationGroup="AgregarGroup" />
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtDni" class="form-label">CUIT/DNI</label>
                <asp:TextBox ID="txtDni" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtDni"
ErrorMessage="DNI es requerido." Display="Dynamic" ValidationGroup="AgregarGroup" />
                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="txtDni" ForeColor="Red"
    ValidationExpression="^\d{1,10}$" ErrorMessage="Ingrese hasta 10 números como máximo." ValidationGroup="AgregarGroup" />
            </div>
            <div class="col-md-6">
                <label for="ddlIva" class="form-label">Categoria IVA</label>
                <asp:DropDownList ID="ddlIva" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtDomicilio" class="form-label">Domicilio</label>
                <asp:TextBox ID="txtDomicilio" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator7" ControlToValidate="txtDomicilio" ForeColor="Red"
ValidationExpression="^.{1,255}$" ErrorMessage="Ingrese hasta 255 caracteres como máximo."
ValidationGroup="AgregarGroup" />
            </div>
            <div class="col-md-6">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ID="txtEmailRegex" ControlToValidate="txtEmail" ForeColor="Red"
    ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
    ErrorMessage="Ingrese una dirección de correo electrónico válida."
    ValidationGroup="AgregarGroup" />
                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator4" ControlToValidate="txtEmail" ForeColor="Red"
ValidationExpression="^.{1,255}$" ErrorMessage="Ingrese hasta 255 caracteres como máximo."
ValidationGroup="AgregarGroup" />
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtTelefono" class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtTelefono"
ErrorMessage="Al menos un telefono es requerido." Display="Dynamic" ValidationGroup="AgregarGroup"  ForeColor="Red"/>
                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator5" ControlToValidate="txtTelefono" ForeColor="Red"
ValidationExpression="^.{1,255}$" ErrorMessage="Ingrese hasta 255 caracteres como máximo."
ValidationGroup="AgregarGroup" />
            </div>
            <div class="col-md-6">
                <label for="txtCelular" class="form-label">Celular</label>
                <asp:TextBox ID="txtCelular" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator6" ControlToValidate="txtCelular" ForeColor="Red"
ValidationExpression="^.{1,255}$" ErrorMessage="Ingrese hasta 255 caracteres como máximo."
ValidationGroup="AgregarGroup" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnAgregarCliente" OnClick="btnAgregarCliente_Click" CssClass="btn btn-primary" runat="server" Text="Agregar" ValidationGroup="AgregarGroup" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary" runat="server" Text="Volver" />
            </div>
        </div>
    </form>
</asp:Content>

