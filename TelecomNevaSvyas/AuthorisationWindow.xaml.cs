using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Npgsql;
using TelecomNevaSvyas.DBModels;

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
            NumberTextBox.Clear();
            PasswordTextBox.Clear();
            CodeTextBox.Clear();
        }
        
        private void NumberValidation(object sender, KeyEventArgs e)
        {
            String number = NumberTextBox.Text;
            
            if (e.Key == Key.Return)
            {
                EmployeesModel employeesModel = new EmployeesModel();
                bool info = employeesModel.NumberInDB(number);

                if (info)
                {
                    IntoButton.IsEnabled = true;
                    PasswordTextBox.IsEnabled = true;
                    PasswordTextBox.IsFocused.Equals(true);
                }
                else
                {
                    IntoButton.IsEnabled = false;
                    PasswordTextBox.IsEnabled = false;
                    PasswordTextBox.IsFocused.Equals(false);
                    MessageBox.Show("Номер отсутствует в базе", "Ошибка");
                }
            }
            
            
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {
            

            MainWindow mainWindow = new MainWindow();
            // var connectionLabelContent = mainWindow.ConnectionLabel.Content = (info);

            // if (info)
            // {
            mainWindow.Show();
            // }


            // NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=123;Database=TelecomNevaSvyasDB;");
            // conn.Open();
            //
            // // Define a query returning a single row result set
            // NpgsqlCommand command = new NpgsqlCommand("SELECT name FROM Positions", conn);
            //
            // // Execute the query and obtain the value of the first column of the first row
            // String count = command.ExecuteScalar().ToString();
            //
            // var connectionLabelContent = mainWindow.ConnectionLabel.Content = (count);
        }
    }
}