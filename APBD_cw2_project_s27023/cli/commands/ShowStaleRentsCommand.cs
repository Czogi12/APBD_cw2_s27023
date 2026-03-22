using APBD_cw2_project_s27023.services.rent;

namespace APBD_cw2_project_s27023.cli.commands;

public class ShowStaleRentsCommand(IRentService rentService) : Command(["show-stale-rents", "show-stale"], [], "Displays all rents that are overdue")
{
    protected override void ExecuteCommand(string[] args)
    {
        foreach (var rent in rentService.GetAllStale()) Console.WriteLine(rent);
    }
}