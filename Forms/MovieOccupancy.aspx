<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MovieOccupancy.aspx.cs" Inherits="coursework.MovieOccupancy" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Movie Occupancy</title>
    <link href="../CSS/style.css" rel="stylesheet" />
</head>

<body>

<form id="form1" runat="server">

<div class="navbar">
    <h1>📊 Movie Occupancy Dashboard</h1>
</div>

<div class="container">

<h2 class="sectionTitle">Find Top Theatre Occupancy</h2>

<div class="dashboard">

<div class="card" style="height:auto;width:420px;padding:30px;">

<asp:Label Text="Enter Movie ID" runat="server"/>
<br />

<asp:TextBox ID="txtMovieId" runat="server" CssClass="input"/>
<br /><br />

<asp:Button ID="btnSearch" runat="server" Text="Check Occupancy" CssClass="btn" OnClick="Search_Click"/>

</div>

</div>

<h2 class="sectionTitle">Top 3 Theatre Occupancy</h2>

<div class="dashboard">

<div class="card" style="height:auto;width:80%;padding:20px;">

<asp:GridView 
ID="GridView1" 
runat="server" 
AutoGenerateColumns="true"
Width="100%" 
CssClass="grid"/>

</div>

</div>

</div>

</form>
</body>
</html>