<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Registration</h1>
    <table>
        <tr>
            <td>Enter First Name:</td>
            <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>Enter Last Name:</td>
            <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Must enter last name."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Enter Email:</td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Must enter email."></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail" runat="server" ErrorMessage="Not a valid email." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Enter Street Address:</td>
            <td><asp:TextBox ID="txtStreet" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>Enter Apartment:</td>
            <td><asp:TextBox ID="txtApt" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>Enter City:</td>
            <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>Enter State:</td>
            <td><asp:TextBox ID="txtState" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>Enter Zip:</td>
            <td><asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>Enter Home Phone:</td>
            <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        
        <tr>
            <td>Enter Password:</td>
            <td><asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Must enter password."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Confirm Password:</td>
            <td><asp:TextBox ID="txtConfirm" TextMode="Password" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvConfirm" runat="server" ControlToValidate="txtConfirm" ErrorMessage="Must confirm password."></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cpvConfirm" runat="server" ErrorMessage="Passwords must match." ControlToValidate="txtConfirm" ControlToCompare="txtPassword"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
            <td><asp:Label ID="lblError" runat="server" Text=""></asp:Label></td>
            <td></td>
        </tr>
        
    </table>

        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx"> Log In</asp:LinkButton>
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            
        </p>
    </div>
    </form>
</body>
</html>