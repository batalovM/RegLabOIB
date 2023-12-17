using Avalonia.Controls;
using Avalonia.Interactivity;
using RegLabOIB.ViewModels;

namespace RegLabOIB.Views;

public partial class MainWindow : Window
{
    private RegistationWindow rgv = new ();
    private MainWindowViewModel mv = new();
    private ProgramWindow ProgramWindow = new();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        rgv.Show();
        DataContext = new RegistrationWindowViewModel();
        Close();
    }

    private void Button_OnClickLogin(object? sender, RoutedEventArgs e)
    {
        if (mv.access == true)
        {
            DataContext = new ProgramWindowViewModel();
            Close();
        }
        
    }
}