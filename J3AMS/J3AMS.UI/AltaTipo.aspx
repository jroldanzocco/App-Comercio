<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaTipo.aspx.cs" Inherits="J3AMS.UI.AltaTipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Nuevo Tipo</h2>
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ControlToValidate="txtNombre"
                    ErrorMessage="El nombre es requerido." Display="Dynamic" ValidationGroup="AgregarGroup" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnAgregarTipo" CssClass="btn btn-primary" OnClick="btnAgregarTipo_Click" CommandArgument='<%#Eval("Id") %>' CommandName="TipoId" ValidationGroup="AgregarGroup" runat="server" Text="Agregar" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary" runat="server" Text="Volver" />
            </div>
        </div>
    </div>
</asp:Content>
