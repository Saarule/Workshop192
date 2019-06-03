<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayCart.aspx.cs" Inherits="GUI.DisplayCart" %>

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
            height: 600px;
            width: 780px;
        }
        .auto-style2 {
            z-index: 1;
            left: 286px;
            top: 4px;
            position: absolute;
            font-weight: 700;
            font-size: xx-large;
        }
        .auto-style3 {
            z-index: 1;
            left: 10px;
            top: 50px;
            position: absolute;
        }
        .auto-style4 {
            z-index: 1;
            left: 10px;
            top: 86px;
            position: absolute;
        }
        .auto-style9 {
            z-index: 1;
            left: 167px;
            top: 85px;
            position: absolute;
            width: 65px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" BackColor="#99FFCC" CssClass="auto-style1">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Shopping Cart:"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" ></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="SendButton1" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style9" ForeColor="White" OnClick="DeleteButton1_Click" Text="Delete" />
                <asp:Label ID="Label2" runat="server" CssClass="auto-style3" Text="Insert ID of Product To Remove:"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:PlaceHolder ID="PH1" runat="server"></asp:PlaceHolder>
                <br />
            </asp:Panel>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
