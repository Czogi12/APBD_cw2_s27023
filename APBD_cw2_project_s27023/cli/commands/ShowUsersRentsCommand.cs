using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.services;
using APBD_cw2_project_s27023.services.rent;
using APBD_cw2_project_s27023.services.user;

namespace APBD_cw2_project_s27023.cli.commands;

public class ShowUsersRentsCommand(IUserService userService, IRentService rentService) : Command(["show-user-rents"], [
    new IntArgument("user", true, 0, null)
], "Displays all active rents")
{
    protected override void ExecuteCommand(string[] args)
    {
        foreach (var rent in rentService.FindActiveRentsOfUser(userService.Get(int.Parse(args[0])))) Console.WriteLine(rent);
    }
}