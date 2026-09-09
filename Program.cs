using System;
using System.IO;

namespace note_cli
{
    class Program
    {
        public const string DefaultFolder = @".notes\db";

        static void Main(string[] args)
        {
            Directory.CreateDirectory(DefaultFolder);

            var fileOperations = new FileOperations(DefaultFolder);
            var notes = new Notes(fileOperations);

            if (args.Length == 0)
            {
                Console.WriteLine("Usage: note_cli <command> [<args>]");
                Console.WriteLine("Commands:");
                Console.WriteLine("  add <content>   Add a new note with the specified content.");
                Console.WriteLine("  list            List all notes.");
                Console.WriteLine("  delete <hash>   Delete the note with the specified hash.");
                return;
            }

            switch (args[0])
            {
                case "add":
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Error: Missing content for the note.");
                        return;
                    }

                    string content = args[1];
                    string hash = notes.Add(content);
                    Console.WriteLine($"Note added with hash: {hash}");
                    break;
                }

                case "list":
                {
                    int count = notes.List();
                    Console.WriteLine($"Total notes: {count}");
                    break;
                }
                case "delete":
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Error: Missing hash for the note to delete.");
                        return;
                    }

                    string hash = args[1];
                    bool deleted = notes.Delete(hash);
                    if (deleted)
                    {
                        Console.WriteLine($"Note with hash '{hash}' deleted.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Note with hash '{hash}' not found.");
                    }
                    break;
                }

                default:
                {
                    Console.WriteLine($"Error: Unknown command '{args[0]}'.");
                    break;
                }
            }
        }
    }
}
