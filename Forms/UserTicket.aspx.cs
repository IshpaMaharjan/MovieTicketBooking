using System;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Web.UI.WebControls;

namespace coursework
{
    public partial class UserTicket : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFilters();
                LoadTickets();
            }
        }

        // Load Customer and Movie dropdowns
        private void LoadFilters()
        {
            using (OracleConnection con = new OracleConnection(connStr))
            {
                con.Open();

                // Customer dropdown
                OracleCommand cmdCust = new OracleCommand("SELECT CustId, CustName FROM Customer ORDER BY CustName", con);
                OracleDataReader drCust = cmdCust.ExecuteReader();
                ddlCustomer.Items.Clear();
                ddlCustomer.Items.Add(new ListItem("All Customers", "0"));
                while (drCust.Read())
                {
                    ddlCustomer.Items.Add(new ListItem(drCust["CustName"].ToString(), drCust["CustId"].ToString()));
                }
                drCust.Close();

                // Movie dropdown
                OracleCommand cmdMovie = new OracleCommand("SELECT MovieId, MovieTitle FROM Movie ORDER BY MovieTitle", con);
                OracleDataReader drMovie = cmdMovie.ExecuteReader();
                ddlMovie.Items.Clear();
                ddlMovie.Items.Add(new ListItem("All Movies", "0"));
                while (drMovie.Read())
                {
                    ddlMovie.Items.Add(new ListItem(drMovie["MovieTitle"].ToString(), drMovie["MovieId"].ToString()));
                }
                drMovie.Close();
            }
        }

        // Load tickets into GridView safely
        private void LoadTickets()
        {
            using (OracleConnection con = new OracleConnection(connStr))
            {
                con.Open();

                string sql = @"
                    SELECT T.TicketId, T.TicketPrice, T.TicketDate, T.TicketStatus, T.SeatNo,
                           C.CustName, M.MovieTitle
                    FROM Ticket T
                    INNER JOIN C_M_TH_H_S_T J ON T.TicketId = J.TicketId
                    INNER JOIN Customer C ON J.CustId = C.CustId
                    INNER JOIN Movie M ON J.MovieId = M.MovieId
                    WHERE 1=1
                ";

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;

                // Filter by Customer
                if (ddlCustomer.SelectedValue != "0")
                {
                    sql += " AND C.CustId = :custId";
                    cmd.Parameters.Add("custId", OracleDbType.Int32).Value = int.Parse(ddlCustomer.SelectedValue);
                }

                // Filter by Movie
                if (ddlMovie.SelectedValue != "0")
                {
                    sql += " AND M.MovieId = :movieId";
                    cmd.Parameters.Add("movieId", OracleDbType.Int32).Value = int.Parse(ddlMovie.SelectedValue);
                }

                sql += " ORDER BY T.TicketDate DESC";
                cmd.CommandText = sql;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvTickets.DataSource = dt;
                gvTickets.DataBind();
            }
        }

        // Event handler for dropdown change
        protected void ddlFilter_Changed(object sender, EventArgs e)
        {
            LoadTickets();
        }
    }
}