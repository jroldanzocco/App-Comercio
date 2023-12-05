<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleFactura.aspx.cs" Inherits="J3AMS.UI.DetalleFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="mb-2">
            <asp:Button ID="btnVolver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" runat="server" Text="Volver al menú" />
        </div>
        <div class="justify-content-between d-flex">
            <asp:Label ID="lblNumeroFactura" CssClass="form-label" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblVendedor" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
        </div>
        <table class="table">
            <thead>
                <tr runat="server">
                    <th scope="col">Descripción</th>
                    <th scope="col">Cantidad</th>
                    <th scope="col">Precio</th>
                </tr>
            </thead>
            <asp:Repeater ID="repDetallesFactura" runat="server">
                <ItemTemplate>
                    <tr runat="server">
                        <td><%# Eval("Descripcion")%></td>
                        <td><%# Eval("Cantidad")%></td>
                        <td><%# Eval("PrecioUnitario")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div class="d-flex justify-content-end">
            <asp:Label ID="lblTotal" CssClass="align-items-end" runat="server" Text=""></asp:Label> 
        </div>
    </div>
</asp:Content>
