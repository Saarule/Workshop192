<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="GUI.CheckoutPage" %>

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
            height: 378px;
            width: 693px;
        }
        .auto-style5 {
            z-index: 1;
            left: 183px;
            top: 75px;
            position: absolute;
            width: 191px;
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
            left: 34px;
            top: 159px;
            position: absolute;
            width: 65px;
        }
        .auto-style2 {
            z-index: 1;
            left: 269px;
            top: 17px;
            position: absolute;
            font-size: xx-large;
        }
        .auto-style10 {
            z-index: 1;
            left: 37px;
            top: 120px;
            position: absolute;
        }
        .auto-style11 {
            z-index: 1;
            left: 116px;
            top: 113px;
            position: absolute;
            width: 191px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server"  BackColor="#99FFCC" CssClass="auto-style1">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style5" ></asp:TextBox>
                <asp:Label ID="search0" runat="server" CssClass="auto-style6" Text="Credit Card Number:"></asp:Label>
                <asp:Button ID="SendButton1" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style9" ForeColor="White" Text="Pay" OnClick="PayButton1_Click" />
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Checkout Page"></asp:Label>
                <asp:Label ID="Label2" runat="server" CssClass="auto-style10" Text="Address: "></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style11"></asp:TextBox>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
