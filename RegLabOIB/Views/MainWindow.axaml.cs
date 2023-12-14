using Avalonia.Controls;
using RegLabOIB.ViewModels;

namespace RegLabOIB.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}