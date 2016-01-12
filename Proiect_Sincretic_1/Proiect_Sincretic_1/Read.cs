using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace Proiect_Sincretic_1
{
    class Read
    {
        private SerialPort _serialPort = null;
        private bool _continue = true;
        private Form1 context = null;

        public Read(SerialPort _serialPort, Form1 context)
        {
            this._serialPort = _serialPort;
            this.context = context;
        }

        public void Run()
        { 
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    string[] temp = message.Split(' ');
                    try
                    {
                        context.setTemp(temp[0]);
                        context.setPrescTemp(temp[1]);
                        context.setLedStatus(temp[2]);
                        context.setDisplayNumber(temp[3]);
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    
                }
                catch (TimeoutException) { }
            }
        }
        public void stop()
        {
            _continue = false;
        }
    }
}
