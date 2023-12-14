using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RegLabOIB.ViewModels;

namespace RegLabOIB.Views;

public partial class ProgramWindow : Window
{
    public ProgramWindow()
    {
        InitializeComponent();
        DataContext = new ProgramWindowViewModel();
    }
}