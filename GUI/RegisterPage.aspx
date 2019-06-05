<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="GUI.RegisterPage" %>

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
        .auto-style5 {
            z-index: 1;
            left: 117px;
            top: 76px;
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
            width: 71px;
        }
        .auto-style2 {
            z-index: 1;
            left: 245px;
            top: 17px;
            position: absolute;
            font-size: xx-large;
            font-weight: 700;
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
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style5"></asp:TextBox>
                <asp:Label ID="search0" runat="server" CssClass="auto-style6" Text="Username: "></asp:Label>
                <asp:Button ID="SendButton1" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style9" ForeColor="White" Text="Sign Up" OnClick="RegisterButton1_Click" />
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Registration Page"></asp:Label>
                <asp:Label ID="Label2" runat="server" CssClass="auto-style10" Text="Password: "></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style11"> </asp:TextBox>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
