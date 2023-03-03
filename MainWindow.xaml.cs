using Chat2._0.AppData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Chat2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static HttpClient httpClient = new HttpClient();
        public static Employee employee;
        public MainWindow()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.login) &&
                !string.IsNullOrEmpty(Properties.Settings.Default.password))
            {
                Enter();
            }
        }

        private async void Enter()
        {
            LoginTb.Text = Properties.Settings.Default.login;
            PassTb.Password = Properties.Settings.Default.password;
        }

        private async void Signin(object sender, RoutedEventArgs e)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var content = new userData { password = PassTb.Password, username = LoginTb.Text };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await httpClient.PostAsync("http://localhost:50203/api/Auth", httpContent);

            if (message.IsSuccessStatusCode)
            {
                var curContent = await message.Content.ReadAsStringAsync();
                employee = JsonConvert.DeserializeObject<Employee>(curContent);

                if ((bool)SaveCheck.IsChecked)
                {
                    Properties.Settings.Default.login = LoginTb.Text;
                    Properties.Settings.Default.password = PassTb.Password;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.login = string.Empty;
                    Properties.Settings.Default.password = string.Empty;
                    Properties.Settings.Default.Save();
                }

                Main m = new Main();
                m.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверные данные!");
            }

        }
        public class userData
        {
            public string username { get; set; }
            public string password { get; set; }
        }

    }
}
