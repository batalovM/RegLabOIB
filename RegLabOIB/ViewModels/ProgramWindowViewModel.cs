using System.Reactive;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using RegLabOIB.Views;

namespace RegLabOIB.ViewModels;

public class ProgramWindowViewModel : ViewModelBase
{
    public ReactiveCommand<Unit,Unit> QuitCommand { get; }

    public ProgramWindowViewModel()
    {
        QuitCommand = ReactiveCommand.Create(Quit);
    }

    private void Quit()
    {
        var logWindow = new MainWindow
        {
            DataContext = new MainWindowViewModel()
        };
        logWindow.Show();
        CloseMethod();
        
    }
    private void CloseMethod()
    {
        var window = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
        window?.Close();
    }
}