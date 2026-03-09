<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TheatreDetails.aspx.cs" Inherits="coursework.TheatreDetails" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Theatre Details</title>
    <link href="../CSS/style.css" rel="stylesheet" />
</head>

<body>

<form runat="server">

<div class="navbar">
    <h1>🏢 Theatre Details</h1>
</div>

<div style="width:60%;margin:auto;margin-top:40px;background:white;padding:30px;border-radius:10px;box-shadow:0px 5px 10px rgba(0,0,0,0.3);">

    <h2>Manage Theatre</h2>

    <asp:Label Text="Theatre ID:" runat="server"/>
    <asp:TextBox ID="txtTheatreID" runat="server"/>
    <br /><br />

    <asp:Label Text="Theatre Name:" runat="server"/>
    <asp:TextBox ID="txtTheatreName" runat="server"/>
    <br /><br />

    <asp:Label Text="Theatre City:" runat="server"/>
    <asp:TextBox ID="txtTheatreCity" runat="server"/>
    <br /><br />

    <asp:Button Text="Insert" runat="server" OnClick="btnInsert_Click"/>
    <asp:Button Text="Update" runat="server" OnClick="btnUpdate_Click"/>
    <asp:Button Text="Delete" runat="server" OnClick="btnDelete_Click"/>

    <br /><br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" Width="100%" />

</div>

</form>
</body>
</html>
