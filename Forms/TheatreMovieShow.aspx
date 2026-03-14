<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TheatreMovieShow.aspx.cs" Inherits="coursework.TheatreMovieShow" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Theatre Movie Show</title>
    <link href="../CSS/style.css" rel="stylesheet" />
    <style>
        body { background:#e6f0fa; font-family:'Segoe UI', sans-serif; }
        .navbar { background:#1e3c72; color:white; padding:20px; text-align:center; box-shadow:0 4px 8px rgba(0,0,0,0.2);}
        .container { max-width:1000px; margin:auto; padding:20px;}
        .sectionTitle { text-align:center; color:#1e3c72; font-weight:600; margin-bottom:20px; }
        .dashboard { display:flex; justify-content:center; flex-wrap:wrap; gap:20px; }
        .card { background:white; border-radius:10px; box-shadow:0 4px 12px rgba(0,0,0,0.15); padding:30px; width:400px; }
        .card:hover {background:white; color:black}
        .card-large { width:100%; padding:20px; }
        .input { width:100%; padding:10px; border-radius:5px; border:1px solid #ccc; margin-top:10px; }
        .btn { padding:10px 20px; border:none; border-radius:5px; background:#1e3c72; color:white; font-weight:600; cursor:pointer; transition:none; }
        .grid, .gridview { width:100%; border-collapse:collapse; }
        .grid th, .gridview th { background:#1e3c72; color:white; padding:10px; text-align:center; }
        .grid td, .gridview td { padding:8px; text-align:center; }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <h1>🎭 Theatre Movie Show</h1>
        </div>

        <div class="container">

            <h2 class="sectionTitle">Search Shows by Theatre</h2>
            <div class="dashboard">
                <div class="card">
                    <asp:Label Text="Enter Theatre ID" runat="server"/>
                    <asp:TextBox ID="txtTheatreId" runat="server" CssClass="input"/>
                    <br /><br />
                    <asp:Button ID="btnSearch" runat="server" Text="Search Shows" CssClass="btn" OnClick="Search_Click"/>
                </div>
            </div>

            <h2 class="sectionTitle">Show Results</h2>
            <div class="dashboard">
                <div class="card card-large">
                    <asp:GridView 
                        ID="GridView1" 
                        runat="server" 
                        AutoGenerateColumns="true" 
                        CssClass="grid"
                        Width="100%" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>