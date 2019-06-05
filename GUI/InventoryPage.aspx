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
            height: 100%;
            width: 100%;
        }
        .auto-style2 {
            z-index: 1;
            left: 607px;
            top: 5px;
            position: absolute;
            font-weight: 700;
            font-size: xx-large;
             margin-bottom: 0px;
         }
        .auto-style7 {
            z-index: 1;
            left: 659px;
            top: 322px;
            position: absolute;
             width: 113px;
             height: 26px;
             margin-bottom: 0px;
         }
         .auto-style8 {
             z-index: 1;
             left: 263px;
             top: 180px;
             position: absolute;
             height: 20px;
             width: 166px;
         }
         .auto-style9 {
             z-index: 1;
             left: 579px;
             top: 265px;
             position: absolute;
             width: 97px;
         }
         .auto-style10 {
             z-index: 1;
             left: 261px;
             top: 205px;
             position: absolute;
             width: 114px;
         }
         .auto-style11 {
             z-index: 1;
             left: 434px;
             top: 204px;
             position: absolute;
             width: 93px;
         }
         .auto-style12 {
             z-index: 1;
             left: 435px;
             top: 181px;
             position: absolute;
         }
         .auto-style13 {
             z-index: 1;
             left: 438px;
             top: 244px;
             position: absolute;
         }
         .auto-style4 {
            z-index: 1;
            left: 41px;
            top: 243px;
            position: absolute;
            width: 181px;
            height: 27px;
        }
         .auto-style17 {
             z-index: 1;
             left: 41px;
             top: 180px;
             position: absolute;
         }
         .auto-style18 {
             z-index: 1;
             left: 261px;
             top: 265px;
             position: absolute;
             width: 116px;
         }
         .auto-style19 {
             z-index: 1;
             left: 263px;
             top: 244px;
             position: absolute;
         }
         .auto-style20 {
             z-index: 1;
             left: 434px;
             top: 264px;
             position: absolute;
             width: 94px;
         }
         .auto-style21 {
             z-index: 1;
             left: 262px;
             top: 303px;
             position: absolute;
             margin-bottom: 1px;
         }
         .auto-style22 {
             z-index: 1;
             left: 45px;
             top: 73px;
             position: absolute;
             height: 26px;
             width: 160px;
         }
         .auto-style23 {
             z-index: 1;
             left: 38px;
             top: 51px;
             position: absolute;
             font-weight: 700;
         }
        .auto-style3 {
            z-index: 1;
            left: 213px;
            top: 90px;
            position: absolute;
            right: 533px;
            height: 35px;
        }
         .auto-style24 {
             z-index: 1;
             left: 443px;
             top: 324px;
             position: absolute;
             width: 95px;
             height: 25px;
         }
         .auto-style25 {
             z-index: 1;
             left: 576px;
             top: 205px;
             position: absolute;
             width: 99px;
         }
         .auto-style26 {
             z-index: 1;
             left: 744px;
             top: 184px;
             position: absolute;
             width: 142px;
         }
         .auto-style27 {
             z-index: 1;
             left: 40px;
             top: 208px;
             position: absolute;
             width: 176px;
         }
         .auto-style28 {
             z-index: 1;
             left: 579px;
             top: 244px;
             position: absolute;
         }
         .auto-style29 {
             z-index: 1;
             left: 745px;
             top: 246px;
             position: absolute;
             width: 108px;
         }
         .auto-style30 {
             z-index: 1;
             left: 745px;
             top: 265px;
             position: absolute;
             width: 95px;
         }
         .auto-style31 {
             z-index: 1;
             left: 743px;
             top: 207px;
             position: absolute;
             width: 86px;
         }
         .auto-style32 {
             z-index: 1;
             left: 574px;
             top: 182px;
             position: absolute;
         }
         .auto-style33 {
             z-index: 1;
             left: 261px;
             top: 326px;
             position: absolute;
         }
         .auto-style34 {
             z-index: 1;
             left: 613px;
             top: 97px;
             position: absolute;
         }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:Panel ID="Panel1" runat="server" BackColor="#99FFCC" CssClass="auto-style1">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Inventory:"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="auto-style22">
                    <asp:ListItem>Add Product</asp:ListItem>
                    <asp:ListItem>Edit Product</asp:ListItem>
                    <asp:ListItem>Delete Product</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="Label10" runat="server" CssClass="auto-style23" Text="Please choose which option you want to do:"></asp:Label>
                <asp:Button ID="WatchCartsButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style7" ForeColor="White" OnClick="AddnewProductButton_Click" Text="Add product" Visible="False" />
                <asp:Label ID="Label3" runat="server" CssClass="auto-style12" Text="Insert Price:" Visible="False"></asp:Label>
                <asp:Label ID="Label7" runat="server" CssClass="auto-style17" Text="Insert Product ID to Remove:" Visible="False"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style10" Visible="False"></asp:TextBox>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style11" Visible="False"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" CssClass="auto-style13" Text="Insert Amount:" Visible="False"></asp:Label>
                <br />
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style24" ForeColor="White" Text="Edit Product" Visible="False" OnClick="Button2_Click" />
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" CssClass="auto-style8" Text="Insert Name of Product :" Visible="False"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label9" runat="server" CssClass="auto-style21" Text="Insert ID of product" Visible="False"></asp:Label>
                <br />
                <asp:Button ID="Button3" runat="server" CssClass="auto-style34" OnClick="Button3_Click" Text="Refresh Page" />
                <br />
                <asp:Button ID="SendButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style3" ForeColor="White" OnClick="SendButton_Click" Text="Continue " />
                <br />
                <br />
                <asp:Button ID="DeleteButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style4" ForeColor="White" OnClick="deleteButton_Click" Text="Delete product" Visible="False" />
                <asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style18" Visible="False"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label14" runat="server" CssClass="auto-style32" Text="Insert Name of Product:" Visible="False"></asp:Label>
                <br />
                &nbsp;&nbsp;
                <asp:TextBox ID="TextBox7" runat="server" CssClass="auto-style27" Visible="False"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox5" runat="server" CssClass="auto-style20" Visible="False"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox6" runat="server" CssClass="auto-style25" Visible="False"></asp:TextBox>
                <asp:Label ID="Label11" runat="server" CssClass="auto-style26" Text="Insert Price:" Visible="False"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox9" runat="server" CssClass="auto-style31" Visible="False"></asp:TextBox>
                <br />
                <asp:Label ID="Label8" runat="server" CssClass="auto-style19" Text="Insert Catagory:" Visible="False"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style9" Visible="False"></asp:TextBox>
                <br />
                <asp:Label ID="Label12" runat="server" CssClass="auto-style28" Text="Insert Amount:" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="Label13" runat="server" CssClass="auto-style29" Text="Insert Catagory:" Visible="False"></asp:Label>
                <asp:TextBox ID="TextBox8" runat="server" CssClass="auto-style30" Visible="False"></asp:TextBox>
                <asp:TextBox ID="TextBox10" runat="server" CssClass="auto-style33" Visible="False"></asp:TextBox>
                <asp:PlaceHolder ID="PH1" runat="server"></asp:PlaceHolder>
                <br />
            </asp:Panel>
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
