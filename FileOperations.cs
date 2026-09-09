using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace note_cli
{
    public class FileOperations : IFileOperations
    {
        public string Folder { get; set; }

        public FileOperations(string folder)
        {
            Folder = folder;
        }

        public void WriteAllText(string fileName, string content)
        {
            string filePath = Path.Combine(Folder, fileName);
            File.WriteAllText(filePath, content);
        }

        public IEnumerable<string> EnumerateFiles()
        {
            return Directory.EnumerateFiles(Folder);
        }

        public bool FileExists(string fileName)
        {
            return File.Exists(Path.Combine(Folder, fileName));
        }

        public void DeleteFile(string fileName)
        {
            string filePath = Path.Combine(Folder, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}