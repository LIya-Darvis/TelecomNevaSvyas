using System;
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
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=123;Database=TelecomNevaSvyasDB;"); 
                conn.Open(); 
                if (conn.State == System.Data.ConnectionState.Open) 
                    Console.WriteLine("Success open postgreSQL connection.");

                if (conn != null) {Console.WriteLine("Success");}
                else {Console.WriteLine("Not Success");}
                
                string sql = "SELECT * FROM Positions";
                using var cmd = new NpgsqlCommand(sql, conn);

                using NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("{0} {1}", rdr.GetInt32(0), rdr.GetString(1));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error...");
            }
        }
    }
}