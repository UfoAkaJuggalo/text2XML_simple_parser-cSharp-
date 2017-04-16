using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text2XML.Models
{
    public static class Lexicon
    {
        private static Dictionary<string, LexiconPhrase> _lexicon = new Dictionary<string, LexiconPhrase>();

        public static string GetTagIn(string elementType)
        {
            return _lexicon[elementType].openTag;
        }
        public static string GetTagOut(string elementType)
        {
            return _lexicon[elementType].closeTag;
        }
        public static int GetTab(string elementType)
        {
            return _lexicon[elementType].tab;
        }
        public static bool GetHasAtrr(string elementType)
        {
            return _lexicon[elementType].canGetAttribute;
        }
        public static void LoadLexicon(string dictPath)
        {
            _lexicon.Clear();
            using (StreamReader r = new StreamReader(dictPath))
            {
                string json = r.ReadToEnd();
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                foreach (var i in result)
                {
                    string type = i.type;
                    LexiconPhrase val = new LexiconPhrase
                    {
                        openTag = i.openTag,
                        closeTag = i.closeTag,
                        tab = i.tab,
                        canGetAttribute = i.canGetAttribute
                    };
                    _lexicon.Add(type, val);
                }
            }
        }
    }
}