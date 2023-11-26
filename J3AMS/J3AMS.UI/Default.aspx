<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="J3AMS.UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container-login">
        <div class="centrar-login">
            <div class="mb-3">
                <label for="txtNombreUsuario" class="form-label">Usuario</label>
                <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Contraseña</label>
                <input id="txtPassword" runat="server" type="password" class="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnLoggin" CssClass="btn btn-primary btn-block" OnClick="btnLoggin_Click" runat="server" Text="Ingresar" />
            </div>
        </div>
    </main>
</asp:Content>