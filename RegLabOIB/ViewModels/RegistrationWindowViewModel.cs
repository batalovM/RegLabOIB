using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Security.Cryptography;
using System.Text;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Newtonsoft.Json;
using ReactiveUI;
using RegLabOIB.Models;
using RegLabOIB.Views;

namespace RegLabOIB.ViewModels;

public class RegistrationWindowViewModel: ViewModelBase
{
    private string salt = "55555555";
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
        Password = HashPassword(_password);
        User user = new User(Login, Password, Mail, salt);
        Console.WriteLine(user.Password);
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

    public string HashPassword(string pass)
    {
        pass += salt;
        byte[] tmpPass;
        byte[] tmpHash;
        tmpPass = ASCIIEncoding.ASCII.GetBytes(pass);
        tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpPass);
        
        StringBuilder sOutput = new StringBuilder(tmpHash.Length);
        for (int i=0;i < tmpHash.Length; i++)
        {
            sOutput.Append(tmpHash[i].ToString("X2"));
        }
        return sOutput.ToString();
    }

}