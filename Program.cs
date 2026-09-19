using System;
using System.Linq;

namespace note_cli;

public class Program
{
    public const string Folder = @".notes\db";

    public static int Main(string[] args)
    {
        var fileOperations = new FileOperations(Folder);
        var notes = new Notes(fileOperations);

        if (args.Length == 0)
        {
            PrintUsage();
            return 1;
        }

        string command = args[0].ToLowerInvariant();

        switch (command)
        {
            case "add":
                if (args.Length < 2)
                {
                    Console.Error.WriteLine("Error: note content missing.");
                    return 1;
                }

                string content = string.Join(" ", args.Skip(1));
                string id = notes.Add(content);
                Console.WriteLine($"Added note: {id}");
                return 0;

            case "list":
                foreach (string noteId in notes.List())
                {
                    string? contentText = notes.Read(noteId);
                    Console.WriteLine(contentText is null ? noteId : $"{noteId}: {contentText}");
                }
                return 0;

            case "delete":
                if (args.Length < 2)
                {
                    Console.Error.WriteLine("Error: note id missing.");
                    return 1;
                }

                notes.Delete(args[1]);
                Console.WriteLine($"Deleted note: {args[1]}");
                return 0;

            default:
                PrintUsage();
                return 1;
        }
    }

    private static void PrintUsage()
    {
        Console.Error.WriteLine("Usage: note-cli add <content> | list | delete <id>");
    }
}
