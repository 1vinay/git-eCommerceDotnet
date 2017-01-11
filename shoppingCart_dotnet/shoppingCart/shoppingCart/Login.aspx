<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="shoppingCart.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
    .auto-style1 {
        height: 15px;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-sm-4 col-sm-offset-1">
					<div class="login-form">
						<h2>Login to your account</h2>
    <table style="width:100%;">
    <tr>
        <td class="auto-style1">
            <asp:TextBox ID="txtLoginName" runat="server">Name</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLoginName" ErrorMessage="Please enter a valid name."></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtLoginPassword" runat="server">Password</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginPassword" ErrorMessage="Please enter a valid password."></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button type="submit" ID="btnLogin" runat="server" OnClick="Button1_Click" Text="Login" class="btn btn-default"/>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>
                        </div>
        </div>
</asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder2">
    
    <div class="col-sm-4">
					<div class="signup-form">
        <table style="width:100%;">
            <tr>
                <td colspan="3">New User Signup!</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox type="text" ID="txtSignupName" runat="server">Name</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSignupName" ErrorMessage="Please choose a name."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="txtSignupEmail" runat="server" TextMode="Email">name@example.com</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSignupEmail" ErrorMessage="Please enter a valid email address."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="txtSignupPassword" runat="server">Password</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSignupPassword" ErrorMessage="Please choose a password."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnSignUp" runat="server" Text="Signup" OnClick="btnSignUp_Click" class="btn btn-default"/>

                    
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
        </div>
   
	
</asp:Content>

