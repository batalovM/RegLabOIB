using System.Windows.Input;
using ReactiveUI;
using RegLabOIB.Views;

namespace RegLabOIB.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand OpenRegWindowCommand { get; }

    public MainWindowViewModel()
    {
       
    }

    private void OpenSecondWindow()
    {
        var secondWindow = new RegistationWindow();
        secondWindow.Show();
    }
}