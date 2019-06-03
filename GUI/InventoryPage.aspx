<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryPage.aspx.cs" Inherits="GUI.InventoryPage" %>

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
            width: 900px;
        }
        .auto-style2 {
            z-index: 1;
            left: 413px;
            top: 3px;
            position: absolute;
            font-weight: 700;
            font-size: xx-large;
        }
        .auto-style7 {
            z-index: 1;
            left: 25px;
            top: 117px;
            position: absolute;
             width: 113px;
         }
         .auto-style8 {
             z-index: 1;
             left: 22px;
             top: 61px;
             position: absolute;
             height: 20px;
             width: 270px;
         }
         .auto-style9 {
             z-index: 1;
             left: 24px;
             top: 84px;
             position: absolute;
             width: 97px;
         }
         .auto-style10 {
             z-index: 1;
             left: 218px;
             top: 82px;
             position: absolute;
             width: 96px;
         }
         .auto-style11 {
             z-index: 1;
             left: 396px;
             top: 82px;
             position: absolute;
             width: 93px;
         }
         .auto-style12 {
             z-index: 1;
             left: 218px;
             top: 61px;
             position: absolute;
         }
         .auto-style13 {
             z-index: 1;
             left: 396px;
             top: 62px;
             position: absolute;
         }
         .auto-style15 {
             z-index: 1;
             left: 348px;
             top: 222px;
             position: absolute;
             height: 11px;
             font-size: xx-large;
             width: 67px;
         }
         .auto-style16 {
             z-index: 1;
             left: 819px;
             top: 553px;
             position: absolute;
         }
        .auto-style4 {
            z-index: 1;
            left: 25px;
            top: 204px;
            position: absolute;
            width: 113px;
            height: 27px;
        }
         .auto-style17 {
             z-index: 1;
             left: 22px;
             top: 153px;
             position: absolute;
         }
         .auto-style18 {
             z-index: 1;
             left: 24px;
             top: 176px;
             position: absolute;
         }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:Panel ID="Panel1" runat="server" BackColor="#99FFCC" CssClass="auto-style1">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Inventory:"></asp:Label>
                <asp:Button ID="WatchCartsButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style7" ForeColor="White" OnClick="AddnewProductButton_Click" Text="Add/Edit product" />
                <asp:Label ID="Label3" runat="server" CssClass="auto-style12" Text="Insert Price:"></asp:Label>
                <asp:Label ID="Label2" runat="server" CssClass="auto-style8" Text="Insert ID of Product :"></asp:Label>
                <asp:Label ID="Label7" runat="server" CssClass="auto-style17" Text="Insert Product ID to Remove:"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style9"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style10"></asp:TextBox>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style11"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" CssClass="auto-style13" Text="Insert Amount:"></asp:Label>
                <asp:Label ID="Label6" runat="server" CssClass="auto-style15" Font-Size="Large" Text="Products:"></asp:Label>
                <asp:Button ID="Button1" runat="server" CssClass="auto-style16" OnClick="Button1_Click1" Text="Refresh" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="DeleteButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style4" ForeColor="White" OnClick="deleteButton_Click" Text="Delete product" />
                <asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style18"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;
                <br />
                &nbsp;<asp:PlaceHolder ID="PH1" runat="server"></asp:PlaceHolder>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
