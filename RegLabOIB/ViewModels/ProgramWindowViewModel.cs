using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using RegLabOIB.Models;
using RegLabOIB.Views;

namespace RegLabOIB.ViewModels;

public class ProgramWindowViewModel : ViewModelBase
{
    private const string path = @"C:\Users\sasha\RiderProjects\RegLabOIB\RegLabOIB\Assets\Documents\Отчет.docx";
    public ObservableCollection<Document> DocumentList { get; set; }
    public ReactiveCommand<Unit,Unit> QuitCommand { get; }

    public ProgramWindowViewModel()
    {
        QuitCommand = ReactiveCommand.Create(Quit);
        DocumentList = new ObservableCollection<Document>(new List<Document>
        {
            new Document("Отчет", path)
        });
        
    }

    public void Quit()
    {
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
}