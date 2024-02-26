<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PanelControl.aspx.vb" Inherits="WebFormBSIGeneralAffair.PanelControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Select your favorite programming language:
            <br />
            <br />
            <asp:RadioButton
                ID="rdlVisualBasic" GroupName="language" Text="Visual Basic" runat="server" />
            <br />
            <br />
            <asp:RadioButton
                ID="rdlCSharp" GroupName="language" Text="C#" runat="server" />
            <br />
            <br />
            <asp:RadioButton
                ID="rdlOther" GroupName="language" Text="Other Language" runat="server" />
            <br />
            <asp:Panel ID="pnlOther" Visible="false" runat="server">
                <asp:Label
                    ID="lblOther" Text="Other Language:" AssociatedControlID="txtOther"
                    runat="server" />
                <asp:TextBox ID="txtOther" runat="server" />
            </asp:Panel>
            <br />
            <br />
            <asp:Button ID="btnSubmit" Text="Submit" runat="server" />
        </div>
    </form>
</body>
</html>
