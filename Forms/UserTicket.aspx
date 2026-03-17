<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserTicket.aspx.cs" Inherits="coursework.UserTicket" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>User Tickets</title>
    <link href="../CSS/style.css" rel="stylesheet" />
    <style>
        body { background:#e6f0fa; font-family:'Segoe UI', sans-serif; }
        .navbar { background:#1e3c72; color:white; padding:20px; text-align:center; box-shadow:0 4px 8px rgba(0,0,0,0.2);}
        .container { max-width:1000px; margin:auto; padding:20px;}
        h2 { color:#1e3c72; font-weight:600; margin-bottom:20px; text-align:center;}
        .filter-section { display:flex; justify-content:center; gap:20px; flex-wrap:wrap; margin-bottom:30px; }
        .filter-section div { display:flex; flex-direction:column; }
        .filter-section label { font-weight:500; margin-bottom:5px; }
        .filter-section select { padding:8px 12px; border-radius:5px; border:1px solid #ccc; min-width:180px; }
        .gv-container { background:white; padding:20px; border-radius:10px; box-shadow:0px 5px 12px rgba(0,0,0,0.15);}
        .gridview th { background:#1e3c72; color:white; padding:10px; }
        .gridview td { padding:8px; text-align:center; }
        .gridview tr:hover { background:#cce0ff; }
    </style>
</head>

<body>
<form id="form1" runat="server">

<div class="navbar">
<h1>🎟 User Ticket Information</h1>
</div>

<div class="container">
<div class="gv-container">

<h2>Filter Tickets</h2>

<div class="filter-section">

<div>
<label><b>Customer</b></label>
<asp:DropDownList 
    ID="ddlCustomer" 
    runat="server" 
    AutoPostBack="true"
    OnSelectedIndexChanged="ddlFilter_Changed">
</asp:DropDownList>
</div>

<div>
<label><b>Movie</b></label>
<asp:DropDownList 
    ID="ddlMovie" 
    runat="server" 
    AutoPostBack="true"
    OnSelectedIndexChanged="ddlFilter_Changed">
</asp:DropDownList>
</div>

<div>
<label><b>Email</b></label>
<asp:DropDownList 
    ID="ddlEmail" 
    runat="server" 
    AutoPostBack="true"
    OnSelectedIndexChanged="ddlFilter_Changed">
</asp:DropDownList>
</div>

</div>

<h2>Ticket Results</h2>

<asp:GridView 
ID="gvTickets" 
runat="server"
AutoGenerateColumns="false"
CssClass="gridview"
Width="100%"
GridLines="Both">

<Columns>
<asp:BoundField HeaderText="Ticket ID" DataField="TicketId" />
<asp:BoundField HeaderText="Price" DataField="TicketPrice" />
<asp:BoundField HeaderText="Date" DataField="TicketDate" DataFormatString="{0:dd-MMM-yyyy}" />
<asp:BoundField HeaderText="Status" DataField="TicketStatus" />
<asp:BoundField HeaderText="Seat No" DataField="SeatNo" />
<asp:BoundField HeaderText="Customer" DataField="CustName" />
<asp:BoundField HeaderText="Movie" DataField="MovieTitle" />
<asp:BoundField HeaderText="Email" DataField="Email" />
</Columns>

</asp:GridView>

</div>
</div>

</form>
</body>
</html>