using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reactive;
using System.Security.Cryptography;
using System.Text;
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
    private const string Path2 = @"C:\Users\sasha\RiderProjects\RegLabOIB\RegLabOIB\userAutorizated.json";
    public bool access = false;
    private string _password;
    private string _login;
    public string Password
    {
        get { return _password; }
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }
    public string Login
    {
        get => _login;
        set => this.RaiseAndSetIfChanged(ref _login, value);
    }
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }
    public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

    public MainWindowViewModel( )
    {
        
        LoginCommand = ReactiveCommand.Create(Autorization);
        RegisterCommand = ReactiveCommand.Create(Registr);
    }
    public void Autorization()
    {
        if (DeserializeAndCheck())
        {
            var progwindow = new ProgramWindow()
            {
                DataContext = new ProgramWindowViewModel()
            };
            progwindow.Show();
        }
        
    }
    private void Registr()
    {
        
        var regWindow = new RegistationWindow
        {
            DataContext = new MainWindowViewModel()
        };
        regWindow.Show();
        
    }
    private void CloseMethod()
    {
        var window = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
        window?.Close();
    }
    public class AutorizationUser
    { 
        public string loginUser;

        public AutorizationUser(string loginUser)
        {
            this.loginUser = loginUser;
        }
    }
    public bool DeserializeAndCheck()
    {
        var json = File.ReadAllText(Path);
        var list = JsonConvert.DeserializeObject<List<User>>(json);
        var selectedUser = list.Where(user => user.Login == Login);
        foreach (User user in selectedUser)
        {
            var hashPAssword = HashPassword(Password, user.Salt);
            Console.WriteLine(hashPAssword);
            if (user.Password == hashPAssword)
            {
                var json2 = File.ReadAllText(Path2);
                var userAuto = JsonConvert.DeserializeObject<AutorizationUser>(json2);
                if (userAuto == null)
                {
                    userAuto = new AutorizationUser(user.Login);
                }
                else
                {
                    userAuto.loginUser = user.Login;
                }
                var newjson = JsonConvert.SerializeObject(userAuto, Formatting.Indented);
                File.WriteAllText(Path2,newjson);
                access = true;
                return true;
            }
        }
        access = false;
        return false;
    }
    private string HashPassword(string pass, string salt)
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