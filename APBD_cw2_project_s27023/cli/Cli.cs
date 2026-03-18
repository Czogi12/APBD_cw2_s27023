namespace APBD_cw2_project_s27023.cli;

public static class Cli
{
    public static void Main(string[] _)
    {
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            var words = line.Split(' ');
            if (words.Length < 1) continue;
            var command = words[0];
            var args = words.Skip(1).ToArray();

            switch (command)
            {
                case "au":
                case "add_user":
                    AddUser(args);
                    break;
            }
        }
    }

    public static void AddUser(string[] args)
    {
        Console.WriteLine("Adding user");
    }
}