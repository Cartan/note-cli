using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace NoteCli;

public class Notes
{
    private IFileOperations _fileOperations;
    public string Folder { get; set; }

    public Notes(IFileOperations fileOperations)
    {
        _fileOperations = fileOperations;
        Folder = _fileOperations.Folder;
        if (!Directory.Exists(Folder))
        {
            Console.WriteLine($"Folder '{Folder}' does not exist. Creating it...");
            Directory.CreateDirectory(Folder);
        }
    }
    public string Add(string note)
    {
        using (SHA1 hasher = SHA1.Create())
        {
            byte[] hashBytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(note));
            string hash = Convert.ToHexString(hashBytes);

            _fileOperations.WriteAllText(hash, note);
            return hash;
        }
    }
    public int List()
    {
        int count = 0;
        foreach (string hash in _fileOperations.EnumerateFiles())
        {
            Console.WriteLine($"{++count}: {Path.GetFileName(hash)}");

        }
        return count;
    }
    public bool Delete(string hash)
    {
        return _fileOperations.Delete(hash);
    }
}
