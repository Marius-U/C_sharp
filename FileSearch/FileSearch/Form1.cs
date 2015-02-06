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
                if(!textBox1.Text.Equals(""))
                {
                    activity.setPath(textBox1.Text);
                    if (!textBox2.Text.Equals(""))
                    {
                        activity.setWord(textBox2.Text);
                        activity.search();
                    }
                    else
                    {
                        MessageBox.Show("No expresion/word was set.\nPlease give a expresion/word first!", "Info");
                    }
                }
                else
                {
                    MessageBox.Show("No path was set.\nPlease set path first!", "Info");
                }

                
            }
            else
            {
                activity.setPath("");
                activity.setWord("");
                if (!textBox1.Text.Equals(""))
                {
                    activity.setPath(textBox1.Text);
                    if (!textBox2.Text.Equals(""))
                    {
                        activity.setWord(textBox2.Text);
                        activity.search();
                    }
                    else
                    {
                        MessageBox.Show("No expresion/word was set.\nPlease give a expresion/word first!", "Info");
                    }
                }
                else
                {
                    MessageBox.Show("No path was set.\nPlease set path first!", "Info");
                }
            }
            
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ListView.SelectedListViewItemCollection album = this.listView1.SelectedItems;
            if (album.Count > 0)
            {
                string[] file = album[0].Text.Split(' ');
                System.Diagnostics.Process.Start(file[0]);
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
