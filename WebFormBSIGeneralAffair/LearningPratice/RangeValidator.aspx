<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RangeValidator.aspx.vb" Inherits="WebFormBSIGeneralAffair.RangeValidator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAge" Text="Age:" AssociatedControlID="txtAge"
                runat="server" />
            <asp:TextBox ID="txtAge" runat="server" />
            <asp:RangeValidator ID="reqAge" ControlToValidate="txtAge"
                Text="(Invalid Age)" MinimumValue="5"
                MaximumValue="100" Type="Integer" runat="server" />
            <br />
            <br />
            <asp:Button ID="btnSubmit" Text="Submit" runat="server" />
        </div>
    </form>
</body>
</html>
