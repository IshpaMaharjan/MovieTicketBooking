<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TheatreMovieShow.aspx.cs" Inherits="coursework.TheatreMovieShow" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Theatre Movie Show</title>
    <link href="../CSS/style.css" rel="stylesheet" />
</head>

<body>

<form id="form1" runat="server">

<div class="navbar">
    <h1>🎭 Theatre Movie Show</h1>
</div>

<div class="container">

<h2 class="sectionTitle">Search Shows by Theatre</h2>

<div class="dashboard">

<div class="card" style="height:auto;width:420px;padding:30px;">

<asp:Label Text="Enter Theatre ID" runat="server"/>
<br />

<asp:TextBox ID="txtTheatreId" runat="server" CssClass="input"/>
<br /><br />

<asp:Button ID="btnSearch" runat="server" Text="Search Shows" CssClass="btn" OnClick="Search_Click"/>

</div>

</div>

<h2 class="sectionTitle">Show Results</h2>

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