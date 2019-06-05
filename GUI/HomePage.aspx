<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GUI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 100%;
        }
        .auto-style2 {
            z-index: 1;
            left: 228px;
            top: 23px;
            position: absolute;
            font-weight: 700;
            font-size: xx-large;
        }
        .auto-style3 {
            z-index: 1;
            left: 33px;
            top: 110px;
            position: absolute;
            right: 590px;
            height: 27px;
        }
        .auto-style4 {
            z-index: 1;
            left: 33px;
            top: 150px;
            position: absolute;
            width: 57px;
            height: 27px;
        }
        .auto-style5 {
            z-index: 1;
            left: 104px;
            top: 76px;
            position: absolute;
            width: 92px;
        }
        .auto-style6 {
            z-index: 1;
            left: 37px;
            top: 78px;
            position: absolute;
            height: 16px;
        }
        .auto-style7 {
            z-index: 1;
            left: 33px;
            top: 190px;
            position: absolute;
        }
        .auto-style8 {
            z-index: 1;
            left: 33px;
            top: 226px;
            position: absolute;
            width: 108px;
        }
        .auto-style10 {
            z-index: 1;
            left: 10px;
            top: 15px;
            position: absolute;
            height: 100%;
            width:  100%;
        }
        .auto-style9 {
            z-index: 1;
            left: 223px;
            top: 74px;
            position: absolute;
            width: 51px;
        }
    </style>
</head>
<body class="auto-style1">
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" BackColor="#99FFCC" CssClass="auto-style10">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Welcome to NOBS site"></asp:Label>
            <asp:Button ID="RegisterButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style3" ForeColor="White" OnClick="RegisterButton_Click" Text="Register" />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style5" ></asp:TextBox>
            <asp:Label ID="search" runat="server" CssClass="auto-style6" Text="Search:"></asp:Label>
            <asp:Button ID="WatchCartsButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style7" ForeColor="White" Text="Watch Carts" OnClick="WatchCartsButton_Click" />
            <asp:Button ID="SearchButton0" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style9" ForeColor="White" OnClick="SearchButton_Click" Text="Search  " />
            <asp:Button ID="CheckoutButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style8" ForeColor="White" Text="Checkout" OnClick="CheckoutButton_Click" />
            <asp:Button ID="LogInButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style4" ForeColor="White" OnClick="LogInButton_Click" Text="Log In" />
        </asp:Panel>
    </form>
</body>
</html>
