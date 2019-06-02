<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUserHomePage.aspx.cs" Inherits="GUI.LoginUserHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 391px;
        }
        .auto-style2 {
            z-index: 1;
            left: 234px;
            top: 26px;
            position: absolute;
            font-size: xx-large;
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
            top: 160px;
            position: absolute;
            width: 92px;
        }
        .auto-style9 {
            z-index: 1;
            left: 223px;
            top: 74px;
            position: absolute;
            width: 51px;
        }
        .auto-style8 {
            z-index: 1;
            left: 33px;
            top: 201px;
            position: absolute;
            width: 79px;
        }
        .auto-style4 {
            z-index: 1;
            left: 34px;
            top: 275px;
            position: absolute;
            width: 71px;
            height: 27px;
        }
        .auto-style3 {
            z-index: 1;
            left: 33px;
            top: 117px;
            position: absolute;
            right: 586px;
            height: 27px;
        }
        .auto-style10 {
            z-index: 1;
            left: 33px;
            top: 238px;
            position: absolute;
        }
        .auto-style11 {
            z-index: 1;
            left: 10px;
            top: 15px;
            position: absolute;
            height: 386px;
            width: 693px;
        }
        .auto-style12 {
            z-index: 1;
            left: 32px;
            top: 315px;
            position: absolute;
            width: 184px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1"> 

            <asp:Panel ID="Panel1" runat="server"  BackColor="#99FFCC" CssClass="auto-style11">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style5"></asp:TextBox>
                <asp:Label ID="search" runat="server" CssClass="auto-style6" Text="Search:"></asp:Label>
                <asp:Button ID="WatchCartsButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style7" ForeColor="White" Text="Watch Carts" OnClick="WatchCartsButton_Click" />
                <asp:Button ID="SearchButton0" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style9" ForeColor="White" Text="Search  " OnClick="SearchButton_Click" />
                <asp:Button ID="CheckoutButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style8" ForeColor="White" Text="Checkout" OnClick="CheckoutButton_Click" />
                <asp:Button ID="LogutButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style4" ForeColor="White" Text="Log Out" OnClick="LogoutButton_Click" />
                <asp:Button ID="OpenStoreButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style3" ForeColor="White" Text="Open Store" OnClick="OpenStoreButton_Click" />
                <asp:Button ID="Button2" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style12" OnClick="Button2_Click" ForeColor="White" Text="Remove User From System" Visible="False" />
                <asp:Button ID="Button1" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style10" ForeColor="White" Text="My roles" OnClick="Button1_Click" />
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Welcome logged in user"></asp:Label>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
