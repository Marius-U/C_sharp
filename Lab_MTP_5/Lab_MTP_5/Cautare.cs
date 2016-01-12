using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_MTP_5
{
    public partial class Cautare : Form
    {
        public Cautare(DataTable dt)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt; 
            dataGridView1.ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cautare_Load(object sender, EventArgs e)
        {

        }
    }
}
