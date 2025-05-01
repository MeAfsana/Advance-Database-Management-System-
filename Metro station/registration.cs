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
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string address = textBoxAddress.Text;
            string phoneNumber = textBoxPhoneNumber.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string age = textBoxAge.Text;
            string nidNo = textBoxNidNo.Text;
            string gender = comboBox1.SelectedIndex == 0 ? "Male" : "Female";
            string role = radioButton1.Checked ? "Passenger" : "Admin";

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings
                    ["con"].ConnectionString)) 
                {
                    con.Open();

                    string sql = "INSERT INTO MEMBERS (NAME, ADDRESS, PHONE_NUMBER, EMAIL, PASSWORD, AGE, NID_NO, GENDER , ROLE) " +
                                  "VALUES (:name, :address, :phoneNumber, :email, :password, :age, :nidNo, :gender , :role)";

                    using (OracleCommand cmd = new OracleCommand(sql, con))
                    {
                        cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = name;
                        cmd.Parameters.Add("address", OracleDbType.Varchar2).Value = address;
                        cmd.Parameters.Add("phoneNumber", OracleDbType.Varchar2).Value = phoneNumber;
                        cmd.Parameters.Add("email", OracleDbType.Varchar2).Value = email;
                        cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;
                        cmd.Parameters.Add("age", OracleDbType.Int32).Value = Convert.ToInt32(age);
                        cmd.Parameters.Add("nidNo", OracleDbType.Varchar2).Value = nidNo;
                        cmd.Parameters.Add("gender", OracleDbType.Varchar2).Value = gender;
                        cmd.Parameters.Add("role", OracleDbType.Varchar2).Value = role;

                        int rowsInserted = cmd.ExecuteNonQuery();
                         if (rowsInserted > 0)
                        {
                            MessageBox.Show("Registration Successfull.");
                        }
                        else
                        {
                            MessageBox.Show("Registration Failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred:" + ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Homepage form9 = new Homepage(); // Navigate to another form
            form9.Show();
            this.Close(); // Close current form
        }
    }
}
