using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace coursework
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboardStats();
            }
        }
        private void LoadDashboardStats()
        {
            string connStr = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

            using (OracleConnection con = new OracleConnection(connStr))
            {
                con.Open();

                OracleCommand cmd1 = new OracleCommand("SELECT COUNT(*) FROM Customer", con);
                lblCustomers.Text = cmd1.ExecuteScalar().ToString();

                OracleCommand cmd2 = new OracleCommand("SELECT COUNT(*) FROM Movie", con);
                lblMovies.Text = cmd2.ExecuteScalar().ToString();

                OracleCommand cmd3 = new OracleCommand("SELECT COUNT(*) FROM Ticket", con);
                lblTickets.Text = cmd3.ExecuteScalar().ToString();

                OracleCommand cmd4 = new OracleCommand("SELECT COUNT(*) FROM C_M_TH_H_S_T", con);
                lblBookings.Text = cmd4.ExecuteScalar().ToString();
            }
        }
    }
}