using System.Collections.Generic;
using System.IO;

namespace note_cli;

public class FileOperations : IFileOperations
{
    public string Folder { get; }

    public FileOperations(string folder)
    {
        Folder = folder;
        Directory.CreateDirectory(Folder);
    }

    private string GetFullPath(string fileName)
    {
        return Path.Combine(Folder, fileName);
    }

    public void WriteAllText(string fileName, string content)
    {
        File.WriteAllText(GetFullPath(fileName), content);
    }

    public string ReadAllText(string fileName)
    {
        return File.ReadAllText(GetFullPath(fileName));
    }

    public IEnumerable<string> EnumerateFiles()
    {
        return Directory.EnumerateFiles(Folder);
    }

    public void Delete(string fileName)
    {
        string fullPath = GetFullPath(fileName);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }
}
