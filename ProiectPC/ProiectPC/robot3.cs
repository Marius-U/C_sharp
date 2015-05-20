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
        private PictureBox b2;
        private int tampon = 0;
        private Form1 activity;

        public robot3(PictureBox robot31, PictureBox t, PictureBox m2,PictureBox b2,Form1 activity)
        {
            // TODO: Complete member initialization
            this.r3 = robot31;
            this.t = t;
            this.m2 = m2;
            this.b2 = b2;
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
                       
                        if (data[1].Equals("T"))
                        {
                            
                            if(t.Tag.ToString() == "tampon_ocupat" && m2.Tag.ToString() == "masina_2_libera")
                            {
                                if(tampon == 0)
                                {
                                    activity.setExecuted();
                                    r3.Image = Properties.Resources.robot_3_1;
                                    r3.Tag = "robot_3_1";
                                    Thread.Sleep(1000);
                                    r3.Image = Properties.Resources.robot_4_1;
                                    r3.Tag = "robot_2_1";
                                    Thread.Sleep(1000);
                                    r3.Image = Properties.Resources.robot_5_1;
                                    r3.Tag = "robot_1_1";
                                    Thread.Sleep(1000);
                                    r3.Image = Properties.Resources.robot_5_0;
                                    r3.Tag = "robot_1_0";
                                    m2.Image = Properties.Resources.masina_2_incarcat;
                                    m2.Tag = "masina_2_incarcat";
                                    tampon++;
                                    Thread.Sleep(5000);
                                }
                                else if( tampon == 1)
                                {
                                    activity.setExecuted();
                                    t.Image = Properties.Resources.tampon_gol;
                                    t.Tag = "tampon_gol";
                                    r3.Image = Properties.Resources.robot_3_1;
                                    r3.Tag = "robot_3_1";
                                    Thread.Sleep(1000);
                                    r3.Image = Properties.Resources.robot_4_1;
                                    r3.Tag = "robot_2_1";
                                    Thread.Sleep(1000);
                                    r3.Image = Properties.Resources.robot_5_1;
                                    r3.Tag = "robot_1_1";
                                    Thread.Sleep(1000);
                                    r3.Image = Properties.Resources.robot_5_0;
                                    r3.Tag = "robot_1_0";
                                    m2.Image = Properties.Resources.masina_2_incarcat;
                                    m2.Tag = "masina_2_incarcat";
                                    tampon++;
                                    Thread.Sleep(5000);
                                }
                                
                            }
                            else
                            {
                                Thread.Sleep(1);
                            }
                           
                        }
                        else if (data[1].Equals("M2"))
                        {
                            activity.setExecuted();
                            Thread.Sleep(1);
                            if(m2.Tag.ToString() == "masina_2_libera")
                            {
                                
                                //m2.Image = Properties.Resources.masina_2_incarcat;
                              //  m2.Tag = "masina_2_incarcat";
                                
                            }
                            else
                            {
                                Thread.Sleep(1);
                            }
                            
                        }
                        else if (data[1].Equals("R"))
                        {
                            activity.setExecuted();
                            m2.Image = Properties.Resources.masina_2_libera;
                            m2.Tag = "masina_2_libera";
                            r3.Image = Properties.Resources.robot_5_1;
                            r3.Tag = "robot_5_1";
                            Thread.Sleep(500);
                            r3.Image = Properties.Resources.robot_4_1;
                            r3.Tag = "robot_4_1";
                            Thread.Sleep(500);
                            r3.Image = Properties.Resources.robot_3_1;
                            r3.Tag = "robot_3_1";
                            Thread.Sleep(500);
                            r3.Image = Properties.Resources.robot_4_1;
                            r3.Tag = "robot_4_1";
                            Thread.Sleep(500);
                            m2.Image = Properties.Resources.masina_2_incarcat;
                            m2.Tag = "masina_2_incarcat";
                            r3.Image = Properties.Resources.robot_3_0;
                            r3.Tag = "robot_3_0";
                            Thread.Sleep(5000);

                        }
                        else if (data[1].Equals("B2"))
                        {
                            if(b2.Tag.ToString() == "banda_goala")
                            {
                                activity.setExecuted();
                                m2.Image = Properties.Resources.masina_2_libera;
                                m2.Tag = "masina_2_libera";
                                r3.Image = Properties.Resources.robot_5_1;
                                r3.Tag = "robot_5_1";
                                Thread.Sleep(200);
                                r3.Image = Properties.Resources.robot_4_1;
                                r3.Tag = "robot_4_1";
                                Thread.Sleep(200);
                                r3.Image = Properties.Resources.robot_3_1;
                                r3.Tag = "robot_3_1";
                                Thread.Sleep(200);
                                r3.Image = Properties.Resources.robot_2_1;
                                r3.Tag = "robot_2_1";
                                Thread.Sleep(200);
                                r3.Image = Properties.Resources.robot_1_0;
                                r3.Tag = "robot_1_0";
                                Thread.Sleep(100);
                                b2.Image = Properties.Resources.banda_poz_2; // poz 0 
                                b2.Tag = "banda_poz_2";
                                Thread.Sleep(200);
                                r3.Image = Properties.Resources.robot_3_0;
                                r3.Tag = "robot_3_0";
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
                    Thread.Sleep(1);
                }
            }
        }
    }
}
