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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadPaymentMethods(); // Load payment methods in ComboBox
        }
        
        // ✅ Function to Load Payment Methods into ComboBox
        private void LoadPaymentMethods()
        {
            comboBox3.Items.AddRange(new string[] { "Mastercard", "bKash", "Nagad", "Upay", "Credit Card" });
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList; // Prevents user input
            comboBox3.SelectedIndex = 0; // Set default selection
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string startStation = comboBox1.Text;
            string endStation = comboBox2.Text;
            string ticketType = radioButton1.Checked ? "Regular" :
                       radioButton3.Checked ? "MRT" :
                       radioButton2.Checked ? "Rapid" : "Unknown";
            string paymentMethod = comboBox3.Text;
            DateTime travelDate = dateTimePicker1.Value;
            string passengerId = textBox2.Text;

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();

                    string sql = "INSERT INTO TICKETS (TICKET_ID, PASSENGER_ID, START_STATION, END_STATION, TICKET_TYPE, PAYMENT_METHOD, TRAVEL_DATE) " +
                                 "VALUES (tickets_id_seq.NEXTVAL, :passengerId, :startStation, :endStation, :ticketType, :paymentMethod, :travelDate)";

                    using (OracleCommand cmd = new OracleCommand(sql, con))
                    {
                        cmd.Parameters.Add("passengerId", OracleDbType.Int32).Value = Convert.ToInt32(passengerId);
                        cmd.Parameters.Add("startStation", OracleDbType.Varchar2).Value = startStation;
                        cmd.Parameters.Add("endStation", OracleDbType.Varchar2).Value = endStation;
                        cmd.Parameters.Add("ticketType", OracleDbType.Varchar2).Value = ticketType;
                        cmd.Parameters.Add("paymentMethod", OracleDbType.Varchar2).Value = paymentMethod;
                        cmd.Parameters.Add("travelDate", OracleDbType.Date).Value = travelDate;

                        int rowsInserted = cmd.ExecuteNonQuery();
                        if (rowsInserted > 0)
                        {
                            MessageBox.Show("🎟️ Ticket Booked Successfully!");
                        }
                        else
                        {
                            MessageBox.Show("❌ Booking Failed. Try Again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ An Error Occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(); // Navigate to another form
            form4.Show();
            this.Close(); // Close current form
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Homepage form9 = new Homepage(); // Navigate to another form
            form9.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }
    }
}


