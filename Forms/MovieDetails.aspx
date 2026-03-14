<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MovieDetails.aspx.cs" Inherits="coursework.MovieDetails" %>

<!DOCTYPE html>
<html>
<head runat="server">
<title>Movie Details</title>

<style>

body{
    font-family:'Segoe UI', Tahoma;
    background: linear-gradient(135deg,#1d4350,#a43931);
    margin:0;
}

.navbar{
    background:#111;
    color:white;
    padding:12px;
    text-align:center;
}


.container{
    width:800px;
    margin:25px auto;
    background:white;
    padding:20px;
    border-radius:10px;
    box-shadow:0px 8px 20px rgba(0,0,0,0.25);
}

.container h2{
    text-align:center;
    margin-bottom:15px;
}

.form-group{
    margin-bottom:10px;
}

input[type=text]{
    width:100%;
    padding:6px;
    border-radius:4px;
    border:1px solid #ccc;
}

.btn-container{
    text-align:center;
    margin-top:12px;
}

.btn{
    padding:7px 15px;
    border:none;
    border-radius:4px;
    color:white;
    font-weight:600;
    cursor:pointer;
    margin:5px;
}

.insert{ background:#28a745; }
.update{ background:#007bff; }
.delete{ background:#dc3545; }

.grid-table{
    width:100%;
    border-collapse:collapse;
    margin-top:15px;
}

.grid-table th{
    background:#343a40;
    color:white;
}

.grid-table td{
    border:1px solid #ccc;
    padding:6px;
}

</style>
</head>

<body>

<form runat="server">

<div class="navbar">
<h1>🎬 Movie Management</h1>
</div>

<div class="container">

<h2>Manage Movie</h2>

<div class="form-group">
Movie ID
<asp:TextBox ID="txtMovieId" runat="server"/>
</div>

<div class="form-group">
Title
<asp:TextBox ID="txtTitle" runat="server"/>
</div>

<div class="form-group">
Language
<asp:TextBox ID="txtLanguage" runat="server"/>
</div>

<div class="form-group">
Genre
<asp:TextBox ID="txtGenre" runat="server"/>
</div>

<div class="form-group">
Duration
<asp:TextBox ID="txtDuration" runat="server"/>
</div>

<div class="form-group">
Release Date
<asp:TextBox ID="txtReleaseDate" runat="server"/>
</div>

<div class="btn-container">

<asp:Button ID="btnInsert" Text="Insert" runat="server" OnClick="Insert_Click" CssClass="btn insert"/>

<asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="Update_Click" CssClass="btn update"/>

<asp:Button ID="btnDelete" Text="Delete" runat="server" OnClick="Delete_Click" CssClass="btn delete"/>

</div>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="grid-table"/>

</div>

</form>
</body>
</html>