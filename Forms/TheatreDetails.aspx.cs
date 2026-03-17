using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace coursework
{
    public partial class TheatreDetails : System.Web.UI.Page
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
                OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM Theatre", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Theatre VALUES(:id,:name,:city)";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("id", txtTheatreID.Text);
                cmd.Parameters.Add("name", txtTheatreName.Text);
                cmd.Parameters.Add("city", txtTheatreCity.Text);

                cmd.ExecuteNonQuery();
            }

            ClearFields();
            LoadData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Theatre SET TheatreName=:name, TheatreCity=:city WHERE TheatreId=:id";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("name", txtTheatreName.Text);
                cmd.Parameters.Add("city", txtTheatreCity.Text);
                cmd.Parameters.Add("id", txtTheatreID.Text);

                cmd.ExecuteNonQuery();
            }

            ClearFields();
            LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                OracleTransaction trans = conn.BeginTransaction();

                try
                {
                    OracleCommand cmd1 = new OracleCommand("DELETE FROM C_M_Th_H_S_T WHERE TheatreId=:id", conn);
                    cmd1.Parameters.Add("id", txtTheatreID.Text);
                    cmd1.ExecuteNonQuery();

                    OracleCommand cmd2 = new OracleCommand("DELETE FROM C_M_Th_H_S WHERE TheatreId=:id", conn);
                    cmd2.Parameters.Add("id", txtTheatreID.Text);
                    cmd2.ExecuteNonQuery();

                    OracleCommand cmd3 = new OracleCommand("DELETE FROM Cust_Mov_Thea_Hall WHERE TheatreId=:id", conn);
                    cmd3.Parameters.Add("id", txtTheatreID.Text);
                    cmd3.ExecuteNonQuery();

                    OracleCommand cmd4 = new OracleCommand("DELETE FROM Cust_Mov_Theatre WHERE TheatreId=:id", conn);
                    cmd4.Parameters.Add("id", txtTheatreID.Text);
                    cmd4.ExecuteNonQuery();

                    OracleCommand cmd5 = new OracleCommand("DELETE FROM Theatre WHERE TheatreId=:id", conn);
                    cmd5.Parameters.Add("id", txtTheatreID.Text);
                    cmd5.ExecuteNonQuery();

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
            txtTheatreID.Text = "";
            txtTheatreName.Text = "";
            txtTheatreCity.Text = "";
        }
    }
}