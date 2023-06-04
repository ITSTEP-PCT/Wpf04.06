using System;
using System.Collections.Generic;
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

namespace Wpf04._06
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            startText.Text = "0";
            endText.Text = "0";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isEnabled;
            if (!int.TryParse(startText.Text, out int k) ||
                !int.TryParse(endText.Text, out int j) ||
                k < 0 || k > mainText.Text.Length - 1 ||
                j < 0 || j > mainText.Text.Length)
                isEnabled = false;
            else
                isEnabled = true;
            for (int i = 0; i < toolBarTray.ToolBars.Count - 1; i++)
            {
                toolBarTray.ToolBars[i].IsEnabled = isEnabled;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int startIndex = int.Parse(startText.Text);
            int len = int.Parse(endText.Text) - startIndex;
            string word = mainText.Text.Substring(0, startIndex);
            string word1 = mainText.Text.Substring(startIndex, len);
            string word2 = mainText.Text.Substring(int.Parse(endText.Text));

            mainText.Inlines.Clear();
            mainText.Inlines.Add(word);
            mainText.Inlines.Add(new Run(word1) 
            { FontWeight = FontWeights.Bold});
            mainText.Inlines.Add(word2);
        }
    }
}
