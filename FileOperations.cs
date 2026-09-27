using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteCli;
public class FileOperations : IFileOperations
{
    public string Folder { get; private set; }

    public FileOperations(string folder)
    {
        if (!Directory.Exists(folder))
        {
            Console.WriteLine($"Directory '{folder}' does not exist. Creating it.");
            Directory.CreateDirectory(folder);
        }
        Folder = folder;
    }

    public string CombinePath(string fileName)
    {
        return Path.Combine(Folder, fileName);
    }

    public void WriteAllText(string path, string content)
    {
        File.WriteAllText(CombinePath(path), content);
    }

    public bool Delete(string file)
    {
        string path = CombinePath(file);
        if (File.Exists(path))
        {
            File.Delete(path);
            return true;
        } else {
            return false;
        }
        
    }

    public IEnumerable<string> EnumerateFiles()
    {
        if (Directory.Exists(Folder))
        {
            return System.IO.Directory.EnumerateFiles(Folder);
        }
        else return Enumerable.Empty<string>();
    }

    public bool DirectoryExists(string path)
    {
        return Directory.Exists(path);
    }

}