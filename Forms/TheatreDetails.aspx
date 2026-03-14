<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TheatreDetails.aspx.cs" Inherits="coursework.TheatreDetails" %>

<!DOCTYPE html>
<html>
<head runat="server">
<title>Theatre Details</title>

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
    width:600px;
    margin:25px auto;
    background:white;
    padding:20px;
    border-radius:10px;
    box-shadow:0px 8px 20px rgba(0,0,0,0.25);
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

.btn{
    padding:7px 15px;
    border:none;
    border-radius:4px;
    color:white;
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
<h1>🏢 Theatre Management</h1>
</div>

<div class="container">

<div class="form-group">
Theatre ID
<asp:TextBox ID="txtTheatreID" runat="server"/>
</div>

<div class="form-group">
Theatre Name
<asp:TextBox ID="txtTheatreName" runat="server"/>
</div>

<div class="form-group">
Theatre City
<asp:TextBox ID="txtTheatreCity" runat="server"/>
</div>

<asp:Button Text="Insert" runat="server" OnClick="btnInsert_Click" CssClass="btn insert"/>
<asp:Button Text="Update" runat="server" OnClick="btnUpdate_Click" CssClass="btn update"/>
<asp:Button Text="Delete" runat="server" OnClick="btnDelete_Click" CssClass="btn delete"/>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="grid-table"/>

</div>

</form>
</body>
</html>