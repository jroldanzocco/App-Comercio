<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="J3AMS.UI.Alta" MasterPageFile="Site.Master" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <form id="frmAltaArticulo" class="container mt-5">
        <h2 class="text-center mb-4">Nuevo Artículo</h2>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ControlToValidate="txtNombre" 
                ErrorMessage="El nombre es requerido." Display="Dynamic" ValidationGroup="AgregarGroup" />
            </div>
            <div class="col-md-6">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtDescripcion" 
                ErrorMessage="La descripcion es requerida." Display="Dynamic" ValidationGroup="AgregarGroup" />
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="ddlTipo" class="form-label">Tipo</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"> </asp:DropDownList>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="ddlProveedor" class="form-label">Proveedor</label>
                <asp:DropDownList ID="ddlProveedor" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <label for="txtPrecioCosto" class="form-label">Precio Costo</label>
                <asp:TextBox ID="txtPrecioCosto" CssClass="form-control" runat="server" />
                <asp:RegularExpressionValidator runat="server" ID="revPrecioCosto" ControlToValidate="txtPrecioCosto"
                ValidationExpression="^\d+(\,\d+)?$" ErrorMessage="Ingrese un número válido." ValidationGroup="AgregarGroup" />
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtPrecioVenta" class="form-label">Precio Venta</label>
                <asp:TextBox ID="txtPrecioVenta" CssClass="form-control" runat="server"/>
                <asp:RegularExpressionValidator runat="server" ID="revPrecioVenta" ControlToValidate="txtPrecioVenta"
                ValidationExpression="^\d+(\,\d+)?$" ErrorMessage="Ingrese un número válido." ValidationGroup="AgregarGroup" />

                
            </div>
            <div class="col-md-6">
                <label for="txtStockMinimo" class="form-label">Stock Mínimo</label>
                <asp:TextBox ID="txtStockMinimo" CssClass="form-control" runat="server"></asp:TextBox>
                           <asp:RegularExpressionValidator runat="server" ID="revStockMinimo" ControlToValidate="txtStockMinimo"
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
    </form>
</asp:Content>




