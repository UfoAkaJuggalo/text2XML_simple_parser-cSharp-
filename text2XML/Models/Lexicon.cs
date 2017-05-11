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
        private static string _type;
        private static List<LexiconPhrase> _lexicon = new List<LexiconPhrase>();

        public static string type { get => _type; set => _type = value; }


        public static string GetStartString(string elementName)
        {
            return _lexicon
                .Find(x=>x.name==elementName)
                .startString;
        }
        public static string GetStopString(string elementName)
        {
            return _lexicon
                .Find(x => x.name == elementName)
                .stopString;
        }
        public static bool GetMultiLevel(string elementName)
        {
            return _lexicon
                .Find(x => x.name == elementName)
                .multiLevel;
        }
        public static string GetTagIn(string elementName)
        {
            return _lexicon
                .Find(x => x.name == elementName)
                .openTag;
        }
        public static string GetTagOut(string elementName)
        {
            return _lexicon
                .Find(x => x.name == elementName)
                .closeTag;
        }
        public static int GetLevel(string elementName)
        {
            return _lexicon
                .Find(x => x.name == elementName)
                .level;
        }
        public static bool GetHasAtrr(string elementName)
        {
            return _lexicon
                .Find(x => x.name == elementName)
                .canGetAttribute;
        }
        public static void LoadLexicon(string dictPath)
        {
            _lexicon.Clear();
            using (StreamReader r = new StreamReader(dictPath))
            {
                string json = r.ReadToEnd();
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                _type = result.type;
                foreach (var i in result.dictionary)
                {
                    LexiconPhrase val = new LexiconPhrase
                    {
                        name = i.name,
                        openTag = i.openTag,
                        closeTag = i.closeTag,
                        level = i.level,
                        startString = i.startString,
                        stopString = i.stopString,
                        multiLevel = i.multiLevel,
                        canGetAttribute = i.canGetAttribute
                    };
                    _lexicon.Add(val);
                }
            }
        }
    }
}