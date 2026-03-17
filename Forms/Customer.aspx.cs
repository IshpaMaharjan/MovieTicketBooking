using System;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace coursework
{
    public partial class Customer : System.Web.UI.Page
    {
        // Oracle Connection String
        string connStr = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        // Load Customer Data into GridView
        void LoadData()
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = "SELECT * FROM Customer";

                OracleDataAdapter da = new OracleDataAdapter(query, conn);
                DataTable dt = new DataTable();

                da.Fill(dt);

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }

        // INSERT Customer
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = "INSERT INTO Customer (CustId, CustName, Address, Phone, Email) VALUES (:id,:name,:custadd,:ph,:em)";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add("id", txtID.Text);
                cmd.Parameters.Add("name", txtName.Text);
                cmd.Parameters.Add("custadd", txtAddress.Text);
                cmd.Parameters.Add("ph", txtPhone.Text);
                cmd.Parameters.Add("em", txtEmail.Text);

                cmd.ExecuteNonQuery();
            }

            ClearFields();
            LoadData();
        }

        // UPDATE Customer
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();

                string query = "UPDATE Customer SET CustName=:name, Address=:custadd, Phone=:ph, Email=:em WHERE CustId=:id";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add("name", txtName.Text);
                cmd.Parameters.Add("custadd", txtAddress.Text);
                cmd.Parameters.Add("ph", txtPhone.Text);
                cmd.Parameters.Add("em", txtEmail.Text);
                cmd.Parameters.Add("id", txtID.Text);

                cmd.ExecuteNonQuery();
            }

            ClearFields();
            LoadData();
        }

        // DELETE Customer
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                OracleTransaction trans = conn.BeginTransaction();

                try
                {
                    OracleCommand cmd1 = new OracleCommand("DELETE FROM C_M_Th_H_S_T WHERE CustId=:id", conn);
                    cmd1.Parameters.Add("id", txtID.Text);
                    cmd1.ExecuteNonQuery();

                    OracleCommand cmd2 = new OracleCommand("DELETE FROM C_M_Th_H_S WHERE CustId=:id", conn);
                    cmd2.Parameters.Add("id", txtID.Text);
                    cmd2.ExecuteNonQuery();

                    OracleCommand cmd3 = new OracleCommand("DELETE FROM Cust_Mov_Thea_Hall WHERE CustId=:id", conn);
                    cmd3.Parameters.Add("id", txtID.Text);
                    cmd3.ExecuteNonQuery();

                    OracleCommand cmd4 = new OracleCommand("DELETE FROM Cust_Mov_Theatre WHERE CustId=:id", conn);
                    cmd4.Parameters.Add("id", txtID.Text);
                    cmd4.ExecuteNonQuery();

                    OracleCommand cmd5 = new OracleCommand("DELETE FROM Cust_Mov WHERE CustId=:id", conn);
                    cmd5.Parameters.Add("id", txtID.Text);
                    cmd5.ExecuteNonQuery();

                    OracleCommand cmd6 = new OracleCommand("DELETE FROM Customer WHERE CustId=:id", conn);
                    cmd6.Parameters.Add("id", txtID.Text);
                    cmd6.ExecuteNonQuery();

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

        // Clear Textboxes
        void ClearFields()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
        }
    }
}