using NoteCli;

namespace NoteCli;

class Program
{
    public const string Folder = @".notes\db";
    static int Main(string[] args)
    {
        IFileOperations fileOperations = new FileOperations(Folder);
        Notes notes = new Notes(fileOperations);
        if (args.Length == 0)
        {
            Console.Error.WriteLine("No command provided.");
            Console.Error.WriteLine("Commands are add/list/delete");
            return 1;
        }
        string command = args[0];
        
        switch (command)
        {
            case "add":
                {

                    if (args.Length < 2)
                    {
                        Console.Error.WriteLine("No note provided.");
                        return 1;
                    }
                    string content = args[1];
                    string hash = notes.Add(content);
                    Console.WriteLine($"Note added with hash: {hash}");
                    break;
                }
                case "list":
                {
                    int count  = notes.List();
                    Console.WriteLine($"Total notes: {count}");
                    break;
                }
            default:
                {
                    Console.Error.WriteLine($"Unknown command: {command}");
                    return 1;
  
                }
        }
        return 0;
    }
}
