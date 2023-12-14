using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Newtonsoft.Json;
using ReactiveUI;
using RegLabOIB.Models;
using RegLabOIB.Views;

namespace RegLabOIB.ViewModels;

public class RegistrationWindowViewModel: ViewModelBase
{
    public ReactiveCommand<Unit, Unit> RegCommand { get; }
    private string _login;
    private  string _password;
    private  string _mail;
    private const string Path = @"C:\Users\sasha\RiderProjects\RegLabOIB\RegLabOIB\AutorizationData.json";
    public string Password
    {
        get { return _password; }
        set { this.RaiseAndSetIfChanged(ref _password, value); }
    }
    public string Mail
    {
        get { return _mail; }
        set { this.RaiseAndSetIfChanged(ref _mail, value); }
    }
    public string Login
    {
        get { return _login; }
        set { this.RaiseAndSetIfChanged(ref _login, value);}
    }
    public RegistrationWindowViewModel()
    {
        
        RegCommand = ReactiveCommand.Create(Registration);
        
    }

    public void Registration()
    {
        AddNewUser();
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

    public void AddNewUser()
    {
        User user = new User(Login, Password, Mail, "5555555555");
        string json = File.ReadAllText(Path);
        List<User> list = JsonConvert.DeserializeObject<List<User>>(json);
        if (list == null)
        {
            list = new List<User>();
        }
        list.Add(user);
        string newjson = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(Path,newjson);
    }
}