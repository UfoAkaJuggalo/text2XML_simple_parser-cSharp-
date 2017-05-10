using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using text2XML.Commands;
using text2XML.Models;
using System.ComponentModel;

namespace text2XML.ViewModels
{
    public class ParserViewModel : INotifyPropertyChanged
    {
        public string SourceText { get => _sourceText; set
            {
                _sourceText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("sourceText"));
            }
        }
        public string ConvertedText { get => _convertedText; set
            {
                _convertedText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("convertedText"));
            }
        }

        public PhraseRoot parser = new PhraseRoot();
        public Action CloseAction { get; set; }
        public Command ExitCommand { get
            {
                return new Command(() => { CloseAction(); });
            } }
        public Command OpenFileCommand => new Command(() =>
                {
                    OpenFileDialog txtFile = new OpenFileDialog();
                    txtFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    if (txtFile.ShowDialog() == true)
                    {
                        SourceText = File.ReadAllText(txtFile.FileName);
                        ConvertedText = "";
                    }
                });
        public Command SaveFileCommand => new Command(() =>
                {
                    if (_convertedText == "")
                        ParseText();
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "XML files (*.xml)|*.xml";
                    if (saveFileDialog.ShowDialog() == true)
                        File.WriteAllText(saveFileDialog.FileName, parser.parsedText);
                });
        public Command ButtonParseText => new Command(() => ParseText());
        private string _sourceText = "Wpisz jakiś tekst, lub otwórz plik z tekstem.";
        private string _convertedText = "";
        private void ParseText()
        {
            parser.parsedText = SourceText;
            ConvertedText = parser.parsedText;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
