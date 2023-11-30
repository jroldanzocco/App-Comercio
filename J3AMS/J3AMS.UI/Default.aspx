<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="J3AMS.UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container-fluid d-flex align-items-center justify-content-center">
        <div class="col-sm-12 col-md-8 col-lg-6 col-xl-4 text-center">
            <div class="mb-3">
                <label for="txtNombreUsuario" class="form-label col-form-label">Usuario</label>
                <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label col-form-label">Contraseña</label>
                <input id="txtPassword" runat="server" type="password" class="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnLoggin" CssClass="btn btn-primary btn-block" OnClick="btnLoggin_Click" runat="server" Text="Ingresar" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnRegister" CssClass="btn btn-danger btn-block" OnClick="bntRegister_Click" runat="server" Text="Registrarse" />
            </div>
        </div>
    </main>
</asp:Content>
<%--  --%>
