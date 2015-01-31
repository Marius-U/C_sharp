using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearch
{
    public partial class Form1 : Form
    {
        private MainActivity activity = new MainActivity();
        public Form1()
        {
            InitializeComponent();
        }
        public void setActivity(Form1 activity)
        {
            this.activity.setActivity(activity);
        }

        private void browse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
                activity.setPath(textBox1.Text);
                activity.setWord(textBox2.Text);
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
           
            if(null == activity.getPath())
            {
                activity.setPath(textBox1.Text);
                activity.setWord(textBox2.Text);
            }
            activity.search();
        }

        public void addListItem(ListViewItem item)
        {
            listView1.Items.Add(item);
        }

        public void setVisibleProgBar(bool value)
        {
            progressBar1.Visible = value;
        }
        public void incrementProgBar(int value)
        {
            progressBar1.Value = value;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

    }
}
