using System.Reactive;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using RegLabOIB.Views;

namespace RegLabOIB.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }
    public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

    public MainWindowViewModel()
    {
        LoginCommand = ReactiveCommand.Create(Login);
        RegisterCommand = ReactiveCommand.Create(Registr);
    }
    private void Login()
    {
        var prWindow = new ProgramWindow();
        prWindow.DataContext = new ProgramWindowViewModel();
        prWindow.Show();
        CloseMethod();
    }
    private void Registr()
    {
        throw new System.NotImplementedException();
    }
    private void CloseMethod()
    {
        var window = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
        window?.Close();
    }
}