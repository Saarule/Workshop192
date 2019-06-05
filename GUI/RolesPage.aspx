<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RolesPage.aspx.cs" Inherits="GUI.RollesPage" %>

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
            left: 257px;
            top: 11px;
            position: absolute;
            font-weight: 700;
            font-size: xx-large;
        }
         .auto-style3 {
             z-index: 1;
             left: 29px;
             top: 49px;
             position: absolute;
         }
         .auto-style4 {
             z-index: 1;
             left: 28px;
             top: 71px;
             position: absolute;
         }
        .auto-style7 {
            z-index: 1;
            left: 208px;
            top: 65px;
            position: absolute;
             width: 80px;
         }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" BackColor="#99FFCC" CssClass="auto-style1">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="My Roles:"></asp:Label>
                <asp:Label ID="Label2" runat="server" CssClass="auto-style3" Text="Insert Store Name:"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="commandButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style7" ForeColor="White" OnClick="ContinueButton_Click" Text="Continue" />
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
