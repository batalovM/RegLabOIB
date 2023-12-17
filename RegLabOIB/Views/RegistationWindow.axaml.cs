using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using RegLabOIB.ViewModels;

namespace RegLabOIB.Views;

public partial class RegistationWindow : Window
{
    private RegistrationWindowViewModel rwvm = new();
    public RegistationWindow()
    {
        InitializeComponent();
        DataContext = new  RegistrationWindowViewModel();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        DataContext = new MainWindowViewModel();
        var logWindow = new MainWindow
        {
            DataContext = new MainWindowViewModel()
        };
        logWindow.Show();
        Close();
    }
}