
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

namespace Chat2._0
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public List<ChatRoom> chatRooms = new List<ChatRoom>();
        public List<ChatRoomEmployee> chatRoomEmployees = new List<ChatRoomEmployee>();
        public static ChatRoom chatRoom;
       
        public Main()
        {
            InitializeComponent();
            hellogrid.DataContext = MainWindow.employee;
            GetRooms();
        }
        public async void GetRooms()
        {
            HttpResponseMessage httpResponseMessage = await MainWindow.httpClient.GetAsync("http://localhost:50203/api/Chatrooms");
            var rooms = await httpResponseMessage.Content.ReadAsStringAsync();

            HttpResponseMessage responseMessage = await MainWindow.httpClient.GetAsync("http://localhost:50203/api/ChatroomEmploees");
            var emp = await responseMessage.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ChatRoomEmployee>>(emp)
                .Where(i => i.idEmployee == MainWindow.employee.id).ToList();

            if (result == null)
            {

            }
            else
            {
                var temp = JsonConvert.DeserializeObject<List<ChatRoom>>(rooms).ToList();
                ChatRoomList.ItemsSource = from t in temp
                                           join r in result on t.id equals r.IdChatRoom
                                           select t;
            }

        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            chatRoom = ChatRoomList.SelectedItem as ChatRoom;
            ChatRoomWindow w = new ChatRoomWindow();
            w.Show();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow d = new MainWindow();
            Close();
            d.Show();

        }
    }
}






// AmountTb.text = Parse((int) number);
// number = 