<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HallDetails.aspx.cs" Inherits="coursework.HallDetails" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Hall Details</title>
    <link href="../CSS/style.css" rel="stylesheet" />
</head>

<body>

<form runat="server">

<div class="navbar">
    <h1>🎭 Hall Details</h1>
</div>

<div style="width:60%;margin:auto;margin-top:40px;background:white;padding:30px;border-radius:10px;box-shadow:0px 5px 10px rgba(0,0,0,0.3);">

    <h2>Manage Hall</h2>

    <asp:Label Text="Hall ID:" runat="server"/>
    <asp:TextBox ID="txtHallId" runat="server"/>
    <br /><br />

    <asp:Label Text="Hall Name:" runat="server"/>
    <asp:TextBox ID="txtHallName" runat="server"/>
    <br /><br />

    <asp:Label Text="Hall Capacity:" runat="server"/>
    <asp:TextBox ID="txtCapacity" runat="server"/>
    <br /><br />

    <asp:Button Text="Insert" runat="server" OnClick="Insert_Click"/>
    <asp:Button Text="Update" runat="server" OnClick="Update_Click"/>
    <asp:Button Text="Delete" runat="server" OnClick="Delete_Click"/>

    <br /><br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" Width="100%" />

</div>

</form>
</body>
</html>