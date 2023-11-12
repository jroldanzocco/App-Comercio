<%@ Page Title="Artículos" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="BuscarArticulo.aspx.cs" Inherits="J3AMS.UI.BuscarArticulo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table">
        <thead>
            <tr>
                <th scope="col">Id</th>
                <th scope="col">Codigo</th>
                <th scope="col">Descripción</th>
                <th scope="col">Tipo</th>
                <th scope="col">Marca</th>
                <th scope="col">Acciones</th>
            </tr>
        </thead>
        <asp:Repeater ID="repRepetidor" runat="server">

            <itemtemplate>
                <tr>
                    <td><%# Eval("Id") %></td>
                    <td><%# Eval("Codigo") %></td>
                    <td><%# Eval("Descripcion") %></td>
                    <td><%# Eval("Tipo") %></td>
                    <td><%# Eval("Marca") %></td>
                    <td>
                        <asp:Button ID="btnEditarArticulo"  OnClick="btnEditarArticulo_Click" CssClass="btn btn-primary" runat="server" Text="Editar" />
                        <asp:Button ID="btnInformeArticulo" CssClass="btn btn-primary" runat="server" Text="Informes" />
                        <asp:Button ID="btnEliminarArticulo" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEliminarArticulo_Click" CssClass="btn btn-primary" runat="server" Text="Eliminar" />
                    </td>
                </tr>
            </itemtemplate>
        </asp:Repeater>
        
        
    </table>
    
    <asp:Button ID="btnNuevoArticulo" OnClick="btnNuevoArticulo_Click" CssClass="btn btn-primary" runat="server" Text="Nuevo" />

</asp:Content>


