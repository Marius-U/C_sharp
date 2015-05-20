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
    class robot2
    {
        private PictureBox r2;
        private PictureBox b1;
        private PictureBox m1;
        private PictureBox t;
        private Form1 activity;

        public robot2(PictureBox robot21,PictureBox b1,PictureBox m1,PictureBox t,Form1 activity)
        {
            // TODO: Complete member initialization
            this.r2 = robot21;
            this.b1 = b1;
            this.m1 = m1;
            this.t = t;
            this.activity = activity;
        }
        public void Thread3()
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
                    if (data[0].Equals("R2"))
                    {
                        activity.setExecuted();
                        if (data[1].Equals("B1"))
                        {
                            r2.Image = Properties.Resources.robot_1_1;
                            Thread.Sleep(1000);
                            r2.Image = Properties.Resources.robot_2_1;
                            Thread.Sleep(1000);
                            r2.Image = Properties.Resources.robot_3_1;
                            Thread.Sleep(1000);
                            r2.Image = Properties.Resources.robot_4_1;
                            Thread.Sleep(1000);
                            r2.Image = Properties.Resources.robot_5_1;
                            Thread.Sleep(1000);
                            r2.Image = Properties.Resources.robot_5_0;
                            b1.Image = Properties.Resources.banda_poz_0;
                            Thread.Sleep(1);
                        }
                        else if (data[1].Equals("M1"))
                        {
                            Thread.Sleep(1000);
                            m1.Image = Properties.Resources.masina_1_incarcat;
                            Thread.Sleep(1);
                        }
                        else
                        {

                        }

                    }
                    else if (data[0].Equals("M1"))
                    {
                        if(data[1].Equals("PT"))
                        {
                            m1.Image = Properties.Resources.masina_1_libera;
                            t.Image = Properties.Resources.tampon_ocupat;
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
