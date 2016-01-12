using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace Proiect_Sincretic_1
{
    public partial class Form1 : Form
    {
        static Form1 context = null;
        private static SerialPort serialPort = new SerialPort();
        string[] portNames = SerialPort.GetPortNames();
        Read readObject = null;
        Thread workerThread = null;
        private bool _continue = true;


        public Form1()
        {   
            InitializeComponent();
            if(portNames.Count() > 0)
            {
                foreach(string s in portNames)
                {
                    comboBox1.Items.Add(s);
                }
                comboBox1.Text = portNames[0];
            }
            
        }
        public  void setContext(Form1 ctx)
        {
            if (context == null)
            {
                context = ctx;
                
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.Equals(comboBox1.Text,""))
            {
                if(!String.Equals(textBox1.Text, ""))
                {
                    serialPort.BaudRate = Convert.ToInt32(textBox1.Text);
                }
                else
                {
                    MessageBox.Show("Error!", "No baud rate was found!");
                    exit();
                }
                if (!String.Equals(comboBox4.Text, ""))
                {
                    serialPort.DataBits = Convert.ToInt16(comboBox4.Text);
                }
                else
                {
                    MessageBox.Show("Error!", "No data bits setting was found!");
                    exit();
                }
                if (!String.Equals(comboBox3.Text, ""))
                {
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), comboBox3.Text, true);
                }
                else
                {
                    MessageBox.Show("Error!", "No parity setting was found!");
                    exit();
                }
                
                serialPort.PortName = comboBox1.Text;

                if (!String.Equals(comboBox2.Text, ""))
                {
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBox2.Text, true);
                }
                else
                {
                    MessageBox.Show("Error!", "No stop bits setting was found!");
                    exit();
                }

                try
                {
                    
                    serialPort.Open();
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    dataGroupBox.Enabled = true;
                    serialPort.Write("c");
                    textBox2.Text = "connected";

                    button1.Visible = false;
                    button2.Visible = true;


                    readObject = new Read(serialPort, context);
                    workerThread = new Thread(readObject.Run);

                    // Start the worker thread.
                    workerThread.Start();

                    // Loop until worker thread activates. 
                    while (!workerThread.IsAlive) ;

                    // Put the main thread to sleep for 1 millisecond to 
                    // allow the worker thread to do some work:
                    Thread.Sleep(1);
                }
            }
            else
            {
                MessageBox.Show("Error!", "No com was found!");
                exit();
            }
        }

        public void exit()
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {               
                readObject.stop();
                workerThread.Join();
                serialPort.Close();
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dataGroupBox.Enabled = false;
                textBox2.Text = "disconnected";
                button2.Visible = false;
                button1.Visible = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if(serialPort.IsOpen)
            {
                if (textBox6.TextLength > 0 && textBox6.TextLength < 2)
                {
                    serialPort.Write(textBox6.Text);
                }
                if(textBox6.TextLength == 2)
                {
                    char temp =   textBox6.Text[1];
                    textBox6.Text = temp.ToString();
                    textBox6.SelectionStart = textBox6.TextLength;
                }
            }
            
        }
        public void setTemp(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(setTemp), new object[] { value });
                return;
            }
            textBox3.Text = value;
            textBox3.Show();
        }
        

        public void setPrescTemp(string temp)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(setPrescTemp), new object[] { temp });
                return;
            }
            textBox4.Text = temp;
            textBox4.Show();
        }

        public void setLedStatus(string status)
        {           
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(setLedStatus), new object[] { status });
                return;
            }
            textBox5.Text = status;
            textBox5.Show();
        }
        public void setDisplayNumber(string nr)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(setDisplayNumber), new object[] { nr });
                return;
            }
            textBox7.Text = nr;
            textBox7.Show();
        }
    }
}
