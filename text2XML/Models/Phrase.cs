using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text2XML.Models
{
    public abstract class Phrase
    {
        protected string _typeOfPhrase;
        public string parsedText { get; set; }
    }
}
