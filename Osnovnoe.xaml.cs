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
using System.Windows.Shapes;

namespace Chat2._0
{
    /// <summary>
    /// Логика взаимодействия для Osnovnoe.xaml
    /// </summary>
    public partial class Osnovnoe : Window
    {
        public Osnovnoe()
        {
            InitializeComponent();
        }

        private void ButtonTg_Click(object sender, RoutedEventArgs e)
        {
            webView.CoreWebView2.Navigate("https://web.telegram.org/k/");
        }

        private void ButtonVk_Click(object sender, RoutedEventArgs e)
        {
            webView.CoreWebView2.Navigate("https://vk.com/");
        }

        private void ButtonChat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
