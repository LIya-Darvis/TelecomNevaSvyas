using System;
using System.Linq;
using System.Windows;
using TelecomNevaSvyas.DBModels;
using Npgsql;

namespace TelecomNevaSvyas
{
    public partial class AuthorisationWindow : Window
    {
        public AuthorisationWindow()
        {
            InitializeComponent();
            TestConnection();
        }

        private void ClearTextBoxes(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {
            // EmployeesModel testConnection = new EmployeesModel();
            // testConnection.TestConnection();

            TestConnection();
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        
        private static void TestConnection()
        {
            // получение данных
            using (EmployeesModel db = new EmployeesModel())
            {
                // получаем объекты из бд и выводим на консоль
                var positions = db.Positions.ToList();
                Console.WriteLine("Positions list:");
                foreach (Positions p in positions)
                {
                    Console.WriteLine($"{p.Id} - {p.Name}");
                }
            }
        }
        
    }
}