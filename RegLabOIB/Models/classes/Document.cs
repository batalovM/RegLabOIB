using System;
using System.Reactive;
using ReactiveUI;

namespace RegLabOIB.Models;

public class Document
{
    private string _documentName;
    private string _documentPath;
    public ReactiveCommand<Unit, Unit> Opendocument{ get; }
    
    
    public string DocumentPath
    {
        get => _documentPath;
        set => _documentPath = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DocumentName
    {
        get => _documentName;
        set => _documentName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Document(string documentName, string documentPath)
    {
        _documentPath = documentPath;
        _documentName = documentName;

    }
    
    public void OpenDocument()
    {
        System.Diagnostics.Process.Start(_documentPath);
    }
}