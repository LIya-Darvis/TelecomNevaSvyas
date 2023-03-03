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
                    // получаем объекты из бд
                    var employees = db.Employees.ToList();
                    List<String> numbers = new List<String>();
                    String number = NumberTextBox.Text;
                    
                    foreach (Employee p in employees)
                    {
                        numbers.Add(p.Number.ToString());
                    }
                    ValidationLabel.Content = s;
                    
                    if (numbers.Contains(number))
                    {
                        PasswordTextBox.IsEnabled = true;
                        final_number = int.Parse(number);
                        ValidationLabel.Content = "";
                    }
                    else
                    {
                        PasswordTextBox.IsEnabled = false;
                        ValidationLabel.Content = "Номер отсутсвует в базе";
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
                    bool flag = false;
                    String s = "";
                    // получаем объекты из бд
                    var employees = db.Employees.ToList();

                    foreach (Employee p in employees)
                    {
                        String password = PasswordTextBox.Text;

                        String[] buffer = {p.Number.ToString(), p.Password};

                        if (buffer[0] == final_number.ToString() & buffer[1] == password)
                        {
                            CodeTextBox.IsEnabled = true;
                            final_password = password;
                            ValidationLabel.Content = "";
                            flag = true;
                            break;
                        }
                        else
                        {
                            CodeTextBox.IsEnabled = false;
                            ValidationLabel.Content = "Неверный пароль";
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        CodeValidation();
                    }
                }
            }
        }

        private void CodeValidation()
        {
            CodeWindow codeWindow = new CodeWindow();
            codeWindow.CodeLabel.Content = CreateRandomPassword();
            codeWindow.Show();
            
        }
        
        private static string CreateRandomPassword(int length = 4)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ" +
                                "abcdefghijkmnopqrstuvwxyz" +
                                "0123456789";
            Random random = new Random();
            
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
        
        
        

        private void GoToMain(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
  
            mainWindow.Show();

        }
    }
}