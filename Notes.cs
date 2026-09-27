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
    IFileOperations _fileOperations;

    public Notes(IFileOperations fileOperations)
    {
        _fileOperations = fileOperations;
    }
    public string Add(string content)
    {
        using (SHA1 hasher = SHA1.Create())
        {
            byte[] contentBytes = Encoding.UTF8.GetBytes(content);
            byte[] hashBytes = hasher.ComputeHash(contentBytes);
            string hash = Convert.ToHexString(hashBytes);
            _fileOperations.WriteAllText(hash, content);
            return hash;
        }
    }



}