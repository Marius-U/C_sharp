using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spec1
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }

        
        const int lines = 25;   //number of lines retrieved from the analyzer
        Analyzer analyzer;      //the anayzer, never use more than 1
        float[] SpectrumData;   //the array where the SpectrumData is stored in the main program
        int Right;              
        int Left;
        bool dinamicDisplay;    //true if the display is done one by one, as the analyzer gets the data

        Graphics g;             //..
        bool Enabled = false;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();            //create the graphics on a panel
            timer1.Enabled = false;                 //disable the timer
            timer1.Interval = 25;                   //set the freq tu 40hz
            analyzer = new Analyzer(lines);         //new analyzer
            analyzer.Updated += analyzer_Updated;   //overload the event
            SpectrumData=new float[lines+1];        //initialize SpectrumData
            progressBar1.Enabled = true;            //and the progressBars
            progressBar2.Enabled = true;
            progressBar1.Maximum = Int16.MaxValue ;
            progressBar2.Maximum = Int16.MaxValue ;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;// smooth out the drawing proccess
            dinamicDisplay = true;

        }

        //this function is called every time the Updated event occurs
        //this way every time a new value is found, it is displayed
        void analyzer_Updated(object sender, EventArgs e)
        {
            bool dataIsValid=!((analyzer.CurrentIndex==0)&&(analyzer.CurrentValue==-1));
            if ((dinamicDisplay) && dataIsValid) 
                DisplayOne(analyzer.CurrentIndex, analyzer.CurrentValue);
        }

        //basicaly draws a white rectangle over that strip of the panel
        //then draws a black one, depending of the value
        void DisplayOne(int index, float value)
        {
            //the width of a line depends of the number of lines an the width of the panel
            float width = panel1.Width / (lines);
            SolidBrush solidBlack = new SolidBrush(Color.Black);
            SolidBrush solidWhite = new SolidBrush(Color.White);
            float proportionalValue;
            //the max value is 255. the height of the rectangle is made proportional with the height of the panel
            //(regula de trei simpla)
            proportionalValue = value * panel1.Height / 255;
            
            g.FillRectangle(solidWhite, index * width, 0, width -1, panel1.Height);//clear the column
            g.FillRectangle(solidBlack, index * width, panel1.Height - proportionalValue, width -1, proportionalValue);//draw the black recangle

        }

        //this function displays the hole array of data
        public void DisplayAll(float[] spectrumData)
        {

            g.Clear(Color.White);               //clear the panel
            float width = panel1.Width / (lines);//get the width of a line
            SolidBrush solidBlack = new SolidBrush(Color.Black);
            float proportionalValue;
            
            for (int x = 0; x<lines; x++)
            {
                proportionalValue =  spectrumData[x] * panel1.Height / 255;// see DisplayOne
                g.FillRectangle(solidBlack, x * width, panel1.Height-proportionalValue, width - 1, proportionalValue);
            }
            
            
        }

        //Display the Right and Left Valuein progressBars
        private void DisplayRightLeft()
        {
            progressBar1.Value = Right;
            progressBar2.Value = Left;
        }

        //enable and disable button
        private void button1_Click(object sender, EventArgs e)
        {
            if(Enabled)
            {
                timer1.Enabled = false;
                analyzer.Enable = false;
                button1.Text = "disabled";
                Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
                analyzer.Enable = true;
                button1.Text = "enabled";
                Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //get the data in SpectrumData
            SpectrumData = analyzer.GetSpectrum(lines,ref Right,ref Left);
            
            //if it is ok display it
            if((SpectrumData[0]!=-1)&&(!dinamicDisplay))
            {
                DisplayAll(SpectrumData);
            }
            DisplayRightLeft();
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            dinamicDisplay = !dinamicDisplay;
            button2.Text = (dinamicDisplay) ? "dinamic" : "complet";
        }

 
    }
}
