<%@ Page Title="" Language="C#" MasterPageFile="~/addProducts.Master" AutoEventWireup="true" CodeBehind="AddProducts.aspx.cs" Inherits="shoppingCart.AddProducts" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 462px;
    }
</style>
</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblProductID" runat="server">Product ID</asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="lblProductName" runat="server" Text="Product Name:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtProductName" runat="server">Name</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProductName" ErrorMessage="Please enter a product name."></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="lblProductPrice" runat="server" Text="Product Price:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" />
        </td>
        <td>
            <asp:Label ID="lblProductMsg" runat="server" Text="Message :"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Select Product" />
                </Columns>
            </asp:GridView>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Button ID="btnShowProducts" runat="server" Text="Show Products" OnClick="btnShowProducts_Click" />
        </td>
        <td>
            <asp:Button ID="btnUpdateProduct" runat="server" Text="Update Product" OnClick="btnUpdateProduct_Click" />
        </td>
    </tr>
</table>
</asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <asp:TextBox ID="txtProductSearch" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearchProduct" runat="server" OnClick="btnSearchProduct_Click" Text="Search" Width="54px" />
</asp:Content>



