using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli.commands;

public class RemoveUserCommand() : Command(["remove-user", "ru"],
    [
        new IntArgument("id", true, null, null)
    ],
    "Adds new user with given FirstName and LastName.")
{
    protected override void ExecuteCommand(string[] args)
    {
        UserService.Instance.Remove(int.Parse(args[0]));
    }
}