using System;
using System.Text;
using System.Security.Cryptography;

namespace note_cli
{
    public class Notes
    {
        private readonly IFileOperations _fileOperations;

        public Notes(IFileOperations fileOperations)
        {
            _fileOperations = fileOperations;
        }

        public string Add(string content)
        {
            using (SHA1 hasher = SHA1.Create())
            {
                byte[] hashBytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(content));
                string hash = Convert.ToHexString(hashBytes);
                _fileOperations.WriteAllText(hash, content);
                return hash;
            }
        }
        public int List()
        {
            int count = 0;
            foreach (string file in _fileOperations.EnumerateFiles())
            {
                count++;
                Console.WriteLine(file);
            }
            return count;
        }
        public bool Delete(string hash)
        {
            if (_fileOperations.FileExists(hash))
            {
                _fileOperations.DeleteFile(hash);
                return true;
            }
            else
            {
                Console.WriteLine($"Error: Note with hash '{hash}' does not exist.");
                return false;
            }
        }
    }
}





    
 