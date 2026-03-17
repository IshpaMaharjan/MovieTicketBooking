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

        protected void Insert_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                string query = @"INSERT INTO ""SHOW"" (ShowId, ShowDate, ShowTime)
                                 VALUES (:id, TO_DATE(:showDate,'YYYY-MM-DD'), :showTime)";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("id", txtShowId.Text);
                cmd.Parameters.Add("showDate", txtShowDate.Text);
                cmd.Parameters.Add("showTime", txtShowTime.Text);
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
                string query = @"UPDATE ""SHOW"" SET ShowDate = TO_DATE(:showDate,'YYYY-MM-DD'),
                                 ShowTime = :showTime WHERE ShowId = :id";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("showDate", txtShowDate.Text);
                cmd.Parameters.Add("showTime", txtShowTime.Text);
                cmd.Parameters.Add("id", txtShowId.Text);
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
                    OracleCommand cmd1 = new OracleCommand("DELETE FROM C_M_Th_H_S_T WHERE ShowId=:id", conn);
                    cmd1.Parameters.Add("id", txtShowId.Text);
                    cmd1.ExecuteNonQuery();

                    OracleCommand cmd2 = new OracleCommand("DELETE FROM C_M_Th_H_S WHERE ShowId=:id", conn);
                    cmd2.Parameters.Add("id", txtShowId.Text);
                    cmd2.ExecuteNonQuery();

                    OracleCommand cmd3 = new OracleCommand("DELETE FROM Show WHERE ShowId=:id", conn);
                    cmd3.Parameters.Add("id", txtShowId.Text);
                    cmd3.ExecuteNonQuery();

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
            txtShowId.Text = "";
            txtShowDate.Text = "";
            txtShowTime.Text = "";
        }
    }
}