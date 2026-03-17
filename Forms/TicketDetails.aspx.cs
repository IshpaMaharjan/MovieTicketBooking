using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace coursework
{
    public partial class TicketDetails : System.Web.UI.Page
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
                OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM TICKET", conn);
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
                string query = @"INSERT INTO TICKET (TicketId, TicketPrice, TicketDate, TicketStatus, SeatNo)
                                 VALUES (:id, :price, TO_DATE(:tdate,'YYYY-MM-DD'), :status, :seat)";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("id", txtTicketId.Text);
                cmd.Parameters.Add("price", txtPrice.Text);
                cmd.Parameters.Add("tdate", txtDate.Text);
                cmd.Parameters.Add("status", txtStatus.Text);
                cmd.Parameters.Add("seat", txtSeatNo.Text);

                cmd.ExecuteNonQuery();
            }

            ClearFields();
            LoadData();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                string query = @"UPDATE TICKET SET TicketPrice = :price,
                                 TicketDate = TO_DATE(:tdate,'YYYY-MM-DD'),
                                 TicketStatus = :status,
                                 SeatNo = :seat WHERE TicketId = :id";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("price", txtPrice.Text);
                cmd.Parameters.Add("tdate", txtDate.Text);
                cmd.Parameters.Add("status", txtStatus.Text);
                cmd.Parameters.Add("seat", txtSeatNo.Text);
                cmd.Parameters.Add("id", txtTicketId.Text);

                cmd.ExecuteNonQuery();
            }

            ClearFields();
            LoadData();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                OracleTransaction trans = conn.BeginTransaction();

                try
                {
                    OracleCommand cmd1 = new OracleCommand("DELETE FROM C_M_Th_H_S_T WHERE TicketId=:id", conn);
                    cmd1.Parameters.Add("id", txtTicketId.Text);
                    cmd1.ExecuteNonQuery();

                    OracleCommand cmd2 = new OracleCommand("DELETE FROM Ticket WHERE TicketId=:id", conn);
                    cmd2.Parameters.Add("id", txtTicketId.Text);
                    cmd2.ExecuteNonQuery();

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

        void ClearFields()
        {
            txtTicketId.Text = "";
            txtPrice.Text = "";
            txtDate.Text = "";
            txtStatus.Text = "";
            txtSeatNo.Text = "";
        }
    }
}