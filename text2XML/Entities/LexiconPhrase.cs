using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text2XML.Models
{
    public class LexiconPhrase
    {
        public string name;
        public string openTag;
        public string closeTag;
        public int level;
        public string startString;
        public string stopString;
        public bool multiLevel;
        public bool canGetAttribute;
    }
}
