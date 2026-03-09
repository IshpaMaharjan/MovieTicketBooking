using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace coursework
{
    public partial class MovieOccupancy : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        protected void Search_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT 
                                M.MovieTitle,
                                S.ShowDate,
                                CAST(COUNT(T.TicketId) AS INTEGER) AS TotalTickets,
                                CAST(SUM(CASE WHEN T.TicketStatus='BOOKED' THEN 1 ELSE 0 END) AS INTEGER) AS BookedTickets,
                                CAST(SUM(CASE WHEN T.TicketStatus='AVAILABLE' THEN 1 ELSE 0 END) AS INTEGER) AS AvailableTickets
                            FROM MOVIE M
                            JOIN C_M_TH_H_S CMS ON M.MovieId = CMS.MovieId
                            JOIN SHOW S ON CMS.ShowId = S.ShowId
                            JOIN C_M_TH_H_S_T CMST ON CMS.ShowId = CMST.ShowId
                            JOIN TICKET T ON CMST.TicketId = T.TicketId
                            WHERE M.MovieId = :mid
                            GROUP BY M.MovieTitle, S.ShowDate";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add("mid", txtMovieId.Text);

                OracleDataAdapter da = new OracleDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}
