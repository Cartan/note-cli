using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace note_cli
{
    public interface IFileOperations
    {
        string Folder { get; set; }
        void WriteAllText(string fileName, string content);
        IEnumerable<string> EnumerateFiles();
        void DeleteFile(string fileName);
    }
}