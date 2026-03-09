<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MovieDetails.aspx.cs" Inherits="coursework.MovieDetails" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Movie Details</title>
    <link href="../CSS/style.css" rel="stylesheet" />
</head>

<body>

<form runat="server">

<div class="navbar">
    <h1>🎬 Movie Details</h1>
</div>

<div style="width:60%;margin:auto;margin-top:40px;background:white;padding:30px;border-radius:10px;box-shadow:0px 5px 10px rgba(0,0,0,0.3);">

    <h2>Manage Movie</h2>

    <asp:Label Text="Movie ID:" runat="server"/>
    <asp:TextBox ID="txtMovieId" runat="server"/>
    <br /><br />

    <asp:Label Text="Title:" runat="server"/>
    <asp:TextBox ID="txtTitle" runat="server"/>
    <br /><br />

    <asp:Label Text="Language:" runat="server"/>
    <asp:TextBox ID="txtLanguage" runat="server"/>
    <br /><br />

    <asp:Label Text="Genre:" runat="server"/>
    <asp:TextBox ID="txtGenre" runat="server"/>
    <br /><br />

    <asp:Label Text="Duration:" runat="server"/>
    <asp:TextBox ID="txtDuration" runat="server"/>
    <br /><br />

    <asp:Label Text="Release Date:" runat="server"/>
    <asp:TextBox ID="txtReleaseDate" runat="server"/>
    <br /><br />

    <asp:Button ID="btnInsert" Text="Insert" runat="server" OnClick="Insert_Click"/>
    <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="Update_Click"/>
    <asp:Button ID="btnDelete" Text="Delete" runat="server" OnClick="Delete_Click"/>

    <br /><br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" Width="100%" />

</div>

</form>
</body>
</html>
