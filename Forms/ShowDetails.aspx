<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowDetails.aspx.cs" Inherits="coursework.ShowDetails" %>

<!DOCTYPE html>
<html>
<head runat="server">
<title>Show Details</title>

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

.container h2{
    text-align:center;
    margin-bottom:15px;
    font-size:18px;
    color:#333;
}

.form-group{
    margin-bottom:10px;
}

input[type=text],
input[type=date]{
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
    font-size:13px;
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
<h1>🎬 Show Management</h1>
</div>

<div class="container">

<h2>Manage Show</h2>

<div class="form-group">
Show ID
<asp:TextBox ID="txtShowId" runat="server"/>
</div>

<div class="form-group">
Show Date
<asp:TextBox ID="txtShowDate" runat="server" TextMode="Date"/>
</div>

<div class="form-group">
Show Time
<asp:TextBox ID="txtShowTime" runat="server"/>
</div>

<div class="btn-container">

<asp:Button 
Text="Insert" 
runat="server" 
OnClick="Insert_Click"
CssClass="btn insert"/>

<asp:Button 
Text="Update" 
runat="server" 
OnClick="Update_Click"
CssClass="btn update"/>

<asp:Button 
Text="Delete" 
runat="server" 
OnClick="Delete_Click"
CssClass="btn delete"/>

</div>

<asp:GridView 
ID="GridView1" 
runat="server" 
AutoGenerateColumns="true"
CssClass="grid-table"/>

</div>

</form>
</body>
</html>