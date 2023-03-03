using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chat2._0.AppData
{
          public partial class ResponseEmployee
    {
           public ResponseEmployee(Employee employee)
        {
            id = employee.id;
            FullName = employee.FullName;
            username = employee.username;
            password = employee.password;
        }
        public int id { get; set; }
        public string FullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
