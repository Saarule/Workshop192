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
            height: 383px;
            width: 693px;
        }
        .auto-style2 {
            z-index: 1;
            left: 257px;
            top: 11px;
            position: absolute;
            font-weight: 700;
            font-size: xx-large;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" BackColor="#99FFCC" CssClass="auto-style1">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="My Roles:"></asp:Label>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
