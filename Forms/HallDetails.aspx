<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HallDetails.aspx.cs" Inherits="coursework.HallDetails" %>

<!DOCTYPE html>
<html>
<head runat="server">
<title>Hall Details</title>

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

.form-group{ margin-bottom:10px; }

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
<h1>🎭 Hall Management</h1>
</div>

<div class="container">

<div class="form-group">
Hall ID
<asp:TextBox ID="txtHallId" runat="server"/>
</div>

<div class="form-group">
Hall Name
<asp:TextBox ID="txtHallName" runat="server"/>
</div>

<div class="form-group">
Hall Capacity
<asp:TextBox ID="txtCapacity" runat="server"/>
</div>

<asp:Button Text="Insert" runat="server" OnClick="Insert_Click" CssClass="btn insert"/>
<asp:Button Text="Update" runat="server" OnClick="Update_Click" CssClass="btn update"/>
<asp:Button Text="Delete" runat="server" OnClick="Delete_Click" CssClass="btn delete"/>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="grid-table"/>

</div>

</form>
</body>
</html>