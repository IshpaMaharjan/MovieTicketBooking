using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace coursework
{
    public partial class TheatreMovieShow : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        protected void Search_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = @"
                SELECT 
                    t.TheatreName,
                    m.MovieTitle,
                    h.HallName,
                    s.ShowDate,
                    s.ShowTime
                FROM C_M_Th_H_S link
                JOIN Theatre t 
                    ON link.TheatreId = t.TheatreId
                JOIN Movie m 
                    ON link.MovieId = m.MovieId
                JOIN Hall h 
                    ON link.HallId = h.HallId
                JOIN Show s 
                    ON link.ShowId = s.ShowId
                WHERE t.TheatreId = :tid
                ORDER BY s.ShowDate, s.ShowTime";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(":tid", txtTheatreId.Text);

                OracleDataAdapter da = new OracleDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}
