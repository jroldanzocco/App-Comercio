<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarVentas.aspx.cs" Inherits="J3AMS.UI.BuscarVentas" %>
<asp:Content ID="ListadoVentas" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Número</th>
                    <th scope="col">Fecha</th>
                    <th scope="col">Id Cliente</th>
                    <th scope="col">Importe</th>
                </tr>
            </thead>

            <asp:Repeater ID="repFacturas" runat="server">
                <ItemTemplate>
                    <tr runat="server">
                        <td><%# Eval("Numero") %></td>
                        <td><%# Eval("FechaEmision") %></td>
                        <td><%# Eval("IdCliente") %></td>
                        <td><%# Eval("Importe") %></td>              
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
    </div>

</asp:Content>
