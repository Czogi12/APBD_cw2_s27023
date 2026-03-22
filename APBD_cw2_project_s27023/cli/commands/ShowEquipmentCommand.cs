using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.services;
using APBD_cw2_project_s27023.services.availability;
using APBD_cw2_project_s27023.services.equipment;

namespace APBD_cw2_project_s27023.cli.commands;

public class ShowEquipmentCommand(IEquipmentService equipmentService, IAvailabilityService availabilityService)
    : Command(
        ["show-equipment", "se"], [
            new StringArgument("mode", true, "(all|available)")
        ], "Displays equipment")
{
    protected override void ExecuteCommand(string[] args)
    {
        foreach (var eq in equipmentService.GetAll())
            if (args[0] == "all")
                Console.WriteLine(eq);
            else if (args[0] == "available" && availabilityService.IsAvailable(eq))
                Console.WriteLine(eq);
    }
}