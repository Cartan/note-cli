namespace note_cli;

class Program
{
    public static string DefaultFolder = @".notes\db";
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
                if (args.Length < 2)
                {
                    Console.WriteLine("Error: Missing content for the note.");
                    return;
                }
                string content = args[1];
                string hash = notes.Add(content);
                Console.WriteLine($"Note added with hash: {hash}");
                break;

            case "list":
                var files = fileOperations.EnumerateFiles();
                foreach (var file in files)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }
                break;

            case "delete":
                if (args.Length < 2)
                {
                    Console.WriteLine("Error: Missing hash for the note to delete.");
                    return;
                }
                string hashToDelete = args[1];
                fileOperations.DeleteFile(hashToDelete);
                Console.WriteLine($"Note with hash {hashToDelete} deleted.");
                break;

            default:
                Console.WriteLine($"Error: Unknown command '{args[0]}'.");
                break;
        }

    }
}
