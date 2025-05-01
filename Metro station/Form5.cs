using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metro_station
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Homepage form9 = new Homepage(); // Navigate to another form
            form9.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Form2 form2 = new Form2(); // Navigate to another form
            form2.Show();
            this.Close();
        }
    }
}
