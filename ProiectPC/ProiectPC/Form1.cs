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

namespace ProiectPC
{
    public partial class Form1 : Form
    {
        Form1 activity;
        private bool fileFlag = true;
        System.IO.StreamReader file;
        string[] lines;
        int lineCount;

        List<FileData> fileData = new List<FileData>();

        public Form1()
        {
            InitializeComponent();

            init();

            banda1 tB1 = new banda1(banda1, this);
            banda2 tB2 = new banda2(banda2, this);
            robot1 tR1 = new robot1(robot1,banda1,banda2,container, this);
            robot2 tR2 = new robot2(robot2,banda1,masina1,tampon, this);
            robot3 tR3 = new robot3(robot3,tampon,masina2,banda2, this);
            robot4 tR4 = new robot4(robot4,container,depozit, this);

            Thread oTB1 = new Thread(new ThreadStart(tB1.Thread2));
            Thread oTB2 = new Thread(new ThreadStart(tB2.Thread5));
            Thread oTR1 = new Thread(new ThreadStart(tR1.Thread1));
            Thread oTR2 = new Thread(new ThreadStart(tR2.Thread3));
            Thread oTR3 = new Thread(new ThreadStart(tR3.Thread4));
            Thread oTR4 = new Thread(new ThreadStart(tR4.Thread6));

            oTR1.Start();
            // Spin for a while waiting for the started thread to become
            // alive: Thread1
            while (!oTR1.IsAlive) ;

            oTB1.Start();
            // Spin for a while waiting for the started thread to become
            // alive: Thread2
            while (!oTB1.IsAlive) ;

            oTR2.Start();
            // Spin for a while waiting for the started thread to become
            // alive:Thread3
            while (!oTR2.IsAlive) ;

            oTR3.Start();
            // Spin for a while waiting for the started thread to become
            // alive: Thread4
            while (!oTR3.IsAlive) ;

            oTB2.Start();
            // Spin for a while waiting for the started thread to become
            // alive: Thread5
            while (!oTB2.IsAlive) ;

            oTR4.Start();
            // Spin for a while waiting for the started thread to become
            // alive: Thread6
            while (!oTR4.IsAlive) ;
            
          //  Thread.Sleep(1);

        }

        public void setActivity(Form1 activity)
        {
            this.activity = activity;
        }

        private void init()
        {
            Properties.Resources.banda_goala.Tag                 = "banda_goala";
            Properties.Resources.banda_poz_0.Tag                 = "banda_poz_0";
            Properties.Resources.banda_poz_1.Tag                 = "banda_poz_1";
            Properties.Resources.banda_poz_2.Tag                 = "banda_poz_2";
            Properties.Resources.blank.Tag                       = "blank";
            Properties.Resources.depozit_0_piese.Tag             = "depozit_0_piese";
            Properties.Resources.depozit_1_piesa.Tag             = "depozit_1_piesa";
            Properties.Resources.depozit_2_piese.Tag             = "depozit_2_piese";
            Properties.Resources.depozit_3_piese.Tag             = "depozit_3_piese";
            Properties.Resources.depozit_4_piese.Tag             = "depozit_4_piese";
            Properties.Resources.masina_1_incarcat.Tag           = "masina_1_incarcata";
            Properties.Resources.masina_1_libera.Tag             = "masina_1_libera";
            Properties.Resources.masina_2_incarcat.Tag           = "masina_2_incarcat";
            Properties.Resources.masina_2_libera.Tag             = "masina_2_libera";
            Properties.Resources.robot_1_0.Tag                   = "robot_1_0";
            Properties.Resources.robot_1_1.Tag                   = "robot_1_1";
            Properties.Resources.robot_2_0.Tag                   = "robot_2_0";
            Properties.Resources.robot_2_1.Tag                   = "robot_2_1";
            Properties.Resources.robot_3_0.Tag                   = "robot_3_0";
            Properties.Resources.robot_3_1.Tag                   = "robot_3_1";
            Properties.Resources.robot_4_0.Tag                   = "robot_4_0";
            Properties.Resources.robot_4_1.Tag                   = "robot_4_1";
            Properties.Resources.robot_5_0.Tag                   = "robot_5_0";
            Properties.Resources.robot_5_1.Tag                   = "robot_5_1";
            Properties.Resources.tampon_gol.Tag                  = "tampon_gol";
            Properties.Resources.tampon_ocupat.Tag               = "tampon_ocupat";


            banda1.Image = Properties.Resources.banda_goala;
            banda1.Tag = "banda_goala";

            banda2.Image = Properties.Resources.banda_goala;
            banda2.Tag = "banda_goala";

            magazie.Image = Properties.Resources.depozit_4_piese;
            magazie.Tag = "depozit_4_piese";

            tampon.Image = Properties.Resources.tampon_gol;
            tampon.Tag = "tampon_gol";

            container.Image = Properties.Resources.tampon_gol;
            container.Tag = "tampon_gol";

            depozit.Image = Properties.Resources.depozit_0_piese;
            depozit.Tag = "depozit_0_piese";

            masina1.Image = Properties.Resources.masina_1_libera;
            masina1.Tag = "masina_1_libera";

            masina2.Image = Properties.Resources.masina_2_libera;
            masina2.Tag = "masina_2_libera";

            robot1.Image = Properties.Resources.robot_1_0;
            robot1.Tag = "robot_1_0";

            robot2.Image = Properties.Resources.robot_1_0;
            robot2.Tag = "robot_1_0";

            robot3.Image = Properties.Resources.robot_1_0;
            robot3.Tag = "robot_1_0";

            robot4.Image = Properties.Resources.robot_1_0;
            robot4.Tag = "robot_1_0";
           
            try
            {
                lines = System.IO.File.ReadAllLines(@"C:\Users\Marius\Desktop\demoPC.txt");
            }

            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            if(lines == null)
            {
                MessageBox.Show("No file was found!", "Error!");
                fileFlag = false;
            }
            else
            {
                foreach(string s in lines)
                {
                    FileData temp = new FileData(s, false);
                    fileData.Add(temp);
                }
            }
        }

        public string getLine()
        {
            string line = null;
            int count = 0;
            foreach(FileData f in fileData)
            {

                if(!f.getExecuted())
                {
                    line = f.getLine();
                    lineCount = count;
                    break;
                }
                count++;
            }

            return line;
        }

        public void setExecuted()
        {
            fileData[lineCount].setExecuted(true);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void robot1_Click(object sender, EventArgs e)
        {

        }

        private void robot3_Click(object sender, EventArgs e)
        {

        }

        private void container_Click(object sender, EventArgs e)
        {

        }

        private void banda2_Click(object sender, EventArgs e)
        {

        }
    }
}
