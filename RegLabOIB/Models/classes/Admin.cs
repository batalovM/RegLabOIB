namespace RegLabOIB.Models;

public class Admin : Accessible
{
    private string _loginAdmin;
    private string _passwordAdmin;

    public Admin(string login, string password)
    {
        _loginAdmin = login;
        _passwordAdmin = password;
    }

    public void CheckPermission()
    {
        throw new System.NotImplementedException();
    }
}