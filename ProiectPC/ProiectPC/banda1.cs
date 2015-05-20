using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPC
{
    class banda1
    {
        private PictureBox b1;
        private Form1 activity;

        public banda1(PictureBox banda11, Form1 activity)
        {
            // TODO: Complete member initialization
            this.b1 = banda11;
            this.activity = activity;
        }
        public void Thread2()
        {
            while (true)
            {
                string line = activity.getLine();
                string pattern = @"_|[S]";
                string[] data = null;

                if (line != null)
                {
                    data = Regex.Split(line, pattern);
                }

                if (data != null)
                {
                    if (data[0].Equals("B1"))
                    {
                        
                        if (data[1].Equals("M"))
                        {
                            if(b1.Tag.ToString() == "banda_poz_0")
                            {
                                activity.setExecuted();
                                Thread.Sleep(1000);
                                b1.Image = Properties.Resources.banda_poz_1;
                                b1.Tag = "banda_poz_1"; 
                                Thread.Sleep(1000);
                                b1.Image = Properties.Resources.banda_poz_2;
                                b1.Tag = "banda_poz_2";
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Thread.Sleep(1);
                            }
                            
                        }
                        else
                        {
                            Thread.Sleep(1);
                        }

                    }
                    else
                    {
                        Thread.Sleep(1);
                    }
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }
    }
}
