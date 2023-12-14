using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Newtonsoft.Json;
using ReactiveUI;
using RegLabOIB.Models;
using RegLabOIB.Views;

namespace RegLabOIB.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private const string Path = @"C:\Users\sasha\RiderProjects\RegLabOIB\RegLabOIB\AutorizationData.json";
    private string _password;
    private string _login;
    public string Password
    {
        get { return _password; }
        set { this.RaiseAndSetIfChanged(ref _password, value); }
    }
    public string Login
    {
        get { return _login; }
        set { this.RaiseAndSetIfChanged(ref _login, value);}
    }
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }
    public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

    public MainWindowViewModel()
    {
        LoginCommand = ReactiveCommand.Create(Autorization);
        RegisterCommand = ReactiveCommand.Create(Registr);
    }
    private void Autorization()
    {
        DeserializeAndCheck();
    }
    private void Registr()
    {
        var regWindow = new RegistationWindow();
        regWindow.DataContext = new RegistrationWindowViewModel();
        regWindow.Show();
        CloseMethod();
    }
    private void CloseMethod()
    {
        var window = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
        window?.Close();
    }

    public void DeserializeAndCheck()
    {
        var json = File.ReadAllText(Path);
        List<User> list = JsonConvert.DeserializeObject<List<User>>(json);
        if ((list.Any(user => user.Login == Login) && list.Any(user => user.Password == Password)) == true)
        {
            var prWindow = new ProgramWindow();
            prWindow.DataContext = new ProgramWindowViewModel();
            prWindow.Show();
            CloseMethod();
        }
        else
        {
            
        }

    }
}