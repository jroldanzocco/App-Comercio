<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="J3AMS.UI.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <div class="container mt-5">
        <h2>Registro</h2>
        <div runat="server" id="formRegistro">
            <div class="form-group">
                <label for="txtNombreUsuario">Nombre de Usuario:</label>
                <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server"
                    ID="nombreValidator"
                    ControlToValidate="txtNombreUsuario"
                    ErrorMessage="El nombre de usuario es requerido."
                    Display="Dynamic"
                    ValidationGroup="RegisterGroup" />
            </div>
            <div class="form-group">
                <label for="txtPassword">Contraseña:</label>
                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator runat="server"
                    ID="passValidator"
                    ControlToValidate="txtPassword"
                    ErrorMessage="La contraseña es requerida."
                    Display="Dynamic"
                    ValidationGroup="RegisterGroup" />
            </div>
            <div class="form-group">
                <label for="txtRepetirPassword">Repetir Contraseña:</label>
                <asp:TextBox ID="txtRepetirPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblPassword" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <label for="txtEmail">Correo Electrónico:</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator runat="server"
                    ID="RequiredFieldValidator4"
                    ControlToValidate="txtEmail"
                    ErrorMessage="Email es requerido."
                    Display="Dynamic"
                    ValidationGroup="RegisterGroup" />
            </div>

            <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" ValidationGroup="RegisterGroup" />
        </div>
    </div>

</asp:Content>
