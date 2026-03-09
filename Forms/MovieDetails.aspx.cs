using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace coursework
{
    public partial class MovieDetails : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        void LoadData()
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM Movie", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Movie (MovieId, MovieTitle, Language, Genre, Duration, ReleaseDate) " +
                               "VALUES (:id, :title, :lang, :genre, :dur, TO_DATE(:rdate,'YYYY-MM-DD'))";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("id", txtMovieId.Text);
                cmd.Parameters.Add("title", txtTitle.Text);
                cmd.Parameters.Add("lang", txtLanguage.Text);
                cmd.Parameters.Add("genre", txtGenre.Text);
                cmd.Parameters.Add("dur", txtDuration.Text);
                cmd.Parameters.Add("rdate", txtReleaseDate.Text);

                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Movie SET MovieTitle=:title, Language=:lang, Genre=:genre, Duration=:dur, ReleaseDate=TO_DATE(:rdate,'YYYY-MM-DD') " +
                               "WHERE MovieId=:id";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("title", txtTitle.Text);
                cmd.Parameters.Add("lang", txtLanguage.Text);
                cmd.Parameters.Add("genre", txtGenre.Text);
                cmd.Parameters.Add("dur", txtDuration.Text);
                cmd.Parameters.Add("rdate", txtReleaseDate.Text);
                cmd.Parameters.Add("id", txtMovieId.Text);

                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("DELETE FROM Movie WHERE MovieId=:id", conn);
                cmd.Parameters.Add("id", txtMovieId.Text);
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }
    }
}