<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        div {
            padding: 10px;
        }

        .labelStyle {
            color: red;
            background-color: yellow;
            border: Solid 2px Red;
        }
    </style>
    <title>Format Label</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblFirst" Text="First Label" ForeColor="Red" BackColor="Yellow"
                BorderStyle="Solid" BorderWidth="2" BorderColor="red" runat="server" />
            <br />
            <br />
            <asp:Label ID="lblSecond" Text="Second Label"
                CssClass="labelStyle" runat="server" />
        </div>
    </form>
</body>
</html>
