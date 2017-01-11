<%@ Page Title="" Language="C#" MasterPageFile="~/addProducts.Master" AutoEventWireup="true" CodeBehind="AdminOrders.aspx.cs" Inherits="shoppingCart.AdminOrders" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="lblProductID" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td id="lblProductID">
                <asp:Label ID="lblProductName" runat="server" Text="Product Name"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                    <Columns>
                        <asp:CommandField SelectText="Select Order" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnConfirmOrder" runat="server" OnClick="btnConfirmOrder_Click" Text="Confirm Order" />
            </td>
        </tr>
    </table>
</asp:Content>
