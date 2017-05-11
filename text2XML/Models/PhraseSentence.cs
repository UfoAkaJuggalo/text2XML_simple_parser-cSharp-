using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text2XML.Models
{
    public class PhraseSentence : Phrase
    {
        private List<PhraseWord> _content = new List<PhraseWord>();
        public string parsedText
        {
            get
            {
                string result;
                string tab = "";
                for (int i = 0; i < Lexicon.GetLevel(_typeOfPhrase); i++)
                {
                    tab += "\t";
                }
                result = tab + Lexicon.GetTagIn(_typeOfPhrase);
                foreach (var j in _content)
                {
                    result += j.parsedText;
                }
                result += tab + Lexicon.GetTagOut(_typeOfPhrase);
                return result;
            }
            set
            {
                _content.Clear();
                char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n' };
                string[] words = value.Split(delimiterChars);
                foreach (string s in words)
                {
                    if(s !="")
                    _content.Add(new PhraseWord { parsedText = s });
                }
            }
        }

        public PhraseSentence()
        {
            _typeOfPhrase = "sentence";
        }
    }
}
