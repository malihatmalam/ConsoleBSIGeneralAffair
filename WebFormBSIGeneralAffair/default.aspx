<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="WebFormBSIGeneralAffair._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Button1 {
            height: 51px;
            width: 154px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Buah nangka wkwkwkw
        </div>
        <p>
            Masukan Nama Anda :&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="32px" Width="246px"></asp:TextBox>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Label">Hello World</asp:Label>
                <p>
                    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
                </p>

                <div>
                    Dari mana anda mengetahui website http://actualtraining.wordpress.com ?
            <ul>
                <li>
                    <asp:RadioButton ID="rdlMajalah" Text="Artikel Majalah"
                        GroupName="Source" runat="server" />
                </li>

                Hands On Training ASP.NET 2.0 / 3.5

Oleh: Erick Kurniawan, S.Kom, M.Kom
15

                <li>
                    <asp:RadioButton ID="rdlTv" Text="Program Televisi"
                        GroupName="Source" runat="server" />
                </li>
                <li>
                    <asp:RadioButton ID="rdlLain" Text="Sumber yang lain"
                        GroupName="Source" runat="server" />
                </li>
            </ul>
                    <asp:Button ID="btnSubmit" Text="Submit" runat="server" />
                    <hr />
                    <asp:Label ID="lblHasil" runat="server" />
                </div>
    </form>

</body>
</html>
