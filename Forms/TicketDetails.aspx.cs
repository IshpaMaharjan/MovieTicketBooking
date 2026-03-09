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
            {
                LoadData();
            }
        }

        // Load Ticket Data
        void LoadData()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT * FROM TICKET";

                    OracleDataAdapter da = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error loading data: " + ex.Message);
            }
        }

        // Insert Ticket
        protected void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connStr))
                {
                    conn.Open();

                    string query = @"INSERT INTO TICKET
                                    (TicketId, TicketPrice, TicketDate, TicketStatus, SeatNo)
                                    VALUES
                                    (:id, :price, TO_DATE(:tdate,'YYYY-MM-DD'), :status, :seat)";

                    OracleCommand cmd = new OracleCommand(query, conn);

                    cmd.BindByName = true;

                    cmd.Parameters.Add("id", OracleDbType.Int32).Value = txtTicketId.Text;
                    cmd.Parameters.Add("price", OracleDbType.Decimal).Value = txtPrice.Text;
                    cmd.Parameters.Add("tdate", OracleDbType.Varchar2).Value = txtDate.Text;
                    cmd.Parameters.Add("status", OracleDbType.Varchar2).Value = txtStatus.Text;
                    cmd.Parameters.Add("seat", OracleDbType.Varchar2).Value = txtSeatNo.Text;

                    cmd.ExecuteNonQuery();
                }

                ClearFields();
                LoadData();
            }
            catch (Exception ex)
            {
                Response.Write("Insert Error: " + ex.Message);
            }
        }

        // Update Ticket
        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connStr))
                {
                    conn.Open();

                    string query = @"UPDATE TICKET
                                     SET TicketPrice = :price,
                                         TicketDate = TO_DATE(:tdate,'YYYY-MM-DD'),
                                         TicketStatus = :status,
                                         SeatNo = :seat
                                     WHERE TicketId = :id";

                    OracleCommand cmd = new OracleCommand(query, conn);

                    cmd.BindByName = true;

                    cmd.Parameters.Add("price", OracleDbType.Decimal).Value = txtPrice.Text;
                    cmd.Parameters.Add("tdate", OracleDbType.Varchar2).Value = txtDate.Text;
                    cmd.Parameters.Add("status", OracleDbType.Varchar2).Value = txtStatus.Text;
                    cmd.Parameters.Add("seat", OracleDbType.Varchar2).Value = txtSeatNo.Text;
                    cmd.Parameters.Add("id", OracleDbType.Int32).Value = txtTicketId.Text;

                    cmd.ExecuteNonQuery();
                }

                ClearFields();
                LoadData();
            }
            catch (Exception ex)
            {
                Response.Write("Update Error: " + ex.Message);
            }
        }

        // Delete Ticket
        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connStr))
                {
                    conn.Open();

                    string query = "DELETE FROM TICKET WHERE TicketId = :id";

                    OracleCommand cmd = new OracleCommand(query, conn);

                    cmd.BindByName = true;

                    cmd.Parameters.Add("id", OracleDbType.Int32).Value = txtTicketId.Text;

                    cmd.ExecuteNonQuery();
                }

                ClearFields();
                LoadData();
            }
            catch (Exception ex)
            {
                Response.Write("Delete Error: " + ex.Message);
            }
        }

        // Clear Textboxes
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
