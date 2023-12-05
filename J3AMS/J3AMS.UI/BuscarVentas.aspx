<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarVentas.aspx.cs" Inherits="J3AMS.UI.BuscarVentas" %>
<asp:Content ID="ListadoVentas" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="mb-2">
            <asp:Button ID="btnVolver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" runat="server" Text="Volver al menú" />
        </div>
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
                        <td>
                        <asp:Button ID="btnDetalle" CommandArgument='<%# Eval("Numero")+ "," + Eval("IdCliente") %>' OnClick="btnDetalle_Click" CommandName="FacturaId" runat="server" CssClass="btn btn-info w-auto" Text="Detalle de factura" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
    </div>

</asp:Content>
