using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli.commands;

public class RemoveUserCommand(UserService userService) : Command(["remove-user", "ru"],
    [
        new IntArgument("id", true, null, null)
    ],
    "Removes user with given id.")
{
    protected override void ExecuteCommand(string[] args)
    {
        userService.Delete(int.Parse(args[0]));
    }
}