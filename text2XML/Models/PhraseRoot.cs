using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text2XML.Models
{
    public class PhraseRoot : Phrase
    {
        private List<PhraseSentence> _content = new List<PhraseSentence>();
        public string parsedText
        {
            get
            {
                string result = Lexicon.GetTagIn(_typeOfPhrase);
                foreach (var i in _content)
                {
                    result += i.parsedText;
                }
                result += Lexicon.GetTagOut(_typeOfPhrase);
                return result;
            }
            set
            {
                _content.Clear();
                char[] delimiterChars = { '?', '!', '.', '\n' };
                string[] sentences = value.Split(delimiterChars);
                foreach (string s in sentences)
                {
                    if (s != "")
                        _content.Add(new PhraseSentence { parsedText = s });
                }
            }
        }

        public PhraseRoot()
        {
            _typeOfPhrase = "root";
        }
    }
}
