using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace FileSearch
{
    class MainActivity
    {
        private string[] files = null;
        private string path = null;
        private string word = null;
        ListView listView = null;
        private  Form1 activity = null;

        public MainActivity()
        {
            
        }
        public void setActivity(Form1 context)
        {
            this.activity = context;
        }
        public bool getFiles()
        {
            bool validation = false;
            if(null != this.path)
            {
                files = System.IO.Directory.GetFiles(path, "*.pdf");
                validation = true;
            }
            else
            {

            }
            return validation;
        }

        public void search()
        {
            int count = 0;
            int nr = 0;
            int h = 0;
            int progVal = 0;
            activity.setVisibleProgBar(true);
            if(null == files)
            {
                getFiles();
               
            }
            if (null != files)
            {
                count = files.Count()-1;
                h = 100/files.Count();
                while (count != 0)
                {
                    string file = files[count];
                    nr = searchThroughFile(file);

                    if (nr != 0)
                    {
                        string temp =  file +" "+nr.ToString()+" times." ;

                        var listViewItem = new ListViewItem(temp);
                        activity.addListItem(listViewItem);
                    }
                    count--;
                    progVal += h;
                    activity.incrementProgBar(progVal);
                }
                activity.incrementProgBar(100);
                activity.setVisibleProgBar(false);
            }
            else
            {
                MessageBox.Show("No extension!", "Info");
            }
        
        }
        private int searchThroughFile(string path)
        {
            int count = 0;
            int index = 0;
            string[] temp = null;
            using (PdfReader reader = new PdfReader(path))
            {

                
                ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string text = null;
                    try
                    {
                        text = (PdfTextExtractor.GetTextFromPage(reader, i, its));
                    }
                    catch(Exception e)
                    {

                    }
                    if (text != null)
                    {
                        temp = text.ToString().Split();
                    while (index < temp.Count())
                    {
                        if (temp[index].Equals(word))
                        {
                            count++;
                        }
                        index++;
                    }
                        }
                    index = 0;
                    
                }
                
               
            }
            return count;
        }
        public void setWord(string word)
        {
            if (null != word)
            {
                this.word = word;
            }
            else
            {
                MessageBox.Show("No word to search!", "Error");
            }
        }
        public string getWord()
        {
            return this.word;
        }
        public void setPath(string path)
        {
            this.path = path;
            if (getFiles())
            {

            }
            else
            {
                MessageBox.Show("No file with that extension!", "Info");
            }
        }
        public string getPath()
        {
            return this.path;
        }
    }
}
