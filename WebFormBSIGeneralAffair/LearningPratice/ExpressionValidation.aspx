<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExpressionValidation.aspx.vb" Inherits="WebFormBSIGeneralAffair.ExpressionValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblEmail" Text="Email Address:"
                AssociatedControlID="txtEmail"
                runat="server" />
            <asp:TextBox ID="txtEmail" runat="server" />
            <asp:RegularExpressionValidator ID="regEmail" ControlToValidate="txtEmail"
                Text="(Invalid email)"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                runat="server" />
            <br />
            <br />
            <asp:Button ID="btnSubmit" Text="Submit" runat="server" />
        </div>
    </form>
</body>
</html>
