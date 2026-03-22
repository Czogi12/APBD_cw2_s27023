using APBD_cw2_project_s27023.services;
using APBD_cw2_project_s27023.services.user;

namespace APBD_cw2_project_s27023.cli.commands;

public class ShowUsersCommand(IUserService userService) : Command(["show-users", "su"], [], "Displays all users")
{
    protected override void ExecuteCommand(string[] args)
    {
        foreach (var user in userService.GetAll()) Console.WriteLine(user);
    }
}