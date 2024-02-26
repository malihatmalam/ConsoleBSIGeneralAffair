<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UploadValidation.aspx.vb" Inherits="WebFormBSIGeneralAffair.UploadValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Image File :
            <asp:FileUpload ID="fpImage" runat="server" /><br />
            <br />
            <asp:Button ID="btnUpload" runat="server" Text="Upload File"
                OnClick="btnUpload_Click" /><br />
            <br />
            <asp:DataList ID="dlImage" runat="server" RepeatColumns="3">
                <ItemTemplate>
                    <asp:Image ID="imgUpload" runat="server"
                        ImageUrl='<%# Eval("Name","~/UploadImage/{0}") %>' Width="200px" />
                </ItemTemplate>
            </asp:DataList>
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
