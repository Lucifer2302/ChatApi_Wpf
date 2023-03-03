using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat2._0.AppData
{
    public partial class Employee
    {
        public string GetTime
        {
            get
            {
                string hello = "Добрый ночи ";
                if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 12)
                {
                    hello = "Доброе утро ";
                    return hello;
                }
                else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
                {
                    hello = "Добрый день ";
                    return hello;
                }
                else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour < 0)
                {
                    hello = "Добрый вечер ";
                    return hello;
                }

                return hello;
            }
        }
        public string Hellow
        {
            get
            {
                string name = $"{GetTime}{FullName}!";
                return name;
            }
        }



        public int id { get; set; }
        public string FullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
