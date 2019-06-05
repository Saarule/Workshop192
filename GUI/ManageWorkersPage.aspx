<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageWorkersPage.aspx.cs" Inherits="GUI.ManageWorkersPage" %>

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
         .auto-style5 {
             z-index: 1;
             left: 341px;
             top: 130px;
             position: absolute;
         }
         .auto-style6 {
             z-index: 1;
             left: 340px;
             top: 99px;
             position: absolute;
             margin-bottom: 0px;
         }
         .auto-style8 {
             z-index: 1;
             left: 336px;
             top: 199px;
             position: absolute;
             height: 26px;
             width: 337px;
         }
         .auto-style9 {
             z-index: 1;
             left: 343px;
             top: 171px;
             position: absolute;
         }
         .auto-style10 {
             z-index: 1;
             left: 13px;
             top: 97px;
             position: absolute;
             height: 26px;
             width: 206px;
         }
        .auto-style3 {
            z-index: 1;
            left: 545px;
            top: 96px;
            position: absolute;
            right: 102px;
            height: 35px;
        }
        .auto-style7 {
            z-index: 1;
            left: 24px;
            top: 212px;
            position: absolute;
             width: 150px;
         }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" BackColor="#99FFCC" CssClass="auto-style1">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Manage Workers"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style5" Visible="False"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" CssClass="auto-style6" Text="Insert User Name:" Visible="False"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="auto-style10" >
                    <asp:ListItem>Add New Store Owner</asp:ListItem>
                    <asp:ListItem>Add New Sore Manager</asp:ListItem>
                    <asp:ListItem>Delete Store Owner</asp:ListItem>
                    <asp:ListItem>Delete Store Manger</asp:ListItem>
                </asp:RadioButtonList>
                <asp:CheckBoxList ID="CheckBox2" runat="server" CssClass="auto-style8" Visible="False">
                    <asp:ListItem>Add product</asp:ListItem>
                    <asp:ListItem>Delete product</asp:ListItem>
                    <asp:ListItem>Edit product</asp:ListItem>
                    <asp:ListItem>Add owner</asp:ListItem>
                    <asp:ListItem>Add manager</asp:ListItem>
                    <asp:ListItem>Delete onwer/manger</asp:ListItem>
                </asp:CheckBoxList>
                <asp:Label ID="priviLabel" runat="server" CssClass="auto-style9" Text="Choose Privileges:" Visible="False"></asp:Label>
                <asp:Button ID="SendButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style3" ForeColor="White" OnClick="SendButton_Click" Text="Send" Visible="False" />
                <asp:Button ID="commandButton" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style7" ForeColor="White" OnClick="ContinueButton_Click" Text="Continue" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
