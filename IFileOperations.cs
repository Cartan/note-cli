using System.Collections.Generic;

namespace note_cli;

public interface IFileOperations
{
    string Folder { get; }
    void WriteAllText(string fileName, string content);
    string ReadAllText(string fileName);
    IEnumerable<string> EnumerateFiles();
    void Delete(string fileName);
}