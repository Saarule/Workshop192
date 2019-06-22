<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="NewGUI.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 258px;
        }
        .auto-style2 {
            z-index: 1;
            left: 216px;
            top: 58px;
            background-color : red;
            color:black;
            font-size:64px;
            position: absolute;
            height: 580px;
            width: 875px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Button ID="Button1" runat="server" CssClass="auto-style2" OnClick="Button1_Click" Text="Initialize" />
        </div>
    </form>
</body>
</html>
