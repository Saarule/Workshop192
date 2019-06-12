<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="GUI.SearchPage" %>

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
            direction: ltr;
        }
        .auto-style2 {
            z-index: 1;
            left: 330px;
            top: 9px;
            position: absolute;
            font-weight: 700;
            font-size: xx-large;
        }
        .auto-style3 {
            z-index: 1;
            left: 7px;
            top: 43px;
            position: absolute;
        }
        .auto-style4 {
            z-index: 1;
            left: 204px;
            top: 44px;
            position: absolute;
        }
        .auto-style5 {
            z-index: 1;
            left: 7px;
            top: 73px;
            position: absolute;
            height: 14px;
            width: 122px;
        }
        .auto-style6 {
            z-index: 1;
            left: 203px;
            top: 72px;
            position: absolute;
        }
        .auto-style9 {
            z-index: 1;
            left: 434px;
            top: 69px;
            position:  absolute;
            width: 100px;
        
            
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            tor<asp:Panel ID="Panel1" runat="server" BackColor="#99FFCC" CssClass="auto-style1">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Results:"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" CssClass="auto-style3" Text="Insert ID of Product:  "></asp:Label>
                <asp:PlaceHolder ID="PH1" runat="server"></asp:PlaceHolder>
                <asp:Label ID="Label3" runat="server" CssClass="auto-style4" Text="Insert Amount:"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style5"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style6"></asp:TextBox>
                <asp:Button ID="SendButton1" runat="server" BackColor="#000066" BorderColor="#000066" CssClass="auto-style9" ForeColor="White" OnClick="AddButton1_Click" Text="Add To Cart" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
