<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="shoppingCart.index1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 819px;
        }
        .auto-style2 {
            width: 437px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="2">
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblProductID" runat="server" Text="Product Selection"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblProductName" runat="server" Text="Product Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblProductPrice" runat="server" Text="Product Price"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Button ID="btnOrderProduct" runat="server" OnClick="btnOrderProduct_Click" Text="Confirm Order" />
                            <asp:Label ID="lblProductMessage" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="btnChangeProduct" runat="server" OnClick="btnChangeProduct_Click" Text="Change Order" />
                            <asp:Label ID="lblProductUpdate" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
