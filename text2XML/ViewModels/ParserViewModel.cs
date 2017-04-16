using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using text2XML.Models;

namespace text2XML.ViewModels
{
    public class ParserViewModel
    {
        public string sourceText
        {
            get
            {
                return _sourceText;
            }
            set
            {
                _sourceText = value;
            }
        }

        public PhraseRoot parser = new PhraseRoot();
        private string _sourceText = "Wpisz jakiś tekst, lub otwórz plik z tekstem.";
    }
}
