using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace RegLabOIB.Models;

public class User : Accessible
{
    private string _login;
    private string _password;
    private string _salt;
    private string _mail;

    public string Login => _login;

    public string Password => _password;

    public string Mail => _mail;

    public string Salt
    {
        get => _salt;
        set => _salt = value ?? throw new ArgumentNullException(nameof(value));
    }
   
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