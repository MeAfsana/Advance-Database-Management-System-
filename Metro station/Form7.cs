using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace Metro_station
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        public static class UserSession
        {
            public static string Role { get; set; }
            public static string UserId { get; set; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Homepage form9 = new Homepage(); // Navigate to another form
            form9.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string userIdInput = textBoxUserId.Text;  // Renamed to avoid conflict
            string password = txtPassword.Text;

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string sql = "SELECT ROLE, USER_ID FROM MEMBERS WHERE NAME = :name AND USER_ID = :userId AND PASSWORD = :password";

                    using (OracleCommand cmd = new OracleCommand(sql, con))
                    {
                        cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = name;
                        cmd.Parameters.Add("userId", OracleDbType.Varchar2).Value = userIdInput;  // FIXED: Correct column name
                        cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;

                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string role = reader["ROLE"].ToString();  // FIXED: Use correct column name
                            string userId = reader["USER_ID"].ToString();  // FIXED: Use correct column name

                            UserSession.Role = role;
                            UserSession.UserId = userId;

                            if (role == "Admin")
                            {
                                Form5 dp = new Form5();
                                dp.Show();
                                Visible = false;
                            }
                            else if (role == "Passenger")
                            {
                                Form3 dp = new Form3();
                                dp.Show();
                                Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Invalid Input");
                            }
                        }
                        else
                        {
                            MessageBox.Show("User not found or incorrect credentials.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
