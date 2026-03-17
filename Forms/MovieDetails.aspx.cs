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

        // INSERT Movie
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
            ClearFields();
            LoadData();
        }

        // UPDATE Movie
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
            ClearFields();
            LoadData();
        }

        // DELETE Movie (transaction-safe, including related tables)
        protected void Delete_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                OracleTransaction trans = conn.BeginTransaction();

                try
                {
                    OracleCommand cmd1 = new OracleCommand("DELETE FROM C_M_Th_H_S_T WHERE MovieId=:id", conn);
                    cmd1.Parameters.Add("id", txtMovieId.Text);
                    cmd1.ExecuteNonQuery();

                    OracleCommand cmd2 = new OracleCommand("DELETE FROM C_M_Th_H_S WHERE MovieId=:id", conn);
                    cmd2.Parameters.Add("id", txtMovieId.Text);
                    cmd2.ExecuteNonQuery();

                    OracleCommand cmd3 = new OracleCommand("DELETE FROM Cust_Mov_Thea_Hall WHERE MovieId=:id", conn);
                    cmd3.Parameters.Add("id", txtMovieId.Text);
                    cmd3.ExecuteNonQuery();

                    OracleCommand cmd4 = new OracleCommand("DELETE FROM Cust_Mov_Theatre WHERE MovieId=:id", conn);
                    cmd4.Parameters.Add("id", txtMovieId.Text);
                    cmd4.ExecuteNonQuery();

                    OracleCommand cmd5 = new OracleCommand("DELETE FROM Cust_Mov WHERE MovieId=:id", conn);
                    cmd5.Parameters.Add("id", txtMovieId.Text);
                    cmd5.ExecuteNonQuery();

                    OracleCommand cmd6 = new OracleCommand("DELETE FROM Movie WHERE MovieId=:id", conn);
                    cmd6.Parameters.Add("id", txtMovieId.Text);
                    cmd6.ExecuteNonQuery();

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }

            ClearFields();
            LoadData();
        }

        // Clear Textboxes
        void ClearFields()
        {
            txtMovieId.Text = "";
            txtTitle.Text = "";
            txtLanguage.Text = "";
            txtGenre.Text = "";
            txtDuration.Text = "";
            txtReleaseDate.Text = "";
        }
    }
}