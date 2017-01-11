<%@ Page Title="" Language="C#" MasterPageFile="~/addProducts.Master" AutoEventWireup="true" CodeBehind="ShowCart.aspx.cs" Inherits="shoppingCart.ShowCart" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
    <tr>
        <td>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="284px">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Remove Product" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnMakeOrder" runat="server" OnClick="Button1_Click" Text="Make Order" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
