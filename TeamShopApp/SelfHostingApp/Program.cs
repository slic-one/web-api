using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Windows.Forms;

namespace SelfHostingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // !!Увага. Налаштування з'єднання до бази вписати у App.config цього проекту

            string address = "http://localhost:8889";

            // Налаштування
            var config = new HttpSelfHostConfiguration(address);

            config.Routes.MapHttpRoute(
                "MyRoute", "api/{controller}/{id}",new { id = RouteParameter.Optional });

            try
            { 
                var server = new HttpSelfHostServer(config); // Создание сервиса

                var task = server.OpenAsync();// Запуск сервиса
                task.Wait();

                Console.WriteLine("Сервис доступен по адресу {0}/api/...", address);
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Стартуйте з правами адміністратора!");
            }
            
  
        }
    }
}
