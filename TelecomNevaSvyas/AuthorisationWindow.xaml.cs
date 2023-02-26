using System;
using System.Linq;
using System.Windows;
using Npgsql;

namespace TelecomNevaSvyas
{
    public partial class AuthorisationWindow : Window
    {
        public AuthorisationWindow()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {
            // EmployeesModel testConnection = new EmployeesModel();
            // testConnection.TestConnection();
            
            Console.WriteLine("Переход");
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=123;Database=TelecomNevaSvyasDB;");
            conn.Open();
 
            // Define a query returning a single row result set
            NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM Positions", conn);
 
            // Execute the query and obtain the value of the first column of the first row
            Int64 count = (Int64)command.ExecuteScalar();
 
            Console.Write("{0}\n", count);
            var connectionLabelContent = mainWindow.ConnectionLabel.Content = (count);
        }

    }
}