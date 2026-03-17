using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace coursework
{
    public partial class HallDetails : System.Web.UI.Page
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
                OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM Hall", conn);
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
                string query = "INSERT INTO Hall VALUES(:id,:name,:cap)";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("id", txtHallId.Text);
                cmd.Parameters.Add("name", txtHallName.Text);
                cmd.Parameters.Add("cap", txtCapacity.Text);

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
                string query = "UPDATE Hall SET HallName=:name, HallCapacity=:cap WHERE HallId=:id";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("name", txtHallName.Text);
                cmd.Parameters.Add("cap", txtCapacity.Text);
                cmd.Parameters.Add("id", txtHallId.Text);

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
                    // Delete from related tables first (example)
                    OracleCommand cmd1 = new OracleCommand("DELETE FROM C_M_Th_H_S_T WHERE HallId=:id", conn);
                    cmd1.Parameters.Add("id", txtHallId.Text);
                    cmd1.ExecuteNonQuery();

                    OracleCommand cmd2 = new OracleCommand("DELETE FROM C_M_Th_H_S WHERE HallId=:id", conn);
                    cmd2.Parameters.Add("id", txtHallId.Text);
                    cmd2.ExecuteNonQuery();

                    OracleCommand cmd3 = new OracleCommand("DELETE FROM Cust_Mov_Thea_Hall WHERE HallId=:id", conn);
                    cmd3.Parameters.Add("id", txtHallId.Text);
                    cmd3.ExecuteNonQuery();

                    OracleCommand cmd4 = new OracleCommand("DELETE FROM Hall WHERE HallId=:id", conn);
                    cmd4.Parameters.Add("id", txtHallId.Text);
                    cmd4.ExecuteNonQuery();

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
            txtHallId.Text = "";
            txtHallName.Text = "";
            txtCapacity.Text = "";
        }
    }
}