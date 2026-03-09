using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace coursework
{
    public partial class ShowDetails : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        // Load Data
        void LoadData()
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM \"SHOW\"", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        // Insert
        protected void Insert_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO ""SHOW"" 
                                (ShowId, ShowDate, ShowTime) 
                                VALUES 
                                (:id, TO_DATE(:showDate,'YYYY-MM-DD'), :showTime)";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.BindByName = true;

                cmd.Parameters.Add("id", OracleDbType.Int32).Value = txtShowId.Text;
                cmd.Parameters.Add("showDate", OracleDbType.Varchar2).Value = txtShowDate.Text;
                cmd.Parameters.Add("showTime", OracleDbType.Varchar2).Value = txtShowTime.Text;

                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearFields();
        }

        // Update
        protected void Update_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = @"UPDATE ""SHOW""
                                SET ShowDate = TO_DATE(:showDate,'YYYY-MM-DD'),
                                    ShowTime = :showTime
                                WHERE ShowId = :id";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.BindByName = true;

                cmd.Parameters.Add("showDate", OracleDbType.Varchar2).Value = txtShowDate.Text;
                cmd.Parameters.Add("showTime", OracleDbType.Varchar2).Value = txtShowTime.Text;
                cmd.Parameters.Add("id", OracleDbType.Int32).Value = txtShowId.Text;

                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearFields();
        }

        // Delete
        protected void Delete_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = @"DELETE FROM ""SHOW"" WHERE ShowId = :id";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.BindByName = true;

                cmd.Parameters.Add("id", OracleDbType.Int32).Value = txtShowId.Text;

                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearFields();
        }

        // Clear Textboxes
        void ClearFields()
        {
            txtShowId.Text = "";
            txtShowDate.Text = "";
            txtShowTime.Text = "";
        }
    }
}
