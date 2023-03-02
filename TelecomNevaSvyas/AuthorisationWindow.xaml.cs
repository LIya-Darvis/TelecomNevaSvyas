﻿using System;
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
            if (e.Key == Key.Return)
            {
                // получение данных
                using (ApplicationContext db = new ApplicationContext())
                {
                    String s = "";
                    // получаем объекты из бд и выводим на консоль
                    var employees = db.Employees.ToList();
                    List<String> numbers = new List<String>();
                    String number = NumberTextBox.Text;
                    
                    foreach (Employee p in employees)
                    {
                        numbers.Add(p.Number.ToString());
                        s += $"{p.Number} \n";
                    }
                    ValidationLabel.Content = s;
                    
                    if (numbers.Contains(number))
                    {
                        PasswordTextBox.IsEnabled = true;
                        final_number = int.Parse(number);
                        ValidationLabel.Content = $"Данный номер есть в базе: {final_number}";
                    }
                    else
                    {
                        PasswordTextBox.IsEnabled = false;
                        MessageBox.Show("Номер отсутствует в базе", "Ошибка");
                    }
                }
            }
        }
        
        private void PasswordValidation(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                // получение данных
                using (ApplicationContext db = new ApplicationContext())
                {
                    String s = "";
                    // получаем объекты из бд и выводим на консоль
                    var employees = db.Employees.ToList();
                    // List<String[]> numbersPasswords = new List<String[]>();
                    
                    
                    foreach (Employee p in employees)
                    {
                        String password = PasswordTextBox.Text;

                        String[] buffer = {p.Number.ToString(), p.Password};

                        if (buffer[0] == final_number.ToString() & buffer[1] == password)
                        {
                            CodeTextBox.IsEnabled = true;
                            final_password = password;
                            ValidationLabel.Content = $"Данный пароль есть в базе: {final_password}";
                            break;
                        }
                        else
                        {
                            CodeTextBox.IsEnabled = false;
                            MessageBox.Show("Пароль отсутствует в базе", "Ошибка");
                            continue;
                        }
                    }
                }
            }
        }
        

        private void GoToMain(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
  
            mainWindow.Show();

        }
    }
}