<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenStorePage.aspx.cs" Inherits="GUI.OpenStorePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            z-index: 1;
            left: 10px;
            top: 15px;
            position: absolute;
            height: 100%;
            width: 100%;
        }
        .auto-style2 {
            z-index: 1;
            left: 196px;
            top: 9px;
            position: absolute;
            font-weight: 700;
            font-size: xx-large;
        }
        .auto-style5 {
            z-index: 1;
            left: 128px;
            top: 75px;
            position: absolute;
            width: 168px;
        }
        .auto-style6 {
            z-index: 1;
            left: 37px;
            top: 78px;
            position: absolute;
            height: 16px;
        }
        .auto-style9 {
            z-index: 1;
            left: 39px;
            top: 119px;
            position: absolute;
            width: 65px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" BackColor ="#99FFCC" CssClass="auto-style1">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Open a new store page"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style5"></asp:TextBox>
                <asp:Label ID="search" runat="server" CssClass="auto-style6" Text="Store Name:"></asp:Label>
                <asp:Button ID="SendButton1" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style9" ForeColor="White" OnClick="Send_Click" Text="Send" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
