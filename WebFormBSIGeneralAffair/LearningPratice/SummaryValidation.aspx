<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SummaryValidation.aspx.vb" Inherits="WebFormBSIGeneralAffair.SummaryValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td align="right">Username :</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rvUsername" runat="server"
                            ErrorMessage="Username masih kosong"
                            ControlToValidate="txtUsername"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">Password :</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"
                            TextMode="Password" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rvPassword" runat="server"
                            ErrorMessage="Password masih kosong"
                            ControlToValidate="txtPassword"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">Re-Password :</td>
                    <td>
                        <asp:TextBox ID="txtRepass" runat="server" TextMode="Password" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rvRePassword" runat="server"
                            ErrorMessage="Re-Password masih kosong"
                            ControlToValidate="txtRepass"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvPassword" runat="server"
                            ErrorMessage="Password dan Repassword harus sama"
                            ControlToCompare="txtPassword"
                            ControlToValidate="txtRepass"
                            SetFocusOnError="True">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                            OnClick="btnSubmit_Click" />
                    </td>
                    <td></td>
                </tr>
            </table>
            <asp:ValidationSummary ID="vsUser" runat="server"
                HeaderText="Error yang ditemukan" />
            <hr />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
