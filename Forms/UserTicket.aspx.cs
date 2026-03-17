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

        private void LoadFilters()
        {
            using (OracleConnection con = new OracleConnection(connStr))
            {
                con.Open();

                // Customer
                OracleCommand cmdCust = new OracleCommand("SELECT CustId, CustName FROM Customer ORDER BY CustName", con);
                OracleDataReader drCust = cmdCust.ExecuteReader();

                ddlCustomer.Items.Clear();
                ddlCustomer.Items.Add(new ListItem("All Customers", "0"));

                while (drCust.Read())
                {
                    ddlCustomer.Items.Add(new ListItem(drCust["CustName"].ToString(), drCust["CustId"].ToString()));
                }
                drCust.Close();


                // Movie
                OracleCommand cmdMovie = new OracleCommand("SELECT MovieId, MovieTitle FROM Movie ORDER BY MovieTitle", con);
                OracleDataReader drMovie = cmdMovie.ExecuteReader();

                ddlMovie.Items.Clear();
                ddlMovie.Items.Add(new ListItem("All Movies", "0"));

                while (drMovie.Read())
                {
                    ddlMovie.Items.Add(new ListItem(drMovie["MovieTitle"].ToString(), drMovie["MovieId"].ToString()));
                }
                drMovie.Close();


                // Email
                OracleCommand cmdEmail = new OracleCommand("SELECT DISTINCT Email FROM Customer ORDER BY Email", con);
                OracleDataReader drEmail = cmdEmail.ExecuteReader();

                ddlEmail.Items.Clear();
                ddlEmail.Items.Add(new ListItem("All Emails", "0"));

                while (drEmail.Read())
                {
                    ddlEmail.Items.Add(new ListItem(drEmail["Email"].ToString(), drEmail["Email"].ToString()));
                }
                drEmail.Close();
            }
        }

        private void LoadTickets()
        {
            using (OracleConnection con = new OracleConnection(connStr))
            {
                con.Open();

                string sql = @"
                SELECT T.TicketId, T.TicketPrice, T.TicketDate, T.TicketStatus, T.SeatNo,
                       C.CustName, C.Email, M.MovieTitle
                FROM Ticket T
                INNER JOIN C_M_TH_H_S_T J ON T.TicketId = J.TicketId
                INNER JOIN Customer C ON J.CustId = C.CustId
                INNER JOIN Movie M ON J.MovieId = M.MovieId
                WHERE 1=1";

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;

                if (ddlCustomer.SelectedValue != "0")
                {
                    sql += " AND C.CustId = :custId";
                    cmd.Parameters.Add("custId", OracleDbType.Int32).Value = int.Parse(ddlCustomer.SelectedValue);
                }

                if (ddlMovie.SelectedValue != "0")
                {
                    sql += " AND M.MovieId = :movieId";
                    cmd.Parameters.Add("movieId", OracleDbType.Int32).Value = int.Parse(ddlMovie.SelectedValue);
                }

                if (ddlEmail.SelectedValue != "0")
                {
                    sql += " AND C.Email = :email";
                    cmd.Parameters.Add("email", OracleDbType.Varchar2).Value = ddlEmail.SelectedValue;
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

        protected void ddlFilter_Changed(object sender, EventArgs e)
        {
            LoadTickets();
        }
    }
}