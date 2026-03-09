<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="coursework.Home" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Movie Booking System</title>
    <link href="CSS/style.css" rel="stylesheet" />
</head>

<body>

<form runat="server">

<div class="navbar">
    <h1>🎬 Movie Booking Management System</h1>
</div>


<div class="container">

    <h2 class="sectionTitle">Basic Forms</h2>

    <div class="dashboard">

        <a href="Forms/Customer.aspx" class="card">
            <span class="icon">👤</span>
            <p>Customer Details</p>
        </a>

        <a href="Forms/MovieDetails.aspx" class="card">
            <span class="icon">🎥</span>
            <p>Movie Details</p>
        </a>

        <a href="Forms/TheatreDetails.aspx" class="card">
            <span class="icon">🏢</span>
            <p>Theatre Details</p>
        </a>

        <a href="Forms/HallDetails.aspx" class="card">
            <span class="icon">🎭</span>
            <p>Hall Details</p>
        </a>

        <a href="Forms/ShowDetails.aspx" class="card">
            <span class="icon">⏰</span>
            <p>Show Details</p>
        </a>

        <a href="Forms/TicketDetails.aspx" class="card">
            <span class="icon">🎟</span>
            <p>Ticket Details</p>
        </a>

    </div>



    <h2 class="sectionTitle">Complex Queries</h2>

    <div class="dashboard">

        <a href="Forms/UserTicket.aspx" class="card complex">
            <span class="icon">📄</span>
            <p>User Ticket Report</p>
        </a>

        <a href="Forms/TheatreMovieShow.aspx" class="card complex">
            <span class="icon">🏢</span>
            <p>Theatre Movie Show</p>
        </a>

        <a href="Forms/MovieOccupancy.aspx" class="card complex">
            <span class="icon">📊</span>
            <p>Movie Occupancy</p>
        </a>

    </div>

</div>

</form>

</body>
</html>