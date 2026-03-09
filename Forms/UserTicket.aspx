<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserTicket.aspx.cs" Inherits="coursework.UserTicket" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>User Tickets</title>
    <link href="../CSS/style.css" rel="stylesheet" />
</head>

<body>

<form id="form1" runat="server">

<div class="navbar">
    <h1>🎟 User Ticket Information</h1>
</div>

<div class="container">

<div style="width:70%;margin:auto;margin-top:40px;background:white;padding:30px;border-radius:10px;box-shadow:0px 5px 12px rgba(0,0,0,0.3);">

<h2 style="text-align:center;margin-bottom:25px;">Filter Tickets</h2>

<div style="display:flex;justify-content:center;gap:20px;margin-bottom:25px;">

<div>
<label><b>Customer</b></label><br />

<asp:DropDownList 
ID="ddlCustomer" 
runat="server" 
AutoPostBack="true" 
OnSelectedIndexChanged="ddlFilter_Changed"
style="padding:8px;border-radius:5px;border:1px solid #ccc;width:180px;">
</asp:DropDownList>

</div>

<div>
<label><b>Movie</b></label><br />

<asp:DropDownList 
ID="ddlMovie" 
runat="server" 
AutoPostBack="true" 
OnSelectedIndexChanged="ddlFilter_Changed"
style="padding:8px;border-radius:5px;border:1px solid #ccc;width:180px;">
</asp:DropDownList>

</div>

</div>

<h2 style="text-align:center;margin-bottom:20px;">Ticket Results</h2>

<asp:GridView 
ID="gvTickets" 
runat="server" 
AutoGenerateColumns="false"
Width="100%"
GridLines="Both"
style="box-shadow:0px 3px 8px rgba(0,0,0,0.2);">

<Columns>

<asp:BoundField HeaderText="Ticket ID" DataField="TicketId" />

<asp:BoundField HeaderText="Price" DataField="TicketPrice" />

<asp:BoundField HeaderText="Date" DataField="TicketDate" DataFormatString="{0:dd-MMM-yyyy}" />

<asp:BoundField HeaderText="Status" DataField="TicketStatus" />

<asp:BoundField HeaderText="Seat No" DataField="SeatNo" />

<asp:BoundField HeaderText="Customer" DataField="CustName" />

<asp:BoundField HeaderText="Movie" DataField="MovieTitle" />

</Columns>

</asp:GridView>

</div>

</div>

</form>

</body>
</html>