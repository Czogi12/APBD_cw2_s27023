using APBD_cw2_project_s27023.factory;
using APBD_cw2_project_s27023.services;

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
        if (args.Length < 3)
        {
            Console.WriteLine("Arguments missing!");
            Console.WriteLine("Usage: [type] [firstName] [lastName]");
        }

        var type = args[0];
        var firstName = args[1];
        var lastName = args[2];

        var user = UserFactory.CreateUser(firstName, lastName, type);

        if (user is null)
        {
            Console.WriteLine("Failed to create user!");
            return;
        }

        UserService.Instance.Add(user);
        Console.WriteLine("User created!");
        Console.WriteLine(user);
    }
}