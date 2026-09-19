using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace note_cli;

public class Notes
{
    private readonly IFileOperations _fileOperations;

    public Notes(IFileOperations fileOperations)
    {
        _fileOperations = fileOperations ?? throw new ArgumentNullException(nameof(fileOperations));
    }

    public string Add(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new ArgumentException("Note content cannot be empty.", nameof(content));
        }

        string hash = ComputeHash(content);
        _fileOperations.WriteAllText(hash, content);
        return hash;
    }

    public IEnumerable<string> List()
    {
        return _fileOperations.EnumerateFiles()
            .Select(path => Path.GetFileName(path));
    }

    public void Delete(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Note id cannot be empty.", nameof(id));
        }

        _fileOperations.Delete(id);
    }

    public string? Read(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Note id cannot be empty.", nameof(id));
        }

        string fullPath = Path.Combine(_fileOperations.Folder, id);
        if (!File.Exists(fullPath))
        {
            return null;
        }

        return _fileOperations.ReadAllText(id);
    }

    private static string ComputeHash(string content)
    {
        using var hasher = SHA256.Create();
        byte[] contentBytes = Encoding.UTF8.GetBytes(content);
        byte[] hashBytes = hasher.ComputeHash(contentBytes);
        return Convert.ToHexString(hashBytes).ToLowerInvariant();
    }
}