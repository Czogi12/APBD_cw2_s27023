using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli.commands;

public class ShowEquipmentCommand(RentService rentService, EquipmentService equipmentService) : Command(
    ["show-equipment", "se"], [
        new StringArgument("mode", true, "(all|avalible)")
    ], "Displays equipment")
{
    protected override void ExecuteCommand(string[] args)
    {
        if (args[0] == "all")
            foreach (var eq in equipmentService.GetAll())
                Console.WriteLine(eq);
        else
            foreach (var eq in rentService.FindAllAvailableEquipment())
                Console.WriteLine(eq);
    }
}