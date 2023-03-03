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

    private void Code_OnClosing(object? sender, CancelEventArgs e)
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        dispatcherTimer.Tick += dispatcherTimerTicker;
        dispatcherTimer.Start();
    }

    public int count = 10;
    private void dispatcherTimerTicker(object sender, EventArgs e)
    {
        count--;
        if (count == 0)
        {
            dispatcherTimer.Stop();
        }
        else
        {
            authorisationWindow.ValidationLabel.Visibility = Visibility.Visible;
            authorisationWindow.ValidationLabel.Content = count.ToString();
            CodeLabel.Content = count.ToString();
        }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
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