using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace coursework
{
    public partial class HallDetails : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        void LoadData()
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = "SELECT * FROM Hall";

                OracleDataAdapter da = new OracleDataAdapter(query, conn);
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

                cmd.Parameters.Add(":id", txtHallId.Text);
                cmd.Parameters.Add(":name", txtHallName.Text);
                cmd.Parameters.Add(":cap", txtCapacity.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = "UPDATE Hall SET HallName=:name, HallCapacity=:cap WHERE HallId=:id";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add(":name", txtHallName.Text);
                cmd.Parameters.Add(":cap", txtCapacity.Text);
                cmd.Parameters.Add(":id", txtHallId.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = "DELETE FROM Hall WHERE HallId=:id";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add(":id", txtHallId.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData();
        }
    }
}