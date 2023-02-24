using System.Windows;

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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}