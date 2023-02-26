using System;
using System.Windows;
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
            throw new System.NotImplementedException();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {
            EmployeesModel testConnection = new EmployeesModel();
            testConnection.TestConnection();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}