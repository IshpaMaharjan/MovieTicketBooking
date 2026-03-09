using System;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace coursework
{
    public partial class TheatreDetails : System.Web.UI.Page
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

                string query = "SELECT * FROM Theatre";

                OracleDataAdapter da = new OracleDataAdapter(query, conn);
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

                LoadData();
            }
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

                LoadData();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = "DELETE FROM Theatre WHERE TheatreID=:id";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add("id", txtTheatreID.Text);

                cmd.ExecuteNonQuery();

                LoadData();
            }
        }
    }
}