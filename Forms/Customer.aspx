<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="coursework.Customer" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Customer Details</title>
    <link href="../CSS/style.css" rel="stylesheet" />
</head>

<body>

<form runat="server">

<div class="navbar">
    <h1>👤 Customer Details</h1>
</div>

<div style="width:60%;margin:auto;margin-top:40px;background:white;padding:30px;border-radius:10px;box-shadow:0px 5px 10px rgba(0,0,0,0.3);">

    <h2>Manage Customer</h2>

    <asp:Label Text="Customer ID:" runat="server"/>
    <asp:TextBox ID="txtID" runat="server"/>
    <br /><br />

    <asp:Label Text="Customer Name:" runat="server"/>
    <asp:TextBox ID="txtName" runat="server"/>
    <br /><br />

    <asp:Label Text="Address:" runat="server"/>
    <asp:TextBox ID="txtAddress" runat="server"/>
    <br /><br />

    <asp:Label Text="Email:" runat="server"/>
    <asp:TextBox ID="txtEmail" runat="server"/>
    <br /><br />

    <asp:Label Text="Phone:" runat="server"/>
    <asp:TextBox ID="txtPhone" runat="server"/>
    <br /><br />

    <asp:Button ID="btnInsert" Text="Insert" runat="server" OnClick="btnInsert_Click"/>
    <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click"/>
    <asp:Button ID="btnDelete" Text="Delete" runat="server" OnClick="btnDelete_Click"/>

    <br /><br />

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true" Width="100%" />

</div>

</form>
</body>
</html>
