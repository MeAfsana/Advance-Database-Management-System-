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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Homepage form9 = new Homepage(); // Navigate to another form
            form9.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(); // Navigate to another form
            form6.Show();
            this.Close();
        }
    }
}
