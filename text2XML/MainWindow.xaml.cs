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
        private ParserViewModel _parser;

        public MainWindow()
        {
            InitializeComponent();
            _parser = new ParserViewModel();
            Lexicon.LoadLexicon("Dictionary\\XML_dictionary.json");
            DataContext = _parser;
            if (_parser.CloseAction == null)
                _parser.CloseAction = new Action(() => Close());
        }
    }
}