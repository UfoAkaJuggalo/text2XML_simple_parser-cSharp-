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

namespace text2XML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Lexicon.LoadLexicon("Dictionary\\XML_dictionary.json");
        }

        private void CommandBinding_Open(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog txtFile = new OpenFileDialog();
            txtFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (txtFile.ShowDialog() == true)
                txtBoxSource.Text = File.ReadAllText(txtFile.FileName);
        }

        private void CommandBinding_Save(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBinding_Exit(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
