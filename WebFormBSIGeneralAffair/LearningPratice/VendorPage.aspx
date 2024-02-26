<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VendorPage.aspx.vb" Inherits="WebFormBSIGeneralAffair.VendorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong><span class="auto-style1">Data Vendor</span><br class="auto-style1" />
            <br />
            <br />
            Nama Vendor :
            <asp:TextBox ID="nameVendor" runat="server"></asp:TextBox >
            <br />
            Alamat&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:TextBox ID="addressVendor" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnStore" runat="server" Text="Tambah Vendor" OnClick="btnStore_Click"/>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="message" runat="server" Text=""></asp:Label>
            </strong>
        </div>
        <p>
        <asp:BulletedList ID="bullteListVendor" runat="server">
        </asp:BulletedList>        
        </p>
    </form>
</body>
</html>
