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
    class robot3
    {
        private PictureBox r3;
        private PictureBox t;
        private PictureBox m2;
        private Form1 activity;

        public robot3(PictureBox robot31, PictureBox t, PictureBox m2,Form1 activity)
        {
            // TODO: Complete member initialization
            this.r3 = robot31;
            this.t = t;
            this.m2 = m2;
            this.activity = activity;
        }
        public void Thread4()
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
                    if (data[0].Equals("R3"))
                    {
                        activity.setExecuted();
                        if (data[1].Equals("T"))
                        {
                            t.Image = Properties.Resources.tampon_gol;
                            Thread.Sleep(3000);
                        }
                        else if (data[1].Equals("M2"))
                        {
                            m2.Image = Properties.Resources.masina_2_incarcat;
                            Thread.Sleep(5);
                        }
                        else if (data[1].Equals("R"))
                        {
                            m2.Image = Properties.Resources.masina_2_libera;
                            r3.Image = Properties.Resources.robot_5_1;
                            Thread.Sleep(500);
                            r3.Image = Properties.Resources.robot_4_1;
                            Thread.Sleep(500);
                            r3.Image = Properties.Resources.robot_3_1;
                            Thread.Sleep(500);
                            r3.Image = Properties.Resources.robot_4_1;
                            Thread.Sleep(500);
                            m2.Image = Properties.Resources.masina_2_incarcat;
                            r3.Image = Properties.Resources.robot_3_0;
                            Thread.Sleep(5000);

                        }
                        else if (data[1].Equals("B2"))
                        {
                            m2.Image = Properties.Resources.masina_2_libera;
                            r3.Image = Properties.Resources.robot_5_1;
                            Thread.Sleep(200);
                            r3.Image = Properties.Resources.robot_4_1;
                            Thread.Sleep(200);
                            r3.Image = Properties.Resources.robot_3_1;
                            Thread.Sleep(200);
                            r3.Image = Properties.Resources.robot_2_1;
                            Thread.Sleep(200);
                            r3.Image = Properties.Resources.robot_1_0;
                            Thread.Sleep(200);
                            r3.Image = Properties.Resources.robot_3_0;
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
        }
    }
}
