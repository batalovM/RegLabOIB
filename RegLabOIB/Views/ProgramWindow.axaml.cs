using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using RegLabOIB.ViewModels;

namespace RegLabOIB.Views;

public partial class ProgramWindow : Window
{
    //private MainWindow MainWindow= new ();
    public ProgramWindow()
    {
        InitializeComponent();
        DataContext = new ProgramWindowViewModel();
    }

    private void Button_OnClickQuit(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow= new ();
        mainWindow.Show();
        DataContext = new MainWindowViewModel();
        Close();
    }
}