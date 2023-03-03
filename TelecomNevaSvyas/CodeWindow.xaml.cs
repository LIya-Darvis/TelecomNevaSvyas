using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;


namespace TelecomNevaSvyas;

public partial class CodeWindow : Window
{
    public DispatcherTimer dispatcherTimer;
    AuthorisationWindow authorisationWindow = new AuthorisationWindow();
    public CodeWindow()
    {
        InitializeComponent();
    }
    public int count = 10;
    
    public void dispatcherTimerTicker(object sender, EventArgs e)
    {
        // if (count <= 0 | authorisationWindow.CodeTextBox.Text != (string)CodeLabel.Content)
        // {
        //     authorisationWindow.UpdateButton.IsEnabled = true;
        //     validation = true;
        //     authorisationWindow.IntoButton.IsEnabled = true;
        // }
        // else
        // {
        //     authorisationWindow.UpdateButton.IsEnabled = false;
        //     validation = false;
        //     authorisationWindow.IntoButton.IsEnabled = false;
        // }
        
        authorisationWindow.ValidationLabel.Visibility = Visibility.Visible; 
        authorisationWindow.ValidationLabel.Content = count.ToString();
        CodeLabel.Content = count.ToString();
        
        count--;
    }

    public void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        authorisationWindow.ValidationLabel.Visibility = Visibility.Visible;
        authorisationWindow.ValidationLabel.Content = count.ToString();
        Close();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        dispatcherTimer.Tick += dispatcherTimerTicker;
        dispatcherTimer.Start();
    }
    
    
}