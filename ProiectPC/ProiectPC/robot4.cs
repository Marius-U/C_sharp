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
    class robot4
    {
        private PictureBox r4;
        private PictureBox container;
        private PictureBox depozit;
        private Form1 activity;
        private int depozitCount = 0;

        public robot4(PictureBox robot41, PictureBox container,PictureBox depozit, Form1 activity)
        {
            // TODO: Complete member initialization
            this.r4 = robot41;
            this.container = container;
            this.depozit = depozit;
            this.activity = activity;
        }
        public void Thread6()
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
                    if (data[0].Equals("R4"))
                    {
                        activity.setExecuted();
                        if (data[1].Equals("DC"))
                        {
                            if(depozitCount < 3)
                            {
                                container.Image = Properties.Resources.blank;
                                depozitCount++;
                                Thread.Sleep(15000-depozitCount);
                                switch(depozitCount)
                                {
                                    case 1:
                                        {
                                            depozit.Image = Properties.Resources.depozit_1_piesa;
                                        }
                                        break;
                                    case 2:
                                        {
                                            depozit.Image = Properties.Resources.depozit_2_piese;
                                        }
                                        break;
                                    case 3:
                                        {
                                            depozit.Image = Properties.Resources.depozit_3_piese;
                                        }
                                        break;
                                    case 4:
                                        {
                                            depozit.Image = Properties.Resources.depozit_4_piese;
                                        }
                                        break;
                                }
                                Thread.Sleep(1);
                                
                                
                            }
                            

                        }
                        else if (data[1].Equals("CG"))
                        {
                            container.Image = Properties.Resources.tampon_gol;
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
