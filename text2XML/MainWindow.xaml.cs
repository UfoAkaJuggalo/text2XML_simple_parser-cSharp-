using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using text2XML.Models;
using text2XML.ViewModels;

namespace text2XML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ParserViewModel _parser = new ParserViewModel();

        public MainWindow()
        {
            InitializeComponent();
            Lexicon.LoadLexicon("Dictionary\\XML_dictionary.json");
            txtBoxSource.Text = _parser.sourceText;
        }

        private void CommandBinding_Open(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog txtFile = new OpenFileDialog();
            txtFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (txtFile.ShowDialog() == true)
                txtBoxSource.Text = _parser.sourceText = File.ReadAllText(txtFile.FileName);
        }

        private void CommandBinding_Save(object sender, ExecutedRoutedEventArgs e)
        {
            if (txtBoxXML.Text == "")
                Button_Parse(sender, e);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, _parser.parser.parsedText);
        }

        private void CommandBinding_Exit(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Parse(object sender, RoutedEventArgs e)
        {
            _parser.sourceText = txtBoxSource.Text;
            _parser.parser.parsedText = _parser.sourceText;
            txtBoxXML.Text = _parser.parser.parsedText;
                    }
    }
}
