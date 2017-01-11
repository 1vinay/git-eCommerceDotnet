<%@ Page Title="" Language="C#" MasterPageFile="~/addProducts.Master" AutoEventWireup="true" CodeBehind="CustomerOrder.aspx.cs" Inherits="shoppingCart.CustomerOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" >
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">Products have been confirmed.</td>
        </tr>
    </table>
</asp:Content>
