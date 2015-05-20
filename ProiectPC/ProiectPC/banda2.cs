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
    class banda2
    {
        private PictureBox b2;
        private Form1 activity;

        public banda2(PictureBox banda21,Form1 activity)
        {
            // TODO: Complete member initialization
            this.b2 = banda21;
            this.activity = activity;
        }
        public void Thread5()
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

                //  MessageBox.Show("Thread1 running.");
                if (data != null)
                {
                    if (data[0].Equals("B2"))
                    {
                        
                        if (data[1].Equals("P"))
                        {
                            if(b2.Tag.ToString() == "banda_poz_2")
                            {
                                activity.setExecuted();
                                b2.Image = Properties.Resources.banda_poz_2; //poz 0
                                b2.Tag = "banda_poz_2";
                                Thread.Sleep(1000);
                                b2.Image = Properties.Resources.banda_poz_1;
                                b2.Tag = "banda_poz_1";
                                Thread.Sleep(1000);
                                b2.Image = Properties.Resources.banda_poz_0; // poz 2
                                b2.Tag = "banda_poz_0";
                                Thread.Sleep(1000);
                            }
                           
                        }
                        else if (data[1].Equals("CB"))
                        {
                            activity.setExecuted();
                            b2.Image = Properties.Resources.banda_poz_0; // poz 2
                            b2.Tag = "banda_poz_0";
                            Thread.Sleep(1);
                        }
                        else
                        {

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
