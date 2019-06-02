<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StorePage.aspx.cs" Inherits="GUI.StorePage" %>

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
        .auto-style3 {
            z-index: 1;
            left: 19px;
            top: 90px;
            position: absolute;
            right: 450px;
            height: 27px;
        }
        .auto-style7 {
            z-index: 1;
            left: 19px;
            top: 135px;
            position: absolute;
             width: 150px;
         }
        .auto-style8 {
            z-index: 1;
            left: 19px;
            top: 180px;
            position: absolute;
            width: 150px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" BackColor="#99FFCC" CssClass="auto-style1">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Store Info"></asp:Label>
                <asp:Button ID="InventoryButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style3" ForeColor="White" OnClick="InventoryButton_Click" Text="See Inventory" />
                <asp:Button ID="TreeButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style7" ForeColor="White" OnClick="TreeButton_Click" Text="Hierarchy Worker Tree" />
                <asp:Button ID="manageWorkerButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style8" ForeColor="White" OnClick="ManageWorkersButton_Click" Text="Manage Workers" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
