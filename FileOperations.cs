using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteCli;

internal class FileOperations : IFileOperations
{
    public string Folder { get; set; }
    public FileOperations(string folder)
    {
        Folder = folder;
    }
    string GetPath(string path)
    {         return Path.Combine(Folder, path);
    }
    public void WriteAllText(string filePath, string content)
    {
        File.WriteAllText(GetPath(filePath), content);
    }
    public IEnumerable<string> EnumerateFiles()
    {
        return Directory.EnumerateFiles(Folder);
    }
    public bool FileExists(string name)
    {
        return File.Exists(GetPath(name));
    }
    public bool Delete(string name)
    {
        
        if (File.Exists(GetPath(name)))
        {
            string filePath = GetPath(name);
            File.Delete(filePath);
            return true;
        }
        return false;
    }
}
