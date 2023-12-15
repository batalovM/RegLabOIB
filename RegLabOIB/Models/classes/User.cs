using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RegLabOIB.Models;

public class User : Accessible
{
    private string _login;
    private string _password;
    private string _salt;
    private string _mail;

    public string Login
    {
        get => _login;
        set => _login = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Password
    {
        get => _password;
        set => _password = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Mail
    {
        get => _mail;
        set => _mail = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Salt
    {
        get => _salt;
        set => _salt = value ?? throw new ArgumentNullException(nameof(value));
    }
    // public string Login => _login;
    //
    // public string Password => _password;
    //
    // public string Salt => _salt;
    //
    // public string Mail => _mail;
    // public string login
    // {
    //     get { return _login; }
    //     set{}
    // }
    public User(string login, string password, string mail, string salt)
    {
        _login = login;
        _password = password;
        _mail = mail;
        _salt = salt;
        
    }

    public void CheckPermission()
    {
        throw new System.NotImplementedException();
    }

    
}