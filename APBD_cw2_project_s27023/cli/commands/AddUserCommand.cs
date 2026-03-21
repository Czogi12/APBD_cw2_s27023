using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.enums;
using APBD_cw2_project_s27023.factory;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli.commands;

public class AddUserCommand(UserService userService) : Command(["add-user", "au"],
    [
        new StringArgument("type", true,
            $"({string.Join("|", Enum.GetNames(typeof(UserType)).Select(name => name.ToLower()))})"),
        new StringArgument("firstName", true, null),
        new StringArgument("lastName", true, null)
    ],
    "Adds new user with given FirstName and LastName.")
{
    protected override void ExecuteCommand(string[] args)
    {
        var user = UserFactory.CreateUser(args[0], args[1], args[2])!;
        userService.Add(user);
        Console.WriteLine($"Successfully added user: {user}");
    }
}