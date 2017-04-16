using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text2XML.Models
{
    public class PhraseWord : Phrase
    {
        private string _content;
        public string parsedText
        {
            get
            {
                string result = "";
                for (int i=0; i<Lexicon.GetTab(_typeOfPhrase);i++)
                {
                    result += "\t";
                }
                result += Lexicon.GetTagIn(_typeOfPhrase) + _content + Lexicon.GetTagOut(_typeOfPhrase);
                return result;
            }
            set
            {
                _content = value;
            }
        }

        public PhraseWord()
        {
            _typeOfPhrase = "word";
        }
    }
}
