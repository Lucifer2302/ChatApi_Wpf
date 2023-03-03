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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Chat2._0
{
    /// <summary>
    /// Логика взаимодействия для ChatRoomWindow.xaml
    /// </summary>
    public partial class ChatRoomWindow : Window

    {
        List<ChatMessage> chatMessages = new List<ChatMessage>();
        public ChatRoomWindow()
        {
            InitializeComponent();
            Title = Main.chatRoom.Topic;
            GetMessage();
            Update();

            
            
        }
        private async void GetMessage()
        {
            HttpResponseMessage httpResponseMessage = await MainWindow.httpClient.GetAsync("http://localhost:50203/api/ChatMessages");
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            chatMessages = JsonConvert.DeserializeObject<List<ChatMessage>>(content);
            MessageList.ItemsSource = chatMessages.Where(i=> i.IdChatRoom == Main.chatRoom.id);
            MessageList.ScrollIntoView(chatMessages.Where(i => i.IdChatRoom == Main.chatRoom.id).LastOrDefault());
        }

      

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Main c = new Main();
            c.Show();
            Close();
        }

        private void Back_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main p = new Main();
            p.Show();
            Close();
        }
        private async void SendMessage(object sender, RoutedEventArgs e)
        {
            var message = new ChatMessage
            {
                IdChatRoom = Main.chatRoom.id,
                DateTime = DateTime.Now,
                TextMessage = MessageTb.Text,
                idEmployee = MainWindow.employee.id
            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            HttpResponseMessage sendmessage = await MainWindow.httpClient.PostAsync("http://localhost:50203/api/ChatMessages", httpContent);
            
            if (String.IsNullOrEmpty(MessageTb.Text))
            {
                MessageBox.Show("Error");
            }
            else 
                GetMessage();
                MessageTb.Text = "";
        }

        public void Update()
        {
            DispatcherTimer timer;
            timer = new DispatcherTimer();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GetMessage();
        }
    }
}
