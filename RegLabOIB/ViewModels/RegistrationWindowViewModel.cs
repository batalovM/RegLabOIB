using System.Reactive;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using RegLabOIB.Views;

namespace RegLabOIB.ViewModels;

public class RegistrationWindowViewModel: ViewModelBase
{
    public ReactiveCommand<Unit, Unit> RegCommand { get; }
    
    
    public RegistrationWindowViewModel()
    {
        RegCommand = ReactiveCommand.Create(Registration);
        
    }

    public void Registration()
    {
        var logWindow = new MainWindow();
        logWindow.DataContext = new MainWindowViewModel();
        logWindow.Show();
        CloseMethod();
    }
    private void CloseMethod()
    {
        var window = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
        window?.Close();
    }
    
}