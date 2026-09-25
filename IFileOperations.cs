using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteCli;

public interface IFileOperations
{
    public string Folder { get; set; }
    void WriteAllText(string filePath, string content);
    IEnumerable<string> EnumerateFiles();
   bool FileExists(string name);
    bool Delete(string name);
}
