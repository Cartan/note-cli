using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteCli;
     
    public interface IFileOperations
    {
        string Folder { get; }
        void WriteAllText(string path, string content);
        bool Delete(string file);
        IEnumerable<string> EnumerateFiles();
        bool DirectoryExists(string path);
    } 