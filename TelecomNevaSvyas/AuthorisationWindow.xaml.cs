using System;
using System.Collections.Generic;
using System.Data;
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
        static DBConnection connection = new DBConnection();
        NpgsqlConnection conn = connection.Connection();

        public int final_number;
        public String final_password = "";

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
            const string TABLE_NAME = "Employees";
            String number = NumberTextBox.Text;
            
            if (e.Key == Key.Return)
            {
                NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM {TABLE_NAME}", conn);
                List<string> numbers = new List<string>();
        
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numbers.Add(reader.GetInt32(2).ToString());
                }

                if (numbers.Contains(number))
                {
                    PasswordTextBox.IsEnabled = true;
                    PasswordTextBox.IsFocused.Equals(true);
                    final_number = int.Parse(number);
                    ValidationLabel.Content = $"Данный номер есть в базе: {final_number}";
                }
                else
                {
                    PasswordTextBox.IsEnabled = false;
                    PasswordTextBox.IsFocused.Equals(false);
                    MessageBox.Show("Номер отсутствует в базе", "Ошибка");
                }
            }
        }
        
        private void PasswordValidation(object sender, KeyEventArgs e)
        {
            const string TABLE_NAME = "employees";
            String password = NumberTextBox.Text;
            
            if (e.Key == Key.Return)
            {
                NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM {TABLE_NAME}", conn);
                List<string> passwords = new List<string>();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    passwords.Add(reader.GetInt32(3).ToString());
                }

                if (passwords.Contains(password))
                {
                    CodeTextBox.IsEnabled = true;
                    CodeTextBox.IsFocused.Equals(true);
                    final_password = password;
                    ValidationLabel.Content = $"Данный пароль есть в базе: {final_password}";
                }
                else
                {
                    CodeTextBox.IsEnabled = false;
                    CodeTextBox.IsFocused.Equals(false);
                    MessageBox.Show("Пароль отсутствует в базе", "Ошибка");
                }


                // if (reader.ToString() == password)
                // {
                //     CodeTextBox.IsEnabled = true;
                //     CodeTextBox.IsFocused.Equals(true);
                //     final_password = password;
                // }
                // else
                // {
                //     CodeTextBox.IsEnabled = false;
                //     CodeTextBox.IsFocused.Equals(false);
                //     MessageBox.Show("Неверный пароль", "Ошибка");
                // }
            }
        }
        

        private void GoToMain(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
  
            mainWindow.Show();

        }
    }
}