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
    class robot1
    {
        private PictureBox r1;
        private PictureBox b1;
        private PictureBox b2;
        private PictureBox container;
        private Form1 activity;
        
        public robot1(PictureBox robot11,PictureBox b1,PictureBox b2,PictureBox container, Form1 activity)
        {
            // TODO: Complete member initialization
            r1 = robot11;
            this.b1 = b1;
            this.b2 = b2;
            this.container = container;
            this.activity = activity;
        }

        public void Thread1()
        {
            while (true)
            {
                string line = activity.getLine();
                string pattern = @"_|[S]";
                string[] data = null;

                if(line != null)
                {
                    data = Regex.Split(line, pattern);
                }
               
                //  MessageBox.Show("Thread1 running.");
                if(data != null)
                {
                    if (data[0].Equals("R1"))
                    {
                        
                        if (data[1].Equals("B1"))
                        {
                            if(b1.Tag.ToString() == "banda_goala")
                            {
                                activity.setExecuted();
                                r1.Image = Properties.Resources.robot_1_1;
                                r1.Tag = "robot_1_1";
                                Thread.Sleep(1000);
                                r1.Image = Properties.Resources.robot_2_1;
                                r1.Tag = "robot_2_1";
                                Thread.Sleep(1000);
                                r1.Image = Properties.Resources.robot_3_1;
                                r1.Tag = "robot_3_1";
                                Thread.Sleep(1000);
                                r1.Image = Properties.Resources.robot_4_1;
                                r1.Tag = "robot_4_1";
                                Thread.Sleep(1000);
                                r1.Image = Properties.Resources.robot_5_1;
                                r1.Tag = "robot_5_1";
                                Thread.Sleep(1000);
                                r1.Image = Properties.Resources.robot_5_0;
                                r1.Tag = "robot_5_0";
                                b1.Image = Properties.Resources.banda_poz_0;
                                b1.Tag = "banda_poz_0";
                                Thread.Sleep(1);
                            }
                            else
                            {
                                Thread.Sleep(1);
                            }
                            
                        }
                        else if (data[1].Equals("B2"))
                        {
                            if(b2.Tag == "banda_poz_0")
                            {
                                activity.setExecuted();
                                b2.Image = Properties.Resources.banda_goala;
                                b2.Tag = "banda_goala";
                                Thread.Sleep(100);
                                container.Image = Properties.Resources.tampon_ocupat;
                                container.Tag = "tampon_ocupat";
                                Thread.Sleep(1);
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
                    Thread.Sleep(10);
                }
                
            }
        }
    }
}
