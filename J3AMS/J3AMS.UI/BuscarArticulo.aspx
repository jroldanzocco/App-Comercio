<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarArticulo.aspx.cs" Inherits="J3AMS.UI.BuscarArticulo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Repeater ID="repRepetidor" runat="server">
        <ItemTemplate>
            <div>
                <h3><%# Eval("Codigo") %></h3>
                <p>Descripción: <%# Eval("Descripcion") %></p>
                <p>Tipo: <%# Eval("Tipo") %></p>
                <p>Marca: <%# Eval("Marca") %></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>