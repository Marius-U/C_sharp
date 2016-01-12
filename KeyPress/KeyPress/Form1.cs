using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyPress
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Visible = false;
            string key1 = textKey1.Text;
            string key2 = textKey2.Text;
            string key3 = textKey3.Text;

            if(!key1.Equals(""))
            {
                PressKey1 pressKey1 = new PressKey1();
                Thread oThread = new Thread(new ThreadStart(pressKey1.Press));

                oThread.Start();

                // Spin for a while waiting for the started thread to become
                // alive:
                while (!oThread.IsAlive) ;

                // Put the Main thread to sleep for 1 millisecond to allow oThread
                // to do some work:
                Thread.Sleep(1);
            }
        }
    }
}
