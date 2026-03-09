<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketDetails.aspx.cs" Inherits="coursework.TicketDetails" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Ticket Details</title>
    <link href="../CSS/style.css" rel="stylesheet" />
</head>

<body>

<form runat="server">

<div class="navbar">
    <h1>🎟 Ticket Details</h1>
</div>

<div style="width:60%;margin:auto;margin-top:40px;background:white;padding:30px;border-radius:10px;box-shadow:0px 5px 10px rgba(0,0,0,0.3);">

    <h2>Manage Ticket</h2>

    <asp:Label Text="Ticket ID:" runat="server"/>
    <asp:TextBox ID="txtTicketId" runat="server"/>
    <br /><br />

    <asp:Label Text="Price:" runat="server"/>
    <asp:TextBox ID="txtPrice" runat="server"/>
    <br /><br />

    <asp:Label Text="Date:" runat="server"/>
    <asp:TextBox ID="txtDate" runat="server" TextMode="Date"/>
    <br /><br />

    <asp:Label Text="Status:" runat="server"/>
    <asp:TextBox ID="txtStatus" runat="server"/>
    <br /><br />

    <asp:Label Text="Seat No:" runat="server"/>
    <asp:TextBox ID="txtSeatNo" runat="server"/>
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
