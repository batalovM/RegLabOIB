namespace RegLabOIB.Models;

public class User : Accessible
{
    private string _loginUser;
    private string _passwordUser;

    public User(string login, string password)
    {
        _loginUser = login;
        _passwordUser = password;
    }

    public void CheckPermission()
    {
        throw new System.NotImplementedException();
    }
}