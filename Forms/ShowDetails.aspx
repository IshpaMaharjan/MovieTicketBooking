<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowDetails.aspx.cs" Inherits="coursework.ShowDetails" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Show Details</title>
    <link href="../CSS/style.css" rel="stylesheet" />
</head>

<body>

<form runat="server">

<div class="navbar">
    <h1>🎬 Show Details</h1>
</div>

<div style="width:60%;margin:auto;margin-top:40px;background:white;padding:30px;border-radius:10px;box-shadow:0px 5px 10px rgba(0,0,0,0.3);">

    <h2>Manage Show</h2>

    <asp:Label Text="Show ID:" runat="server"/>
    <asp:TextBox ID="txtShowId" runat="server" />
    <br /><br />

    <asp:Label Text="Show Date:" runat="server"/>
    <asp:TextBox ID="txtShowDate" runat="server" TextMode="Date"/>
    <br /><br />

    <asp:Label Text="Show Time:" runat="server"/>
    <asp:TextBox ID="txtShowTime" runat="server"/>
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
