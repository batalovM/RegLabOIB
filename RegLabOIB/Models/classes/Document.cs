using System;

namespace RegLabOIB.Models;

public class Document: IOpenDocument
{
    private string _documentName;
    private string _documentPath;
    
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
    public void OpenDocument(string documentPath)
    {
        System.Diagnostics.Process.Start(documentPath);
    }
}