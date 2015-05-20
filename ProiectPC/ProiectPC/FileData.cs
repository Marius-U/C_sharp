using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPC
{
    class FileData
    {
        private string line = null;
        private bool executed = false;
        public FileData(string line, bool executed)
        {
            this.line = line;
            this.executed = executed;
        }
        /************Setter*****************/
        public void setLine(string line)
        {
            this.line = line;
        }
        public void setExecuted(bool executed)
        {
            this.executed = executed;
        }
        /*************Getter***************/
        public string getLine()
        {
            return this.line;
        }
        public bool getExecuted()
        {
            return executed;
        }
    }
}
