using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextFreeGrammar
{
    public class Road
    {
        private string start;
        private string end;
        private bool vaLid = false; 

        public string Start { get => start; set => start = value; }
        public string End { get => end; set => end = value; }

        public bool isVaLid()
        {
            if (vaLid)
            {
                return true;
            }

            return false;
        }
        public void SetValid(bool b)
        {
            vaLid = b;
        }
    }

    
}
