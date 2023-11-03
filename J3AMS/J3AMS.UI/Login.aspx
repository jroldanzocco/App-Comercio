<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="J3AMS.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link
      href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css"
      rel="stylesheet"
    />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="Resources/css/styles.css" rel="stylesheet" />
    <title>Login</title>
</head>
    <body class="d-flex align-items-center py-4 bg-body-tertiary">
    
    <main class="form-signin w-100 m-auto">
      <form runat="server">
       <%-- <img
          class="mb-4"
          src="../assets/brand/bootstrap-logo.svg"
          alt=""
          width="72"
          height="57"
        />--%>
        <h1 class="h3 mb-3 fw-normal">J3AMS - Ingreso</h1>

        <div class="form-floating">
            
            <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
            <label for="txtNombreUsuario">Usuario</label>
        </div>
          <br />
        <div class="form-floating">
          <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
           <label for="txtPassword">Password</label>
        </div>
          <hr />
          <asp:Button ID="btnIngresar" CssClass="btn btn-primary w-100 py-2" OnClick="btnLoggin_Click" runat="server" Text="Ingresar" />
        
        <p class="mt-5 mb-3 text-body-secondary">&copy; Grupo 28 - 2023</p>
      </form>
    </main>
</body>
</html>
