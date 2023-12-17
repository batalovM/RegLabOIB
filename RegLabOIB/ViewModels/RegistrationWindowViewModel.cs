using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    private string salt;
    public ReactiveCommand<Unit, Unit> RegCommand { get; }
    private  string _login;
    private  string _password;
    private  string _mail;
    private const string Path = @"C:\Users\sasha\RiderProjects\RegLabOIB\RegLabOIB\AutorizationData.json";
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }
    public string Mail
    {
        get => _mail;
        set => this.RaiseAndSetIfChanged(ref _mail, value);
    }
    public string Login
    {
        get => _login;
        set => this.RaiseAndSetIfChanged(ref _login, value);
    }
    public RegistrationWindowViewModel()
    {
        
        RegCommand = ReactiveCommand.Create(Registration);
        
    }

    public void Registration()
    {
        AddNewUser();
        // var logWindow = new MainWindow
        // {
        //     DataContext = new MainWindowViewModel()
        // };
        // logWindow.Show();
    }
    private void CloseMethod()
    {
        var window = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
        window?.Close();
    }

    public void AddNewUser()
    {
        Password = HashPassword(_password);
        var user = new User(Login, Password, Mail, salt);
        Console.WriteLine(user.Password);
        Console.WriteLine(user.Login);
        Console.WriteLine(user.Mail);
        var json = File.ReadAllText(Path);
        var list = JsonConvert.DeserializeObject<List<User>>(json);
        if (list == null)
        {
            list = new List<User>();
        }
        list.Add(user);
        var newjson = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(Path,newjson);
    }

    private string HashPassword(string pass)
    {
        salt = Salt();
        pass += salt;
        var tmpPass = ASCIIEncoding.ASCII.GetBytes(pass);
        var tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpPass);
        
        var sOutput = new StringBuilder(tmpHash.Length);
        foreach (var t in tmpHash)
        {
            sOutput.Append(t.ToString("X2"));
        }
        return sOutput.ToString();
    }
    string Salt()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var result = new string(Enumerable.Repeat(chars, 8)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return result;
    }
}