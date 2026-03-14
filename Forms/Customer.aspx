<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="coursework.Customer" %>

<!DOCTYPE html>
<html>
<head runat="server">
<title>Customer Details</title>

<style>

/* Background */

body{
    font-family:'Segoe UI', Tahoma;
    background: linear-gradient(135deg,#1d4350,#a43931);
    margin:0;
}

/* Navbar */

.navbar{
    background:#111;
    color:white;
    padding:12px;
    text-align:center;
}



/* Container */

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
    font-size:18px;
    color:#333;
}

/* Form group */

.form-group{
    margin-bottom:10px;
}

/* Labels */

label{
    font-weight:600;
    font-size:13px;
}

/* Textboxes */

input[type=text]{
    width:100%;
    padding:6px;
    border-radius:4px;
    border:1px solid #ccc;
    margin-top:3px;
    font-size:13px;
}

/* Buttons */

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

/* Button Colors */

.insert{ background:#28a745; }
.insert:hover{ background:#218838; }

.update{ background:#007bff; }
.update:hover{ background:#0069d9; }

.delete{ background:#dc3545; }
.delete:hover{ background:#c82333; }

/* GridView */

.grid-table{
    width:100%;
    border-collapse:collapse;
    margin-top:15px;
    font-size:13px;
}

.grid-table th{
    background:#343a40;
    color:white;
    padding:6px;
}

.grid-table td{
    padding:5px;
    border:1px solid #ccc;
    text-align:center;
}

.grid-table tr:nth-child(even){
    background:#f2f2f2;
}

</style>
</head>

<body>

<form runat="server">

<div class="navbar">
<h1>👤 Customer Details</h1>
</div>

<div class="container">

<h2>Manage Customer</h2>

<div class="form-group">
<asp:Label Text="Customer ID" runat="server"/>
<asp:TextBox ID="txtID" runat="server"/>
</div>

<div class="form-group">
<asp:Label Text="Customer Name" runat="server"/>
<asp:TextBox ID="txtName" runat="server"/>
</div>

<div class="form-group">
<asp:Label Text="Address" runat="server"/>
<asp:TextBox ID="txtAddress" runat="server"/>
</div>

<div class="form-group">
<asp:Label Text="Email" runat="server"/>
<asp:TextBox ID="txtEmail" runat="server"/>
</div>

<div class="form-group">
<asp:Label Text="Phone" runat="server"/>
<asp:TextBox ID="txtPhone" runat="server"/>
</div>

<div class="btn-container">

<asp:Button 
ID="btnInsert" 
Text="Insert" 
runat="server" 
OnClick="btnInsert_Click"
CssClass="btn insert"/>

<asp:Button 
ID="btnUpdate" 
Text="Update" 
runat="server" 
OnClick="btnUpdate_Click"
CssClass="btn update"/>

<asp:Button 
ID="btnDelete" 
Text="Delete" 
runat="server" 
OnClick="btnDelete_Click"
CssClass="btn delete"/>

</div>

<asp:GridView 
ID="GridView2" 
runat="server" 
AutoGenerateColumns="true"
CssClass="grid-table"/>

</div>

</form>
</body>
</html>